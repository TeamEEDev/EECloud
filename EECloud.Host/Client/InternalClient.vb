Friend NotInheritable Class InternalClient
    Implements IClient(Of Player), IDisposable

#Region "Properties"

    Private ReadOnly myPluginManager As IPluginManager

    Friend ReadOnly Property PluginManager As IPluginManager Implements IClient(Of Player).PluginManager
        Get
            Return myPluginManager
        End Get
    End Property

    Private ReadOnly myWorld As IWorld

    Friend ReadOnly Property World As IWorld Implements IClient(Of Player).World
        Get
            Return myWorld
        End Get
    End Property

    Private ReadOnly myConnection As IConnection

    Friend ReadOnly Property Connection As IConnection Implements IClient(Of Player).Connection
        Get
            Return myConnection
        End Get
    End Property

    Private ReadOnly myUploader As IUploader

    Friend ReadOnly Property Uploader As IUploader Implements IClient(Of Player).Uploader
        Get
            Return myUploader
        End Get
    End Property

    Private ReadOnly myGame As IGame

    Friend ReadOnly Property Game As IGame Implements IClient(Of Player).Game
        Get
            Return myGame
        End Get
    End Property

    Private ReadOnly myKeyManager As IKeyManager

    Friend ReadOnly Property KeyManager As IKeyManager Implements IClient(Of Player).KeyManager
        Get
            Return myKeyManager
        End Get
    End Property

    Private ReadOnly myPotionManager As IPotionManager

    Public ReadOnly Property PotionManager As IPotionManager Implements IClient(Of Player).PotionManager
        Get
            Return myPotionManager
        End Get
    End Property

    Private ReadOnly myInternalChatter As InternalChatter

    Friend ReadOnly Property InternalChatter As InternalChatter
        Get
            Return myInternalChatter
        End Get
    End Property

    Private ReadOnly myInternalPlayerManager As InternalPlayerManager

    Friend ReadOnly Property InternalPlayerManager() As InternalPlayerManager
        Get
            Return myInternalPlayerManager
        End Get
    End Property

    Private ReadOnly myInternalCommandManager As InternalCommandManager

    Friend ReadOnly Property InternalCommandManager As InternalCommandManager
        Get
            Return myInternalCommandManager
        End Get
    End Property

    Private ReadOnly myChatter As IChatter

    Friend ReadOnly Property Chatter As IChatter Implements IClient(Of Player).Chatter
        Get
            Return myChatter
        End Get
    End Property

    Private ReadOnly myCommandManager As ICommandManager

    Friend ReadOnly Property CommandManager As ICommandManager Implements IClient(Of Player).CommandManager
        Get
            Return myCommandManager
        End Get
    End Property

    Private ReadOnly myPlayerManager As IPlayerManager(Of Player)

    Friend ReadOnly Property PlayerManager As IPlayerManager(Of Player) Implements IClient(Of Player).PlayerManager
        Get
            Return myPlayerManager
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(Optional commandChar As Char = Nothing)
        'Creating instances
        Cloud.Logger = New Logger(Me)
        Console.CursorVisible = True

        myPluginManager = New PluginManager(New ClientCloneFactory(Me))
        myConnection = New Connection(Me)
        myWorld = New World(Me)
        myUploader = New Uploader(Me)
        myGame = New Game(Me)
        myKeyManager = New KeyManager(Me)
        myPotionManager = New PotionManager(Me)

        myInternalChatter = New InternalChatter(Me)
        myInternalPlayerManager = New InternalPlayerManager(Me)
        myInternalCommandManager = New InternalCommandManager(Me, commandChar)

        myChatter = New Chatter(myInternalChatter, "Bot")
        myPlayerManager = New PlayerManager(Of Player)(Me, Me)
        myCommandManager = New CommandManager(Of Player)(Me, myInternalCommandManager)
    End Sub

#End Region

#Region "IDisposable Support"
    Private myDisposedValue As Boolean

    Private Sub Dispose(disposing As Boolean)
        If Not myDisposedValue Then
            If disposing Then

            End If

            myPlayerManager.Dispose()
            myCommandManager.Dispose()
        End If
        myDisposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub

    Friend Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region
End Class
