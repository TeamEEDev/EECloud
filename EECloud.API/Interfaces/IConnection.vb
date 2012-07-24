Public Interface IConnection
    Inherits IDisposable
    Event OnDisconnect As EventHandler

    ReadOnly Property WorldID As String
    ReadOnly Property Connected As Boolean

    ReadOnly Property BlockManager As IBlocks

    Sub Disconnect()
End Interface
