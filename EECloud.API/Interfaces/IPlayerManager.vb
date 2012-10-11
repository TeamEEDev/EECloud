Public Interface IPlayerManager(Of TPlayer As {Player, New})
    ReadOnly Property Players(number As Integer) As TPlayer
    ReadOnly Property GetPlayers As TPlayer()
    ReadOnly Property Crown As TPlayer
End Interface
