Public Interface IPlayerManager (Of TPlayer As {Player, New})
    Event Join As EventHandler(Of TPlayer)
    Event Leave As EventHandler(Of TPlayer)

    ''' <summary>
    ''' Returns the player or nothing if the user does not exist
    ''' </summary>
    ''' <param name="number">The UserID</param>
    ''' <value></value>
    ''' <returns>The requested user or nothing</returns>
    ''' <remarks>Make sure to do a null check after getting a player</remarks>
    ReadOnly Property Player(number As Integer) As TPlayer

    ''' <summary>
    ''' Returns the player or nothing if the user does not exist
    ''' </summary>
    ''' <param name="username">The username of the user</param>
    ''' <value></value>
    ''' <returns>The requested user or nothing</returns>
    ''' <remarks>Make sure to do a null check after getting a player</remarks>
    ReadOnly Property Player(username As String) As TPlayer
    ReadOnly Property Count As Integer
    ReadOnly Property GetPlayers As TPlayer()
    ReadOnly Property Crown As TPlayer
End Interface
