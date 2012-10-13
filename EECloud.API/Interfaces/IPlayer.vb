Friend Interface IPlayer
    Event SmileyChange As EventHandler(Of ItemChangedEventArgs(Of Smiley))
    Event Move As EventHandler(Of ItemEventArgs(Of MoveReceiveMessage))
    Event SilverCrown As EventHandler
    Event GodMode As EventHandler(Of ItemChangedEventArgs(Of Boolean))
    Event ModMode As EventHandler(Of ItemChangedEventArgs(Of Boolean))
    Event Coin As EventHandler(Of ItemChangedEventArgs(Of Integer))
    Event UsePotion As EventHandler(Of ItemEventArgs(Of Potion))
    Event DeactivatePotion As EventHandler(Of ItemEventArgs(Of Potion))
    Event GroupChange As EventHandler(Of ItemChangedEventArgs(Of Group))
    Event YoScrollWinsChange As EventHandler(Of ItemChangedEventArgs(Of UInteger))

    Event Chat As EventHandler(Of ItemEventArgs(Of String))
    Event AutoText As EventHandler(Of ItemEventArgs(Of AutoText))
    Event Leave As EventHandler

    ReadOnly Property UserID As Integer
    ReadOnly Property Username As String
    ReadOnly Property Smiley As Smiley
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
    ReadOnly Property RedAuraPotion As Boolean
    ReadOnly Property BlueAuraPotion As Boolean
    ReadOnly Property YellowAuraPotion As Boolean

    Property Group As Group
    Property YoScrollWins As UInteger

    Function ReloadUserDataAsync() As Task
    Sub Reply(msg As String)
    Sub Kick(msg As String)
End Interface