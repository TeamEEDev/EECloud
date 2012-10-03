Friend Class Connection(Of TPlayer As {Player, New})
    Inherits ConnectionBase(Of TPlayer)

#Region "Fields"
    Private ReadOnly myEvents As New EventHandlerList
#End Region

#Region "Properties"

    Friend Overrides ReadOnly Property WorldID As String
        Get
            Return InternalConnection.WorldID
        End Get
    End Property

    Friend Overrides ReadOnly Property Connected As Boolean
        Get
            Return InternalConnection.Connected
        End Get
    End Property

    Friend Overrides ReadOnly Property World As World
        Get
            Return InternalConnection.World
        End Get
    End Property

    Friend Overrides ReadOnly Property PluginManager As IPluginManager
        Get
            Return InternalConnection.PluginManager
        End Get
    End Property

    Private ReadOnly myChatter As IChatter

    Friend Overrides ReadOnly Property Chatter As IChatter
        Get
            Return myChatter
        End Get
    End Property

    Private ReadOnly myPlayerManager As PlayerManager(Of TPlayer)

    Friend Overrides ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer)
        Get
            Return myPlayerManager
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(internalConnection As InternalConnection, chatter As IChatter)
        Me.InternalConnection = internalConnection
        myChatter = chatter
        myPlayerManager = New PlayerManager(Of TPlayer)(internalConnection.InternalPlayerManager, internalConnection)
    End Sub

    Friend Overrides Sub Send(message As SendMessage)
        If Not RaiseSendEvent(message) Then
            InternalConnection.Send(message)
        End If
    End Sub

#End Region
End Class
