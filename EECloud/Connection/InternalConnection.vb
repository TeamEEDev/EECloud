﻿Imports System.Reflection

Friend Class InternalConnection
#Region "Fields"
    Private myConnection As PlayerIOClient.Connection
#End Region

#Region "Properties"
    Friend ReadOnly Property Connected As Boolean
        Get
            If myConnection IsNot Nothing Then
                Return myConnection.Connected
            Else
                Return False
            End If
        End Get
    End Property

    Private myWorldID As String
    Friend ReadOnly Property WorldID As String
        Get
            Return myWorldID
        End Get
    End Property

    Private myWorld As World
    Friend ReadOnly Property World As World
        Get
            Return myWorld
        End Get
    End Property

    Private myDefaultConnection As New Connection(Of Player)(Me, New Chatter(myInternalChatter, "Bot"))
    Friend ReadOnly Property DefaultConnection As Connection(Of Player)
        Get
            Return myDefaultConnection
        End Get
    End Property

    Private myInternalChatter As New InternalChatter(Me.DefaultConnection)
    Friend ReadOnly Property InternalChatter As InternalChatter
        Get
            Return myInternalChatter
        End Get
    End Property

    Private myPluginManager As IPluginManager = New PluginManager
    Public ReadOnly Property PluginManager As IPluginManager
        Get
            Return myPluginManager
        End Get
    End Property
#End Region

#Region "Events"
    Friend Event OnDisconnect(sender As Object, e As String)
    Friend Event OnMessage(sender As Object, e As ReceiveMessage)
#End Region

