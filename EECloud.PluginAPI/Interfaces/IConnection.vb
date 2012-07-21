Public Interface IConnection
    Event OnMessage As EventHandler(Of OnMessageEventArgs)
    Event OnLogin As EventHandler
    Event OnJoin As EventHandler
    Event OnError As EventHandler
    Event OnDisconnect As EventHandler

    ReadOnly Property Connection As PlayerIOClient.Connection
    ReadOnly Property WorldID As String

    ReadOnly Property BlockManager As IBlockManager
    ReadOnly Property ConnectionManager As IConnectionManager
    ReadOnly Property SettingManager As ISettingManager
    ReadOnly Property LogManager As ILogManager
End Interface
