﻿Public Class CloudConnection
#Region "Events"
    Public Event OnMessage(sender As Object, e As OnMessageEventArgs)
    Public Event OnJoin(sender As Object, e As EventArgs)
    Public Event OnDisconnect(sender As Object, e As EventArgs)
#End Region

#Region "Properties"
    Private m_Connection As PlayerIOClient.Connection
    Public ReadOnly Property Connection As PlayerIOClient.Connection
        Get
            Return m_Connection
        End Get
    End Property

    Private ReadOnly m_WorldID As String
    Public ReadOnly Property WorldID As String
        Get
            Return m_WorldID
        End Get
    End Property
#End Region

    Sub New(PConnection As PlayerIOClient.Connection, PWorldID As String)
        RegisterMessages()

        m_Connection = PConnection
        m_WorldID = PWorldID

        m_Connection.AddOnDisconnect(Sub() RaiseEvent OnDisconnect(Me, New EventArgs))
        m_Connection.AddOnMessage(AddressOf MessageReciver)
        RaiseEvent OnJoin(Me, New EventArgs)
    End Sub

    Private Sub MessageHandler(sender As Object, e As OnMessageEventArgs) Handles Me.OnMessage

    End Sub

    Private Sub MessageReciver(sender As Object, e As PlayerIOClient.Message)
        Try
            Dim myRegisteredMessageInfo As RegisteredMessageInfo = MessageDictionary(e.Type)
            Dim myMessage As Message = CType(Activator.CreateInstance(myRegisteredMessageInfo.Message, e), Message)
            Dim myEventArgs As New OnMessageEventArgs(myRegisteredMessageInfo.Type, myMessage)
            RaiseEvent OnMessage(Me, myEventArgs)
        Catch ex As KeyNotFoundException
            Throw New KeyNotFoundException(String.Format("Message is not registered: {0}", e.Type))
        End Try
    End Sub

#Region "Message Register"
    Private RegisteredMessages As Boolean
    Private Sub RegisterMessages()
        If RegisteredMessages = False Then
            RegisteredMessages = True
            RegisterMessage("groupdisallowedjoin", MessageType.GroupDisallowedJoin, GetType(GroupDisallowedJoin_Message))
            RegisterMessage("upgrade", MessageType.Upgrade, GetType(Upgrade_Message))
            RegisterMessage("info", MessageType.Info, GetType(Info_Message))
            RegisterMessage("init", MessageType.Init, GetType(Init_Message))
            RegisterMessage("updatemeta", MessageType.UpdateMeta, GetType(UpdateMeta_Message))
            RegisterMessage("add", MessageType.Add, GetType(Add_Message))
            RegisterMessage("left", MessageType.Left, GetType(Left_Message))
            RegisterMessage("m", MessageType.Move, GetType(Move_Message))
            RegisterMessage("c", MessageType.Coin, GetType(Coin_Message))
            RegisterMessage("k", MessageType.Crown, GetType(Crown_Message))
            RegisterMessage("ks", MessageType.SilverCrown, GetType(SilverCrown_Message))
            RegisterMessage("face", MessageType.Face, GetType(Face_Message))
            RegisterMessage("show", MessageType.ShowKey, GetType(ShowKey_Message))
            RegisterMessage("hide", MessageType.HideKey, GetType(HideKey_Message))
            RegisterMessage("say", MessageType.Say, GetType(Say_Message))
            RegisterMessage("say_old", MessageType.SayOld, GetType(SayOld_Message))
            RegisterMessage("autotext", MessageType.AutoText, GetType(AutoText_Message))
            RegisterMessage("write", MessageType.Write, GetType(Write_Message))
            RegisterMessage("b", MessageType.BlockPlace, GetType(BlockPlace_Message))
            RegisterMessage("bc", MessageType.CoinDoorPlace, GetType(CoinDoorPlace_Message))
            RegisterMessage("bs", MessageType.SoundPlace, GetType(SoundPlace_Message))
            RegisterMessage("pt", MessageType.PortalPlace, GetType(PortalPlace_Message))
            RegisterMessage("lb", MessageType.LabelPlace, GetType(LabelPlace_Message))
            RegisterMessage("god", MessageType.Godmode, GetType(Godmode_Message))
            RegisterMessage("mod", MessageType.Modmode, GetType(Modmode_Message))
            RegisterMessage("access", MessageType.Access, GetType(Access_Message))
            RegisterMessage("lostaccess", MessageType.LostAccess, GetType(LostAccess_Message))
            RegisterMessage("tele", MessageType.Teleport, GetType(Teleport_Message))
            RegisterMessage("reset", MessageType.Reset, GetType(Reset_Message))
            RegisterMessage("clear", MessageType.Clear, GetType(Clear_Message))
            RegisterMessage("saved", MessageType.SaveDone, GetType(SaveDone_Message))
            RegisterMessage("refreshshop", MessageType.RefreshShop, GetType(RefreshShop_Message))
            RegisterMessage("givewizard", MessageType.GiveWizard, GetType(GiveWizard_Message))
            RegisterMessage("givewizard2", MessageType.GiveWizard2, GetType(GiveWizard2_Message))
            RegisterMessage("givewitch", MessageType.GiveWitch, GetType(GiveWitch_Message))
            RegisterMessage("givegrinch", MessageType.GiveGrinch, GetType(GiveGrinch_Message))
        End If
    End Sub

    Private MessageDictionary As New Dictionary(Of String, RegisteredMessageInfo)
    Public Sub RegisterMessage(PString As String, PType As MessageType, PMessage As Type)
        If MessageDictionary.ContainsKey(PString) Then
            Throw New InvalidOperationException("Message ID already registered")
        ElseIf Not PMessage.IsSubclassOf(GetType(Message)) Then
            Throw New InvalidOperationException("Invalid message class! Must inherit EECloudAPI.Messages.Message")
        Else
            MessageDictionary.Add(PString, New RegisteredMessageInfo(PType, PMessage))
        End If
    End Sub
#End Region
End Class
