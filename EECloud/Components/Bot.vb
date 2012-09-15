Friend NotInheritable Class Bot
    Implements IBot

#Region "Events"
    Public Event OnConnect() Implements IBot.OnConnect
#End Region

#Region "Fields"
    Private Const GameVersionSetting As String = "GameVersion"
    Friend Shared myGameVersionSetting As Integer = 0
    Friend myConnection As InternalConnection
#End Region

#Region "Properties"
    Private myAppEnvironment As AppEnvironment
    Friend ReadOnly Property AppEnvironment As AppEnvironment Implements IBot.AppEnvironment
        Get
            Return myAppEnvironment
        End Get
    End Property

    Private myService As PlayerIOClient.Client
    Friend ReadOnly Property Service As PlayerIOClient.Client Implements IBot.Service
        Get
            Return myService
        End Get
    End Property

    Private mySQL As New MySqlConnection(Config.MySQLConnectionString)
    Friend ReadOnly Property SQL As MySqlConnection Implements IBot.SQL
        Get
            Return mySQL
        End Get
    End Property

    Private myLogger As ILogger
    Friend ReadOnly Property Logger As ILogger Implements IBot.Logger
        Get
            Return myLogger
        End Get
    End Property

    Private mySettings As ISettings
    Friend ReadOnly Property Settings As ISettings Implements IBot.Settings
        Get
            Return mySettings
        End Get
    End Property

    Private myPluginManager As IPluginManager
    Friend ReadOnly Property PluginManager As IPluginManager Implements IBot.PluginManager
        Get
            Return myPluginManager
        End Get
    End Property

    Public ReadOnly Property HasConnection As Boolean Implements IBot.HasConnection
        Get
            Return myConnection IsNot Nothing
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New(PAppEnvironment As AppEnvironment, PService As PlayerIOClient.Client)
        myAppEnvironment = PAppEnvironment
        myService = PService
        myLogger = New Logger(Me)
        mySettings = New Settings(Me)
        myPluginManager = New PluginManager(Me)

        If myGameVersionSetting = 0 Then
            myGameVersionSetting = Settings.GetInteger(GameVersionSetting)
        End If
    End Sub

    Private Function Connect(Of P As {Player, New})(PConnection As PlayerIOClient.Connection, PWorldID As String) As Connection(Of P)
        Dim mConnection As New InternalConnection(Me, PConnection, PWorldID)
        If myConnection Is Nothing Then
            myConnection = mConnection
            AddHandler myConnection.DefaultConnection.OnReceiveInit, AddressOf raiseConnect
        End If
        Return New Connection(Of P)(Me, mConnection)
    End Function

    Private Sub raiseConnect(sender As Object, e As Init_ReceiveMessage)
        RemoveHandler myConnection.DefaultConnection.OnReceiveInit, AddressOf raiseConnect
        RaiseEvent OnConnect()
    End Sub

    Private Sub Connect(Of P As {Player, New})(PClient As PlayerIOClient.Client, PWorldID As String, PSuccessCallback As Action(Of Connection(Of P)), PErrorCallback As Action(Of EECloudException))
        PClient.Multiplayer.CreateJoinRoom(PWorldID, Config.NormalRoom & myGameVersionSetting, True, Nothing, Nothing,
            Sub(PConnection As PlayerIOClient.Connection)
                PSuccessCallback.Invoke(Connect(Of P)(PConnection, PWorldID))
            End Sub,
            Sub(ex As PlayerIOClient.PlayerIOError)
                If ex.ErrorCode = PlayerIOClient.ErrorCode.UnknownRoomType Then
                    Try
                        UpdateVersion(ex)
                        Connect(PClient, PWorldID, PSuccessCallback, PErrorCallback)
                    Catch ex2 As EECloudException
                        PErrorCallback.Invoke(New EECloudException(API.ErrorCode.PlayerIOError))
                    End Try
                Else
                    PErrorCallback.Invoke(New EECloudPlayerIOException(ex))
                End If
            End Sub)
    End Sub

    Friend Sub Connect(Of P As {Player, New})(PUsername As String, PPassword As String, PWorldID As String, PSuccessCallback As Action(Of IConnection(Of P)), PErrorCallback As Action(Of EECloudException)) Implements IBot.Connect
        PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(Config.GameID, PUsername, PPassword,
            Sub(PClient As PlayerIOClient.Client)
                Connect(Of P)(PClient, PWorldID, PSuccessCallback, PErrorCallback)
            End Sub,
            Sub(ex As PlayerIOClient.PlayerIOError)
                PErrorCallback.Invoke(New EECloudPlayerIOException(ex))
            End Sub)
    End Sub

    Private Sub UpdateVersion(ex As PlayerIOClient.PlayerIOError)
        Dim ErrorMessage() As String = ex.Message.Split("["c)(1).Split(CChar(" "))
        For N = ErrorMessage.Length - 1 To 0 Step -1
            Dim CurrentRoomType As String
            CurrentRoomType = ErrorMessage(N)
            If CurrentRoomType.StartsWith(Config.NormalRoom) Then
                myGameVersionSetting = CInt(CurrentRoomType.Substring(Config.NormalRoom.Length, CurrentRoomType.Length - Config.NormalRoom.Length - 1))
                Settings.SetSetting(GameVersionSetting, myGameVersionSetting)
                Exit Sub
            End If
        Next
        Throw New EECloudException(API.ErrorCode.GameVersionNotInList, "Unable to get room version")
    End Sub

    Public Function GetChatter(connection As IConnection(Of Player), name As String) As IChatter Implements IBot.GetChatter
        Return New Chatter(CType(connection, Connection(Of Player)).InternalChatter, name)
    End Function

    Friend Function GetConnection(Of P As {Player, New})() As IConnection(Of P) Implements IBot.GetConnection
        Return New Connection(Of P)(Me, myConnection)
    End Function

    Public Function GetDefaultChatter(connection As IConnection(Of Player)) As IChatter Implements IBot.GetDefaultChatter
        Try
            Return CType(connection, Connection(Of Player)).DefaultChatter
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetDefaultConnection(Of P As {New, Player})(connection As IConnection(Of P)) As IConnection(Of Player) Implements IBot.GetDefaultConnection
        Try
            Return CType(connection, Connection(Of P)).DefaultConnection
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
End Class
