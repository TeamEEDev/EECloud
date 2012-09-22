Imports System.Threading.Tasks

Friend Class ConnectionHandle
    Inherits Connection(Of Player)
    Implements IConnectionHandle

    Private Const GameVersionSetting As String = "GameVersion"
    Friend Shared myGameVersionSetting As Integer = 0

    Friend Sub New()
        If myGameVersionSetting = 0 Then
            Try
                myGameVersionSetting = CInt(Cloud.Service.GetSetting(GameVersionSetting))
            Catch
                Cloud.Logger.Log(LogPriority.Error, "Invalid GameVersion setting.")
            End Try
        End If
    End Sub

    Friend Async Function Join(Username As String, password As String, worldID As String) As Task Implements IConnectionHandle.Join
        Await Task.Run(
            Sub()
                Try
                    Dim IOClient As PlayerIOClient.Client = PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(Config.GameID, Username, password)
                    Dim IOConnection As PlayerIOClient.Connection = GetIOConnection(IOClient, worldID)
                    myInternalConnection = New InternalConnection(IOConnection, worldID)
                Catch ex As PlayerIOClient.PlayerIOError
                    Throw New EECloudPlayerIOException(ex)
                End Try
            End Sub)
    End Function

    Private Function GetIOConnection(PClient As PlayerIOClient.Client, PWorldID As String) As PlayerIOClient.Connection
        Try
            Return PClient.Multiplayer.CreateJoinRoom(PWorldID, Config.NormalRoom & myGameVersionSetting, True, Nothing, Nothing)
        Catch ex As PlayerIOClient.PlayerIOError
            If ex.ErrorCode = PlayerIOClient.ErrorCode.UnknownRoomType Then
                UpdateVersion(ex)
                Return GetIOConnection(PClient, PWorldID)
            Else
                Throw New EECloudPlayerIOException(ex)
            End If
        End Try
    End Function

    Private Sub UpdateVersion(ex As PlayerIOClient.PlayerIOError)
        Dim ErrorMessage() As String = ex.Message.Split("["c)(1).Split(CChar(" "))
        For N = ErrorMessage.Length - 1 To 0 Step -1
            Dim CurrentRoomType As String
            CurrentRoomType = ErrorMessage(N)
            If CurrentRoomType.StartsWith(Config.NormalRoom) Then
                myGameVersionSetting = CInt(CurrentRoomType.Substring(Config.NormalRoom.Length, CurrentRoomType.Length - Config.NormalRoom.Length - 1))
                Cloud.Service.SetSetting(GameVersionSetting, CStr(myGameVersionSetting))
                Exit Sub
            End If
        Next
        Throw New EECloudException(API.ErrorCode.GameVersionNotInList, "Unable to get room version")
    End Sub

    Public Sub Disconnect() Implements IConnectionHandle.Disconnect
        myInternalConnection.Disconnect()
    End Sub
End Class
