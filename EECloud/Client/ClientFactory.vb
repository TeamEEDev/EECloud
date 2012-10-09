Friend NotInheritable Class ClientFactory
    Implements IClientFactory
    Private ReadOnly myInternalConnection As InternalClient

    Sub New(internalConnection As InternalClient)
        myInternalConnection = internalConnection
    End Sub

    Friend Function GetConnection(Of TPlayer As {New, Player})(plugin As IPluginObject, instance As Object) As IConnection(Of TPlayer) Implements IClientFactory.GetConnection
        Dim name As String = plugin.Attribute.ChatName
        If name = Nothing Then name = plugin.Name
        Return New Connection(Of TPlayer)(myInternalConnection, plugin, instance)
    End Function
End Class
