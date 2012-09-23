Public Interface ICreator
    Function GenerateConnection(Of P As {Player, New})() As IConnection(Of P)
End Interface
