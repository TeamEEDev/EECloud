Imports System.Threading.Tasks

Friend NotInheritable Class ClientHandle
    Implements IClientHandle

#Region "Fields"
    Private Const GameID As String = "everybody-edits-su9rn58o40itdbnw69plyw"
    Private Const NormalRoom As String = "Everybodyedits"
    Private Const GameVersionSetting As String = "GameVersion"
    Friend Shared GameVersionNumber As Integer = 0
#End Region

#Region "Properties"

    Private ReadOnly myInternalClient As New InternalClient

    Public ReadOnly Property Client As IClient(Of Player) Implements IClientHandle.Client
        Get
            Return myInternalClient
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

    Friend Async Function ConnectAsync(username As String, password As String, id As String) As Task Implements IClientHandle.ConnectAsync
        If Not Client.Connection.Connected Then
            Await Task.Run(
                Sub()
                    Try
                        Dim ioClient As PlayerIOClient.Client = PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(GameID, username, password)
                        Dim ioConnection As PlayerIOClient.Connection = GetIOConnection(ioClient, id)
                        myInternalClient.Connection.SetupConnection(ioConnection, id)
                    Catch ex As PlayerIOClient.PlayerIOError
                        Throw New EECloudPlayerIOException(ex)
                    End Try
                End Sub)
        Else
            Throw New Exception("Can not create a new Client while an other Client already exists")
        End If
    End Function

    Private Function GetIOConnection(ioClient As PlayerIOClient.Client, id As String) As PlayerIOClient.Connection
        Try
            Return ioClient.Multiplayer.CreateJoinRoom(id, NormalRoom & GameVersionNumber, True, Nothing, Nothing)
        Catch ex As PlayerIOClient.PlayerIOError
            If ex.ErrorCode = PlayerIOClient.ErrorCode.UnknownRoomType Then
                UpdateVersion(ex)
                Return GetIOConnection(ioClient, id)
            Else
                Throw New EECloudPlayerIOException(ex)
            End If
        End Try
    End Function

    Private Sub UpdateVersion(ex As PlayerIOClient.PlayerIOError)
        Dim errorMessage() As String = ex.Message.Split("["c)(1).Split(CChar(" "))
        For N = errorMessage.Length - 1 To 0 Step -1
            Dim currentRoomType As String
            currentRoomType = errorMessage(N)
            If currentRoomType.StartsWith(NormalRoom, StringComparison.Ordinal) Then
                GameVersionNumber = CInt(currentRoomType.Substring(NormalRoom.Length, currentRoomType.Length - NormalRoom.Length - 1))
                Cloud.Service.SetSetting(GameVersionSetting, CStr(GameVersionNumber))
                Exit Sub
            End If
        Next
        Throw New EECloudException(ErrorCode.GameVersionNotInList, "Unable to get room version")
    End Sub

    Friend Sub Close() Implements IClientHandle.Close
        myInternalClient.Connection.Close()
    End Sub

#End Region
End Class
