Imports System.Threading.Tasks
Imports PlayerIOClient

Friend NotInheritable Class ConnectionHandle
    Implements IConnectionHandle

#Region "Fields"
    Private Const GameVersionSetting As String = "GameVersion"
    Friend Shared GameVersionNumber As Integer = 0
#End Region

#Region "Properties"

    Private ReadOnly myInternalConnection As New InternalConnection

    Public ReadOnly Property Connection As IConnection(Of Player) Implements IConnectionHandle.Connection
        Get
            Return myInternalConnection
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

    Friend Async Function ConnectAsync(username As String, password As String, id As String) As Task Implements IConnectionHandle.ConnectAsync
        If Not Connection.Connected Then
            Await Task.Run(
                Sub()
                    Try
                        Dim ioClient As Client = PlayerIO.QuickConnect.SimpleConnect(Config.GameID, username, password)
                        Dim ioConnection As Connection = GetIOConnection(ioClient, id)
                        myInternalConnection.SetupConnection(ioConnection, id)
                    Catch ex As PlayerIOError
                        Throw New EECloudPlayerIOException(ex)
                    End Try
                End Sub)
        Else
            Throw New Exception("Can not create a new connection while an other connection already exists")
        End If
    End Function

    Private Function GetIOConnection(client As Client, id As String) As Connection
        Try
            Return client.Multiplayer.CreateJoinRoom(id, Config.NormalRoom & GameVersionNumber, True, Nothing, Nothing)
        Catch ex As PlayerIOError
            If ex.ErrorCode = ErrorCode.UnknownRoomType Then
                UpdateVersion(ex)
                Return GetIOConnection(client, id)
            Else
                Throw New EECloudPlayerIOException(ex)
            End If
        End Try
    End Function

    Private Sub UpdateVersion(ex As PlayerIOError)
        Dim errorMessage() As String = ex.Message.Split("["c)(1).Split(CChar(" "))
        For N = errorMessage.Length - 1 To 0 Step -1
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
        myInternalConnection.Disconnect()
    End Sub

#End Region
End Class
