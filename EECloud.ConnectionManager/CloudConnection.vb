<Export(GetType(PluginAPI.IConnection))>
Public Class CloudConnection
    Implements IConnection

    Public Event OnDisconnect(sender As Object, e As EventArgs) Implements IConnection.OnDisconnect

    Public Event OnJoin(sender As Object, e As EventArgs) Implements IConnection.OnJoin

    Public Event OnJoinError(sender As Object, e As EventArgs) Implements IConnection.OnJoinError

    Public Event OnMessage(sender As Object, e As OnMessageEventArgs) Implements IConnection.OnMessage

#Region "Properties"
    Private m_Connection As PlayerIOClient.Connection
    Public ReadOnly Property Connection As PlayerIOClient.Connection Implements IConnection.Connection
        Get
            Return m_Connection
        End Get
    End Property

    Private ReadOnly m_WorldID As String
    Public ReadOnly Property WorldID As String Implements IConnection.WorldID
        Get
            Return m_WorldID
        End Get
    End Property

    <Import()>
    Friend m_Components As IComponentManager
    Public ReadOnly Property Components As IComponentManager Implements IConnection.Components
        Get
            Return m_Components
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
            Throw New ArgumentException("PConnection cannot be null.")
        End If
    End Sub

    Sub New(PClient As PlayerIOClient.Client, PWorldID As String)
        If PClient IsNot Nothing Then
            m_Connection = PClient.Multiplayer.JoinRoom(PWorldID, Nothing)
            m_WorldID = PWorldID
            Init()
        Else
            Throw New ArgumentException("PClient cannot be null.")
        End If
    End Sub

    Sub New(PUsername As String, PPassword As String, PWorldID As String)
        Dim myClient As PlayerIOClient.Client = PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(GameID, PUsername, PPassword)
        m_Connection = myClient.Multiplayer.JoinRoom(PWorldID, Nothing)
        m_WorldID = PWorldID
        Init()
    End Sub

    Private Sub Init()
        RegisterMessages()
        m_Connection.AddOnDisconnect(Sub() RaiseEvent OnDisconnect(Me, New EventArgs))
        m_Connection.AddOnMessage(AddressOf MessageReciver)
        RaiseEvent OnJoin(Me, New EventArgs)
        m_Connection.Send("init")
    End Sub
#End Region

