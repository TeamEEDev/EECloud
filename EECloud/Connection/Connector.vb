Friend Class Connector
    Implements IConnector

    Friend Function CreateConnection() As IConnectionHandle Implements IConnector.CreateConnection
        Return New ConnectionHandle()
    End Function
End Class
