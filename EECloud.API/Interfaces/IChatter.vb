''' <summary>
''' Allows chatting using the standard format.
''' </summary>
''' <remarks></remarks>
Public Interface IChatter

    ''' <summary>
    ''' Sends a message to the specified user.
    ''' </summary>
    ''' <param name="msg">The message text to be sent.</param>
    ''' <remarks></remarks>
    Sub Reply(username As String, msg As String)

    ''' <summary>
    ''' Sends a chat message with the current chat style.
    ''' </summary>
    ''' <param name="msg">The message text to be sent.</param>
    ''' <remarks></remarks>
    Sub Chat(msg As String)

    ''' <summary>
    ''' Sends a chat message without formatting it
    ''' </summary>
    ''' <param name="msg">The message text to be sent.</param>
    ''' <remarks></remarks>
    Sub Send(msg As String)

    ''' <summary>
    ''' Kicks a user
    ''' </summary>
    ''' <param name="username">The username of the person being kicked.</param>
    ''' <remarks></remarks>
    Sub Kick(username As String)

    ''' <summary>
    ''' Kicks a user
    ''' </summary>
    ''' <param name="username">The username of the person being kicked.</param>
    ''' <param name="reason">The reason for the kick.</param>
    ''' <remarks></remarks>
    Sub Kick(username As String, reason As String)

    ''' <summary>
    ''' Kicks all guests
    ''' </summary>
    ''' <remarks></remarks>
    Sub KickGuests()

    ''' <summary>
    ''' Reloads the level from its last save.
    ''' </summary>
    ''' <remarks></remarks>
    Sub LoadLevel()

    ''' <summary>
    ''' Resets everyone's position
    ''' </summary>
    ''' <remarks></remarks>
    Sub Reset()

    ''' <summary>
    ''' Gives edit rights to a user
    ''' </summary>
    ''' <remarks></remarks>
    Sub GiveEdit(username As String)

    ''' <summary>
    ''' Takes edit rights away from a user
    ''' </summary>
    ''' <remarks></remarks>
    Sub RemoveEdit(username As String)

    ''' <summary>
    ''' Enables the use of specific potions in the world.
    ''' </summary>
    ''' <remarks></remarks>
    Sub PotionsOn(ParamArray potions As String())

    ''' <summary>
    ''' Enables the use of specific potions in the world.
    ''' </summary>
    ''' <remarks></remarks>
    Sub PotionsOn(ParamArray potions As Integer())

    ''' <summary>
    ''' Enables the use of specific potions in the world.
    ''' </summary>
    ''' <remarks></remarks>
    Sub PotionsOn(ParamArray potions As Potion())

    ''' <summary>
    ''' Disables the use of specific potions in the world.
    ''' </summary>
    ''' <remarks></remarks>
    Sub PotionsOff(ParamArray potions As String())

    ''' <summary>
    ''' Disables the use of specific potions in the world.
    ''' </summary>
    ''' <remarks></remarks>
    Sub PotionsOff(ParamArray potions As Integer())

    ''' <summary>
    ''' Disables the use of specific potions in the world.
    ''' </summary>
    ''' <remarks></remarks>
    Sub PotionsOff(ParamArray potions As Potion())

    ''' <summary>
    ''' Respawns the bot, moving it to the last checkpoint or its spawn position.
    ''' </summary>
    ''' <remarks></remarks>
    Sub Respawn()

    ''' <summary>
    ''' Respawns everyone in the world
    ''' </summary>
    ''' <remarks></remarks>
    Sub RespawnAll()

    ''' <summary>
    ''' Kills a player in the world
    ''' </summary>
    ''' <remarks></remarks>
    Sub Kill(username As String)

    ''' <summary>
    ''' Kills all players in the world
    ''' </summary>
    ''' <remarks></remarks>
    Sub KillAll()

    ''' <summary>
    ''' Teleports the given player to the host's current location.
    ''' </summary>
    ''' <remarks></remarks>
    Sub Teleport(username As String)

    ''' <summary>
    ''' Teleports the given player to a specific position.
    ''' </summary>
    ''' <remarks></remarks>
    Sub Teleport(username As String, x As Integer, y As Integer)

    ''' <summary>
    ''' The syntax provider used to generate chat strings
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SyntaxProvider As IChatSyntaxProvider

End Interface
