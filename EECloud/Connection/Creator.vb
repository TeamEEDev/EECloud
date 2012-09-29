﻿Friend Class Creator
    Implements ICreator
    Private myInternalConnection As InternalConnection
    Sub New(internalConnection As InternalConnection)
        myInternalConnection = internalConnection
    End Sub

    Friend Function GenerateConnection(Of P As {New, Player})(plugin As IPluginObject) As IConnection(Of P) Implements ICreator.GenerateConnection
        Dim name As String = plugin.Attribute.ChatName
        If name = Nothing Then name = plugin.Name
        Return New Connection(Of P)(myInternalConnection, New Chatter(myInternalConnection.InternalChatter, name))
    End Function
End Class
