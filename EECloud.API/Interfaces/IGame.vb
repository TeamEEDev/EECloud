Public Interface IGame
    Property Name As String
    Property Location As Location
    Property Smiley As Smiley
    Property GodMode As Boolean


    ReadOnly Property Encryption As String
    ReadOnly Property Plays As String
    ReadOnly Property Owner As String
    ReadOnly Property MyPlayer As Player
    ReadOnly Property RedKey As KeyState
    ReadOnly Property BlueKey As KeyState
    ReadOnly Property GreenKey As KeyState
    ReadOnly Property TimedKey As KeyState
    Sub PressKey(key As Key)
    ReadOnly Property RedAuraPotionCount As Integer
    ReadOnly Property BlueAuraPotionCount As Integer
    ReadOnly Property YellowAuraPotionCount As Integer
    Sub UsePotion(potion As Potion)
    ReadOnly Property ModMode As Boolean
    Sub EnterModMode()
End Interface
