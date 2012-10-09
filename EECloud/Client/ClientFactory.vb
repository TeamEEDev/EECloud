Friend NotInheritable Class ClientFactory
    Implements IClientGenerator
    Private ReadOnly myInternalConnection As InternalClient

    Sub New(internalConnection As InternalClient)
        myInternalConnection = internalConnection
    End Sub

    Friend Function GetConnection(Of TPlayer As {New, Player})(plugin As IPluginObject, instance As Object) As IClient(Of TPlayer) Implements IClientGenerator.GetConnection
        Dim name As String = plugin.Attribute.ChatName
        If name = Nothing Then name = plugin.Name
        Return New Client(Of TPlayer)(myInternalConnection, plugin)
    End Function
End Class
