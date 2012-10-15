﻿Friend NotInheritable Class InternalCommandManager

#Region "Fields"
    Private ReadOnly myClient As InternalClient
#End Region

#Region "Events"
    Friend Event OnCommand(msg As String, user As Integer, rights As Group, e As CommandEventArgs)
#End Region

#Region "Methods"

    Friend Sub New(client As InternalClient)
        myClient = client
        AddHandler myClient.Connection.ReceiveSay, AddressOf myConnection_OnReceiveSay
        AddHandler Cloud.Logger.OnInput,
            Sub(sender As Object, e As EventArgs) HandleMessage(Cloud.Logger.Input, - 1, Group.Host)
    End Sub

    Private Sub myConnection_OnReceiveSay(sender As Object, e As SayReceiveMessage)
        If e.Text.StartsWith("!", StringComparison.Ordinal) Then
            HandleMessage(e.Text.Substring(1), e.UserID, Group.Limited)
        End If
    End Sub

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
