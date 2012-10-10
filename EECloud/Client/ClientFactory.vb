Friend NotInheritable Class ClientFactory
    Implements IClientFactory

    Friend Function GetConnectionHandle() As IClient(Of Player) Implements IClientFactory.CreateClient
        Return New InternalClient
    End Function
End Class
