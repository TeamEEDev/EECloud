Friend NotInheritable Class InternalCommandManager

#Region "Fields"
    Private Shared ReadOnly myRegisteredCmdChars As New List(Of String)
    Private ReadOnly myCommandChar As Char
    Private ReadOnly myClient As InternalClient
#End Region

#Region "Events"
    Friend Event OnCommand As EventHandler(Of CommandEventArgs)
#End Region

#Region "Methods"

    Friend Sub New(client As InternalClient, commandChar As Char)
        If commandChar <> Nothing Then
            SyncLock myRegisteredCmdChars
                If myRegisteredCmdChars.Contains(commandChar) Then
                    Throw New ArgumentException("Command char already taken", "commandChar")
                End If
                myRegisteredCmdChars.Add(commandChar)
            End SyncLock
        End If

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

    Private Sub GlobalCommandManager_OnConsoleCommand(sender As Object, e As CommandEventArgs)
        If ShouldHandle(e.Message) AndAlso Not e.Handled Then
            e.Handled = True
            HandleMessage(Cloud.Logger.Input.Substring(1), e.UserID, e.Rights)
        End If
    End Sub

    Private ReadOnly Property ShouldHandle(str As String) As Boolean
        Get
            Return myCommandChar <> Nothing AndAlso str.ToCharArray()(0) = myCommandChar
        End Get
    End Property

    Friend Sub HandleMessage(msg As String, user As Integer, rights As Group)
        Dim sender As IPlayer = Nothing
        If myClient.InternalPlayerManager.Players.ContainsKey(user) Then
            sender = myClient.InternalPlayerManager.Players(user)
        End If

        If sender IsNot Nothing Then
            If sender.Group > rights Then rights = sender.Group
        End If

        Dim eventArgs As New CommandEventArgs(msg, rights, user)
        RaiseEvent OnCommand(Me, eventArgs)

        If eventArgs.Handled = False Then
            If sender IsNot Nothing Then
                If eventArgs.Rights >= Group.Trusted Then
                    sender.Reply("Unknown command")
                End If
            ElseIf eventArgs.Rights >= Group.Moderator Then
                Cloud.Logger.Log(LogPriority.Info, "Unknown command")
            End If
        End If
    End Sub

#End Region
End Class
