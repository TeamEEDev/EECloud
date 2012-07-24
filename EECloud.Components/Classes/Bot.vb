Public NotInheritable Class Bot
    Implements IBot

#Region "Fields"
    Private myGameVersionSetting As Integer = 0
#End Region

#Region "Properties"
    Friend myConnection As Connection
    Public ReadOnly Property Connection As IConnection Implements IBot.Connection
        Get
            Return myConnection
        End Get
    End Property

    Friend mySettings As New Settings(Me)
    Public ReadOnly Property Settings As ISettings Implements IBot.Settings
        Get
            Return mySettings
        End Get
    End Property

    Friend myLogger As New Logger(Me)
    Public ReadOnly Property Logger As ILogger Implements IBot.Logger
        Get
            Return myLogger
        End Get
    End Property

    Friend myDatabase As New Database(Me)
    Public ReadOnly Property Database As IDatabase Implements IBot.Database
        Get
            Return myDatabase
        End Get
    End Property

    Friend myBlocks As New Blocks(myConnection)
    Public ReadOnly Property Blocks As IBlocks Implements IBot.Blocks
        Get
            Return myBlocks
        End Get
    End Property

    Private myAppEnvironment As AppEnvironment
    Public ReadOnly Property AppEnvironment As AppEnvironment Implements IBot.AppEnvironment
        Get
            Return myAppEnvironment
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub New(PAppEnvironment As AppEnvironment)
        'Setting variables
        myAppEnvironment = PAppEnvironment
        'TODO: Finish SettingManager
        myGameVersionSetting = 119 'mySettingManager.GetInteger("GameVersion")
    End Sub

    Public Sub SetMainConnection(PConnection As IConnection)
        myConnection = PConnection
    End Sub

    Public Overloads Function Connect(PConnection As PlayerIOClient.Connection, PWorldID As String) As IConnection Implements IBot.Connect
        Dim myConnection As New Connection(Me, PConnection, PWorldID)
        Return myConnection
    End Function

    Public Overloads Sub Connect(PClient As PlayerIOClient.Client, PWorldID As String, PCallback As PlayerIOClient.Callback(Of IConnection)) Implements IBot.Connect
        PClient.Multiplayer.CreateJoinRoom(PWorldID, Config.NormalRoom & myGameVersionSetting, True, Nothing, Nothing,
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
                myGameVersionSetting = CInt(CurrentRoomType.Substring(Config.NormalRoom.Length, CurrentRoomType.Length - Config.NormalRoom.Length - 1))
            End If
        Next
        Throw New KeyNotFoundException("Room type not available: """ & Config.NormalRoom & """")
    End Sub
#End Region
End Class
