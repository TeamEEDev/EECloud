Public Interface IClient(Of TPlayer As {Player, New})
    ReadOnly Property Connection As IConnection
    ReadOnly Property Chatter As IChatter
    ReadOnly Property World As IWorld
    ReadOnly Property PluginManager As IPluginManager
    ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer)
    ReadOnly Property CommandManager As ICommandManager
End Interface
