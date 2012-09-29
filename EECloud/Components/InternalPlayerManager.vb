Friend Class InternalPlayerManager
#Region "Fields"
    Private WithEvents myConnection As Connection(Of Player)
#End Region

#Region "Events"
    Friend Event OnAddUser(sender As Object, e As InternalPlayer)
    Friend Event OnRemoveUser(sender As Object, e As Left_ReceiveMessage)
#End Region

#Region "Properties"
    Private myPlayers As Dictionary(Of Integer, InternalPlayer)
    Friend ReadOnly Property Players As Dictionary(Of Integer, InternalPlayer)
        Get
            Return myPlayers
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub New(connection As Connection(Of Player))
        myConnection = connection
    End Sub

    Private Sub myConnection_OnReceiveAdd(sender As Object, e As Add_ReceiveMessage) Handles myConnection.OnReceiveAdd
        Try
            Dim myPlayer As New InternalPlayer(myConnection, e)
            myPlayers.Add(myPlayer.UserID, myPlayer)
            RaiseEvent OnAddUser(Me, myPlayer)
        Catch ex As Exception
            Cloud.Logger.Log(ex)
        End Try
    End Sub

    Private Sub myConnection_OnReceiveLeft(sender As Object, e As Left_ReceiveMessage) Handles myConnection.OnReceiveLeft
        RaiseEvent OnRemoveUser(Me, e)

        Try
            myPlayers.Remove(e.UserID)
        Catch ex As Exception
            Cloud.Logger.Log(ex)
        End Try
    End Sub
#End Region
End Class
