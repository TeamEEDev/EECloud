Imports System.Reflection

Friend NotInheritable Class CommandManager (Of TPlayer As {New, Player})
    Implements ICommandManager, IDisposable

#Region "Fields"
    Private ReadOnly myCommandsDictionary As New Dictionary(Of String, List(Of CommandHandle(Of TPlayer)))
    Private ReadOnly myClient As IClient(Of TPlayer)
    Private WithEvents myInternalCommandManager As InternalCommandManager
    Private ReadOnly myAddedTargets As New List(Of Object)
#End Region

#Region "Properties"

    Friend ReadOnly Property Count As Integer Implements ICommandManager.Count
        Get
            Return myCommandsDictionary.Count
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(client As IClient(Of TPlayer), internalCommandManager As InternalCommandManager)
        myClient = client
        myInternalCommandManager = internalCommandManager
    End Sub

    Friend Sub Load(target As Object) Implements ICommandManager.Load
        SyncLock myAddedTargets
            SyncLock myCommandsDictionary
                If myAddedTargets.Contains(target) Then
                    Throw New EECloudException(ErrorCode.CommandTargetAlreadyAdded)
                End If
                For Each method As MethodInfo In target.GetType.GetMethods
                    Dim attributes As Object() = method.GetCustomAttributes(GetType(CommandAttribute), True)
                    If attributes IsNot Nothing AndAlso attributes.Length = 1 Then
                        Dim attribute As CommandAttribute = CType(attributes(0), CommandAttribute)
                        Try
                            Dim handle As New CommandHandle(Of TPlayer)(attribute, method, target)
                            Try
                                AddCommand(attribute.Type, handle)

                                If attribute.Aliases IsNot Nothing Then
                                    For Each item As String In attribute.Aliases
                                        AddCommand(item, handle)
                                    Next
                                End If
                            Catch ex As Exception
                                Cloud.Logger.Log(LogPriority.Error, "Failed to Load command: " & attribute.Type)
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

    Private Sub ProcessMessage(sender As Object, e As CommandEventArgs) Handles myInternalCommandManager.OnCommand
        If Not e.Handled Then
            Dim msgSender As TPlayer = myClient.PlayerManager.Player(e.UserID)
            Dim cmd As String() = e.Message.Split(" "c)
            Dim type As String = cmd(0).ToLower(InvariantCulture)
            If e.Message.StartsWith("help ", StringComparison.OrdinalIgnoreCase) AndAlso myCommandsDictionary.ContainsKey(cmd(1).ToLower(InvariantCulture)) Then
                e.Handled = True
                If e.Rights >= Group.Moderator Then
                    ReplyToSender(msgSender, GetUsagesStr(cmd(1).ToLower(InvariantCulture)))
                End If
            ElseIf myCommandsDictionary.ContainsKey(type) Then
                e.Handled = True
                Dim mostHandle As CommandHandle(Of TPlayer) = Nothing
                For Each handle In myCommandsDictionary(type)
                    'Check for syntax
                    If handle.Count = cmd.Length - 1 OrElse (handle.Count < cmd.Length AndAlso handle.HasParamArray) Then
                        TryRunCmd(msgSender, e.Rights, cmd, type, e.Message, handle)
                        Exit Sub
                    ElseIf handle.Count < cmd.Length - 1 Then
                        If mostHandle Is Nothing OrElse handle.Count > mostHandle.Count Then
                            mostHandle = handle
                        End If
                    End If
                Next
                'Try the one that most methods fit in 
                If mostHandle IsNot Nothing Then
                    TryRunCmd(msgSender, e.Rights, cmd, type, e.Message, mostHandle)
                ElseIf e.Rights >= Group.Moderator Then
                    ReplyToSender(msgSender, GetUsagesStr(type))
                End If
            End If
        End If
    End Sub

    Private Function GetUsagesStr(cmd As String) As String
        Dim usages As String = String.Empty
        usages = myCommandsDictionary(cmd).Aggregate(usages, Function(current, handle) current & handle.ToString & " / ")
        Return "Command usage(s): " & Left(usages, usages.Length - 3)
    End Function

    Private Sub TryRunCmd(sender As TPlayer, rights As Group, cmd As String(), type As String, text As String, handle As CommandHandle(Of TPlayer))
        'Check for rights
        If handle.Attribute.MinPermission > rights Then
            If sender Is Nothing OrElse handle.Attribute.MinPermission > sender.Group Then
                If sender IsNot Nothing AndAlso sender.Group >= Group.Moderator Then
                    ReplyToSender(sender, "You are not allowed to use this command!")
                End If

                Exit Sub
            End If
        End If

        'Check for bots access rights
        If myClient.Game.AccessRight < handle.Attribute.AccessRight Then
            If handle.Attribute.AccessRight = AccessRight.Edit Then
                ReplyToSender(sender, "Bot needs edit rights to run this command!")
            Else
                ReplyToSender(sender, "Bot needs owner rights to run this command!")
            End If
            Exit Sub
        End If

        'Build args
        Dim toCount As Integer = cmd.Length - 1
        If toCount > handle.Count Then toCount = handle.Count

        Dim args(toCount + CInt(IIf(handle.HasParamArray, 1, 0))) As Object
        args(0) = New Command(Of TPlayer)(sender, type, text)

        For i = 1 To toCount
            args(i) = cmd(i)
        Next

        If handle.HasParamArray Then
            Dim pramArgs(cmd.Length - toCount - 2) As String
            For i = 0 To cmd.Length - toCount - 2
                pramArgs(i) = cmd(i + toCount + 1)
            Next

            args(args.Length - 1) = pramArgs
        End If

        'Excecute
        handle.Run(args)
    End Sub

    Private Sub ReplyToSender(sender As TPlayer, msg As String)
        If sender IsNot Nothing Then
            sender.Reply(msg)
        Else
            Cloud.Logger.Log(LogPriority.Info, msg)
        End If
    End Sub

    Friend Sub InvokeCommand(player As Player, msg As String, rights As Group) Implements ICommandManager.InvokeCommand
        Try
            myInternalCommandManager.HandleMessage(My.Settings.CommandChar & msg, player.UserID, rights)
        Catch ex As NullReferenceException
            myInternalCommandManager.HandleMessage(My.Settings.CommandChar & msg, -1, rights)
        Catch ex As ArgumentNullException
            myInternalCommandManager.HandleMessage(My.Settings.CommandChar & msg, -1, rights)
        End Try
    End Sub

    Private Sub AddCommand(name As String, handle As CommandHandle(Of TPlayer))
        If myCommandsDictionary.ContainsKey(name) Then
            Dim list As List(Of CommandHandle(Of TPlayer)) = myCommandsDictionary(name)
            Dim usedNums As New List(Of Integer)
            Dim maxNum As Integer = - 1
            For Each item In list
                If item.HasParamArray Then
                    maxNum = item.Count
                Else
                    usedNums.Add(item.Count)
                End If
            Next
            If maxNum = -1 OrElse (handle.Count <= maxNum AndAlso Not handle.HasParamArray) Then
                If Not usedNums.Contains(handle.Count) OrElse (handle.HasParamArray AndAlso Not usedNums.Contains(handle.Count + 1)) Then
                    myCommandsDictionary(name).Add(handle)
                Else
                    Cloud.Logger.Log(LogPriority.Error, "Can not overload command because of conflicting parameter count: " & name)
                End If
            Else
                Cloud.Logger.Log(LogPriority.Error, "Can not overload command because of conflicting ParamArray variable: " & name)
            End If
        Else
            Dim list As New List(Of CommandHandle(Of TPlayer))
            list.Add(handle)
            myCommandsDictionary.Add(name, list)
        End If
    End Sub

    Friend Function Contains(cmd As String) As Boolean Implements ICommandManager.Contains
        Return myCommandsDictionary.ContainsKey(cmd)
    End Function

    Friend Function Contains(cmd As String, paramCount As Integer) As Boolean Implements ICommandManager.Contains
        If Contains(cmd) Then
            Return myCommandsDictionary(cmd).Any(Function(cmdHandle) cmdHandle.Count <= paramCount)
        Else
            Return False
        End If
    End Function

#End Region

#Region "IDisposable Support"
    Private myDisposedValue As Boolean

    Private Sub Dispose(disposing As Boolean)
        If Not myDisposedValue Then
            If disposing Then

            End If

            myInternalCommandManager = Nothing
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

#End Region
End Class
