Public Interface ICommand(Of TPlayer As {New, Player})
    ReadOnly Property Sender As TPlayer
    ReadOnly Property Label As String
End Interface
