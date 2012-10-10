Friend NotInheritable Class Client(Of TPlayer As {Player, New})
    Implements IClient(Of TPlayer)

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

    Private ReadOnly myChatter As IChatter

    Friend ReadOnly Property Chatter As IChatter Implements IClient(Of TPlayer).Chatter
        Get
            Return myChatter
        End Get
    End Property

    Private ReadOnly myPlayerManager As IPlayerManager(Of TPlayer)

    Friend ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer) Implements IClient(Of TPlayer).PlayerManager
        Get
            Return myPlayerManager
        End Get
    End Property

    Private ReadOnly myCommandManager As ICommandManager

    Public ReadOnly Property CommandManager As ICommandManager Implements IClient(Of TPlayer).CommandManager
        Get
            Return myCommandManager
        End Get
    End Property
#End Region

#Region "Methods"

    Friend Sub New(internalClient As InternalClient, pluginObject As IPluginObject)
        myInternalClient = InternalClient

        Dim chatterName As String = pluginObject.Attribute.ChatName
        If chatterName = Nothing Then chatterName = pluginObject.Name
        myChatter = New Chatter(InternalClient.InternalChatter, chatterName)

        myPlayerManager = New PlayerManager(Of TPlayer)(InternalClient)
        myCommandManager = New CommandManager(Of TPlayer)(Me, InternalClient.InternalCommandManager)
    End Sub

#End Region
End Class
