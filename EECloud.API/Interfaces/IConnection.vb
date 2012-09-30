Public Interface IConnection(Of TPlayer As {Player, New})
    Inherits IMessageManager

    ReadOnly Property Chatter As IChatter
    ReadOnly Property World As World
    ReadOnly Property PluginManager As IPluginManager
    ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer)

    ReadOnly Property WorldID As String
    ReadOnly Property Connected As Boolean
    Sub Send(message As SendMessage)
End Interface
