Friend Interface IPlayer
    ReadOnly Property UserID As Integer
    ReadOnly Property Username As String
    ReadOnly Property Face As Smiley
    ReadOnly Property PlayerPosX As Integer
    ReadOnly Property PlayerPosY As Integer
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

    Property Group As Group
    Property YoScrollWins As UInteger

    Function ReloadUserDataAsync() As Task
    Sub Reply(msg As String)
    Sub Kick(msg As String)
End Interface