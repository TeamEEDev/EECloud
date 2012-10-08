Friend NotInheritable Class InternalPlayerManager

#Region "Fields"
    Private WithEvents myConnection As InternalConnection
#End Region

#Region "Events"
    Friend Event OnAddUser(sender As Object, e As InternalPlayer)
    Friend Event OnRemoveUser(sender As Object, e As LeftReceiveMessage)
#End Region

#Region "Properties"
    Private ReadOnly myPlayers As New Dictionary(Of Integer, InternalPlayer)

    Friend ReadOnly Property Players As Dictionary(Of Integer, InternalPlayer)
        Get
            Return myPlayers
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(connection As InternalConnection)
        myConnection = connection
    End Sub

    Private Async Sub myConnection_OnReceiveAdd(sender As Object, e As AddReceiveMessage) Handles myConnection.OnReceiveAdd
        Try
            Dim player As New InternalPlayer(myConnection, e)
            Await player.ReloadUserDataAsync
            myPlayers.Add(player.UserID, player)
            RaiseEvent OnAddUser(Me, player)
        Catch ex As Exception
            Cloud.Logger.LogEx(ex)
        End Try
    End Sub

    Private Sub myConnection_OnReceiveCrown(sender As Object, e As CrownReceiveMessage) Handles myConnection.OnReceiveCrown
        Try
            If Not e.UserID = -1 Then
                myCrown = Players(e.UserID)
            End If
        Catch ex As Exception
            Cloud.Logger.LogEx(ex)
        End Try
    End Sub

    Private Sub myConnection_OnReceiveLeft(sender As Object, e As LeftReceiveMessage) Handles myConnection.OnReceiveLeft
        RaiseEvent OnRemoveUser(Me, e)

        Try
            myPlayers.Remove(e.UserID)
        Catch ex As Exception
            Cloud.Logger.LogEx(ex)
        End Try
    End Sub

    Private myCrown As InternalPlayer

    Friend ReadOnly Property Crown As InternalPlayer
        Get
            Return myCrown
        End Get
    End Property

#End Region
End Class
