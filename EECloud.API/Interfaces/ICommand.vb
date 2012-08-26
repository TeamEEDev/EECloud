Public Interface ICommand
    ReadOnly Property Type As String
    ReadOnly Property Args As String()
    ReadOnly Property Sender As Player
End Interface
