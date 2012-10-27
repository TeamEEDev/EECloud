﻿Friend NotInheritable Class InternalClient
    Implements IClient(Of Player)

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

    Public ReadOnly Property Connection As IConnection Implements IClient(Of Player).Connection
        Get
            Return myConnection
        End Get
    End Property

    Private ReadOnly myUploader As IUploader

    Public ReadOnly Property Uploader As IUploader Implements IClient(Of Player).Uploader
        Get
            Return myUploader
        End Get
    End Property

    Private ReadOnly myGame As IGame

    Public ReadOnly Property Game As IGame Implements IClient(Of Player).Game
        Get
            Return myGame
        End Get
    End Property

    Private ReadOnly myKeyManager As IKeyManager

    Public ReadOnly Property KeyManager As IKeyManager Implements IClient(Of Player).KeyManager
        Get
            Return myKeyManager
        End Get
    End Property

    Private ReadOnly myInternalChatter As InternalChatter

    Friend ReadOnly Property InternalChatter As InternalChatter
        Get
            Return myInternalChatter
        End Get
    End Property

    Private ReadOnly myInternalPlayerManager As InternalPlayerManager

    Public ReadOnly Property InternalPlayerManager() As InternalPlayerManager
        Get
            Return myInternalPlayerManager
        End Get
    End Property

    Private ReadOnly myInternalCommandManager As InternalCommandManager

    Public ReadOnly Property InternalCommandManager As InternalCommandManager
        Get
            Return myInternalCommandManager
        End Get
    End Property

    Private ReadOnly myChatter As IChatter

    Public ReadOnly Property Chatter As IChatter Implements IClient(Of Player).Chatter
        Get
            Return myChatter
        End Get
    End Property

    Private ReadOnly myCommandManager As ICommandManager

    Public ReadOnly Property CommandManager As ICommandManager Implements IClient(Of Player).CommandManager
        Get
            Return myCommandManager
        End Get
    End Property

    Private ReadOnly myPlayerManager As IPlayerManager(Of Player)

    Public ReadOnly Property PlayerManager As IPlayerManager(Of Player) Implements IClient(Of Player).PlayerManager
        Get
            Return myPlayerManager
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(commandChar As Char)
        'Creating instances
        myPluginManager = New PluginManager(New ClientCloneCloneFactory(Me))
        myConnection = New Connection(Me)
        myWorld = New World(Me)
        myUploader = New Uploader(Me)
        myGame = New Game(Me)
        myKeyManager = New KeyManager(Me)

        myInternalChatter = New InternalChatter(Me)
        myInternalPlayerManager = New InternalPlayerManager(Me)
        myInternalCommandManager = New InternalCommandManager(Me, commandChar)

        myChatter = New Chatter(myInternalChatter, "Bot")
        myPlayerManager = New PlayerManager(Of Player)(Me)
        myCommandManager = New CommandManager(Of Player)(Me, myInternalCommandManager)
    End Sub

#End Region
End Class
