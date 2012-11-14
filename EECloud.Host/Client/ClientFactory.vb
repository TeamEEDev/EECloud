Friend NotInheritable Class ClientFactory
    Implements IClientFactory

#Region "Methods"

    Friend Function GetConnectionHandle(commandChar As Char) As IClient(Of Player) Implements IClientFactory.CreateClient
        Return New InternalClient(commandChar)
    End Function

#End Region
End Class
