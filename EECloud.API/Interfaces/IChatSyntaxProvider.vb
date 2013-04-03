Public Interface IChatSyntaxProvider
    ''' <summary>
    ''' Runs whenever a text must be sent
    ''' </summary>
    ''' <param name="chat">The text being chatted</param>
    ''' <param name="chatName">The chatName of the chatting plugin</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ApplyChatSyntax(chat As String, chatName As String) As String

    ''' <summary>
    ''' Runs whenever Player.Reply, Command.Reply or Chatter.Reply is invoked
    ''' </summary>
    ''' <param name="chat">The text being chatted</param>
    ''' <param name="chatName">The chatName of the chatting plugin</param>
    ''' <param name="playerName">The target player</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ApplyReplySyntax(chat As String, chatName As String, playerName As String) As String

    ''' <summary>
    ''' Runs whenever Chatter.Kick or Player.Kick is invoked
    ''' </summary>
    ''' <param name="chatName">The chatName of the chatting plugin</param>
    ''' <param name="playerName">The target player</param>
    ''' <param name="reason">The kick reason</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ApplyKickSyntax(chatName As String, playerName As String, reason As String) As String
End Interface
