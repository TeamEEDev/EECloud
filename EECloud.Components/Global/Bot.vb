Public NotInheritable Class Bot
    Implements IBot
#Region "Events"
    Public Event OnDisconnect(sender As Object, e As EventArgs) Implements IConnection.OnDisconnect
    Public Event OnMessage(sender As Object, e As OnMessageEventArgs) Implements IConnection.OnMessage
#End Region

#Region "Fields"
    Private m_GameVersionSetting As Integer = 0
    Private WithEvents m_Connection As IConnection
#End Region

#Region "Properties"
    Private m_SettingManager As ISettings = New Settings
    Public ReadOnly Property SettingManager As ISettings Implements IBot.SettingManager
        Get
            Return m_SettingManager
        End Get
    End Property

    Private m_LogManager As ILogger = New Logger
    Public ReadOnly Property LogManager As ILogger Implements IBot.LogManager
        Get
            Return m_LogManager
        End Get
    End Property

    Private m_DatabaseManager As IDatabase = New Database
    Public ReadOnly Property DatabaseManager As IDatabase Implements IBot.DatabaseManager
        Get
            Return m_DatabaseManager
        End Get
    End Property

    Private m_AppEnvironment As AppEnvironment
    Public ReadOnly Property OnAppHarbor As Boolean Implements IBot.OnAppHarbor
        Get
            Return (m_AppEnvironment = AppEnvironment.Release)
        End Get
    End Property

    Public ReadOnly Property BlockManager As IBlocks Implements IConnection.BlockManager
        Get
            Return m_Connection.BlockManager
        End Get
    End Property

    Public ReadOnly Property WorldID As String Implements IConnection.WorldID
        Get
            Return m_Connection.WorldID
        End Get
    End Property

    Public ReadOnly Property Connected As Boolean Implements IConnection.Connected
        Get
            Return m_Connection.Connected
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub New(PAppEnvironment As AppEnvironment)
        'Setting variables
        m_AppEnvironment = PAppEnvironment
        'TODO: Finish SettingManager
        m_GameVersionSetting = 119 'm_SettingManager.GetInteger("GameVersion")

        'Component init
        If m_AppEnvironment = AppEnvironment.Dev Then
            m_LogManager.AttemptSetup()
        End If
    End Sub

    Private Sub m_Connection_OnDisconnect(sender As Object, e As EventArgs) Handles m_Connection.OnDisconnect
        RaiseEvent OnDisconnect(sender, e)
    End Sub

    Private Sub m_Connection_OnMessage(sender As Object, e As OnMessageEventArgs) Handles m_Connection.OnMessage
        RaiseEvent OnMessage(sender, e)
    End Sub

    Public Sub SetMainConnection(PConnection As IConnection)
        m_Connection = PConnection
    End Sub

    Public Overloads Function Connect(PConnection As PlayerIOClient.Connection, PWorldID As String) As IConnection Implements IBot.Connect
        Dim myConnection As New Connection(Me, PConnection, PWorldID)
        Return myConnection
    End Function

    Public Overloads Sub Connect(PClient As PlayerIOClient.Client, PWorldID As String, PCallback As PlayerIOClient.Callback(Of IConnection)) Implements IBot.Connect
        PClient.Multiplayer.CreateJoinRoom(PWorldID, Config.NormalRoom & m_GameVersionSetting, True, Nothing, Nothing,
            Sub(PConnection As PlayerIOClient.Connection)
                Dim myConnection As PlayerIOClient.Connection = PConnection
                Connect(myConnection, PWorldID)
                PCallback.Invoke(Connect(PConnection, PWorldID))
            End Sub,
            Sub(ex As PlayerIOClient.PlayerIOError)
                If ex.ErrorCode = PlayerIOClient.ErrorCode.UnknownRoomType Then
                    GetVersion(ex)
                    Connect(PClient, PWorldID, PCallback)
                Else
                    Throw ex
                End If
            End Sub)
    End Sub

    Public Overloads Sub Connect(PUsername As String, PPassword As String, PWorldID As String, PCallback As PlayerIOClient.Callback(Of IConnection)) Implements IBot.Connect
        PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(Config.GameID, PUsername, PPassword,
            Sub(PClient As PlayerIOClient.Client)
                Connect(PClient, PWorldID, PCallback)
            End Sub,
            Sub(ex As PlayerIOClient.PlayerIOError)
                Throw ex
            End Sub)
    End Sub

    Private Sub GetVersion(ex As PlayerIOClient.PlayerIOError)
        Dim ErrorMessage() As String = ex.Message.Split(CChar(" "))
        Dim CurrentRoomType As String
        For N = ErrorMessage.Length - 1 To 0 Step -1
            CurrentRoomType = ErrorMessage(N)
            If CurrentRoomType.StartsWith(Config.NormalRoom) Then
                m_GameVersionSetting = CInt(CurrentRoomType.Substring(Config.NormalRoom.Length, CurrentRoomType.Length - Config.NormalRoom.Length - 1))
            End If
        Next
        Throw New KeyNotFoundException("Room type not available: """ & Config.NormalRoom & """")
    End Sub

    Public Sub Disconnect() Implements IConnection.Disconnect
        m_Connection.Disconnect()
    End Sub

    Public Sub Send(PMessage As SendMessage) Implements IConnection.Send
        m_Connection.Send(PMessage)
    End Sub
#End Region
End Class
