Friend Class Connection(Of TPlayer As {Player, New})
    Inherits MessageManager
    Implements IConnection(Of TPlayer)

#Region "Fields"
    Private ReadOnly myEvents As New EventHandlerList
#End Region

#Region "Properties"

    Friend ReadOnly Property WorldID As String Implements IConnection(Of TPlayer).WorldID
        Get
            Return InternalConnection.WorldID
        End Get
    End Property

    Friend ReadOnly Property Connected As Boolean Implements IConnection(Of TPlayer).Connected
        Get
            Return InternalConnection.Connected
        End Get
    End Property

    Friend ReadOnly Property World As World Implements IConnection(Of TPlayer).World
        Get
            Return InternalConnection.World
        End Get
    End Property

    Friend Overridable ReadOnly Property PluginManager As IPluginManager Implements IConnection(Of TPlayer).PluginManager
        Get
            Return InternalConnection.PluginManager
        End Get
    End Property

    Private ReadOnly myChatter As IChatter

    Friend ReadOnly Property Chatter As IChatter Implements IConnection(Of TPlayer).Chatter
        Get
            Return myChatter
        End Get
    End Property

    Private ReadOnly myPlayerManager As PlayerManager(Of TPlayer)

    Friend ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer) Implements IConnection(Of TPlayer).PlayerManager
        Get
            Return myPlayerManager
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(internalConnection As InternalConnection, chatter As IChatter)
        Me.InternalConnection = internalConnection
        myChatter = chatter
        myPlayerManager = New PlayerManager(Of TPlayer)(internalConnection.InternalPlayerManager, internalConnection.DefaultConnection)
    End Sub

    Protected Sub New()
    End Sub

    Friend Sub Send(message As SendMessage) Implements IConnection(Of TPlayer).Send
        If Not RaiseSendEvent(message) Then
            InternalConnection.Send(message)
        End If
    End Sub

#End Region
End Class
