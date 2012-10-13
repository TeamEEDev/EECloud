Public Interface IGame(Of TPlayer As {New, Player})
    Event OnSave As EventHandler
    Event OnLoadLevel As EventHandler
    Event OnReset As EventHandler
    Event OnClear As EventHandler
    Event NameChange As EventHandler(Of String)

    Event AccessRigthtChange As EventHandler(Of ItemChangedEventArgs(Of AccessRight))
    Event KeyPress As EventHandler(Of Key)
    Event KeyRelease As EventHandler(Of Key)
    Event RedKeyStateChange As EventHandler(Of Boolean)
    Event BlueKeyStateChange As EventHandler(Of Boolean)
    Event GreenKeyStateChange As EventHandler(Of Boolean)

    Property WorldName As String
    WriteOnly Property Location As Location
    WriteOnly Property Smiley As Smiley
    WriteOnly Property GodMode As Boolean

    ReadOnly Property AccessRight As AccessRight
    ReadOnly Property Encryption As String
    ReadOnly Property Plays As String
    ReadOnly Property Owner As String
    ReadOnly Property MyPlayer As TPlayer
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
