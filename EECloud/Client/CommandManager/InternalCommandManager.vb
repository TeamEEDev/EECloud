﻿Friend NotInheritable Class InternalCommandManager
    Private ReadOnly myClient As InternalClient

    Friend Event OnCommand(msg As String, user As Integer, e As CommandEventArgs)

    Friend Sub New(client As InternalClient)
        myClient = client
        AddHandler myClient.Connection.ReceiveSay, AddressOf myConnection_OnReceiveSay
        AddHandler Cloud.Logger.OnInput,
            Sub(sender As Object, e As EventArgs) HandleMessage(Cloud.Logger.Input, -1)
    End Sub

    Private Sub myConnection_OnReceiveSay(sender As Object, e As SayReceiveMessage)
        If e.Text.StartsWith("!", StringComparison.Ordinal) Then
            HandleMessage(e.Text.Substring(1), e.UserID)
        End If
    End Sub

    Friend Sub HandleMessage(msg As String, user As Integer)
        Dim eventArgs As New CommandEventArgs
        RaiseEvent OnCommand(msg, user, eventArgs)
        If eventArgs.Handled = False Then
            Dim sender As IPlayer = myClient.InternalPlayerManager.Players(user)
            If sender IsNot Nothing AndAlso sender.Group >= Group.Trusted Then
                sender.Reply("Unknown command")
            End If
        End If
    End Sub
End Class