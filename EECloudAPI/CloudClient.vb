Imports EECloudAPI.EECloudAPI.Messages

Public MustInherit Class CloudClient
    Public LockObject As Object
#Region "Events"
    Public Class OnMessageEventArgs
        Inherits EventArgs

        Public Sub New(PMessage As PlayerIOClient.Message)
            Message = PMessage
        End Sub

        Public Message As PlayerIOClient.Message
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
                RegisterMessage("groupdisallowedjoin", GetType(GroupDisallowedJoin_Message))
                RegisterMessage("upgrade", GetType(Upgrade_Message))
                RegisterMessage("info", GetType(Info_Message))
                RegisterMessage("init", GetType(Init_Message))
                RegisterMessage("updatemeta", GetType(UpdateMeta_Message))
                RegisterMessage("add", GetType(Add_Message))
                RegisterMessage("left", GetType(Left_Message))
                RegisterMessage("m", GetType(Move_Message))
                RegisterMessage("c", GetType(Coin_Message))
                RegisterMessage("k", GetType(Crown_Message))
                RegisterMessage("ks", GetType(SilverCrown_Message))
                RegisterMessage("face", GetType(Face_Message))
                RegisterMessage("show", GetType(ShowKey_Message))
                RegisterMessage("hide", GetType(HideKey_Message))
                RegisterMessage("say", GetType(Say_Message))
                RegisterMessage("autotext", GetType(AutoText_Message))
                RegisterMessage("write", GetType(Write_Message))
                RegisterMessage("b", GetType(BlockPlace_Message))
                RegisterMessage("bc", GetType(CoinDoorPlace_Message))
                RegisterMessage("bs", GetType(SoundPlace_Message))
                RegisterMessage("pt", GetType(PortalPlace_Message))
                RegisterMessage("lb", GetType(LabelPlace_Message))
                RegisterMessage("god", GetType(Godmode_Message))
                RegisterMessage("mod", GetType(Modmode_Message))
                RegisterMessage("access", GetType(Access_Message))
                RegisterMessage("lostaccess", GetType(LostAccess_Message))
                RegisterMessage("tele", GetType(Teleport_Message))
                RegisterMessage("reset", GetType(Reset_Message))
                RegisterMessage("clear", GetType(Clear_Message))
                RegisterMessage("saved", GetType(SaveDone_Message))
                RegisterMessage("refreshshop", GetType(RefreshShop_Message))
            End If
        End SyncLock
    End Sub


    Private MessageDictionary As Dictionary(Of String, Type)
    Private Sub RegisterMessage(PType As String, PMessage As Type)
        If MessageDictionary.ContainsKey(PType) Then
            Throw New InvalidOperationException("Message ID already registered")
        ElseIf Not PMessage.IsSubclassOf(GetType(Message)) Then
            Throw New InvalidOperationException("Invalid message class! Must inherit EECloudAPI.Messages.Message")
        Else
            MessageDictionary.Add(PType, PMessage)
        End If
    End Sub
#End Region
End Class
