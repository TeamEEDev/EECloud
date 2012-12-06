Friend NotInheritable Class InternalCommandManager

#Region "Fields"
    Private Shared ReadOnly RegisteredCmdChars As New List(Of String)
    Private ReadOnly myCommandChar As Char
    Private ReadOnly myClient As InternalClient
#End Region

#Region "Events"
    Friend Event OnCommand(msg As String, user As Integer, rights As Group, e As CommandEventArgs)
#End Region

#Region "Methods"

    Friend Sub New(ByVal client As InternalClient, commandChar As Char)
        SyncLock RegisteredCmdChars
            If RegisteredCmdChars.Contains(commandChar) Then
                Throw New ArgumentException("Command char already taken", "commandChar")
            End If
            RegisteredCmdChars.Add(commandChar)
        End SyncLock

        myClient = client
        myCommandChar = commandChar
        AddHandler myClient.Connection.ReceiveSay, AddressOf myConnection_OnReceiveSay
        AddHandler GlobalCommandManager.Value.OnConsoleCommand, AddressOf GlobalCommandManager_OnConsoleCommand
    End Sub

    Private Sub myConnection_OnReceiveSay(sender As Object, e As SayReceiveMessage)
        If ShouldHandle(e.Text) Then
            HandleMessage(e.Text.Substring(1), e.UserID, Group.Limited)
        End If
    End Sub

    Private Sub GlobalCommandManager_OnConsoleCommand(msg As String, e As CommandEventArgs)
        If ShouldHandle(msg) And Not e.Handled Then
            e.Handled = True
            HandleMessage(Cloud.Logger.Input.Substring(1), - 1, Group.Host)
        End If
    End Sub

    Private ReadOnly Property ShouldHandle(str As String) As Boolean
        Get
            Return str.StartsWith(myCommandChar, StringComparison.Ordinal)
        End Get
    End Property

    Friend Sub HandleMessage(msg As String, user As Integer, rights As Group)
        Dim eventArgs As New CommandEventArgs
        RaiseEvent OnCommand(msg, user, rights, eventArgs)
        If eventArgs.Handled = False Then
            If myClient.InternalPlayerManager.Players.ContainsKey(user) Then
                Dim sender As IPlayer = myClient.InternalPlayerManager.Players(user)
                If sender.Group >= Group.Trusted Then
                    sender.Reply("Unknown command")
                End If
            ElseIf rights >= Group.Moderator Then
                Cloud.Logger.Log(LogPriority.Info, "Unknown command")
            End If
        End If
    End Sub

#End Region
End Class
