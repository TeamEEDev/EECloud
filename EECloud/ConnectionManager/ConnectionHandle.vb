Imports System.Threading.Tasks
Imports PlayerIOClient

Friend NotInheritable Class ConnectionHandle
    Inherits Connection(Of Player)
    Implements IConnectionHandle

#Region "Fields"
    Private Const GameVersionSetting As String = "GameVersion"
    Friend Shared GameVersionNumber As Integer = 0
#End Region

#Region "Properties"
    Private myCreator As IConnectionFactory

    Friend ReadOnly Property Creator As IConnectionFactory
        Get
            Return myCreator
        End Get
    End Property

    Private ReadOnly myPluginManager As IPluginManager = New PluginManager

    Friend Overrides ReadOnly Property PluginManager As IPluginManager
        Get
            Return myPluginManager
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New()
        If GameVersionNumber = 0 Then
            Try
                GameVersionNumber = CInt(Cloud.Service.GetSetting(GameVersionSetting))
            Catch
                Cloud.Logger.Log(LogPriority.Error, "Invalid GameVersion setting.")
            End Try
        End If
    End Sub

    Friend Async Function JoinAsync(username As String, password As String, id As String) As Task Implements IConnectionHandle.JoinAsync
        Await Task.Run(
            Sub()
                Try
                    Dim ioClient As Client = PlayerIO.QuickConnect.SimpleConnect(Config.GameID, username, password)
                    Dim ioConnection As Connection = GetIoConnection(ioClient, id)
                    InternalConnection = New InternalConnection(ioConnection, id, myPluginManager)
                    myCreator = New ConnectionFactory(InternalConnection)
                Catch ex As PlayerIOError
                    Throw New EECloudPlayerIOException(ex)
                          End Try
                          End Sub)
    End Function

    Private Function GetIoConnection(client As Client, id As String) As Connection
        Try
            Return client.Multiplayer.CreateJoinRoom(id, Config.NormalRoom & GameVersionNumber, True, Nothing, Nothing)
        Catch ex As PlayerIOError
            If ex.ErrorCode = ErrorCode.UnknownRoomType Then
                UpdateVersion(ex)
                Return GetIoConnection(client, id)
            Else
                Throw New EECloudPlayerIOException(ex)
            End If
        End Try
    End Function

    Private Sub UpdateVersion(ex As PlayerIOError)
        Dim errorMessage() As String = ex.Message.Split("["c)(1).Split(CChar(" "))
        For N = errorMessage.Length - 1 To 0 Step - 1
            Dim currentRoomType As String
            currentRoomType = errorMessage(N)
            If currentRoomType.StartsWith(Config.NormalRoom, StringComparison.Ordinal) Then
                GameVersionNumber = CInt(currentRoomType.Substring(Config.NormalRoom.Length, currentRoomType.Length - Config.NormalRoom.Length - 1))
                Cloud.Service.SetSetting(GameVersionSetting, CStr(GameVersionNumber))
                Exit Sub
            End If
        Next
        Throw New EECloudException(API.ErrorCode.GameVersionNotInList, "Unable to get room version")
    End Sub

    Friend Sub Disconnect() Implements IConnectionHandle.Disconnect
        InternalConnection.Disconnect()
    End Sub

#End Region
End Class
