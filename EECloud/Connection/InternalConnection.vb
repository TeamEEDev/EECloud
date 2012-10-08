﻿Imports PlayerIOClient
Imports System.Reflection

Friend NotInheritable Class InternalConnection
    Inherits ConnectionBase(Of Player)

#Region "Fields"
    Private WithEvents myConnection As Connection
    Private ReadOnly myMessageDictionary As New Dictionary(Of String, Type)
    Private myExpectingDisconnect As Boolean
#End Region

#Region "Properties"

    Friend Overrides ReadOnly Property Connected As Boolean
        Get
            If myConnection IsNot Nothing Then
                Return myConnection.Connected
            Else
                Return False
            End If
        End Get
    End Property

    Private myWorldID As String

    Friend Overrides ReadOnly Property WorldID As String
        Get
            Return myWorldID
        End Get
    End Property

    Private myWorld As IWorld

    Friend Overrides ReadOnly Property World As IWorld
        Get
            Return myWorld
        End Get
    End Property

    Private ReadOnly myPluginManager As IPluginManager

    Friend Overrides ReadOnly Property PluginManager As IPluginManager
        Get
            Return myPluginManager
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

    Friend Overrides ReadOnly Property Chatter As IChatter
        Get
            Return myChatter
        End Get
    End Property

    Private ReadOnly myPlayerManager As PlayerManager(Of Player)

    Friend Overrides ReadOnly Property PlayerManager As IPlayerManager(Of Player)
        Get
            Return myPlayerManager
        End Get
    End Property

    Private myCommandManager As ICommandManager

    Public Overrides ReadOnly Property CommandManager As ICommandManager
        Get
            Return myCommandManager
        End Get
    End Property

#End Region

#Region "Events"
    Friend Event OnInternalDisconnect(sender As Object, e As DisconnectEventArgs)
    Friend Event OnInternalDisconnecting(sender As Object, e As EventArgs)
    Friend Event OnInternalMessage(sender As Object, e As ReceiveMessage)
#End Region

