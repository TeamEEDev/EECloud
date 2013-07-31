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

    Private Sub myConnection_OnReceiveAdd(sender As Object, e As AddReceiveMessage) Handles myConnection.ReceiveAdd
        If Not myPlayers.ContainsKey(e.UserID) Then
            Dim player As InternalPlayer = New InternalPlayer(myClient, e)
            myPlayers.Add(player.UserID, player)
            RaiseEvent AddUser(Me, player)
            'Await player.ReloadUserDataAsync()
        End If
    End Sub

    Private Sub myConnection_OnReceiveCrown(sender As Object, e As CrownReceiveMessage) Handles myConnection.ReceiveCrown
        SyncLock myPlayers
            Dim player As InternalPlayer = Nothing
            If myPlayers.TryGetValue(e.UserID, player) Then
                myCrown = player
            End If
        End SyncLock
    End Sub

    Private Sub myConnection_OnReceiveLeft(sender As Object, e As LeftReceiveMessage) Handles myConnection.ReceiveLeft
        SyncLock myPlayers
            myPlayers.Remove(e.UserID)
        End SyncLock

        RaiseEvent RemoveUser(Me, e)
    End Sub

    Private myCrown As InternalPlayer

    Friend ReadOnly Property Crown As InternalPlayer
        Get
            Return myCrown
        End Get
    End Property

#End Region

End Class
