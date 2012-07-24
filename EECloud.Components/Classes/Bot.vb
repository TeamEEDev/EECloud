Public NotInheritable Class Bot
    Implements IBot

#Region "Fields"
    Private m_GameVersionSetting As Integer = 0
#End Region

#Region "Properties"
    Private m_Connection As IConnection
    Public ReadOnly Property Connection As IConnection Implements IBot.Connection
        Get
            Return m_Connection
        End Get
    End Property

    Private m_Settings As ISettings = New Settings
    Public ReadOnly Property Settings As ISettings Implements IBot.Settings
        Get
            Return m_Settings
        End Get
    End Property

    Private m_Logger As ILogger = New Logger
    Public ReadOnly Property Logger As ILogger Implements IBot.Logger
        Get
            Return m_Logger
        End Get
    End Property

    Private m_Database As IDatabase = New Database
    Public ReadOnly Property Database As IDatabase Implements IBot.Database
        Get
            Return m_Database
        End Get
    End Property

    Private m_AppEnvironment As AppEnvironment
    Public ReadOnly Property OnAppHarbor As Boolean Implements IBot.OnAppHarbor
        Get
            Return (m_AppEnvironment = AppEnvironment.Release)
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
            m_Logger.AttemptSetup()
        End If
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
#End Region
End Class
