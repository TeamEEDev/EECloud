Friend Class SimpleChatSyntaxProvider
    Implements IChatSyntaxProvider

    Friend Function ApplyChatSyntax(chat As String, chatName As String) As String Implements IChatSyntaxProvider.ApplyChatSyntax
        Return String.Format("<{0}> {1}", chatName, chat)
    End Function

    Friend Function ApplyReplySyntax(chat As String, chatName As String, playerName As String) As String Implements IChatSyntaxProvider.ApplyReplySyntax
        Return String.Format("<{0} (@{1})> {2}", chatName, MakeFirstLetterUpperCased(playerName), chat)
    End Function

    Friend Function ApplyKickSyntax(chatName As String, playerName As String, reason As String) As String Implements IChatSyntaxProvider.ApplyKickSyntax
        Return String.Format("/kick {0} <{1}> {2}", playerName, chatName, reason)
    End Function
End Class
