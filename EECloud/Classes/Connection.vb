Public NotInheritable Class Connection
    Inherits BaseGlobalComponent
    Implements IConnection

#Region "Events"
    Public Event OnMessage(sender As Object, e As OnMessageEventArgs)
    Public Event OnDisconnect(sender As Object, e As EventArgs) Implements IConnection.OnDisconnect
#End Region

#Region "Fields"
    Private myConnection As PlayerIOClient.Connection
#End Region

#Region "Properties"
    Private myWorldID As String
    Public ReadOnly Property WorldID As String Implements IConnection.WorldID
        Get
            Return myWorldID
        End Get
    End Property

    Public ReadOnly Property Connected As Boolean Implements IConnection.Connected
        Get
            If myConnection IsNot Nothing Then
                Return myConnection.Connected
            Else
                Return False
            End If
        End Get
    End Property

    Friend myBlocks As New Blocks(Me)
    Public ReadOnly Property Blocks As IBlocks Implements IConnection.Blocks
        Get
            Return myBlocks
        End Get
    End Property
#End Region

#Region "Methods"
    Sub New(PBot As Bot, PConnection As PlayerIOClient.Connection, PWorldID As String)
        MyBase.New(PBot)
        If PBot Is Nothing Then
            Throw New ArgumentException("PBot cannot be null.")
        End If
        If PConnection Is Nothing Then
            Throw New ArgumentException("PConnection cannot be null.")
        End If
        If PWorldID Is Nothing Then
            Throw New ArgumentException("PWorldID cannot be null.")
        End If
        myConnection = PConnection
        myWorldID = PWorldID
        myBot = PBot

        myConnection.AddOnDisconnect(Sub() RaiseEvent OnDisconnect(Me, New EventArgs))
        myConnection.AddOnMessage(AddressOf MessageReciver)

        RegisterMessage("groupdisallowedjoin", GetType(GroupDisallowedJoin_ReciveMessage))
        RegisterMessage("info", GetType(Info_ReciveMessage))
        RegisterMessage("upgrade", GetType(Upgrade_ReciveMessage))
        RegisterMessage("init", GetType(Init_ReciveMessage))
        Send(New Init_SendMessage)
    End Sub

    Private Sub MessageHandler(sender As Object, e As OnMessageEventArgs) Handles Me.OnMessage
        If e.Type = GetType(Init_ReciveMessage) Then
            Dim m As Init_ReciveMessage = CType(e.Message, Init_ReciveMessage)
            UnRegisterMessage("init")
            UnRegisterMessage("groupdisallowedjoin")
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
            myBot.Logger.Log(LogPriority.Warning, "Recived not registered message: " & e.Type)
        End Try
    End Sub

    Public Sub Send(PMessage As SendMessage)
        If myConnection IsNot Nothing Then
            myConnection.Send(PMessage.GetMessage(Me))
        End If
    End Sub

    Public Sub Disconnect() Implements IConnection.Disconnect
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

#Region "IDisposable Support"
    Private disposedValue As Boolean
    Protected Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                myConnection.Disconnect()
                myConnection = Nothing
            End If

            MessageDictionary.Clear()
        End If
        Me.disposedValue = True
    End Sub
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
