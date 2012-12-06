Friend Interface IPlayer
    Event GroupChange As EventHandler(Of ItemChangedEventArgs(Of Group))
    Event LoadUserData As EventHandler(Of UserData)
    Event UserDataReady As EventHandler

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
    ReadOnly Property SpawnX As Integer
    ReadOnly Property SpawnY As Integer
    ReadOnly Property Chat As String
    ReadOnly Property AutoText As AutoText
    ReadOnly Property IsUserDataReady As Boolean

    Property Group As Group

    Sub ReloadUserData()
    Sub Reply(msg As String)
    Sub Kick(msg As String)
End Interface