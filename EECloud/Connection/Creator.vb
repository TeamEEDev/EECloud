Friend Class Creator
    Implements ICreator
    Private myInternalConnection As InternalConnection
    Sub New(internalConnection As InternalConnection)
        myInternalConnection = internalConnection
    End Sub

    Public Function GenerateConnection(Of P As {New, Player})(plugin As IPluginObject) As IConnection(Of P) Implements ICreator.GenerateConnection
        Return New Connection(Of P)(myInternalConnection, plugin.Attribute.ChatName)
    End Function
End Class
