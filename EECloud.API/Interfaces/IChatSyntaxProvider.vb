Public Interface IChatSyntaxProvider
    Function ApplyChatSyntax(chat As String, chatName As String) As String
    Function ApplyReplySyntax(chat As String, chatName As String, player As String) As String
    Function ApplyKickSyntax(chatName As String, player As String, ByVal reason As String) As String
End Interface
