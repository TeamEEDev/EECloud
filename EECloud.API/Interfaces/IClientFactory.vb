Public Interface IClientFactory
    Function CreateClient(commandChar As Char) As IClient(Of Player)
End Interface
