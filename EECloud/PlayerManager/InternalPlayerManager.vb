Friend NotInheritable Class InternalPlayerManager

#Region "Fields"
    Private WithEvents myConnection As IConnection
    Private ReadOnly myClient As IClient(Of Player)
#End Region

#Region "Events"
    Friend Event AddUser(sender As Object, e As InternalPlayer)
    Friend Event RemoveUser(sender As Object, e As LeftReceiveMessage)
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

    Friend Sub New(client As IClient(Of Player))
        myClient = client
        myConnection = client.Connection
    End Sub

    Private Async Sub myConnection_OnReceiveAdd(sender As Object, e As AddReceiveMessage) Handles myConnection.ReceiveAdd
        Try
            Dim player As New InternalPlayer(myClient, e)
            Await player.ReloadUserDataAsync
            myPlayers.Add(player.UserID, player)
            RaiseEvent AddUser(Me, player)
        Catch ex As Exception
            Cloud.Logger.LogEx(ex)
        End Try
    End Sub

    Private Sub myConnection_OnReceiveCrown(sender As Object, e As CrownReceiveMessage) Handles myConnection.ReceiveCrown
        Try
            If Not e.UserID = -1 Then
                myCrown = Players(e.UserID)
            End If
        Catch ex As Exception
            Cloud.Logger.LogEx(ex)
        End Try
    End Sub

    Private Sub myConnection_OnReceiveLeft(sender As Object, e As LeftReceiveMessage) Handles myConnection.ReceiveLeft
        RaiseEvent RemoveUser(Me, e)

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