#Region "Methods"

    Friend Sub New()
        myCommandManager = CommandManager
        'Setting variables
        InternalConnection = Me

        'Creating instances
        myPluginManager = New PluginManager(New ConnectionFactory(Me))
        myInternalChatter = New InternalChatter(Me)
        myInternalPlayerManager = New InternalPlayerManager(Me)
        myInternalCommandManager = New InternalCommandManager(Me)
        myChatter = New Chatter(myInternalChatter, "Bot")
        myPlayerManager = New PlayerManager(Of Player)(myInternalPlayerManager, Me, myChatter)
        myCommandManager = New CommandManager(Of Player)(Me, myInternalCommandManager)
    End Sub

    Friend Sub SetupConnection(pconnection As Connection, id As String)
        'Setting variables
        myConnection = pconnection
        myWorldID = id

        'Registering messages
        RegisterMessage("groupdisallowedjoin", GetType(GroupDisallowedJoinReceiveMessage))
        RegisterMessage("info", GetType(InfoReceiveMessage))
        RegisterMessage("upgrade", GetType(UpgradeReceiveMessage))
        RegisterMessage("init", GetType(InitReceiveMessage))

        'Initing connection
        Send(New InitSendMessage)
    End Sub

    Private Async Sub MessageHandler(sender As Object, e As ReceiveMessage) Handles Me.OnInternalMessage
        Select Case e.GetType
            Case GetType(InitReceiveMessage)
                Dim m As InitReceiveMessage = CType(e, InitReceiveMessage)
                myWorld = New World(Me, m)

                UnRegisterMessage("init")
                UnRegisterMessage("groupdisallowedjoin")
                RegisterMessages()
                Send(New Init2SendMessage)
            Case GetType(UpgradeReceiveMessage)
                ConnectionHandle.GameVersionNumber += 1
                Cloud.Logger.Log(LogPriority.Info, "The game has been updated!")
                Await Cloud.Service.SetSettingAsync("GameVersion", CStr(ConnectionHandle.GameVersionNumber))
        End Select
    End Sub

    Friend Overrides Sub Send(message As SendMessage)
        If myConnection IsNot Nothing Then
            myConnection.Send(message.GetMessage(World))
        End If
    End Sub

    Friend Sub Close()
        If myConnection IsNot Nothing Then
            RaiseEvent OnInternalDisconnecting(Me, EventArgs.Empty)
            myConnection.Disconnect()
        End If
    End Sub

    Private myRegisteredMessages As Boolean

    Private Sub RegisterMessages()
        If myRegisteredMessages = False Then
            myRegisteredMessages = True
            RegisterMessage("updatemeta", GetType(UpdateMetaReceiveMessage))
            RegisterMessage("add", GetType(AddReceiveMessage))
            RegisterMessage("left", GetType(LeftReceiveMessage))
            RegisterMessage("m", GetType(MoveReceiveMessage))
            RegisterMessage("c", GetType(CoinReceiveMessage))
            RegisterMessage("k", GetType(CrownReceiveMessage))
            RegisterMessage("ks", GetType(SilverCrownReceiveMessage))
            RegisterMessage("face", GetType(FaceReceiveMessage))
            RegisterMessage("show", GetType(ShowKeyReceiveMessage))
            RegisterMessage("hide", GetType(HideKeyReceiveMessage))
            RegisterMessage("say", GetType(SayReceiveMessage))
            RegisterMessage("say_old", GetType(SayOld_ReceiveMessage))
            RegisterMessage("autotext", GetType(AutoTextReceiveMessage))
            RegisterMessage("write", GetType(WriteReceiveMessage))
            RegisterMessage("b", GetType(BlockPlaceReceiveMessage))
            RegisterMessage("bc", GetType(CoinDoorPlace_ReceiveMessage))
            RegisterMessage("bs", GetType(SoundPlaceReceiveMessage))
            RegisterMessage("pt", GetType(PortalPlaceReceiveMessage))
            RegisterMessage("lb", GetType(LabelPlaceReceiveMessage))
            RegisterMessage("god", GetType(GodModeReceiveMessage))
            RegisterMessage("mod", GetType(ModModeReceiveMessage))
            RegisterMessage("access", GetType(AccessReceiveMessage))
            RegisterMessage("lostaccess", GetType(LostAccessReceiveMessage))
            RegisterMessage("tele", GetType(TeleportReceiveMessage))
            RegisterMessage("reset", GetType(ResetReceiveMessage))
            RegisterMessage("clear", GetType(ClearReceiveMessage))
            RegisterMessage("saved", GetType(SaveDoneReceiveMessage))
            RegisterMessage("refreshshop", GetType(RefreshShopReceiveMessage))
            RegisterMessage("givewizard", GetType(GiveWizardReceiveMessage))
            RegisterMessage("givewizard2", GetType(GiveFireWizardReceiveMessage))
            RegisterMessage("givewitch", GetType(GiveWitchReceiveMessage))
            RegisterMessage("givegrinch", GetType(GiveGrinchReceiveMessage))
        End If
    End Sub

    Private Sub myConnection_OnDisconnect(sender As Object, message As String) Handles myConnection.OnDisconnect
        UnRegisterAll()
        RaiseEvent OnInternalDisconnect(Me, New DisconnectEventArgs(myExpectingDisconnect))
        myExpectingDisconnect = False
    End Sub

    Private Sub myConnection_OnMessage(sender As Object, e As Message) Handles myConnection.OnMessage
        Try
            If myMessageDictionary.ContainsKey(e.Type) Then
                Dim messageType As Type = myMessageDictionary(e.Type)
                Dim constructorInfo As ConstructorInfo = messageType.GetConstructor(BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, New Type() {GetType(Message)}, Nothing)
                Dim message As ReceiveMessage = CType(constructorInfo.Invoke(New Object() {e}), ReceiveMessage)
                RaiseEvent OnInternalMessage(Me, message)
            Else
                Cloud.Logger.Log(LogPriority.Warning, "Received not registered message: " & e.Type)
            End If
        Catch ex As KeyNotFoundException
            Cloud.Logger.Log(LogPriority.Error, "Failed to parse message: " & e.Type)
            Cloud.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled: {1} {2}", ex.ToString, ex.Message, ex.StackTrace))
        End Try
    End Sub

    Private Sub RegisterMessage(str As String, type As Type)
        Try
            If Not type.IsSubclassOf(GetType(ReceiveMessage)) Then
                Throw New InvalidOperationException("Invalid message class! Must inherit " & GetType(ReceiveMessage).ToString)
            Else
                myMessageDictionary.Add(str, type)
            End If
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to register message: " & str)
        End Try
    End Sub

    Private Sub UnRegisterMessage(pString As String)
        Try
            myMessageDictionary.Remove(pString)
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to unregister message: " & pString)
        End Try
    End Sub

    Private Sub UnRegisterAll()
        myRegisteredMessages = False
        myMessageDictionary.Clear()
    End Sub

#End Region
End Class
