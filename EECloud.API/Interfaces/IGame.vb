Public Interface IGame(Of TPlayer As {New, Player})
    Event Init As EventHandler
    Event OnSave As EventHandler
    Event OnLoadLevel As EventHandler
    Event OnReset As EventHandler
    Event OnClear As EventHandler
    Event WorldNameChange As EventHandler(Of ItemChangedEventArgs(Of String))
    Event PlaysChange As EventHandler(Of ItemChangedEventArgs(Of Integer))
    Event OwnerChange As EventHandler(Of ItemChangedEventArgs(Of String))

    Event AccessRightChange As EventHandler(Of ItemChangedEventArgs(Of AccessRight))
    Event KeyPress As EventHandler(Of Key)
    Event KeyRelease As EventHandler(Of Key)

    Property WorldName As String
    WriteOnly Property Location As Location
    WriteOnly Property Smiley As Smiley
    WriteOnly Property GodMode As Boolean

    ReadOnly Property AccessRight As AccessRight
    ReadOnly Property Encryption As String
    ReadOnly Property Plays As Integer
    ReadOnly Property Owner As String
    ReadOnly Property MyPlayer As TPlayer
    ReadOnly Property RedKey As Boolean
    ReadOnly Property BlueKey As Boolean
    ReadOnly Property GreenKey As Boolean
    ReadOnly Property TimedKey As Boolean
    ReadOnly Property RedAuraPotionCount As Integer
    ReadOnly Property BlueAuraPotionCount As Integer
    ReadOnly Property YellowAuraPotionCount As Integer
    ReadOnly Property GravityMultiplayer As Double
    ReadOnly Property IsTutorialRoom As Boolean
    ReadOnly Property AllowPotions As Boolean

    Sub PressRedKey()
    Sub PressBlueKey()
    Sub PressGreenKey()
    Sub UsePotion(potion As Potion)
    Sub EnterModMode()
    Sub Save()
    Sub LoadLevel()
    Sub Reset()
    Sub Clear()
    Sub TryAccess(key As String)
End Interface
