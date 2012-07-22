<Export(GetType(PluginAPI.IConnectionManager))>
Public Class CloudConnectionManager
    Implements IConnectionManager

#Region "Fields"
    Private m_GameVersionSetting As Integer = 0

    <Import(AllowDefault:=True)>
    Friend m_SettingManager As ISettingManager

    <Import(AllowDefault:=True)>
    Friend m_LogManager As ILogManager

    <Import(AllowDefault:=True)>
    Friend m_DatabaseManager As IDatabaseManager

    Friend m_CompositionContainer As CompositionContainer
#End Region

#Region "Properties"
    Private CloudConnectionsList As New List(Of IConnection)
    Public ReadOnly Property Count As Integer Implements IConnectionManager.Count
        Get
            Return CloudConnectionsList.Count
        End Get
    End Property

    Default Public ReadOnly Property Item(Index As Integer) As IConnection Implements IConnectionManager.Item
        Get
            Return CloudConnectionsList.Item(Index)
        End Get
    End Property

    Private m_MainConnection As Integer = 0
    Public Property MainConnection As IConnection Implements IConnectionManager.MainConnection
        Get
            If CloudConnectionsList.Count >= m_MainConnection + 1 Then
                Return CloudConnectionsList(m_MainConnection)
            Else
                Return Nothing
            End If
        End Get
        Set(value As IConnection)
            If CloudConnectionsList.Contains(value) Then
                m_MainConnection = CloudConnectionsList.IndexOf(value)
            Else
                Throw New ApplicationException("Unknown Connection")
            End If
        End Set
    End Property

    Private m_OnAppHarbor As Boolean
    Public ReadOnly Property OnAppHarbor As Boolean Implements IConnectionManager.OnAppHarbor
        Get
            Return m_OnAppHarbor
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub AttemptSetup(POnAppharbor As Boolean, PContainer As Hosting.CompositionContainer) Implements IConnectionManager.AttemptSetup
        m_OnAppHarbor = POnAppharbor
        m_CompositionContainer = PContainer

        If Not POnAppharbor Then
            m_LogManager.AttemptSetup()
        End If

        m_GameVersionSetting = 119 'm_SettingManager.GetInteger("GameVersion")
    End Sub

#Region "Add"
    Public Overloads Sub Add(PConnection As IConnection) Implements IConnectionManager.Add
        If Not CloudConnectionsList.Contains(PConnection) Then
            CloudConnectionsList.Add(PConnection)
        Else
            Throw New ApplicationException("Connection has been already added.")
        End If
    End Sub

    Public Overloads Sub Add(PConnection As PlayerIOClient.Connection, PWorldID As String) Implements IConnectionManager.Add
        Dim myConnection As New CloudConnection()
        InitConnection(myConnection, PConnection, PWorldID)
        CloudConnectionsList.Add(myConnection)
    End Sub

    Public Overloads Sub Add(PClient As PlayerIOClient.Client, PWorldID As String) Implements IConnectionManager.Add
        Dim myIOConnection = JoinWorld(PClient, PWorldID)
        Dim myConnection As New CloudConnection()
        InitConnection(myConnection, myIOConnection, PWorldID)
        CloudConnectionsList.Add(myConnection)
    End Sub

    Public Overloads Sub Add(PUsername As String, PPassword As String, PWorldID As String) Implements IConnectionManager.Add
        Dim myClient As PlayerIOClient.Client = LogIn(PUsername, PPassword)
        Dim myIOConnection = JoinWorld(myClient, PWorldID)
        Dim myConnection As New CloudConnection()
        InitConnection(myConnection, myIOConnection, PWorldID)
        CloudConnectionsList.Add(myConnection)
    End Sub

    Private Function LogIn(PUsername As String, PPassword As String) As PlayerIOClient.Client
        Return PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(Config.GameID, PUsername, PPassword)
    End Function

    Private Function JoinWorld(PClient As PlayerIOClient.Client, PWorldID As String) As PlayerIOClient.Connection
        Try
            Return PClient.Multiplayer.CreateJoinRoom(PWorldID, Config.NormalRoom & m_GameVersionSetting, True, Nothing, Nothing)
        Catch ex As PlayerIOClient.PlayerIOError
            If ex.ErrorCode = PlayerIOClient.ErrorCode.UnknownRoomType Then
                Dim ErrorMessage() As String = ex.Message.Split(CChar(" "))
                Dim CurrentRoomType As String
                For N = ErrorMessage.Length - 1 To 0 Step -1
                    CurrentRoomType = ErrorMessage(N)
                    If CurrentRoomType.StartsWith(Config.NormalRoom) Then
                        m_GameVersionSetting = CInt(CurrentRoomType.Substring(Config.NormalRoom.Length, CurrentRoomType.Length - Config.NormalRoom.Length - 1))
                        'm_SettingManager.SetSetting("GameVersion", CInt(CurrentRoomType.Substring(Config.NormalRoom.Length, CurrentRoomType.Length - Config.NormalRoom.Length - 1)))
                        Return JoinWorld(PClient, PWorldID)
                    End If
                Next
                Throw New KeyNotFoundException("Room type not available: """ & Config.NormalRoom & """")
            Else
                Throw
            End If
        End Try
    End Function

    Private Sub InitConnection(PCloudConnection As CloudConnection, PConnection As PlayerIOClient.Connection, PWorldID As String)
        PCloudConnection.AttemptSetup(Me, PConnection, PWorldID)
        m_CompositionContainer.ComposeParts(PCloudConnection)
    End Sub
#End Region

    Public Sub Remove(PConnection As IConnection) Implements IConnectionManager.Remove
        If CloudConnectionsList.Contains(PConnection) Then
            CloudConnectionsList.Remove(PConnection)
        Else
            Throw New ApplicationException("Unknown Connection")
        End If
    End Sub
#End Region
End Class
