Friend NotInheritable Class Host
#Region "Fields"
    Private Const GameVersionSetting As String = "GameVersion"
    Friend Shared myGameVersionSetting As Integer = 0
    Friend myConnection As ConnectionHandle
#End Region

#Region "Methods"
    Friend Sub New()
        If myGameVersionSetting = 0 Then
            Try
                myGameVersionSetting = CInt(Cloud.Service.GetSetting(GameVersionSetting))
            Catch
                Cloud.Logger.Log(LogPriority.Error, "Invalid GameVersion setting.")
            End Try
        End If
    End Sub

    Private Function Connect(Of P As {Player, New})(PConnection As PlayerIOClient.Connection, PWorldID As String) As Connection(Of P)
        Dim mConnection As New ConnectionHandle(Me, PConnection, PWorldID)
        If myConnection Is Nothing Then
            myConnection = mConnection
            AddHandler myConnection.DefaultConnection.OnReceiveInit, AddressOf raiseConnect
        End If
        Return New Connection(Of P)(Me, mConnection)
    End Function

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

    Friend Sub Connect(Of P As {Player, New})(PUsername As String, PPassword As String, PWorldID As String, PSuccessCallback As Action(Of IConnection(Of P)), PErrorCallback As Action(Of EECloudException))
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
                Cloud.Service.SetSetting(GameVersionSetting, CStr(myGameVersionSetting))
                Exit Sub
            End If
        Next
        Throw New EECloudException(API.ErrorCode.GameVersionNotInList, "Unable to get room version")
    End Sub

    Public Function GetChatter(connection As IConnection(Of Player), name As String) As IChatter
        Return New Chatter(CType(connection, Connection(Of Player)).InternalChatter, name)
    End Function

    Friend Function GetConnection(Of P As {Player, New})() As IConnection(Of P)
        Return New Connection(Of P)(Me, myConnection)
    End Function

    Public Function GetDefaultChatter(connection As IConnection(Of Player)) As IChatter
        Try
            Return CType(connection, Connection(Of Player)).DefaultChatter
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function GetDefaultConnection(Of P As {New, Player})(connection As IConnection(Of P)) As IConnection(Of Player)
        Try
            Return CType(connection, Connection(Of P)).DefaultConnection
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
#End Region
End Class
