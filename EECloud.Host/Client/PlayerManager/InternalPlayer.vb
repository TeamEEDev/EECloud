Friend NotInheritable Class InternalPlayer
    Implements IPlayer

#Region "Fields"
    Private WithEvents myConnection As IConnection
    Private ReadOnly myClient As IClient(Of Player)
#End Region

#Region "Events"
    Friend Event GroupChange(sender As Object, e As EventArgs) Implements IPlayer.GroupChange

    Friend Event LoadUserData(sender As Object, e As UserData) Implements IPlayer.LoadUserData

    Public Event UserDataReady(sender As Object, e As EventArgs) Implements IPlayer.UserDataReady

    Public Event SaveUserData(sender As Object, e As EventArgs) Implements IPlayer.SaveUserData
#End Region

#Region "Properties"
    Private ReadOnly myUsername As String

    Friend ReadOnly Property Username As String Implements IPlayer.Username
        Get
            Return myUsername
        End Get
    End Property

    Private ReadOnly myUserID As Integer

    Friend ReadOnly Property UserID As Integer Implements IPlayer.UserID
        Get
            Return myUserID
        End Get
    End Property

    Private myIsUserDataReady As Boolean

    Public ReadOnly Property IsUserDataReady As Boolean Implements IPlayer.IsUserDataReady
        Get
            Return myIsUserDataReady
        End Get
    End Property

    Public ReadOnly Property DatabaseName As String Implements IPlayer.DatabaseName
        Get
            If IsGuest Then
                Return "guest"
            Else
                Return Username
            End If
        End Get
    End Property

    Private myGroup As Group

    Friend Property Group As Group Implements IPlayer.Group
        Get
            Return myGroup
        End Get

        Set(value As Group)
            myGroup = value
            RaiseEvent GroupChange(Me, EventArgs.Empty)
        End Set
    End Property

    Public ReadOnly Property IsGuest As Boolean Implements IPlayer.IsGuest
        Get
            'Not my fault for this being the way it is done in the swf
            Return Username.Contains("-"c)
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

    Private ReadOnly myIsClubMember As Boolean

    Public ReadOnly Property IsClubMember As Boolean Implements IPlayer.IsClubMember
        Get
            Return myIsClubMember
        End Get
    End Property

    Private myIsDisconnected As Boolean

    Public ReadOnly Property IsDisconnected As Boolean Implements IPlayer.IsDisconnected
        Get
            Return myIsDisconnected
        End Get
    End Property

    Private ReadOnly myHasChat As Boolean

    Friend ReadOnly Property HasChat As Boolean Implements IPlayer.HasChat
        Get
            Return myHasChat
        End Get
    End Property

    Private myMagicClass As MagicClass

    Public ReadOnly Property MagicClass As MagicClass Implements IPlayer.MagicClass
        Get
            Return myMagicClass
        End Get
    End Property

    Private mySmiley As Smiley

    Friend ReadOnly Property Smiley As Smiley Implements IPlayer.Smiley
        Get
            Return mySmiley
        End Get
    End Property

    Private myCoins As Integer

    Friend ReadOnly Property Coins As Integer Implements IPlayer.Coins
        Get
            Return myCoins
        End Get
    End Property

    Private ReadOnly mySpawnX As Integer

    Friend ReadOnly Property SpawnX As Integer Implements IPlayer.SpawnX
        Get
            Return mySpawnX
        End Get
    End Property

    Private ReadOnly mySpawnY As Integer

    Friend ReadOnly Property SpawnY As Integer Implements IPlayer.SpawnY
        Get
            Return mySpawnY
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

    Friend ReadOnly Property BlockX As Integer Implements IPlayer.BlockX
        Get
            Return myPlayerPosX + 8 >> 4
        End Get
    End Property

    Friend ReadOnly Property BlockY As Integer Implements IPlayer.BlockY
        Get
            Return myPlayerPosY + 8 >> 4
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

    Private myVertical As Double

    Friend ReadOnly Property Vertical As Double Implements IPlayer.Vertical
        Get
            Return myVertical
        End Get
    End Property

    Private myHorizontal As Double

    Friend ReadOnly Property Horizontal As Double Implements IPlayer.Horizontal
        Get
            Return myHorizontal
        End Get
    End Property

    Private mySay As String = Nothing

    Friend ReadOnly Property Say As String Implements IPlayer.Say
        Get
            Return mySay
        End Get
    End Property

    Private myAutoText As String

    Friend ReadOnly Property AutoText As String Implements IPlayer.AutoText
        Get
            Return myAutoText
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

    Private myHasSilverCrown As Boolean

    Friend ReadOnly Property HasSilverCrown As Boolean Implements IPlayer.HasSilverCrown
        Get
            Return myHasSilverCrown
        End Get
    End Property

    Private myRedAuraPotion As Boolean

    Friend ReadOnly Property RedAuraPotion As Boolean Implements IPlayer.RedAuraPotion
        Get
            Return myRedAuraPotion
        End Get
    End Property

    Private myBlueAuraPotion As Boolean

    Friend ReadOnly Property BlueAuraPotion As Boolean Implements IPlayer.BlueAuraPotion
        Get
            Return myBlueAuraPotion
        End Get
    End Property

    Private myYellowAuraPotion As Boolean

    Friend ReadOnly Property YellowAuraPotion As Boolean Implements IPlayer.YellowAuraPotion
        Get
            Return myYellowAuraPotion
        End Get
    End Property

    Private myGreenAuraPotion As Boolean

    Public ReadOnly Property GreenAuraPotion As Boolean Implements IPlayer.GreenAuraPotion
        Get
            Return myGreenAuraPotion
        End Get
    End Property

    Private myJumpPotion As Boolean

    Public ReadOnly Property JumpPotion As Boolean Implements IPlayer.JumpPotion
        Get
            Return myJumpPotion
        End Get
    End Property

    Private myCursePotion As Boolean

    Public ReadOnly Property CursePotion As Boolean Implements IPlayer.CursePotion
        Get
            Return myCursePotion
        End Get
    End Property

    Private myFirePotion As Boolean

    Public ReadOnly Property FirePotion As Boolean Implements IPlayer.FirePotion
        Get
            Return myFirePotion
        End Get
    End Property

    Private myProtectionPotion As Boolean

    Public ReadOnly Property ProtectionPotion As Boolean Implements IPlayer.ProtectionPotion
        Get
            Return myProtectionPotion
        End Get
    End Property

    Private myLastPotion As Potion?

    Public ReadOnly Property LastPotion As Potion? Implements IPlayer.LastPotion
        Get
            Return myLastPotion
        End Get
    End Property

    Private myLastPotionEnabled As Boolean

    Public ReadOnly Property LastPotionEnabled As Boolean Implements IPlayer.LastPotionEnabled
        Get
            Return myLastPotionEnabled
        End Get
    End Property

    Private myLastPotionTimeout As Integer

    Public ReadOnly Property LastPotionTimeout As Integer Implements IPlayer.LastPotionTimeout
        Get
            Return myLastPotionTimeout
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(client As IClient(Of Player), addMessage As AddReceiveMessage)
        myClient = client
        myConnection = client.Connection
        myUserID = addMessage.UserID
        myUsername = addMessage.Username.ToLower(InvariantCulture)
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
        myIsClubMember = addMessage.IsClubMember
        myMagicClass = addMessage.MagicClass
        myJumpPotion = addMessage.IsPurple
    End Sub

    Friend Sub New(client As IClient(Of Player), initMessage As InitReceiveMessage)
        myClient = client
        myConnection = client.Connection
        myUserID = initMessage.UserID
        myUsername = initMessage.Username.ToLower(InvariantCulture)
        myPlayerPosX = initMessage.SpawnX
        myPlayerPosY = initMessage.SpawnY
        mySpawnX = initMessage.SpawnX
        mySpawnY = initMessage.SpawnY
    End Sub

    Friend Sub ReloadUserData() Implements IPlayer.ReloadUserData
        Dim userData As UserData = Cloud.Service.GetPlayerData(DatabaseName)
        If userData IsNot Nothing Then
            myGroup = CType(userData.GroupID, Group)
            RaiseEvent LoadUserData(Me, userData)
        End If

        If Not myIsUserDataReady Then
            myIsUserDataReady = True
            RaiseEvent UserDataReady(Me, EventArgs.Empty)
        End If
    End Sub

    Public Async Function ReloadUserDataAsync() As Task Implements IPlayer.ReloadUserDataAsync
        Dim userData As UserData
        Await Task.Run(Sub() userData = Cloud.Service.GetPlayerData(DatabaseName))
        If userData IsNot Nothing Then
            ' ReSharper disable VBWarnings::BC42104
            myGroup = userData.GroupID
            ' ReSharper restore VBWarnings::BC42104
            RaiseEvent LoadUserData(Me, userData)
        End If

        If Not myIsUserDataReady Then
            myIsUserDataReady = True
            RaiseEvent UserDataReady(Me, EventArgs.Empty)
        End If
    End Function

    Friend Sub Reply(msg As String) Implements IPlayer.Reply
        myClient.Chatter.Reply(myUsername, msg)
    End Sub

    Public Sub GiveEdit() Implements IPlayer.GiveEdit
        myClient.Chatter.GiveEdit(Username)
    End Sub

    Public Sub RemoveEdit() Implements IPlayer.RemoveEdit
        myClient.Chatter.RemoveEdit(Username)
    End Sub

    Private Sub myConnection_PreviewReceiveAutoText(sender As Object, e As AutoTextReceiveMessage) Handles myConnection.PreviewReceiveAutoText
        If e.UserID = myUserID Then
            myAutoText = e.AutoText
        End If
    End Sub

    Private Sub myConnection_OnReceiveCoin(sender As Object, e As CoinReceiveMessage) Handles myConnection.PreviewReceiveCoin
        If e.UserID = myUserID Then
            myCoins = e.Coins
        End If
    End Sub

    Private Sub myConnection_OnReceiveFace(sender As Object, e As FaceReceiveMessage) Handles myConnection.PreviewReceiveFace
        If e.UserID = myUserID Then
            mySmiley = e.Face
        End If
    End Sub

    Private Sub myConnection_OnReceiveMove(sender As Object, e As MoveReceiveMessage) Handles myConnection.PreviewReceiveMove
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

    Private Sub myConnection_OnReceiveGodMode(sender As Object, e As GodModeReceiveMessage) Handles myConnection.PreviewReceiveGodMode
        If e.UserID = myUserID Then
            myIsGod = e.IsGod
        End If
    End Sub

    Private Sub myConnection_OnReceiveModMode(sender As Object, e As ModModeReceiveMessage) Handles myConnection.PreviewReceiveModMode
        If e.UserID = myUserID Then
            myIsMod = True
        End If
    End Sub

    Private Sub myConnection_OnReceiveSilverCrown(sender As Object, e As SilverCrownReceiveMessage) Handles myConnection.PreviewReceiveSilverCrown
        If e.UserID = myUserID Then
            myHasSilverCrown = True
        End If
    End Sub

    Private Sub myConnection_OnReceiveTeleport(sender As Object, e As TeleportReceiveMessage) Handles myConnection.PreviewReceiveTeleport
        If e.Coordinates.ContainsKey(myUserID) Then
            Dim loc = e.Coordinates.Item(myUserID)
            myPlayerPosX = loc.X
            myPlayerPosY = loc.Y

            If e.ResetCoins = True Then
                myCoins = 0
            End If
        End If
    End Sub

    Private Sub myConnection_ReceiveLeft(sender As Object, e As LeftReceiveMessage) Handles myConnection.PreviewReceiveLeft
        If e.UserID = myUserID Then
            myConnection = Nothing
            myIsDisconnected = True
        End If
    End Sub

    Private Sub myConnection_ReceivePotion(sender As Object, e As PotionReceiveMessage) Handles myConnection.PreviewReceivePotion
        If e.UserID = myUserID Then
            myLastPotion = e.Potion
            myLastPotionEnabled = e.Enabled
            myLastPotionTimeout = e.Timeout

            Select Case e.Potion
                Case Potion.RedAura
                    myRedAuraPotion = e.Enabled
                Case Potion.BlueAura
                    myBlueAuraPotion = e.Enabled
                Case Potion.YellowAura
                    myYellowAuraPotion = e.Enabled
                Case Potion.GreenAura
                    myGreenAuraPotion = e.Enabled
                Case Potion.Jump
                    myJumpPotion = e.Enabled
                Case Potion.Curse
                    myCursePotion = e.Enabled
                Case Potion.Fire
                    myFirePotion = e.Enabled
                Case Potion.Protection
                    myProtectionPotion = e.Enabled
            End Select
        End If
    End Sub

    Private Sub myConnection_ReceiveSay(sender As Object, e As SayReceiveMessage) Handles myConnection.PreviewReceiveSay
        If e.UserID = myUserID Then
            mySay = e.Text
        End If
    End Sub

    Private Sub myConnection_PreviewReceiveLevelUp(sender As Object, e As LevelUpReceiveMessage) Handles myConnection.PreviewReceiveLevelUp
        If e.UserID = myUserID Then
            myMagicClass = e.NewClass
        End If
    End Sub

    Friend Sub Kick(msg As String) Implements IPlayer.Kick
        myClient.Chatter.Kick(myUsername, msg)
    End Sub

    Public Sub Save() Implements IPlayer.Save
        Cloud.Service.SetPlayerDataGroupID(DatabaseName, CShort(Group))
        RaiseEvent SaveUserData(Me, EventArgs.Empty)
    End Sub

    Public Sub Kill() Implements IPlayer.Kill
        myClient.Chatter.Kill(myUsername)
    End Sub

    Public Sub Teleport() Implements IPlayer.Teleport
        myClient.Chatter.Teleport(Username)
    End Sub

    Public Sub Teleport(x As Integer, y As Integer) Implements IPlayer.Teleport
        myClient.Chatter.Teleport(Username, x, y)
    End Sub

    Public Sub Kick() Implements IPlayer.Kick
        myClient.Chatter.Kick(myUsername)
    End Sub

#End Region
End Class
