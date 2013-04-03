Imports System.Reflection

Friend NotInheritable Class CommandManager(Of TPlayer As {New, Player})
    Implements ICommandManager, IDisposable

#Region "Fields"
    Private ReadOnly myCommandsDictionary As New Dictionary(Of String, List(Of CommandHandle))
    Private ReadOnly myClient As IClient(Of TPlayer)
    Private WithEvents myInternalCommandManager As InternalCommandManager
    Private myAddedTargets As New List(Of Object)
#End Region

#Region "Methods"

    Friend Sub New(client As IClient(Of TPlayer), internalCommandManager As InternalCommandManager)
        myClient = client
        myInternalCommandManager = internalCommandManager
    End Sub

    Friend Sub Load(target As Object) Implements ICommandManager.Load
        SyncLock myAddedTargets
            SyncLock myCommandsDictionary
                If myAddedTargets.Contains(target) Then
                    Throw New EECloudException(ErrorCode.CommandTargetAlreadyAdded)
                End If


                For Each method As MethodInfo In target.GetType.GetMethods()
                    Dim attributes As CommandAttribute() = method.GetCustomAttributes(GetType(CommandAttribute), True)

                    If attributes IsNot Nothing AndAlso attributes.Length = 1 Then
                        Dim attribute As CommandAttribute = attributes(0)

                        Try
                            Dim handle As New CommandHandle(attribute, method, target)
                            Try
                                AddCommand(attribute.Type, handle)

                                If attribute.Aliases IsNot Nothing Then
                                    For Each item As String In attribute.Aliases
                                        AddCommand(item, handle)
                                    Next
                                End If
                            Catch ex As Exception
                                Cloud.Logger.Log(LogPriority.Error, "Failed to load command: " & attribute.Type)
                                Cloud.Logger.LogEx(ex)
                            End Try
                        Catch ex As Exception
                            Cloud.Logger.Log(LogPriority.Error, "Method has bad signature: " & attribute.Type)
                            Cloud.Logger.LogEx(ex)
                        End Try
                    End If
                Next
            End SyncLock
        End SyncLock
    End Sub

    Private Sub AddCommand(name As String, handle As CommandHandle)
        'Overloading command?
        If myCommandsDictionary.ContainsKey(name) Then
            For Each item In myCommandsDictionary(name)
                If handle.Count = item.Count Then
                    Cloud.Logger.Log(LogPriority.Error, "Can't overload command because of conflicting parameter count: " & name)
                    Exit Sub
                End If

                If item.HasParamArray Then
                    If handle.HasParamArray OrElse handle.Count >= item.Count Then 'Dare you merge the two Ifs, Jojatekok... 
                        Cloud.Logger.Log(LogPriority.Error, "Can't overload command because of conflicting ParamArray variable: " & name)
                        Exit Sub
                    End If
                End If
            Next

            myCommandsDictionary(name).Add(handle)
        Else
            Dim list As New List(Of CommandHandle)
            list.Add(handle)
            myCommandsDictionary.Add(name, list)
        End If
    End Sub

    Private Function ProcessMessage(request As CommandRequest) As Boolean
        If Not myCommandsDictionary.ContainsKey(request.Phrase.Type) Then
            Return False
        End If

        'First, inject the chatter
        request.Sender.InjectChatter(myClient.Chatter)

        Dim mostHandle As CommandHandle = Nothing
        For Each handle In myCommandsDictionary(request.Phrase.Type)
            'Check for syntax
            If (handle.Count = request.Phrase.Parameters.Length AndAlso Not handle.HasParamArray) OrElse (handle.HasParamArray AndAlso handle.Count < request.Phrase.Parameters.Length) Then
                TryRunCmd(request, handle)
                Return True

            ElseIf handle.Count <= request.Phrase.Parameters.Length Then
                If mostHandle Is Nothing OrElse handle.Count > mostHandle.Count Then
                    mostHandle = handle
                End If
            End If
        Next

        'Try the one that most methods fit in
        If mostHandle IsNot Nothing Then
            TryRunCmd(request, mostHandle)
        ElseIf request.Rights >= Group.Moderator Then
            request.Sender.Reply(GetUsagesStr(request.Phrase.Type))
        End If

        Return True
    End Function

    Private Function GetUsagesStr(cmd As String) As String
        Dim usages As String = String.Empty
        usages = myCommandsDictionary(cmd).Aggregate(usages, Function(current, handle) current & handle.ToString() & " / ")
        Return "Command usage(s): " & Left(usages, usages.Length - 3)
    End Function

    Private Sub TryRunCmd(request As CommandRequest, handle As CommandHandle)
        'Check for rights
        If handle.Attribute.MinPermission > request.Rights Then
            If request.Rights >= Group.Moderator Then
                request.Sender.Reply("You are not allowed to use this command!")
            End If

            Exit Sub
        End If

        'Check for the bot's access rights
        If myClient.Game.AccessRight < handle.Attribute.AccessRight Then
            If handle.Attribute.AccessRight = AccessRight.Edit Then
                request.Sender.Reply("Bot needs edit rights to run this command")
            Else
                request.Sender.Reply("Bot needs owner rights to run this command.")
            End If
            Exit Sub
        End If

        'Excecute
        If Not handle.HasParamArray Then
            handle.Run(request, request.Phrase.Parameters)
        Else
            Dim args(handle.Count) As Object

            For i = 0 To handle.Count - 1
                args(i) = request.Phrase.Parameters(i)
            Next

            Dim pramArgs(request.Phrase.Parameters.Length - handle.Count - 1) As String
            For i = 0 To pramArgs.Length - 1
                pramArgs(i) = request.Phrase.Parameters(i + handle.Count)
            Next

            args(args.Length - 1) = pramArgs

            handle.Run(request, args)
        End If
    End Sub

    Friend Sub InvokeCommand(request As CommandRequest) Implements ICommandManager.InvokeCommand
        Try
            myInternalCommandManager.HandleMessage(request)
        Catch ex As Exception
            Cloud.Logger.LogEx(ex)
        End Try
    End Sub

#End Region

#Region "IDisposable Support"
    Private myDisposedValue As Boolean

    Private Sub Dispose(disposing As Boolean)
        If Not myDisposedValue Then
            If disposing Then

            End If

            myInternalCommandManager = Nothing
            myAddedTargets = Nothing
        End If
        myDisposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub

    Friend Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Private Sub myInternalCommandManager_OnCommand(sender As Object, e As CommandEventArgs) Handles myInternalCommandManager.OnCommand
        If e.Handled = False AndAlso ProcessMessage(e.Request) Then
            e.Handled = True
        End If
    End Sub

#End Region


End Class
