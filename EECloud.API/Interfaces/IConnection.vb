Public Interface IConnection
    Event OnMessage As EventHandler(Of OnMessageEventArgs)
    Event OnDisconnect As EventHandler

    ReadOnly Property WorldID As String
    ReadOnly Property Connected As Boolean
    ReadOnly Property BlockManager As IBlocks

    Sub Send(PMessage As SendMessage)
    Sub Disconnect()
End Interface
