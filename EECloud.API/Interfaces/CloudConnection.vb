Public MustInherit Class CloudConnection
    Public Event OnMessage As EventHandler(Of OnMessageEventArgs)
    Protected Overridable Sub RaiseOnMessage(e As OnMessageEventArgs)
        RaiseEvent OnMessage(Me, e)
    End Sub
    Public Event OnJoin As EventHandler
    Protected Overridable Sub RaiseOnJoin(e As EventArgs)
        RaiseEvent OnJoin(Me, e)
    End Sub
    Public Event OnJoinError As EventHandler
    Protected Overridable Sub RaiseOnJoinError(e As EventArgs)
        RaiseEvent OnJoinError(Me, e)
    End Sub
    Public Event OnDisconnect As EventHandler
    Protected Overridable Sub RaiseOnDisconnect(e As EventArgs)
        RaiseEvent OnDisconnect(Me, e)
    End Sub

    Public MustOverride ReadOnly Property Connection As PlayerIOClient.Connection
    Public MustOverride ReadOnly Property WorldID As String
End Class
