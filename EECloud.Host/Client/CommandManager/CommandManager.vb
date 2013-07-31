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
                                    For i = 0 To attribute.Aliases.Length - 1
                                        AddCommand(attribute.Aliases(i), handle)
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
        Dim items As List(Of CommandHandle) = Nothing
        If myCommandsDictionary.TryGetValue(name, items) Then
            For Each item In items
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
        Dim handleList As List(Of CommandHandle) = Nothing
        If Not myCommandsDictionary.TryGetValue(request.Phrase.Type, handleList) Then
            Return False
        End If


        Dim mostHandle As CommandHandle = Nothing
        For Each handle In handleList
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
        handle.Run(request)
    End Sub

    Friend Function InvokeCommand(request As CommandRequest) As ICommandResult Implements ICommandManager.InvokeCommand
        Try
            myInternalCommandManager.HandleMessage(request)
        Catch ex As Exception
            Cloud.Logger.LogEx(ex)
        End Try
    End Function

    Public Function InvokeCommand(request As CommandRequest, scope As CommandScope) As ICommandResult Implements ICommandManager.InvokeCommand

    End Function

    Public Sub SetHandler() Implements ICommandManager.SetHandler

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
