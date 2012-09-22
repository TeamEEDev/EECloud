Public Class Connector
    Implements IConnector

    Public Function CreateConnection() As IConnectionHandle Implements IConnector.CreateConnection
        Return New ConnectionHandle()
    End Function
End Class
