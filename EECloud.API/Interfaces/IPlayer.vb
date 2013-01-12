Friend Interface IPlayer
    Event GroupChange As EventHandler
    Event LoadUserData As EventHandler(Of UserData)
    Event UserDataReady As EventHandler
    Event SaveUserData As EventHandler

    ReadOnly Property UserID As Integer
    ReadOnly Property Username As String
    ReadOnly Property Smiley As Smiley
    ReadOnly Property PlayerPosX As Integer
    ReadOnly Property PlayerPosY As Integer
    ReadOnly Property BlockX As Integer
    ReadOnly Property BlockY As Integer
    ReadOnly Property IsGod As Boolean
    ReadOnly Property IsMod As Boolean
    ReadOnly Property HasChat As Boolean
    ReadOnly Property Coins As Integer
    ReadOnly Property IsMyFriend As Boolean
    ReadOnly Property SpeedX As Double
    ReadOnly Property SpeedY As Double
    ReadOnly Property ModifierX As Double
    ReadOnly Property ModifierY As Double
    ReadOnly Property Horizontal As Double
    ReadOnly Property Vertical As Double
    ReadOnly Property HasSilverCrown As Boolean
    ReadOnly Property HasCrown As Boolean
    ReadOnly Property RedAuraPotion As Boolean
    ReadOnly Property BlueAuraPotion As Boolean
    ReadOnly Property YellowAuraPotion As Boolean
    ReadOnly Property JumpPotion As Boolean
    ReadOnly Property GreenAuraPotion As Boolean
    ReadOnly Property SpawnX As Integer
    ReadOnly Property SpawnY As Integer
    ReadOnly Property Say As String
    ReadOnly Property AutoText As String
    ReadOnly Property IsUserDataReady As Boolean
    ReadOnly Property MagicClass As MagicClass
    ReadOnly Property IsClubMember As Boolean
    ReadOnly Property IsDisconnected As Boolean
    ReadOnly Property IsGuest As Boolean
    ReadOnly Property DatabaseName As String
    ReadOnly Property LastPotion As Potion?
    ReadOnly Property LastPotionEnabled As Boolean
    ReadOnly Property LastPotionTimeout As Integer

    Property Group As Group

    Sub Save()
    Sub ReloadUserData()
    Function ReloadUserDataAsync() As Task
    Sub Reply(msg As String)
    Sub Kick(msg As String)
    Sub GiveEdit()
    Sub RemoveEdit()
    Sub Kill()
End Interface