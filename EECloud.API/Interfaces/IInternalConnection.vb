Friend Interface IInternalConnection
    Event OnMessage As EventHandler(Of ReciveMessage)
    Event OnDisconnect As EventHandler
    Event OnAddUser(sender As Object, e As IPlayer)
    Event OnRemoveUser(sender As Object, e As Left_ReciveMessage)

    ReadOnly Property WorldID As String
    ReadOnly Property Connected As Boolean
    ReadOnly Property IsMainConnection As Boolean
    ReadOnly Property World As World
    ReadOnly Property DefaultConnection As Connection(Of Player)
    ReadOnly Property Encryption As String

    Sub Send(message As SendMessage)
    Sub Disconnect()
End Interface
