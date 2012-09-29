Friend NotInheritable Class Creator
    Implements ICreator
    Private ReadOnly myInternalConnection As InternalConnection
    Sub New(internalConnection As InternalConnection)
        myInternalConnection = internalConnection
    End Sub

    Friend Function GenerateConnection(Of TPlayer As {New, Player})(plugin As IPluginObject) As IConnection(Of TPlayer) Implements ICreator.GenerateConnection
        Dim name As String = plugin.Attribute.ChatName
        If name = Nothing Then name = plugin.Name
        Return New Connection(Of TPlayer)(myInternalConnection, New Chatter(myInternalConnection.InternalChatter, name))
    End Function
End Class
