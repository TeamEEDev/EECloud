Public Interface ICommand (Of TPlayer As {New, Player})
    ReadOnly Property Sender As TPlayer
    ReadOnly Property Label As String
    Sub Reply(msg As String)
End Interface
