Public MustInherit Class PluginPart(Of TPlayer As {Player, New})
    Implements IClient(Of TPlayer)

#Region "Fields"
    Friend Client As IClient(Of TPlayer)
#End Region

#Region "Properties"
    Public ReadOnly Property Chatter As IChatter Implements IClient(Of TPlayer).Chatter
        Get
            Return Client.Chatter
        End Get
    End Property

    Public ReadOnly Property CommandManager As ICommandManager Implements IClient(Of TPlayer).CommandManager
        Get
            Return Client.CommandManager
        End Get
    End Property

    Public ReadOnly Property Connection As IConnection Implements IClient(Of TPlayer).Connection
        Get
            Return Client.Connection
        End Get
    End Property

    Public ReadOnly Property Game As IGame Implements IClient(Of TPlayer).Game
        Get
            Return Client.Game
        End Get
    End Property

    Public ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer) Implements IClient(Of TPlayer).PlayerManager
        Get
            Return Client.PlayerManager
        End Get
    End Property

    Public ReadOnly Property PluginManager As IPluginManager Implements IClient(Of TPlayer).PluginManager
        Get
            Return Client.PluginManager
        End Get
    End Property

    Public ReadOnly Property Uploader As IUploader Implements IClient(Of TPlayer).Uploader
        Get
            Return Client.Uploader
        End Get
    End Property

    Public ReadOnly Property World As IWorld Implements IClient(Of TPlayer).World
        Get
            Return Client.World
        End Get
    End Property

    Public ReadOnly Property KeyManager As IKeyManager Implements IClient(Of TPlayer).KeyManager
        Get
            Return Client.KeyManager
        End Get
    End Property

    Public ReadOnly Property PotionManager As IPotionManager Implements IClient(Of TPlayer).PotionManager
        Get
            Return Client.PotionManager
        End Get
    End Property
#End Region

#Region "Methods"

    Friend Overridable Sub Enable(client As IClient(Of TPlayer))
        Me.Client = client
        If Me.Client.Connection.Connected Then
            OnConnect()
        Else
            AddHandler Me.Client.Connection.ReceiveInit, AddressOf Connect
        End If

        OnEnable()
    End Sub

    Friend Overridable Sub Disable()
        OnDisable()
    End Sub

    Private Sub Connect(sender As Object, e As InitReceiveMessage)
        RemoveHandler Client.Connection.ReceiveInit, AddressOf Connect
        OnConnect()
    End Sub

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnDisable()
    Protected MustOverride Sub OnConnect()
#End Region
End Class
