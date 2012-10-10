Friend NotInheritable Class ClientFactory
    Implements IClientFactory

#Region "Methods"
    Friend Function GetConnectionHandle() As IClient(Of Player) Implements IClientFactory.CreateClient
        Return New InternalClient
    End Function
#End Region
End Class
