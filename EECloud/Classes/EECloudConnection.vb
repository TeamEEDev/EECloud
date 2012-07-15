Public Class EECloudConnection
    Inherits CloudConnection

#Region "Properties"
    Private m_Connection As PlayerIOClient.Connection
    Public Overrides ReadOnly Property Connection As PlayerIOClient.Connection
        Get
            Return m_Connection
        End Get
    End Property

    Private ReadOnly m_WorldID As String
    Public Overrides ReadOnly Property WorldID As String
        Get
            Return m_WorldID
        End Get
    End Property
#End Region

#Region "Methods"
#Region "Instance Creation"
    Sub New(PConnection As PlayerIOClient.Connection, PWorldID As String)
        If PConnection IsNot Nothing Then
            m_Connection = PConnection
            m_WorldID = PWorldID
            Init()
        Else
            Throw New NullReferenceException("PConnection cannot be null.")
        End If
    End Sub

    Sub New(PClient As PlayerIOClient.Client, PWorldID As String)
        If PClient IsNot Nothing Then
            m_Connection = PClient.Multiplayer.JoinRoom(PWorldID, Nothing)
            m_WorldID = PWorldID
            Init()
        Else
            Throw New NullReferenceException("PClient cannot be null.")
        End If
    End Sub

    Sub New(PUsername As String, PPassword As String, PWorldID As String)
        Dim myClient As PlayerIOClient.Client = PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(gameID, PUsername, PPassword)
        m_Connection = myClient.Multiplayer.JoinRoom(PWorldID, Nothing)
        m_WorldID = PWorldID
        Init()
    End Sub

    Private Sub Init()
        RegisterMessages()
        m_Connection.AddOnDisconnect(Sub() RaiseOnDisconnect(New EventArgs))
        m_Connection.AddOnMessage(AddressOf MessageReciver)
        RaiseOnJoin(New EventArgs)
        m_Connection.Send("init")
    End Sub
#End Region

#Region "Message Handling"
    Private Sub MessageHandler(sender As Object, e As OnMessageEventArgs) Handles Me.OnMessage
        If e.Type = MessageType.Init Then
            Dim m As Recive.Init_ReciveMessage = CType(e.Message, Recive.Init_ReciveMessage)
            Connection.Send("init2")
        End If
    End Sub

    Private Sub MessageReciver(sender As Object, e As PlayerIOClient.Message)
        Try
            Dim myRegisteredMessageInfo As RegisteredMessageInfo = MessageDictionary(e.Type)
            Dim myMessage As Recive.ReciveMessage = CType(Activator.CreateInstance(myRegisteredMessageInfo.Message, e), Recive.ReciveMessage)
            Dim myEventArgs As New OnMessageEventArgs(myRegisteredMessageInfo.Type, myMessage)
            RaiseOnMessage(myEventArgs)
        Catch ex As KeyNotFoundException
            Throw New KeyNotFoundException(String.Format("Message is not registered: {0}", e.Type))
        End Try
    End Sub
#End Region

