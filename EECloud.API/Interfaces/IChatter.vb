''' <summary>
'''     Allows chatting using the standard format.
''' </summary>
''' <remarks></remarks>
Public Interface IChatter
    ''' <summary>
    '''     Sends a message to the specified user.
    ''' </summary>
    ''' <param name="username">The username of the user.</param>
    ''' <param name="msg">The message text.</param>
    ''' <remarks></remarks>
    Sub Reply(username As String, msg As String)

    ''' <summary>
    '''     Sends a chat message with the current chat style.
    ''' </summary>
    ''' <param name="msg">The message text to be sent.</param>
    ''' <remarks></remarks>
    Sub Chat(msg As String)

    ''' <summary>
    '''     Sends a chat message without formatting it
    ''' </summary>
    ''' <param name="msg">The message text to be sent.</param>
    ''' <remarks></remarks>
    Sub Send(msg As String)

    ''' <summary>
    '''     Kicks a user.
    ''' </summary>
    ''' <param name="username">The username of the person being kicked.</param>
    ''' <remarks></remarks>
    Sub Kick(username As String)

    ''' <summary>
    '''     Kicks a user.
    ''' </summary>
    ''' <param name="username">The username of the person being kicked.</param>
    ''' <param name="msg">The reason for the kick.</param>
    ''' <remarks></remarks>
    Sub Kick(username As String, msg As String)

    ''' <summary>
    '''     Reloads the level data.
    ''' </summary>
    ''' <remarks></remarks>
    Sub Loadlevel()

    ''' <summary>
    '''     Resets everyone's position.
    ''' </summary>
    ''' <remarks></remarks>
    Sub Reset()

    ''' <summary>
    ''' Gives edit rights to a user
    ''' </summary>
    ''' <param name="username">The username of the target</param>
    ''' <remarks></remarks>
    Sub GiveEdit(username As String)

    ''' <summary>
    ''' Takes edit rights away from a user
    ''' </summary>
    ''' <param name="username">The username of the target</param>
    ''' <remarks></remarks>
    Sub RemoveEdit(username As String)

    ''' <summary>
    ''' Respawns the bot, moving it to the last checkpoint or its spawn
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
    ''' Teleports the given player
    ''' </summary>
    ''' <remarks></remarks>
    Sub Teleport(username As String)

    ''' <summary>
    ''' Teleports the given player
    ''' </summary>
    ''' <remarks></remarks>
    Sub Teleport(username As String, x As Integer, y As Integer)

    ''' <summary>
    '''     The Syntax provider used to generate chat strings
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SyntaxProvider As IChatSyntaxProvider
End Interface
