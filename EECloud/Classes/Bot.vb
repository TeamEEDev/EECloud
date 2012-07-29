Public NotInheritable Class Bot
    Implements IBot

#Region "Fields"
    Private myGameVersionSetting As Integer = 0
    Friend myConnection As Connection
#End Region

#Region "Properties"
    Private myLicenceUsername As String
    Public ReadOnly Property LicenceUsername As String Implements IBot.LicenceUsername
        Get
            Return myLicenceUsername
        End Get
    End Property

    Private myLicenceKey As String
    Public ReadOnly Property LicenceKey As String Implements IBot.LicenceKey
        Get
            Return myLicenceKey
        End Get
    End Property

    Private myAppEnvironment As AppEnvironment
    Public ReadOnly Property AppEnvironment As AppEnvironment Implements IBot.AppEnvironment
        Get
            Return myAppEnvironment
        End Get
    End Property

    Friend myLogger As Logger
    Public ReadOnly Property Logger As ILogger Implements IBot.Logger
        Get
            Return myLogger
        End Get
    End Property

    Friend myService As Service
    Public ReadOnly Property Service As IService Implements IBot.Service
        Get
            Return myService
        End Get
    End Property

    Friend mySettings As Settings
    Public ReadOnly Property Settings As ISettings Implements IBot.Settings
        Get
            Return mySettings
        End Get
    End Property

    Friend myPluginManager As PluginManager
    Public ReadOnly Property PluginManager As IPluginManager Implements IBot.PluginManager
        Get
            Return myPluginManager
        End Get
    End Property

    Public ReadOnly Property Blocks As IBlocks Implements IBot.Blocks
        Get
            Return myConnection.myBlocks
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub New(PAppEnvironment As AppEnvironment, PLicenceUsername As String, PLicenceKey As String)
        myAppEnvironment = PAppEnvironment
        myLicenceUsername = PLicenceUsername
        myLicenceKey = PLicenceKey

        myLogger = New Logger(Me)
        myService = New Service(Me)
        mySettings = New Settings(Me)
        myPluginManager = New PluginManager(Me)

        myGameVersionSetting = Settings.GetInteger("GameVersion")
    End Sub

    Private Overloads Function Connect(PConnection As PlayerIOClient.Connection, PWorldID As String) As IConnection
        Dim mConnection As New Connection(Me, PConnection, PWorldID)
        If mConnection Is Nothing Then
            myConnection = mConnection
        End If
        Return mConnection
    End Function

    Private Overloads Sub Connect(PClient As PlayerIOClient.Client, PWorldID As String, PSuccessCallback As PlayerIOClient.Callback(Of IConnection), PErrorCallback As PlayerIOClient.Callback(Of EECloudException))
        PClient.Multiplayer.CreateJoinRoom(PWorldID, Config.NormalRoom & myGameVersionSetting, True, Nothing, Nothing,
            Sub(PConnection As PlayerIOClient.Connection)
                PSuccessCallback.Invoke(Connect(PConnection, PWorldID))
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

    Public Overloads Sub Connect(PUsername As String, PPassword As String, PWorldID As String, PSuccessCallback As PlayerIOClient.Callback(Of IConnection), PErrorCallback As PlayerIOClient.Callback(Of EECloudException)) Implements IBot.Connect
        PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(Config.GameID, PUsername, PPassword,
            Sub(PClient As PlayerIOClient.Client)
                Connect(PClient, PWorldID, PSuccessCallback, PErrorCallback)
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
                mySettings.SetSetting("GameVersion", myGameVersionSetting)
                Exit Sub
            End If
        Next
        Throw New EECloudException(API.ErrorCode.GameVersionNotInList, "Unable to get GameVersion")
    End Sub
#End Region
End Class
