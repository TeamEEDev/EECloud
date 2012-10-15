Public Interface IPlayerManager(Of TPlayer As {Player, New})
    Event Join As EventHandler(Of TPlayer)
    Event Leave As EventHandler(Of TPlayer)

    ReadOnly Property Player(number As Integer) As TPlayer
    ReadOnly Property Player(username As String) As TPlayer
    ReadOnly Property GetPlayers As TPlayer()
    ReadOnly Property Crown As TPlayer
End Interface
