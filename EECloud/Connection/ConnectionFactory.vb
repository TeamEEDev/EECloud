Friend NotInheritable Class ConnectionFactory
    Implements IConnectionFactory
    Private ReadOnly myInternalConnection As InternalConnection
    Sub New(internalConnection As InternalConnection)
        myInternalConnection = internalConnection
    End Sub

    Friend Function GetConnection(Of TPlayer As {New, Player})(plugin As IPluginObject) As IConnection(Of TPlayer) Implements IConnectionFactory.GetConnection
        Dim name As String = plugin.Attribute.ChatName
        If name = Nothing Then name = plugin.Name
        Return New Connection(Of TPlayer)(myInternalConnection, New Chatter(myInternalConnection.InternalChatter, name))
    End Function
End Class
