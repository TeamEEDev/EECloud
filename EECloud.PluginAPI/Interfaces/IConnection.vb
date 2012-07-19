Public Interface IConnection
    Event OnMessage As EventHandler(Of OnMessageEventArgs)
    Event OnJoin As EventHandler
    Event OnJoinError As EventHandler
    Event OnDisconnect As EventHandler

    ReadOnly Property Connection As PlayerIOClient.Connection
    ReadOnly Property WorldID As String

    ReadOnly Property BlockManager As IBlockManager
End Interface
