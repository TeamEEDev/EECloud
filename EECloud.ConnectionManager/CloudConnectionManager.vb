<Export(GetType(PluginAPI.IConnectionManager))>
Public Class CloudConnectionManager
    Implements IConnectionManager

#Region "Fields"
    Private m_GameVersionSetting As Integer = 0

    <Import(AllowDefault:=True)>
    Private m_SettingManager As ISettingManager

    <Import(AllowDefault:=True)>
    Private m_LogManager As ILogManager

    Private m_CompositionContainer As CompositionContainer
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
#End Region

#Region "Methods"
    Public Sub AttemptSetup(PContainer As Hosting.CompositionContainer) Implements IConnectionManager.AttemptSetup
        m_CompositionContainer = PContainer

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
        Dim myConnection As New CloudConnection(PConnection, PWorldID)
        InitConnection(myConnection)
        CloudConnectionsList.Add(myConnection)
    End Sub

    Public Overloads Sub Add(PClient As PlayerIOClient.Client, PWorldID As String) Implements IConnectionManager.Add
        Dim myIOConnection = JoinWorld(PClient, PWorldID)
        Dim myConnection As New CloudConnection(myIOConnection, PWorldID)
        InitConnection(myConnection)
        CloudConnectionsList.Add(myConnection)
    End Sub

    Public Overloads Sub Add(PUsername As String, PPassword As String, PWorldID As String) Implements IConnectionManager.Add
        Dim myClient As PlayerIOClient.Client = LogIn(PUsername, PPassword)
        Dim myIOConnection = JoinWorld(myClient, PWorldID)
        Dim myConnection As New CloudConnection(myIOConnection, PWorldID)
        InitConnection(myConnection)
        CloudConnectionsList.Add(myConnection)
    End Sub

    Private Function LogIn(PUsername As String, PPassword As String) As PlayerIOClient.Client
        m_LogManager.Log("Logging in...")
        Dim Client As PlayerIOClient.Client = PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(Config.GameID, PUsername, PPassword)
        m_LogManager.Log("Logged in.")
        Return Client
    End Function

    Private Function JoinWorld(PClient As PlayerIOClient.Client, PWorldID As String) As PlayerIOClient.Connection
        m_LogManager.Log("Joining world """ & PWorldID & """...")
        Try
            Dim Connection As PlayerIOClient.Connection = PClient.Multiplayer.CreateJoinRoom(PWorldID, Config.NormalRoom & m_GameVersionSetting, True, Nothing, Nothing)
            m_LogManager.Log("Joined world """ & PWorldID & """.")
            Return Connection
        Catch ex As PlayerIOClient.PlayerIOError
            If ex.ErrorCode = PlayerIOClient.ErrorCode.UnknownRoomType Then
                Dim ErrorMessage() As String = ex.Message.Split(CChar(" "))
                Dim CurrentRoomType As String
                For N = ErrorMessage.Length - 1 To 0 Step -1
                    CurrentRoomType = ErrorMessage(N)
                    If CurrentRoomType.StartsWith(Config.NormalRoom) Then
                        m_SettingManager.SetSetting("GameVersion", CInt(CurrentRoomType.Substring(Config.NormalRoom.Length, CurrentRoomType.Length - Config.NormalRoom.Length - 1)))
                        Return JoinWorld(PClient, PWorldID)
                    End If
                Next
                Throw New KeyNotFoundException("Room type not available: """ & Config.NormalRoom & """")
            Else
                Throw
            End If
        End Try
    End Function

    Private Sub InitConnection(PCloudConnection As CloudConnection)
        PCloudConnection.AttemptSetup(Me, m_SettingManager, m_LogManager)
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
