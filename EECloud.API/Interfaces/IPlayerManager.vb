Public Interface IPlayerManager (Of TPlayer As {Player, New})
    Inherits IEnumerable(Of TPlayer)
    Event OnCrown As EventHandler(Of TPlayer)
    Event OnSmiley As EventHandler(Of TPlayer)
    Event OnMove As EventHandler(Of TPlayer)
    Event OnPotion As EventHandler(Of TPlayer)
    Event OnGodmode As EventHandler(Of TPlayer)
    Event OnModmode As EventHandler(Of TPlayer)
    Event OnCoin As EventHandler(Of TPlayer)
    Event OnSilverCrown As EventHandler(Of TPlayer)
    Event OnSay As EventHandler(Of TPlayer)
    Event OnAutoText As EventHandler(Of TPlayer)
    Event OnLevelUp As EventHandler(Of TPlayer)
    Event OnWootUp As EventHandler(Of TPlayer)
    Event OnMagic As EventHandler(Of TPlayer)
    Event OnTeleport As EventHandler(Of TPlayer)
    Event OnKill As EventHandler(Of TPlayer)

    Event Join As EventHandler(Of TPlayer)
    Event Leave As EventHandler(Of TPlayer)
    Event UserDataReady As EventHandler(Of TPlayer)
    Event GroupChange As EventHandler(Of TPlayer)

    ''' <summary>
    '''     Returns the player or nothing if the user does not exist
    ''' </summary>
    ''' <param name="number">The UserID</param>
    ''' <value></value>
    ''' <returns>The requested user or nothing</returns>
    ''' <remarks>Make sure to do a null check after getting a player</remarks>
    ReadOnly Property Player(number As Integer) As TPlayer
    
    ''' <summary>
    '''     Returns the player or nothing if the user does not exist
    ''' </summary>
    ''' <param name="username">The username of the user</param>
    ''' <value></value>
    ''' <returns>The requested user or nothing</returns>
    ''' <remarks>Make sure to do a null check after getting a player</remarks>
    ReadOnly Property Player(username As String) As TPlayer

    ReadOnly Property Count As Integer

    ReadOnly Property Crown As TPlayer
End Interface
