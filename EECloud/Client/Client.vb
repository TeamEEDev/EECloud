Friend NotInheritable Class Client (Of TPlayer As {Player, New})
    Implements IClient(Of TPlayer), IDisposable

#Region "Fields"
    Private ReadOnly myInternalClient As InternalClient
#End Region

#Region "Properties"

    Friend ReadOnly Property World As IWorld Implements IClient(Of TPlayer).World
        Get
            Return myInternalClient.World
        End Get
    End Property

    Friend ReadOnly Property PluginManager As IPluginManager Implements IClient(Of TPlayer).PluginManager
        Get
            Return myInternalClient.PluginManager
        End Get
    End Property

    Public ReadOnly Property Connection As IConnection Implements IClient(Of TPlayer).Connection
        Get
            Return myInternalClient.Connection
        End Get
    End Property

    Public ReadOnly Property Uploader As IUploader Implements IClient(Of TPlayer).Uploader
        Get
            Return myInternalClient.Uploader
        End Get
    End Property

    Public ReadOnly Property Game As IGame Implements IClient(Of TPlayer).Game
        Get
            Return myInternalClient.Game
        End Get
    End Property

    Public ReadOnly Property KeyManager As IKeyManager Implements IClient(Of TPlayer).KeyManager
        Get
            Return myInternalClient.KeyManager
        End Get
    End Property

    Private ReadOnly myChatter As Chatter

    Friend ReadOnly Property Chatter As IChatter Implements IClient(Of TPlayer).Chatter
        Get
            Return myChatter
        End Get
    End Property

    Private ReadOnly myPlayerManager As PlayerManager(Of TPlayer)

    Friend ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer) Implements IClient(Of TPlayer).PlayerManager
        Get
            Return myPlayerManager
        End Get
    End Property

    Private ReadOnly myCommandManager As CommandManager(Of TPlayer)

    Public ReadOnly Property CommandManager As ICommandManager Implements IClient(Of TPlayer).CommandManager
        Get
            Return myCommandManager
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(internalClient As InternalClient, pluginObject As IPluginObject)
        myInternalClient = internalClient

        Dim chatterName As String = pluginObject.Attribute.ChatName
        If chatterName = Nothing Then chatterName = pluginObject.Name
        myChatter = New Chatter(internalClient.InternalChatter, chatterName)

        myPlayerManager = New PlayerManager(Of TPlayer)(internalClient)
        myCommandManager = New CommandManager(Of TPlayer)(Me, internalClient.InternalCommandManager)
    End Sub

#End Region

#Region "IDisposable Support"
    Private myDisposedValue As Boolean

    Private Sub Dispose(disposing As Boolean)
        If Not myDisposedValue Then
            If disposing Then
                myPlayerManager.Dispose()
                myCommandManager.Dispose()
            End If
        End If
        myDisposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
    End Sub
#End Region
End Class