#Region "Message Register"
    Private RegisteredMessages As Boolean
    Private Sub RegisterMessages()
        If RegisteredMessages = False Then
            RegisteredMessages = True
            RegisterMessage("groupdisallowedjoin", MessageType.GroupDisallowedJoin, GetType(Recive.GroupDisallowedJoin_ReciveMessage))
            RegisterMessage("upgrade", MessageType.Upgrade, GetType(Recive.Upgrade_ReciveMessage))
            RegisterMessage("info", MessageType.Info, GetType(Recive.Info_ReciveMessage))
            RegisterMessage("init", MessageType.Init, GetType(Recive.Init_ReciveMessage))
            RegisterMessage("updatemeta", MessageType.UpdateMeta, GetType(Recive.UpdateMeta_ReciveMessage))
            RegisterMessage("add", MessageType.Add, GetType(Recive.Add_ReciveMessage))
            RegisterMessage("left", MessageType.Left, GetType(Recive.Left_ReciveMessage))
            RegisterMessage("m", MessageType.Move, GetType(Recive.Move_ReciveMessage))
            RegisterMessage("c", MessageType.Coin, GetType(Recive.Coin_ReciveMessage))
            RegisterMessage("k", MessageType.Crown, GetType(Recive.Crown_ReciveMessage))
            RegisterMessage("ks", MessageType.SilverCrown, GetType(Recive.SilverCrown_ReciveMessage))
            RegisterMessage("face", MessageType.Face, GetType(Recive.Face_ReciveMessage))
            RegisterMessage("show", MessageType.ShowKey, GetType(Recive.ShowKey_ReciveMessage))
            RegisterMessage("hide", MessageType.HideKey, GetType(Recive.HideKey_ReciveMessage))
            RegisterMessage("say", MessageType.Say, GetType(Recive.Say_ReciveMessage))
            RegisterMessage("say_old", MessageType.SayOld, GetType(Recive.SayOld_ReciveMessage))
            RegisterMessage("autotext", MessageType.AutoText, GetType(Recive.AutoText_ReciveMessage))
            RegisterMessage("write", MessageType.Write, GetType(Recive.Write_ReciveMessage))
            RegisterMessage("b", MessageType.BlockPlace, GetType(Recive.BlockPlace_ReciveMessage))
            RegisterMessage("bc", MessageType.CoinDoorPlace, GetType(Recive.CoinDoorPlace_ReciveMessage))
            RegisterMessage("bs", MessageType.SoundPlace, GetType(Recive.SoundPlace_ReciveMessage))
            RegisterMessage("pt", MessageType.PortalPlace, GetType(Recive.PortalPlace_ReciveMessage))
            RegisterMessage("lb", MessageType.LabelPlace, GetType(Recive.LabelPlace_ReciveMessage))
            RegisterMessage("god", MessageType.Godmode, GetType(Recive.Godmode_ReciveMessage))
            RegisterMessage("mod", MessageType.Modmode, GetType(Recive.Modmode_ReciveMessage))
            RegisterMessage("access", MessageType.Access, GetType(Recive.Access_ReciveMessage))
            RegisterMessage("lostaccess", MessageType.LostAccess, GetType(Recive.LostAccess_ReciveMessage))
            RegisterMessage("tele", MessageType.Teleport, GetType(Recive.Teleport_ReciveMessage))
            RegisterMessage("reset", MessageType.Reset, GetType(Recive.Reset_ReciveMessage))
            RegisterMessage("clear", MessageType.Clear, GetType(Recive.Clear_ReciveMessage))
            RegisterMessage("saved", MessageType.SaveDone, GetType(Recive.SaveDone_ReciveMessage))
            RegisterMessage("refreshshop", MessageType.RefreshShop, GetType(Recive.RefreshShop_ReciveMessage))
            RegisterMessage("givewizard", MessageType.GiveWizard, GetType(Recive.GiveWizard_ReciveMessage))
            RegisterMessage("givewizard2", MessageType.GiveWizard2, GetType(Recive.GiveWizard2_ReciveMessage))
            RegisterMessage("givewitch", MessageType.GiveWitch, GetType(Recive.GiveWitch_ReciveMessage))
            RegisterMessage("givegrinch", MessageType.GiveGrinch, GetType(Recive.GiveGrinch_ReciveMessage))
        End If
    End Sub

    Private MessageDictionary As New Dictionary(Of String, RegisteredMessageInfo)
    Public Overrides Sub RegisterMessage(PString As String, PType As MessageType, PMessage As Type)
        If MessageDictionary.ContainsKey(PString) Then
            Throw New InvalidOperationException("Message ID already registered")
        ElseIf Not PMessage.IsSubclassOf(GetType(Recive.ReciveMessage)) Then
            Throw New InvalidOperationException("Invalid message class! Must inherit EECloudAPI.Messages.Message")
        Else
            MessageDictionary.Add(PString, New RegisteredMessageInfo(PType, PMessage))
        End If
    End Sub
#End Region
#End Region
End Class
