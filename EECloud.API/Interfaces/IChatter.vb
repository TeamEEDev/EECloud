''' <summary>
''' Allows chatting using the standard format.
﻿

''' <summary>
'''     Allows chatting using the standard format.
''' </summary>
Public Interface IChatter

    ''' <summary>
    ''' Sends a chat message with the current chat style.
    ''' </summary>
    ''' <param name="msg">The message text to be sent.</param>
    Sub Chat(msg As String)

    ''' <summary>
    ''' Sends a chat message without formatting it
    ''' </summary>
    ''' <param name="msg">The message text to be sent.</param>
    Sub Send(msg As String)

    ''' <summary>
    ''' Sends a message to the specified user.
    ''' </summary>
    ''' <param name="msg">The message text to be sent.</param>
    Sub Reply(username As String, msg As String)


    ''' <summary>
    ''' Gives edit rights to a user
    ''' </summary>
    Sub GiveEdit(username As String)

    ''' <summary>
    ''' Takes edit rights away from a user
    ''' </summary>
    Sub RemoveEdit(username As String)

    ''' <summary>
    ''' Teleports the given player to the host's current location.
    ''' </summary>
    Sub Teleport(username As String)

    ''' <summary>
    ''' Teleports the given player to a specific position.
    ''' </summary>
    Sub Teleport(username As String, x As Integer, y As Integer)


    ''' <summary>
    ''' Kicks a user
    ''' </summary>
    ''' <param name="username">The username of the person being kicked.</param>
    Sub Kick(username As String)

    ''' <summary>
    ''' Kicks a user
    ''' </summary>
    ''' <param name="username">The username of the person being kicked.</param>
    ''' <param name="reason">The reason for the kick.</param>
    Sub Kick(username As String, reason As String)

    ''' <summary>
    ''' Kicks all guests
    ''' </summary>
    Sub KickGuests()

    ''' <summary>
    ''' Kills a player in the world
    ''' </summary>
    Sub Kill(username As String)

    ''' <summary>
    ''' Kills all players in the world
    ''' </summary>
    Sub KillAll()

    ''' <summary>
    ''' Resets everyone's position
    ''' </summary>
    Sub Reset()

    ''' <summary>
    ''' Respawns the bot, moving it to the last checkpoint or its spawn position.
    ''' </summary>
    Sub Respawn()

    ''' <summary>
    ''' Respawns everyone in the world
    ''' </summary>
    Sub RespawnAll()


    ''' <summary>
    ''' Enables the use of specific potions in the world.
    ''' </summary>
    Sub PotionsOn(ParamArray potions As String())

    ''' <summary>
    ''' Enables the use of specific potions in the world.
    ''' </summary>
    Sub PotionsOn(ParamArray potions As Integer())

    ''' <summary>
    ''' Enables the use of specific potions in the world.
    ''' </summary>
    Sub PotionsOn(ParamArray potions As Potion())

    ''' <summary>
    ''' Disables the use of specific potions in the world.
    ''' </summary>
    Sub PotionsOff(ParamArray potions As String())

    ''' <summary>
    ''' Disables the use of specific potions in the world.
    ''' </summary>
    Sub PotionsOff(ParamArray potions As Integer())

    ''' <summary>
    ''' Disables the use of specific potions in the world.
    ''' </summary>
    Sub PotionsOff(ParamArray potions As Potion())


    ''' <summary>
    ''' Makes the world shown or hidden in the lobby.
    ''' </summary>
    Sub ChangeVisibility(visible As Boolean)


    ''' <summary>
    ''' Reloads the level from its last save.
    ''' </summary>
    Sub LoadLevel()


    ''' <summary>
    ''' The syntax provider used to generate chat strings
    ''' </summary>
    Property SyntaxProvider As IChatSyntaxProvider

End Interface
