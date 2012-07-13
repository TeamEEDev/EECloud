Imports EECloudAPI.EECloudAPI.Messages

Public MustInherit Class CloudClient
    Public LockObject As Object
#Region "Events"
    Public Class OnMessageEventArgs
        Inherits EventArgs

        Public Sub New(PMessage As Message)
            Message = PMessage
        End Sub

        Public Type As MessageType
        Public Message As Message
    End Class

    Public Event OnMessage(sender As Object, e As OnMessageEventArgs)
    Public Event OnJoin(sender As Object, e As EventArgs)
    Public Event OnDisconnect(sender As Object, e As EventArgs)
#End Region

#Region "Methods"
    Private Connected As Boolean
    Public Sub Connect()
        SyncLock LockObject
            If Not Connected Then
                Connected = True
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
            End If
        End SyncLock
    End Sub

    Public Sub MessageHandler(sender As Object, e As OnMessageEventArgs) Handles Me.OnMessage
        If e.Type = MessageType.Init Then
            Dim Message As Init_Message = e.Message
            'TODO: Load the world
        End If
    End Sub

    Private MessageDictionary As Dictionary(Of String, RegisteredMessageInfo)
    Private Sub RegisterMessage(PString As String, PType As MessageType, PMessage As Type)
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
