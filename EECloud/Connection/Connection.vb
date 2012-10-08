Friend NotInheritable Class Connection(Of TPlayer As {Player, New})
    Inherits ConnectionBase(Of TPlayer)

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

    Friend Overrides ReadOnly Property World As IWorld
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

    Private ReadOnly myPlayerManager As IPlayerManager(Of TPlayer)

    Friend Overrides ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer)
        Get
            Return myPlayerManager
        End Get
    End Property

    Private ReadOnly myCommandManager As CommandManager(Of TPlayer)

    Public Overrides ReadOnly Property CommandManager As ICommandManager
        Get
            Return myCommandManager
        End Get
    End Property
#End Region

#Region "Methods"

    Friend Sub New(internalConnection As InternalConnection, pluginObject As IPluginObject, instance As Object)
        Me.InternalConnection = internalConnection

        Dim chatterName As String = pluginObject.Attribute.ChatName
        If chatterName = Nothing Then chatterName = pluginObject.Name
        myChatter = New Chatter(internalConnection.InternalChatter, chatterName)

        myPlayerManager = New PlayerManager(Of TPlayer)(internalConnection.InternalPlayerManager, internalConnection, myChatter)
        myCommandManager = New CommandManager(Of TPlayer)(Me, internalConnection.InternalCommandManager)
        myCommandManager.Add(instance)
    End Sub

    Friend Overrides Sub Send(message As SendMessage)
        If Not RaiseSendEvent(message) Then
            InternalConnection.Send(message)
        End If
    End Sub

#End Region
End Class