#Region "Methods"
    Friend Sub New(PConnection As PlayerIOClient.Connection, PWorldID As String)
        myConnection = PConnection
        myWorldID = PWorldID

        myConnection.AddOnMessage(AddressOf MessageReceiver)
        myConnection.AddOnDisconnect(
            Sub(sender As Object, message As String)
                RaiseEvent OnDisconnect(Me, message)
            End Sub)
        If Not myConnection.Connected Then 'Just in case we are too late to catch the error
            RaiseEvent OnDisconnect(Me, "")
        End If


        RegisterMessage("groupdisallowedjoin", GetType(GroupDisallowedJoin_ReceiveMessage))
        RegisterMessage("info", GetType(Info_ReceiveMessage))
        RegisterMessage("upgrade", GetType(Upgrade_ReceiveMessage))
        RegisterMessage("init", GetType(Init_ReceiveMessage))
        Send(New Init_SendMessage)
    End Sub

    Private Sub MessageHandler(sender As Object, e As ReceiveMessage) Handles Me.OnMessage
        Select Case e.GetType
            Case GetType(Init_ReceiveMessage)
                Dim m As Init_ReceiveMessage = CType(e, Init_ReceiveMessage)
                myWorld = New World(Me.DefaultConnection, m)

                UnRegisterMessage("init")
                UnRegisterMessage("groupdisallowedjoin")
                RegisterMessages()
                Send(New Init2_SendMessage)
            Case GetType(Upgrade_ReceiveMessage)
                Dim m As Upgrade_ReceiveMessage = CType(e, Upgrade_ReceiveMessage)

                ConnectionHandle.myGameVersionSetting += 1
                Cloud.Logger.Log(LogPriority.Info, "The game has been updated!")
        End Select
    End Sub

    Private Sub MessageReceiver(sender As Object, e As PlayerIOClient.Message)
        Try
            If MessageDictionary.ContainsKey(e.Type) Then
                Dim messageType As Type = MessageDictionary(e.Type)
                Dim myConstructorInfo As ConstructorInfo = messageType.GetConstructor(BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, New Type() {GetType(PlayerIOClient.Message)}, Nothing)
                Dim myMessage As ReceiveMessage = CType(myConstructorInfo.Invoke(New Object() {e}), ReceiveMessage)
                RaiseEvent OnMessage(Me, myMessage)
            Else
                Cloud.Logger.Log(LogPriority.Warning, "Received not registered message: " & e.Type)
            End If
        Catch ex As KeyNotFoundException
            Cloud.Logger.Log(LogPriority.Error, "Failed to parse message: " & e.Type)
            Cloud.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled: {1} {2}", ex.ToString, ex.Message, ex.StackTrace))
        End Try
    End Sub

    Friend Sub Send(PMessage As SendMessage)
        If myConnection IsNot Nothing Then
            myConnection.Send(PMessage.GetMessage(Me.DefaultConnection))
        End If
    End Sub

    Friend Sub Disconnect()
        If myConnection IsNot Nothing Then
            myConnection.Disconnect()
        End If
    End Sub

    Private RegisteredMessages As Boolean
    Private Sub RegisterMessages()
        If RegisteredMessages = False Then
            RegisteredMessages = True
            RegisterMessage("updatemeta", GetType(UpdateMeta_ReceiveMessage))
            RegisterMessage("add", GetType(Add_ReceiveMessage))
            RegisterMessage("left", GetType(Left_ReceiveMessage))
            RegisterMessage("m", GetType(Move_ReceiveMessage))
            RegisterMessage("c", GetType(Coin_ReceiveMessage))
            RegisterMessage("k", GetType(Crown_ReceiveMessage))
            RegisterMessage("ks", GetType(SilverCrown_ReceiveMessage))
            RegisterMessage("face", GetType(Face_ReceiveMessage))
            RegisterMessage("show", GetType(ShowKey_ReceiveMessage))
            RegisterMessage("hide", GetType(HideKey_ReceiveMessage))
            RegisterMessage("say", GetType(Say_ReceiveMessage))
            RegisterMessage("say_old", GetType(SayOld_ReceiveMessage))
            RegisterMessage("autotext", GetType(AutoText_ReceiveMessage))
            RegisterMessage("write", GetType(Write_ReceiveMessage))
            RegisterMessage("b", GetType(BlockPlace_ReceiveMessage))
            RegisterMessage("bc", GetType(CoinDoorPlace_ReceiveMessage))
            RegisterMessage("bs", GetType(SoundPlace_ReceiveMessage))
            RegisterMessage("pt", GetType(PortalPlace_ReceiveMessage))
            RegisterMessage("lb", GetType(LabelPlace_ReceiveMessage))
            RegisterMessage("god", GetType(GodMode_ReceiveMessage))
            RegisterMessage("mod", GetType(ModMode_ReceiveMessage))
            RegisterMessage("access", GetType(Access_ReceiveMessage))
            RegisterMessage("lostaccess", GetType(LostAccess_ReceiveMessage))
            RegisterMessage("tele", GetType(Teleport_ReceiveMessage))
            RegisterMessage("reset", GetType(Reset_ReceiveMessage))
            RegisterMessage("clear", GetType(Clear_ReceiveMessage))
            RegisterMessage("saved", GetType(SaveDone_ReceiveMessage))
            RegisterMessage("refreshshop", GetType(RefreshShop_ReceiveMessage))
            RegisterMessage("givewizard", GetType(GiveWizard_ReceiveMessage))
            RegisterMessage("givewizard2", GetType(GiveFireWizard_ReceiveMessage))
            RegisterMessage("givewitch", GetType(GiveWitch_ReceiveMessage))
            RegisterMessage("givegrinch", GetType(GiveGrinch_ReceiveMessage))
        End If
    End Sub

    Private MessageDictionary As New Dictionary(Of String, Type)
    Private Sub RegisterMessage(PString As String, PType As Type)
        Try
            If Not PType.IsSubclassOf(GetType(ReceiveMessage)) Then
                Throw New InvalidOperationException("Invalid message class! Must inherit " & GetType(ReceiveMessage).ToString)
            Else
                MessageDictionary.Add(PString, PType)
            End If
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to register message: " & PString)
        End Try
    End Sub

    Private Sub UnRegisterMessage(PString As String)
        Try
            MessageDictionary.Remove(PString)
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to unregister message: " & PString)
        End Try
    End Sub
#End Region
End Class
