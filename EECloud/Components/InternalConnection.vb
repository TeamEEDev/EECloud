Imports System.Reflection

Friend Class InternalConnection
    Inherits BaseGlobalComponent
    Implements IInternalConnection


#Region "Fields"
    Private myConnection As PlayerIOClient.Connection
#End Region

#Region "Properties"
    Private myWorldID As String
    Friend ReadOnly Property WorldID As String Implements IInternalConnection.WorldID
        Get
            Return myWorldID
        End Get
    End Property

    Private myWorld As World
    Friend ReadOnly Property World As World Implements IInternalConnection.World
        Get
            Return myWorld
        End Get
    End Property

    Friend ReadOnly Property IsMainConnection As Boolean Implements IInternalConnection.IsMainConnection
        Get
            Return Me Is myBot.Connection
        End Get
    End Property

    Friend ReadOnly Property Connected As Boolean Implements IInternalConnection.Connected
        Get
            If myConnection IsNot Nothing Then
                Return myConnection.Connected
            Else
                Return False
            End If
        End Get
    End Property

    Private myDefaultConnection As New Connection(Of Player)(myBot, Me)
    Friend ReadOnly Property DefaultConnection As Connection(Of Player) Implements IInternalConnection.DefaultConnection
        Get
            Return myDefaultConnection
        End Get
    End Property

    Private myEncryption As String
    ReadOnly Property Encryption As String Implements IInternalConnection.Encryption
        Get
            Return myEncryption
        End Get
    End Property
#End Region

#Region "Events"
    Friend Event OnDisconnect(sender As Object, e As String) Implements IInternalConnection.OnDisconnect

    Friend Event OnMessage(sender As Object, e As ReciveMessage) Implements IInternalConnection.OnMessage

    Friend Event OnAddUser(sender As Object, e As IPlayer) Implements IInternalConnection.OnAddUser

    Friend Event OnRemoveUser(sender As Object, e As Left_ReciveMessage) Implements IInternalConnection.OnRemoveUser
#End Region

#Region "Methods"
    Friend Sub New(PBot As Bot, PConnection As PlayerIOClient.Connection, PWorldID As String)
        MyBase.New(PBot)
        myConnection = PConnection
        myWorldID = PWorldID
        myBot = PBot
        myConnection.AddOnDisconnect(
            Sub(sender As Object, message As String)
                RaiseEvent OnDisconnect(Me, message)
            End Sub)
        myConnection.AddOnMessage(AddressOf MessageReciver)

        RegisterMessage("groupdisallowedjoin", GetType(GroupDisallowedJoin_ReciveMessage))
        RegisterMessage("info", GetType(Info_ReciveMessage))
        RegisterMessage("upgrade", GetType(Upgrade_ReciveMessage))
        RegisterMessage("init", GetType(Init_ReciveMessage))
        Send(New Init_SendMessage)
    End Sub

    Private Sub MessageHandler(sender As Object, e As ReciveMessage) Handles Me.OnMessage
        Select Case e.GetType
            Case GetType(Init_ReciveMessage)
                Dim m As Init_ReciveMessage = CType(e, Init_ReciveMessage)
                myWorld = New World(Me.DefaultConnection, m)

                UnRegisterMessage("init")
                UnRegisterMessage("groupdisallowedjoin")
                RegisterMessages()
                Send(New Init2_SendMessage)
            Case GetType(Add_ReciveMessage)
                Dim m As Add_ReciveMessage = CType(e, Add_ReciveMessage)
                Dim myPlayer As New InternalPlayer(Me.DefaultConnection, m)
                RaiseEvent OnAddUser(Me, myPlayer)
            Case GetType(Left_ReciveMessage)
                Dim m As Left_ReciveMessage = CType(e, Left_ReciveMessage)
                RaiseEvent OnRemoveUser(Me, m)
            Case GetType(Upgrade_ReciveMessage)
                Dim m As Upgrade_ReciveMessage = CType(e, Upgrade_ReciveMessage)

                Bot.myGameVersionSetting += 1
        End Select
    End Sub

    Private Sub MessageReciver(sender As Object, e As PlayerIOClient.Message)
        Try
            If MessageDictionary.ContainsKey(e.Type) Then
                Dim messageType As Type = MessageDictionary(e.Type)
                Dim myConstructorInfo As ConstructorInfo = messageType.GetConstructor(BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, New Type() {GetType(PlayerIOClient.Message)}, Nothing)
                Dim myMessage As ReciveMessage = CType(myConstructorInfo.Invoke(New Object() {e}), ReciveMessage)
                RaiseEvent OnMessage(Me, myMessage)
            Else
                myBot.Logger.Log(LogPriority.Warning, "Recived not registered message: " & e.Type)
            End If
        Catch ex As KeyNotFoundException
            myBot.Logger.Log(LogPriority.Error, "Failed to parse message: " & e.Type)
            myBot.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled: {1} {2}", ex.ToString, ex.Message, ex.StackTrace))
        End Try
    End Sub

    Friend Sub Send(PMessage As SendMessage) Implements IInternalConnection.Send
        If myConnection IsNot Nothing Then
            myConnection.Send(PMessage.GetMessage(Me))
        End If
    End Sub

    Friend Sub Disconnect() Implements IInternalConnection.Disconnect
        If myConnection IsNot Nothing Then
            myConnection.Disconnect()
        End If
    End Sub

    Private RegisteredMessages As Boolean
    Private Sub RegisterMessages()
        If RegisteredMessages = False Then
            RegisteredMessages = True
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
        Try
            If Not PType.IsSubclassOf(GetType(ReciveMessage)) Then
                Throw New InvalidOperationException("Invalid message class! Must inherit " & GetType(ReciveMessage).ToString)
            Else
                MessageDictionary.Add(PString, PType)
            End If
        Catch ex As Exception
            myBot.Logger.Log(LogPriority.Error, "Failed to register message: " & PString)
        End Try
    End Sub

    Private Sub UnRegisterMessage(PString As String)
        Try
            MessageDictionary.Remove(PString)
        Catch ex As Exception
            myBot.Logger.Log(LogPriority.Error, "Failed to unregister message: " & PString)
        End Try
    End Sub
#End Region
End Class
