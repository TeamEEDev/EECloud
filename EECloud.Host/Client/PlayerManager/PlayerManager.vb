Friend NotInheritable Class PlayerManager (Of TPlayer As {Player, New})
    Implements IPlayerManager(Of TPlayer), IDisposable

#Region "Fields"
    Private WithEvents myInternalPlayerManager As InternalPlayerManager
    Private WithEvents myConnection As IConnection
    Private ReadOnly myClient As IClient(Of TPlayer)
#End Region

#Region "Events"
    Friend Event Join(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).Join

    Friend Event Leave(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).Leave

    Friend Event OnCoin(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnCoin

    Friend Event OnCrown(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnCrown

    Friend Event OnGodmode(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnGodmode

    Friend Event OnModmode(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnModmode

    Friend Event OnMove(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnMove

    Friend Event OnPotion(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnPotion

    Friend Event OnSilverCrown(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnSilverCrown

    Friend Event OnSmiley(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnSmiley

    Friend Event OnAutoText(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnAutoText

    Friend Event OnSay(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnSay

    Public Event OnLevelUp(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnLevelUp

    Public Event OnMagic(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnMagic

    Public Event OnWootUp(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnWootUp

    Public Event GroupChange(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).GroupChange

    Public Event UserDataReady(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).UserDataReady

    Public Event OnTeleport(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnTeleport

    Public Event OnKill(sender As Object, e As TPlayer) Implements IPlayerManager(Of TPlayer).OnKill
#End Region

#Region "Properties"
    Private ReadOnly myIDDictionary As New Dictionary(Of Integer, TPlayer)
    Private ReadOnly myUsernameDictionary As New Dictionary(Of String, List(Of TPlayer))

    Friend ReadOnly Property Player(number As Integer) As TPlayer Implements IPlayerManager(Of TPlayer).Player
        Get
            SyncLock myUsernameDictionary
                If myIDDictionary.ContainsKey(number) Then
                    Return myIDDictionary(number)
                Else
                    Return Nothing
                End If
            End SyncLock
        End Get
    End Property

    Friend ReadOnly Property Player(username As String) As TPlayer Implements IPlayerManager(Of TPlayer).Player
        Get
            SyncLock myUsernameDictionary
                If myUsernameDictionary.ContainsKey(username.ToLower(InvariantCulture)) Then
                    Dim list As List(Of TPlayer) = myUsernameDictionary(username.ToLower(InvariantCulture))
                    If list.Count > 0 Then
                        Return list(0)
                    Else
                        Return Nothing
                    End If
                Else
                    Return Nothing
                End If
            End SyncLock
        End Get
    End Property

    Private myCrown As TPlayer

    Friend ReadOnly Property Crown As TPlayer Implements IPlayerManager(Of TPlayer).Crown
        Get
            Return myCrown
        End Get
    End Property

    Friend ReadOnly Property Count As Integer Implements IPlayerManager(Of TPlayer).Count
        Get
            Return myIDDictionary.Count
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(internalClient As InternalClient, client As IClient(Of TPlayer))
        myInternalPlayerManager = internalClient.InternalPlayerManager
        myConnection = internalClient.Connection
        myClient = client

        For Each player1 As InternalPlayer In myInternalPlayerManager.Players.Values
            AddPlayer(player1)
        Next

        If myInternalPlayerManager.Crown IsNot Nothing Then
            myCrown = Player(myInternalPlayerManager.Crown.UserID)
        End If
    End Sub

    Private Sub myInternalPlayerManager_OnRemoveUser(sender As Object, e As LeftReceiveMessage) Handles myInternalPlayerManager.RemoveUser
        Dim player1 As TPlayer = Nothing

        SyncLock myIDDictionary
            If myIDDictionary.ContainsKey(e.UserID) Then
                player1 = myIDDictionary(e.UserID)
                myIDDictionary.Remove(e.UserID)

                SyncLock myUsernameDictionary
                    If myUsernameDictionary.ContainsKey(player1.Username) Then
                        Dim list As List(Of TPlayer) = myUsernameDictionary(player1.Username)

                        For Each item In From item1 In list Where item1.UserID = e.UserID
                            list.Remove(item)
                            Exit For
                        Next
                    End If
                End SyncLock
            End If
        End SyncLock

        If player1 IsNot Nothing Then
            RaiseEvent Leave(Me, player1)
        End If
    End Sub

    Private Sub myInternalPlayerManager_OnAddUser(sender As Object, e As InternalPlayer) Handles myInternalPlayerManager.AddUser
        AddPlayer(e)
    End Sub

    Private Sub myConnection_ReceiveAutoText(sender As Object, e As AutoTextReceiveMessage) Handles myConnection.ReceiveAutoText
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnAutoText(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceiveCoin(sender As Object, e As CoinReceiveMessage) Handles myConnection.ReceiveCoin
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnCoin(Me, p)
        End If
    End Sub

    Private Sub myConnection_OnReceiveCrown(sender As Object, e As CrownReceiveMessage) Handles myConnection.ReceiveCrown
        Dim p As TPlayer = Player(e.UserID)
        myCrown = p

        If p IsNot Nothing Then
            RaiseEvent OnCrown(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceiveFace(sender As Object, e As FaceReceiveMessage) Handles myConnection.ReceiveFace
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnSmiley(Me, p)
        End If
    End Sub

    Private Sub AddPlayer(internalPlayer As InternalPlayer)
        Dim player1 As TPlayer = Nothing

        SyncLock myIDDictionary
            If Not myIDDictionary.ContainsKey(internalPlayer.UserID) Then
                player1 = New TPlayer()
                player1.SetupPlayer(internalPlayer, myClient.Chatter)
                myIDDictionary.Add(player1.UserID, player1)

                SyncLock myUsernameDictionary
                    If Not myUsernameDictionary.ContainsKey(player1.Username) Then
                        Dim list As New List(Of TPlayer)
                        list.Add(player1)
                        myUsernameDictionary.Add(player1.Username, list)
                    Else
                        myUsernameDictionary(player1.Username).Add(player1)
                    End If
                End SyncLock
            End If
        End SyncLock

        If player1 IsNot Nothing Then
            RaiseEvent Join(Me, player1)

            AddHandler player1.UserDataReady,
                Sub()
                    RaiseEvent UserDataReady(Me, player1)
                End Sub

            AddHandler player1.GroupChange,
                Sub()
                    RaiseEvent GroupChange(Me, player1)
                End Sub
        End If
    End Sub

    Private Sub myConnection_ReceiveGodMode(sender As Object, e As GodModeReceiveMessage) Handles myConnection.ReceiveGodMode
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnGodmode(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceiveKill(sender As Object, e As KillReceiveMessage) Handles myConnection.ReceiveKill
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnKill(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceiveLevelUp(sender As Object, e As LevelUpReceiveMessage) Handles myConnection.ReceiveLevelUp
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnLevelUp(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceiveMagic(sender As Object, e As MagicReceiveMessage) Handles myConnection.ReceiveMagic
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnMagic(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceiveModMode(sender As Object, e As ModModeReceiveMessage) Handles myConnection.ReceiveModMode
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnModmode(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceiveMove(sender As Object, e As MoveReceiveMessage) Handles myConnection.ReceiveMove
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnMove(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceivePotion(sender As Object, e As PotionReceiveMessage) Handles myConnection.ReceivePotion
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnPotion(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceiveSay(sender As Object, e As SayReceiveMessage) Handles myConnection.ReceiveSay
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnSay(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceiveSilverCrown(sender As Object, e As SilverCrownReceiveMessage) Handles myConnection.ReceiveSilverCrown
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnSilverCrown(Me, p)
        End If
    End Sub

    Private Sub myConnection_ReceiveTeleport(sender As Object, e As TeleportReceiveMessage) Handles myConnection.ReceiveTeleport
        Dim p As TPlayer
        For Each p1 In e.Coordinates
            p = Player(p1.Key)

            If p IsNot Nothing Then
                RaiseEvent OnTeleport(Me, p)
            End If
        Next
    End Sub

    Private Sub myConnection_ReceiveWootUp(sender As Object, e As WootUpReceiveMessage) Handles myConnection.ReceiveWootUp
        Dim p As TPlayer = Player(e.UserID)

        If p IsNot Nothing Then
            RaiseEvent OnWootUp(Me, p)
        End If
    End Sub

#End Region

#Region "IDisposable Support"
    Private myDisposedValue As Boolean

    Private Sub Dispose(disposing As Boolean)
        If Not myDisposedValue Then
            If disposing Then

            End If

            myConnection = Nothing
            myInternalPlayerManager = Nothing
        End If
        myDisposedValue = True
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(False)
        MyBase.Finalize()
    End Sub

    Friend Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of TPlayer) Implements IEnumerable(Of TPlayer).GetEnumerator
        Return myIDDictionary.Values.GetEnumerator
    End Function

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function

#End Region

End Class
