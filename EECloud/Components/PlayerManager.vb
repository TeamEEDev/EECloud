Friend NotInheritable Class PlayerManager(Of TPlayer As {Player, New})
    Implements IPlayerManager(Of TPlayer)

#Region "Fields"
    Private WithEvents myInternalPlayerManager As InternalPlayerManager
    Private WithEvents myConnection As Connection(Of Player)
#End Region

#Region "Properties"
    Private ReadOnly myPlayersDictionary As New Dictionary(Of Integer, TPlayer)

    Friend ReadOnly Property Players(number As Integer) As TPlayer Implements IPlayerManager(Of TPlayer).Players
        Get
            If myPlayersDictionary.ContainsKey(number) Then
                Return myPlayersDictionary(number)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Friend ReadOnly Property Players As IEnumerable(Of TPlayer) Implements IPlayerManager(Of TPlayer).Players
        Get
            Try
                Return myPlayersDictionary.Values
            Catch
                Return Nothing
            End Try
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

    Sub New(internalPlayerManager As InternalPlayerManager, ByVal connection As Connection(Of Player))
        myInternalPlayerManager = internalPlayerManager
        myConnection = connection
        For Each player As InternalPlayer In myInternalPlayerManager.Players.Values
            AddPlayer(player)
        Next
        myCrown = Players(myInternalPlayerManager.Crown.UserID)
    End Sub

    Private Sub myInternalPlayerManager_OnRemoveUser(sender As Object, e As LeftReceiveMessage) Handles myInternalPlayerManager.OnRemoveUser
        Try
            myPlayersDictionary.Remove(e.UserID)
        Catch
        End Try
    End Sub

    Private Sub myInternalPlayerManager_OnAddUser(sender As Object, e As InternalPlayer) Handles myInternalPlayerManager.OnAddUser
        AddPlayer(e)
    End Sub

    Private Sub myConnection_OnReceiveCrown(sender As Object, e As CrownReceiveMessage) Handles myConnection.OnReceiveCrown
        myCrown = Players(e.UserID)
    End Sub

    Private Sub AddPlayer(internalPlayer As InternalPlayer)
        If Not myPlayersDictionary.ContainsKey(internalPlayer.UserID) Then
            Dim player As New TPlayer
            player.SetupPlayer(player)
            myPlayersDictionary.Add(player.UserID, player)
        End If
    End Sub

#End Region
End Class