#Region "Message Handling"
    Private Sub MessageHandler(sender As Object, e As OnMessageEventArgs) Handles Me.OnMessage
        If e.Type = ReciveType.Init Then
            Dim m As Recive.Init_ReciveMessage = CType(e.Message, Recive.Init_ReciveMessage)
            Connection.Send("init2")
        End If
    End Sub

    Private Sub MessageReciver(sender As Object, e As PlayerIOClient.Message)
        Try
            Dim myRegisteredMessageInfo As RegisteredMessageInfo = MessageDictionary(e.Type)
            Dim myMessage As Recive.ReciveMessage = CType(Activator.CreateInstance(myRegisteredMessageInfo.Message, e), Recive.ReciveMessage)
            Dim myEventArgs As New OnMessageEventArgs(myRegisteredMessageInfo.Type, myMessage)
            RaiseEvent OnMessage(Me, myEventArgs)
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
            RegisterMessage("groupdisallowedjoin", ReciveType.GroupDisallowedJoin, GetType(Recive.GroupDisallowedJoin_ReciveMessage))
            RegisterMessage("upgrade", ReciveType.Upgrade, GetType(Recive.Upgrade_ReciveMessage))
            RegisterMessage("info", ReciveType.Info, GetType(Recive.Info_ReciveMessage))
            RegisterMessage("init", ReciveType.Init, GetType(Recive.Init_ReciveMessage))
            RegisterMessage("updatemeta", ReciveType.UpdateMeta, GetType(Recive.UpdateMeta_ReciveMessage))
            RegisterMessage("add", ReciveType.Add, GetType(Recive.Add_ReciveMessage))
            RegisterMessage("left", ReciveType.Left, GetType(Recive.Left_ReciveMessage))
            RegisterMessage("m", ReciveType.Move, GetType(Recive.Move_ReciveMessage))
            RegisterMessage("c", ReciveType.Coin, GetType(Recive.Coin_ReciveMessage))
            RegisterMessage("k", ReciveType.Crown, GetType(Recive.Crown_ReciveMessage))
            RegisterMessage("ks", ReciveType.SilverCrown, GetType(Recive.SilverCrown_ReciveMessage))
            RegisterMessage("face", ReciveType.Face, GetType(Recive.Face_ReciveMessage))
            RegisterMessage("show", ReciveType.ShowKey, GetType(Recive.ShowKey_ReciveMessage))
            RegisterMessage("hide", ReciveType.HideKey, GetType(Recive.HideKey_ReciveMessage))
            RegisterMessage("say", ReciveType.Say, GetType(Recive.Say_ReciveMessage))
            RegisterMessage("say_old", ReciveType.SayOld, GetType(Recive.SayOld_ReciveMessage))
            RegisterMessage("autotext", ReciveType.AutoText, GetType(Recive.AutoText_ReciveMessage))
            RegisterMessage("write", ReciveType.Write, GetType(Recive.Write_ReciveMessage))
            RegisterMessage("b", ReciveType.BlockPlace, GetType(Recive.BlockPlace_ReciveMessage))
            RegisterMessage("bc", ReciveType.CoinDoorPlace, GetType(Recive.CoinDoorPlace_ReciveMessage))
            RegisterMessage("bs", ReciveType.SoundPlace, GetType(Recive.SoundPlace_ReciveMessage))
            RegisterMessage("pt", ReciveType.PortalPlace, GetType(Recive.PortalPlace_ReciveMessage))
            RegisterMessage("lb", ReciveType.LabelPlace, GetType(Recive.LabelPlace_ReciveMessage))
            RegisterMessage("god", ReciveType.Godmode, GetType(Recive.Godmode_ReciveMessage))
            RegisterMessage("mod", ReciveType.Modmode, GetType(Recive.Modmode_ReciveMessage))
            RegisterMessage("access", ReciveType.Access, GetType(Recive.Access_ReciveMessage))
            RegisterMessage("lostaccess", ReciveType.LostAccess, GetType(Recive.LostAccess_ReciveMessage))
            RegisterMessage("tele", ReciveType.Teleport, GetType(Recive.Teleport_ReciveMessage))
            RegisterMessage("reset", ReciveType.Reset, GetType(Recive.Reset_ReciveMessage))
            RegisterMessage("clear", ReciveType.Clear, GetType(Recive.Clear_ReciveMessage))
            RegisterMessage("saved", ReciveType.SaveDone, GetType(Recive.SaveDone_ReciveMessage))
            RegisterMessage("refreshshop", ReciveType.RefreshShop, GetType(Recive.RefreshShop_ReciveMessage))
            RegisterMessage("givewizard", ReciveType.GiveWizard, GetType(Recive.GiveWizard_ReciveMessage))
            RegisterMessage("givewizard2", ReciveType.GiveFireWizard, GetType(Recive.GiveFireWizard_ReciveMessage))
            RegisterMessage("givewitch", ReciveType.GiveWitch, GetType(Recive.GiveWitch_ReciveMessage))
            RegisterMessage("givegrinch", ReciveType.GiveGrinch, GetType(Recive.GiveGrinch_ReciveMessage))
        End If
    End Sub

    Private MessageDictionary As New Dictionary(Of String, RegisteredMessageInfo)
    Private Sub RegisterMessage(PString As String, PType As ReciveType, PMessage As Type)
        If MessageDictionary.ContainsKey(PString) Then
            Throw New InvalidOperationException("Message ID already registered")
        ElseIf Not PMessage.IsSubclassOf(GetType(Recive.ReciveMessage)) Then
            Throw New InvalidOperationException("Invalid message class! Must inherit " & GetType(Recive.ReciveMessage).ToString)
        Else
            MessageDictionary.Add(PString, New RegisteredMessageInfo(PType, PMessage))
        End If
    End Sub
#End Region
#End Region
End Class
