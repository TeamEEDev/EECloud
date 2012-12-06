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
    ''' Sends a chat message without formatting it
    ''' </summary>
    ''' <param name="msg">The message text to be sent.</param>
    ''' <remarks></remarks>
    Sub Send(msg As String)

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

    ''' <summary>
    ''' Replaces the current chat provider with the given provider
    ''' </summary>
    ''' <param name="provider">The new syntax provider</param>
    ''' <remarks></remarks>
    <Obsolete("Use SyntaxProvider property instead")>
    Sub InjectSyntaxProvider(provider As IChatSyntaxProvider)

    ''' <summary>
    ''' The Syntax provider used to generate chat strings
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property SyntaxProvider As IChatSyntaxProvider
End Interface
