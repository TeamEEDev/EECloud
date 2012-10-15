Friend NotInheritable Class PlayerManager (Of TPlayer As {Player, New})
    Implements IPlayerManager(Of TPlayer)

#Region "Fields"
    Private WithEvents myInternalPlayerManager As InternalPlayerManager
    Private WithEvents myConnection As IConnection
    Private ReadOnly myClient As InternalClient
#End Region

#Region "Events"
    Public Event Join(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).Join

    Public Event Leave(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).Leave
#End Region

#Region "Properties"
    Private ReadOnly myPlayersDictionary As New Dictionary(Of Integer, TPlayer)

    Friend ReadOnly Property Player(number As Integer) As TPlayer Implements IPlayerManager(Of TPlayer).Player
        Get
            If myPlayersDictionary.ContainsKey(number) Then
                Return myPlayersDictionary(number)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Player(username As String) As TPlayer Implements IPlayerManager(Of TPlayer).Player
        Get
            For Each player1 As TPlayer In myPlayersDictionary.Values
                If player1.Username = username Then
                    Return player1
                End If
            Next
            Return Nothing
        End Get
    End Property

    Friend ReadOnly Property GetPlayers As TPlayer() Implements IPlayerManager(Of TPlayer).GetPlayers
        Get
            Return myPlayersDictionary.Values.ToArray
        End Get
    End Property

    Private myCrown As TPlayer

    Friend ReadOnly Property Crown As TPlayer Implements IPlayerManager(Of TPlayer).Crown
        Get
            Return myCrown
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(internalClient As InternalClient)
        myInternalPlayerManager = internalClient.InternalPlayerManager
        myConnection = internalClient.Connection
        myClient = internalClient

        For Each player1 As InternalPlayer In myInternalPlayerManager.Players.Values
            AddPlayer(player1)
        Next

        If myInternalPlayerManager.Crown IsNot Nothing Then
            myCrown = Player(myInternalPlayerManager.Crown.UserID)
        End If
    End Sub

    Private Sub myInternalPlayerManager_OnRemoveUser(sender As Object, e As LeftReceiveMessage) Handles myInternalPlayerManager.RemoveUser
        If myPlayersDictionary.ContainsKey(e.UserID) Then
            RaiseEvent Leave(Me, myPlayersDictionary(e.UserID))

            myPlayersDictionary.Remove(e.UserID)
        End If
    End Sub

    Private Sub myInternalPlayerManager_OnAddUser(sender As Object, e As InternalPlayer) Handles myInternalPlayerManager.AddUser
        AddPlayer(e)
    End Sub

    Private Sub myConnection_OnReceiveCrown(sender As Object, e As CrownReceiveMessage) Handles myConnection.ReceiveCrown
        myCrown = Player(e.UserID)
    End Sub

    Private Sub AddPlayer(internalPlayer As InternalPlayer)
        If Not myPlayersDictionary.ContainsKey(internalPlayer.UserID) Then
            Dim player1 As New TPlayer
            player1.SetupPlayer(internalPlayer, myClient.Chatter)
            myPlayersDictionary.Add(player1.UserID, player1)
            RaiseEvent Join(Me, player1)
        End If
    End Sub

#End Region
End Class
