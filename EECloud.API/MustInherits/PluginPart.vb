Public MustInherit Class PluginPart(Of TPlayer As {Player, New}, TProtocol)
    Implements IClient(Of TPlayer)

#Region "Fields"
    Private WithEvents myPluginHost As IPlugin
#End Region

#Region "Properties"

    Private myHost As TProtocol

    Public ReadOnly Property Host As TProtocol
        Get
            Return myHost
        End Get
    End Property

    Private myClient As IClient(Of TPlayer)

    Friend ReadOnly Property Client As IClient(Of TPlayer)
        Get
            Return myClient
        End Get
    End Property

    Protected ReadOnly Property Chatter As IChatter Implements IClient(Of TPlayer).Chatter
        Get
            Return myClient.Chatter
        End Get
    End Property

    Protected ReadOnly Property CommandManager As ICommandManager Implements IClient(Of TPlayer).CommandManager
        Get
            Return myClient.CommandManager
        End Get
    End Property

    Protected ReadOnly Property Connection As IConnection Implements IClient(Of TPlayer).Connection
        Get
            Return myClient.Connection
        End Get
    End Property

    Protected ReadOnly Property Game As IGame Implements IClient(Of TPlayer).Game
        Get
            Return myClient.Game
        End Get
    End Property

    Protected ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer) Implements IClient(Of TPlayer).PlayerManager
        Get
            Return myClient.PlayerManager
        End Get
    End Property

    Protected ReadOnly Property PluginManager As IPluginManager Implements IClient(Of TPlayer).PluginManager
        Get
            Return myClient.PluginManager
        End Get
    End Property

    Protected ReadOnly Property Uploader As IUploader Implements IClient(Of TPlayer).Uploader
        Get
            Return myClient.Uploader
        End Get
    End Property

    Protected ReadOnly Property World As IWorld Implements IClient(Of TPlayer).World
        Get
            Return myClient.World
        End Get
    End Property

    Protected ReadOnly Property KeyManager As IKeyManager Implements IClient(Of TPlayer).KeyManager
        Get
            Return myClient.KeyManager
        End Get
    End Property

    Protected ReadOnly Property PotionManager As IPotionManager Implements IClient(Of TPlayer).PotionManager
        Get
            Return myClient.PotionManager
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Overridable Sub Enable(client As IClient(Of TPlayer), host As IPlugin)
        myClient = client
        myPluginHost = host
        myHost = CType(host, TProtocol)

        If myClient.Connection.Connected Then
            OnConnect()
        Else
            AddHandler myClient.Connection.ReceiveInit, AddressOf Connect
        End If

        OnEnable()
    End Sub

    Protected Friend Overridable Sub Disable() Handles myPluginHost.Disabling
        OnDisable()
    End Sub

    Private Sub Connect(sender As Object, e As InitReceiveMessage)
        RemoveHandler myClient.Connection.ReceiveInit, AddressOf Connect
        OnConnect()
    End Sub

    Protected Function EnablePart(Of TPart As {PluginPart(Of TPlayer, TProtocol), New})() As TPart
        Dim part As New TPart
        part.Enable(Client, myPluginHost)
        Return part
    End Function

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnDisable()
    Protected MustOverride Sub OnConnect()
#End Region
End Class
