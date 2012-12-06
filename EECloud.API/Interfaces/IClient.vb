
''' <summary>
'''     A client that has its own connection and has details about the current room it is in.
''' </summary>
''' <typeparam name="TPlayer"></typeparam>
''' <remarks></remarks>
    Public Interface IClient (Of TPlayer As {Player, New})
    
    ''' <summary>
    '''     The connection to a room.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Connection As IConnection
    
    ''' <summary>
    '''     The client's main chatter instance.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Chatter As IChatter
    
    ''' <summary>
    '''     The client's world instance.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property World As IWorld
    
    ''' <summary>
    '''     The client's main uploader instance that can upload blocks to a world.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Uploader As IUploader
    
    ''' <summary>
    '''     The client's plugin manager service you can enable/disable plugins for the client with.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PluginManager As IPluginManager
    
    ''' <summary>
    '''     The client's player manager service that contains data about users of the current room the client is in.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer)
    
    ''' <summary>
    '''     The client's command manager service. If it wouldn't exist, you wouldn't be able to give the client any commands.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CommandManager As ICommandManager
    
    ''' <summary>
    '''     Details and options for the world the client is in.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Game As IGame
    
    ''' <summary>
    '''     The client's key manager that is responsible for firing key, switch, etc. press/release/toggle events.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property KeyManager As IKeyManager
    
    ''' <summary>
    '''     The client's potion manager that is responsible for keeping track of player's potions
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PotionManager As IPotionManager
End Interface
