Friend NotInheritable Class ConnectionFactory
    Implements IConnectionFactory
    Private ReadOnly myInternalConnection As InternalConnection

    Sub New(internalConnection As InternalConnection)
        myInternalConnection = internalConnection
    End Sub

    Friend Function GetConnection(Of TPlayer As {New, Player})(plugin As IPluginObject, instance As Object) As IConnection(Of TPlayer) Implements IConnectionFactory.GetConnection
        Dim name As String = plugin.Attribute.ChatName
        If name = Nothing Then name = plugin.Name
        Return New Connection(Of TPlayer)(myInternalConnection, plugin, instance)
    End Function
End Class
