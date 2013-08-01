''' <summary>
''' A Client that has its own Connection and has details about the current room it is in.
''' </summary>
Public Interface IClient(Of TPlayer As {Player, New})

    ''' <summary>
    ''' The Connection to a room
    ''' </summary>
    ReadOnly Property Connection As IConnection

    ''' <summary>
    ''' The Client's main Chatter instance
    ''' </summary>
    ReadOnly Property Chatter As IChatter

    ''' <summary>
    ''' The Client's World instance
    ''' </summary>
    ReadOnly Property World As IWorld

    ''' <summary>
    ''' The Client's main Uploader instance that can upload blocks to a world.
    ''' </summary>
    ReadOnly Property Uploader As IUploader

    ''' <summary>
    ''' The Plugin Manager service you can enable/disable plugins for this Client with.
    ''' </summary>
    ReadOnly Property PluginManager As IPluginManager

    ''' <summary>
    ''' The Player Manager service that contains data about users of the current room this Client is in.
    ''' </summary>
    ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer)

    ''' <summary>
    ''' The Command Manager service which allows you to give commands to this Client.
    ''' </summary>
    ReadOnly Property CommandManager As ICommandManager

    ''' <summary>
    ''' Details and options for the World the Client is in.
    ''' </summary>
    ReadOnly Property Game As IGame

    ''' <summary>
    ''' The Client's Key Manager service that is responsible for firing key, switch, etc. press/release/toggle events.
    ''' </summary>
    ReadOnly Property KeyManager As IKeyManager

    ''' <summary>
    ''' The Client's Potion Manager service that is responsible for keeping track of players' potions.
    ''' </summary>
    ReadOnly Property PotionManager As IPotionManager

End Interface
