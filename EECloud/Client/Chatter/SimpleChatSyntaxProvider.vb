Public Class SimpleChatSyntaxProvider
    Implements IChatSyntaxProvider

    Public Function ApplyChatSyntax(chat As String, chatName As String) As String Implements IChatSyntaxProvider.ApplyChatSyntax
        Return String.Format("<{0}> {1}", chatName, chat)
    End Function

    Public Function ApplyReplySyntax(chat As String, chatName As String, player As String) As String Implements IChatSyntaxProvider.ApplyReplySyntax
        Return String.Format("<{0} (@{1})> {2}", chatName, StrConv(player, VbStrConv.ProperCase), chat)
    End Function

    Public Function ApplyKickSyntax(reason As String, chatName As String, player As String) As String Implements IChatSyntaxProvider.ApplyKickSyntax
        Return String.Format("/kick {0} <{1}> {2}", player, chatName, reason)
    End Function
End Class
