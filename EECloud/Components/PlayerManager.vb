Friend Class PlayerManager(Of P As {Player, New})
    Implements IPlayerManager(Of P)

#Region "Fields"
    Private WithEvents myInternalPlayerManager As InternalPlayerManager
    Private WithEvents myConnection As IConnection(Of P)
#End Region

#Region "Properties"
    Private myPlayersDictionary As New Dictionary(Of Integer, P)
    Public ReadOnly Property Players(number As Integer) As P Implements IPlayerManager(Of P).Players
        Get
            If myPlayersDictionary.ContainsKey(number) Then
                Return myPlayersDictionary(number)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Players As IEnumerable(Of P) Implements IPlayerManager(Of P).Players
        Get
            Try
                Return myPlayersDictionary.Values
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Private myCrown As P
    Public ReadOnly Property Crown As P Implements IPlayerManager(Of P).Crown
        Get
            Return myCrown
        End Get
    End Property
#End Region

#Region "Methods"
    Sub New(connection As Connection(Of P), internalPlayerManager As InternalPlayerManager)
        myConnection = connection
        myInternalPlayerManager = internalPlayerManager
        For Each Player As InternalPlayer In myInternalPlayerManager.Players.Values
            AddPlayer(Player)
        Next
    End Sub

    Private Sub myInternalPlayerManager_OnRemoveUser(sender As Object, e As Left_ReceiveMessage) Handles myInternalPlayerManager.OnRemoveUser
        Try
            myPlayersDictionary.Remove(e.UserID)
        Catch
        End Try
    End Sub

    Private Sub myInternalPlayerManager_OnAddUser(sender As Object, e As InternalPlayer) Handles myInternalPlayerManager.OnAddUser
        AddPlayer(e)
    End Sub

    Private Sub AddPlayer(player As InternalPlayer)
        If Not myPlayersDictionary.ContainsKey(player.UserID) Then
            Dim myPlayer As New P
            myPlayer.SetupPlayer(player)
            myPlayersDictionary.Add(player.UserID, myPlayer)
        End If
    End Sub
#End Region
End Class
