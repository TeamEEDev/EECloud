Public Interface IGame
    Event OnSave As EventHandler
    Event OnLoadLevel As EventHandler
    Event OnReset As EventHandler
    Event OnClear As EventHandler
    Event NameChange As EventHandler(Of String)
    Event LocationChange As EventHandler(Of ItemChangedEventArgs(Of Location))
    Event SmileyChange As EventHandler(Of Smiley)
    Event GodModeChange As EventHandler(Of String)

    Property WorldName As String
    Property Location As Location
    Property Smiley As Smiley
    Property GodMode As Boolean
    Property EditKey As String

    ReadOnly Property AccessRight As AccessRight
    ReadOnly Property Encryption As String
    ReadOnly Property Plays As String
    ReadOnly Property Owner As String
    ReadOnly Property MyPlayer As Player
    ReadOnly Property RedKey As KeyState
    ReadOnly Property BlueKey As KeyState
    ReadOnly Property GreenKey As KeyState
    ReadOnly Property TimedKey As KeyState
    Sub PressRedKey()
    Sub PressBlueKey()
    Sub PressGreenKey()
    ReadOnly Property RedAuraPotionCount As Integer
    ReadOnly Property BlueAuraPotionCount As Integer
    ReadOnly Property YellowAuraPotionCount As Integer
    Sub UsePotion(potion As Potion)
    ReadOnly Property ModMode As Boolean
    Sub EnterModMode()

    Sub Save()
    Sub LoadLevel()
    Sub Reset()
    Sub Clear()
    Sub TryAccess(key As String)
End Interface
