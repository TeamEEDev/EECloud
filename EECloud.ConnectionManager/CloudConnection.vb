<Export(GetType(PluginAPI.IConnection))>
Public Class CloudConnection
    Implements IConnection

#Region "Events"
    Public Event OnMessage(sender As Object, e As OnMessageEventArgs) Implements IConnection.OnMessage
    Public Event OnDisconnect(sender As Object, e As EventArgs) Implements IConnection.OnDisconnect
#End Region

#Region "Fields"
    Private m_ConnectionManager As IConnectionManager
    Private m_Connection As PlayerIOClient.Connection
#End Region

#Region "Properties"
    Private m_WorldID As String
    Public ReadOnly Property WorldID As String Implements IConnection.WorldID
        Get
            Return m_WorldID
        End Get
    End Property

    Public ReadOnly Property Connected As Boolean Implements IConnection.Connected
        Get
            Return m_Connection.Connected
        End Get
    End Property

    <Import(AllowDefault:=True)>
    Private m_BlockManager As IBlockManager
    Public ReadOnly Property BlockManager As IBlockManager Implements IConnection.BlockManager
        Get
            Return m_BlockManager
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub AttemptSetup(PConnectionManager As CloudConnectionManager, PConnection As PlayerIOClient.Connection, PWorldID As String)
        If PConnection IsNot Nothing Then
            m_Connection = PConnection
            m_WorldID = PWorldID

            m_Connection.AddOnDisconnect(Sub() RaiseEvent OnDisconnect(Me, New EventArgs))
            m_Connection.AddOnMessage(AddressOf MessageReciver)

            m_ConnectionManager = PConnectionManager

            RegisterMessage("init", GetType(Init_ReciveMessage))
            Send(New Init_SendMessage)
        Else
            Throw New ArgumentException("PConnection cannot be null.")
        End If
    End Sub

    Private Sub MessageHandler(sender As Object, e As OnMessageEventArgs) Handles Me.OnMessage
        If e.Type = GetType(Init_ReciveMessage) Then
            Dim m As Init_ReciveMessage = CType(e.Message, Init_ReciveMessage)
            RegisterMessages()
            Send(New Init2_SendMessage)
        End If
    End Sub

    Private Sub MessageReciver(sender As Object, e As PlayerIOClient.Message)
        Try
            Dim messageType As Type = MessageDictionary(e.Type)

            Dim myMessage As ReciveMessage = CType(Activator.CreateInstance(messageType, e), ReciveMessage)
            Dim myEventArgs As New OnMessageEventArgs(myMessage)

            RaiseEvent OnMessage(Me, myEventArgs)
        Catch ex As KeyNotFoundException
            m_ConnectionManager.LogManager.Log(LogPriority.Warning, "Recived not registered message: " & e.Type)
        End Try
    End Sub

    Public Sub Send(PMessage As SendMessage) Implements IConnection.Send
        m_Connection.Send(PMessage.GetMessage(Me))
    End Sub

    Public Sub Disconnect() Implements IConnection.Disconnect
        m_Connection.Disconnect()
    End Sub

    Private RegisteredMessages As Boolean
    Private Sub RegisterMessages()
        If RegisteredMessages = False Then
            RegisteredMessages = True
            RegisterMessage("groupdisallowedjoin", GetType(GroupDisallowedJoin_ReciveMessage))
            RegisterMessage("upgrade", GetType(Upgrade_ReciveMessage))
            RegisterMessage("info", GetType(Info_ReciveMessage))
            'RegisterMessage("init",  GetType(Init_ReciveMessage)) 'Already registered at Init()
            RegisterMessage("updatemeta", GetType(UpdateMeta_ReciveMessage))
            RegisterMessage("add", GetType(Add_ReciveMessage))
            RegisterMessage("left", GetType(Left_ReciveMessage))
            RegisterMessage("m", GetType(Move_ReciveMessage))
            RegisterMessage("c", GetType(Coin_ReciveMessage))
            RegisterMessage("k", GetType(Crown_ReciveMessage))
            RegisterMessage("ks", GetType(SilverCrown_ReciveMessage))
            RegisterMessage("face", GetType(Face_ReciveMessage))
            RegisterMessage("show", GetType(ShowKey_ReciveMessage))
            RegisterMessage("hide", GetType(HideKey_ReciveMessage))
            RegisterMessage("say", GetType(Say_ReciveMessage))
            RegisterMessage("say_old", GetType(SayOld_ReciveMessage))
            RegisterMessage("autotext", GetType(AutoText_ReciveMessage))
            RegisterMessage("write", GetType(Write_ReciveMessage))
            RegisterMessage("b", GetType(BlockPlace_ReciveMessage))
            RegisterMessage("bc", GetType(CoinDoorPlace_ReciveMessage))
            RegisterMessage("bs", GetType(SoundPlace_ReciveMessage))
            RegisterMessage("pt", GetType(PortalPlace_ReciveMessage))
            RegisterMessage("lb", GetType(LabelPlace_ReciveMessage))
            RegisterMessage("god", GetType(Godmode_ReciveMessage))
            RegisterMessage("mod", GetType(Modmode_ReciveMessage))
            RegisterMessage("access", GetType(Access_ReciveMessage))
            RegisterMessage("lostaccess", GetType(LostAccess_ReciveMessage))
            RegisterMessage("tele", GetType(Teleport_ReciveMessage))
            RegisterMessage("reset", GetType(Reset_ReciveMessage))
            RegisterMessage("clear", GetType(Clear_ReciveMessage))
            RegisterMessage("saved", GetType(SaveDone_ReciveMessage))
            RegisterMessage("refreshshop", GetType(RefreshShop_ReciveMessage))
            RegisterMessage("givewizard", GetType(GiveWizard_ReciveMessage))
            RegisterMessage("givewizard2", GetType(GiveFireWizard_ReciveMessage))
            RegisterMessage("givewitch", GetType(GiveWitch_ReciveMessage))
            RegisterMessage("givegrinch", GetType(GiveGrinch_ReciveMessage))
        End If
    End Sub

    Private MessageDictionary As New Dictionary(Of String, Type)
    Private Sub RegisterMessage(PString As String, PType As Type)
        If MessageDictionary.ContainsKey(PString) Then
            Throw New InvalidOperationException("Message ID already registered")
        ElseIf Not PType.IsSubclassOf(GetType(ReciveMessage)) Then
            Throw New InvalidOperationException("Invalid message class! Must inherit " & GetType(ReciveMessage).ToString)
        Else
            MessageDictionary.Add(PString, PType)
        End If
    End Sub
#End Region
End Class
