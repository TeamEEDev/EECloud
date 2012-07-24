<Export(GetType(PluginAPI.IConnectionManager))>
Public NotInheritable Class ConnectionManager
    Implements IConnectionManager
#Region "Events"
    Public Event OnDisconnect(sender As Object, e As EventArgs) Implements IConnection.OnDisconnect
    Public Event OnMessage(sender As Object, e As OnMessageEventArgs) Implements IConnection.OnMessage
#End Region

#Region "Fields"
    Private m_GameVersionSetting As Integer = 0
    Private m_CompositionContainer As CompositionContainer
    Private WithEvents m_Connection As IConnection
#End Region

#Region "Properties"
    <Import(AllowDefault:=True)>
    Private m_SettingManager As ISettingManager
    Public ReadOnly Property SettingManager As ISettingManager Implements IConnectionManager.SettingManager
        Get
            Return m_SettingManager
        End Get
    End Property

    <Import(AllowDefault:=True)>
    Private m_LogManager As ILogManager
    Public ReadOnly Property LogManager As ILogManager Implements IConnectionManager.LogManager
        Get
            Return m_LogManager
        End Get
    End Property

    <Import(AllowDefault:=True)>
    Private m_DatabaseManager As IDatabaseManager
    Public ReadOnly Property DatabaseManager As IDatabaseManager Implements IConnectionManager.DatabaseManager
        Get
            Return m_DatabaseManager
        End Get
    End Property

    Private m_OnAppHarbor As Boolean
    Public ReadOnly Property OnAppHarbor As Boolean Implements IConnectionManager.OnAppHarbor
        Get
            Return m_OnAppHarbor
        End Get
    End Property

    Public ReadOnly Property BlockManager As IBlockManager Implements IConnection.BlockManager
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
    Private Sub m_Connection_OnDisconnect(sender As Object, e As EventArgs) Handles m_Connection.OnDisconnect
        RaiseEvent OnDisconnect(sender, e)
    End Sub

    Private Sub m_Connection_OnMessage(sender As Object, e As OnMessageEventArgs) Handles m_Connection.OnMessage
        RaiseEvent OnMessage(sender, e)
    End Sub

    Public Sub Setup(POnAppharbor As Boolean, PContainer As CompositionContainer) Implements IConnectionManager.AttemptSetup
        'Setting variables
        m_OnAppHarbor = POnAppharbor
        m_CompositionContainer = PContainer
        'TODO: Finish SettingManager
        m_GameVersionSetting = 119 'm_SettingManager.GetInteger("GameVersion")

        'Component init
        If Not POnAppharbor Then
            m_LogManager.AttemptSetup()
        End If
    End Sub

    Public Sub SetMainConnection(PConnection As IConnection) Implements IConnectionManager.SetMainConnection
        m_Connection = PConnection
    End Sub

    Public Overloads Function Connect(PConnection As PlayerIOClient.Connection, PWorldID As String) As IConnection Implements IConnectionManager.Connect
        Dim myConnection As New Connection()
        InitConnection(myConnection, PConnection, PWorldID)
        Return myConnection
    End Function

    Public Overloads Sub Connect(PClient As PlayerIOClient.Client, PWorldID As String, PCallback As PlayerIOClient.Callback(Of IConnection)) Implements IConnectionManager.Connect
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

    Public Overloads Sub Connect(PUsername As String, PPassword As String, PWorldID As String, PCallback As PlayerIOClient.Callback(Of IConnection)) Implements IConnectionManager.Connect
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

    Private Sub InitConnection(PCloudConnection As Connection, PConnection As PlayerIOClient.Connection, PWorldID As String)
        PCloudConnection.AttemptSetup(Me, PConnection, PWorldID)
        m_CompositionContainer.ComposeParts(PCloudConnection)
    End Sub

    Public Sub Disconnect() Implements IConnection.Disconnect
        m_Connection.Disconnect()
    End Sub

    Public Sub Send(PMessage As SendMessage) Implements IConnection.Send
        m_Connection.Send(PMessage)
    End Sub
#End Region
End Class
