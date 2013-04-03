Friend NotInheritable Class InternalCommandManager

#Region "Fields"
    Private ReadOnly myCommandChar As Char
    Private ReadOnly myClient As InternalClient
#End Region

#Region "Events"
    Friend Event OnCommand As EventHandler(Of CommandEventArgs)
#End Region

#Region "Methods"

    Friend Sub New(client As InternalClient, commandChar As Char)
        myClient = client
        myCommandChar = commandChar

        AddHandler myClient.PlayerManager.OnSay, AddressOf myPlayerManager_OnSay
    End Sub

    Private Sub myPlayerManager_OnSay(sender As Object, e As player)
        If ShouldHandle(e.Say) Then
            HandleMessage(New CommandRequest(New PlayerCommandSender(e), New CommandPhrase(e.Say), e.Group))
        End If
    End Sub

    Private ReadOnly Property ShouldHandle(str As String) As Boolean
        Get
            Return myCommandChar <> Nothing AndAlso str.ToCharArray()(0) = myCommandChar
        End Get
    End Property

    Friend Sub HandleMessage(request As CommandRequest)
        Dim eventArgs As New CommandEventArgs(request)
        RaiseEvent OnCommand(Me, eventArgs)

        If Not eventArgs.Handled Then
            request.Sender.Reply("Unknown command.")
        End If
    End Sub

#End Region
End Class
