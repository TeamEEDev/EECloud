''' <summary>
''' Allows chatting using the standard format.
''' </summary>
''' <remarks></remarks>
    Public Interface IChatter
    ''' <summary>
    ''' Sends a message to the specified user.
    ''' </summary>
    ''' <param name="username">The username of the user.</param>
    ''' <param name="msg">The message text.</param>
    ''' <remarks></remarks>
    Sub Reply(username As String, msg As String)

    ''' <summary>
    ''' Sends a chat message with the current chat style.
    ''' </summary>
    ''' <param name="msg">The message text to be sent.</param>
    ''' <remarks></remarks>
    Sub Chat(msg As String)

    ''' <summary>
    ''' Kicks a user.
    ''' </summary>
    ''' <param name="username">The username of the person being kicked.</param>
    ''' <param name="msg">The reason for the kick.</param>
    ''' <remarks></remarks>
    Sub Kick(username As String, msg As String)

    ''' <summary>
    ''' Reloads the level data. />.
    ''' </summary>
    ''' <remarks></remarks>
    Sub Loadlevel()

    ''' <summary>
    ''' Resets everyones position. />.
    ''' </summary>
    ''' <remarks></remarks>
    Sub Reset()
End Interface
