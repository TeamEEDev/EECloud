Friend NotInheritable Class InternalPlayer
    Implements IPlayer

#Region "Fields"
    Private WithEvents myConnection As IConnection
    Private ReadOnly myClient As IClient(Of Player)
#End Region

#Region "Events"
    Public Event GroupChange(sender As Object, e As ItemChangedEventArgs(Of Group)) Implements IPlayer.GroupChange

    Public Event LoadUserData(sender As Object, e As UserData) Implements IPlayer.LoadUserData
#End Region

#Region "Properties"
    Private myCoins As Integer

    Friend ReadOnly Property Coins As Integer Implements IPlayer.Coins
        Get
            Return myCoins
        End Get
    End Property

    Private myPlayerPosX As Integer

    Friend ReadOnly Property PlayerPosX As Integer Implements IPlayer.PlayerPosX
        Get
            Return myPlayerPosX
        End Get
    End Property

    Private myPlayerPosY As Integer

    Friend ReadOnly Property PlayerPosY As Integer Implements IPlayer.PlayerPosY
        Get
            Return myPlayerPosY
        End Get
    End Property

    Private ReadOnly myUserID As Integer

    Friend ReadOnly Property UserID As Integer Implements IPlayer.UserID
        Get
            Return myUserID
        End Get
    End Property

    Private ReadOnly myUsername As String

    Friend ReadOnly Property Username As String Implements IPlayer.Username
        Get
            Return myUsername
        End Get
    End Property

    Private mySmiley As Smiley

    Friend ReadOnly Property Smiley As Smiley Implements IPlayer.Smiley
        Get
            Return mySmiley
        End Get
    End Property

    Private ReadOnly myHasChat As Boolean

    Friend ReadOnly Property HasChat As Boolean Implements IPlayer.HasChat
        Get
            Return myHasChat
        End Get
    End Property

    Private myHorizontal As Double

    Friend ReadOnly Property Horizontal As Double Implements IPlayer.Horizontal
        Get
            Return myHorizontal
        End Get
    End Property

    Private myIsGod As Boolean

    Friend ReadOnly Property IsGod As Boolean Implements IPlayer.IsGod
        Get
            Return myIsGod
        End Get
    End Property

    Private myIsMod As Boolean

    Friend ReadOnly Property IsMod As Boolean Implements IPlayer.IsMod
        Get
            Return myIsMod
        End Get
    End Property

    Private ReadOnly myIsMyFriend As Boolean

    Friend ReadOnly Property IsMyFriend As Boolean Implements IPlayer.IsMyFriend
        Get
            Return myIsMyFriend
        End Get
    End Property

    Private myModifierX As Double

    Friend ReadOnly Property ModifierX As Double Implements IPlayer.ModifierX
        Get
            Return myModifierX
        End Get
    End Property

    Private myModifierY As Double

    Friend ReadOnly Property ModifierY As Double Implements IPlayer.ModifierY
        Get
            Return myModifierY
        End Get
    End Property

    Private mySpeedX As Double

    Friend ReadOnly Property SpeedX As Double Implements IPlayer.SpeedX
        Get
            Return mySpeedX
        End Get
    End Property

    Private mySpeedY As Double

    Friend ReadOnly Property SpeedY As Double Implements IPlayer.SpeedY
        Get
            Return mySpeedY
        End Get
    End Property

    Private myVertical As Double

    Friend ReadOnly Property Vertical As Double Implements IPlayer.Vertical
        Get
            Return myVertical
        End Get
    End Property

    Private myHasSilverCrown As Boolean

    Friend ReadOnly Property HasSilverCrown As Boolean Implements IPlayer.HasSilverCrown
        Get
            Return myHasSilverCrown
        End Get
    End Property

    Friend ReadOnly Property HasCrown As Boolean Implements IPlayer.HasCrown
        Get
            Try
                Return myClient.PlayerManager.Crown.UserID = myUserID
            Catch
                Return False
            End Try
        End Get
    End Property

    Private myGroup As Group

    Public Property Group As Group Implements IPlayer.Group
        Get
            Return myGroup
        End Get

        Set(value As Group)
            RaiseEvent GroupChange(Me, New ItemChangedEventArgs(Of Group)(myGroup, value))

            myGroup = value
            Cloud.Service.SetPlayerDataGroupID(Username, CShort(value))
        End Set
    End Property

    Private myBlueAuraPotion As Boolean

    Public ReadOnly Property BlueAuraPotion As Boolean Implements IPlayer.BlueAuraPotion
        Get
            Return myBlueAuraPotion
        End Get
    End Property

    Private myRedAuraPotion As Boolean

    Public ReadOnly Property RedAuraPotion As Boolean Implements IPlayer.RedAuraPotion
        Get
            Return myRedAuraPotion
        End Get
    End Property

    Private myYellowAuraPotion As Boolean

    Public ReadOnly Property YellowAuraPotion As Boolean Implements IPlayer.YellowAuraPotion
        Get
            Return myYellowAuraPotion
        End Get
    End Property

    Private ReadOnly mySpawnX As Integer

    Public ReadOnly Property SpawnX As Integer Implements IPlayer.SpawnX
        Get
            Return mySpawnX
        End Get
    End Property

    Private ReadOnly mySpawnY As Integer

    Public ReadOnly Property SpawnY As Integer Implements IPlayer.SpawnY
        Get
            Return mySpawnY
        End Get
    End Property

    Public ReadOnly Property BlockX As Integer Implements IPlayer.BlockX
        Get
            Return myPlayerPosX + 8 >> 4
        End Get
    End Property

    Public ReadOnly Property BlockY As Integer Implements IPlayer.BlockY
        Get
            Return myPlayerPosY + 8 >> 4
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(client As IClient(Of Player), addMessage As AddReceiveMessage)
        myClient = client
        myConnection = client.Connection
        myUserID = addMessage.UserID
        myUsername = addMessage.Username.ToLower
        mySmiley = addMessage.Face
        myHasChat = addMessage.HasChat
        myIsGod = addMessage.IsGod
        myIsMod = addMessage.IsMod
        myIsMyFriend = addMessage.IsMyFriend
        myCoins = addMessage.Coins
        myPlayerPosX = addMessage.PlayerPosX
        myPlayerPosY = addMessage.PlayerPosY
        mySpawnX = addMessage.PlayerPosX
        mySpawnY = addMessage.PlayerPosY
    End Sub

    Friend Sub New(client As IClient(Of Player), initMessage As InitReceiveMessage)
        myClient = client
        myConnection = client.Connection
        myUserID = initMessage.UserID
        myUsername = initMessage.Username.ToLower
        myPlayerPosX = initMessage.SpawnX
        myPlayerPosY = initMessage.SpawnY
        mySpawnX = initMessage.SpawnX
        mySpawnY = initMessage.SpawnY
    End Sub

    Friend Sub ReloadUserData() Implements IPlayer.ReloadUserData
        Dim userData As UserData = Cloud.Service.GetPlayerData(myUsername)
        If userData IsNot Nothing Then
            myGroup = CType(userData.GroupID, Group)
            RaiseEvent LoadUserData(Me, userData)
        End If
    End Sub

    Public Sub Reply(msg As String) Implements IPlayer.Reply
        myClient.Chatter.Reply(myUsername, msg)
    End Sub

    Private Sub myConnection_OnReceiveCoin(sender As Object, e As CoinReceiveMessage) Handles myConnection.ReceiveCoin
        If e.UserID = myUserID Then
            myCoins = e.Coins
        End If
    End Sub

    Private Sub myConnection_OnReceiveFace(sender As Object, e As FaceReceiveMessage) Handles myConnection.ReceiveFace
        If e.UserID = myUserID Then
            mySmiley = e.Face
        End If
    End Sub

    Private Sub myConnection_OnReceiveMove(sender As Object, e As MoveReceiveMessage) Handles myConnection.ReceiveMove
        If e.UserID = myUserID Then
            myCoins = e.Coins
            myHorizontal = e.Horizontal
            myVertical = e.Vertical
            myModifierX = e.ModifierX
            myModifierY = e.ModifierY
            mySpeedX = e.SpeedX
            mySpeedY = e.SpeedY
            myPlayerPosX = e.PlayerPosX
            myPlayerPosY = e.PlayerPosY
        End If
    End Sub

    Private Sub myConnection_OnReceiveGodMode(sender As Object, e As GodModeReceiveMessage) Handles myConnection.ReceiveGodMode
        If e.UserID = myUserID Then
            myIsGod = e.IsGod
        End If
    End Sub

    Private Sub myConnection_OnReceiveModMode(sender As Object, e As ModModeReceiveMessage) Handles myConnection.ReceiveModMode
        If e.UserID = myUserID Then
            myIsMod = True
        End If
    End Sub

    Private Sub myConnection_OnReceiveSilverCrown(sender As Object, e As SilverCrownReceiveMessage) Handles myConnection.ReceiveSilverCrown
        If e.UserID = myUserID Then
            myHasSilverCrown = True
        End If
    End Sub

    Private Sub myConnection_OnReceiveTeleport(sender As Object, e As TeleportReceiveMessage) Handles myConnection.ReceiveTeleport
        If e.Coordinates.ContainsKey(myUserID) Then
            Dim loc As Location = e.Coordinates(myUserID)
            myPlayerPosX = loc.X
            myPlayerPosY = loc.Y

            If e.ResetCoins = True Then
                myCoins = 0
            End If
        End If
    End Sub

    Private Sub myConnection_ReceiveLeft(sender As Object, e As LeftReceiveMessage) Handles myConnection.ReceiveLeft
        myConnection = Nothing
    End Sub

    Private Sub myConnection_ReceivePotion(sender As Object, e As PotionReceiveMessage) Handles myConnection.ReceivePotion
        If e.UserID = myUserID Then
            Select Case e.Potion
                Case Potion.RedAura
                    myRedAuraPotion = e.Enabled
                Case Potion.BlueAura
                    myBlueAuraPotion = e.Enabled
                Case Potion.YellowAura
                    myYellowAuraPotion = e.Enabled
            End Select
        End If
    End Sub

    Private Sub myConnection_ReceiveSay(sender As Object, e As SayReceiveMessage) Handles myConnection.ReceiveSay
        If e.UserID = myUserID Then
        End If
    End Sub

    Public Sub Kick(msg As String) Implements IPlayer.Kick
        myClient.Chatter.Kick(myUsername, msg)
    End Sub

#End Region
End Class
