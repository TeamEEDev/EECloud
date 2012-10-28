Public Interface IGame
    ReadOnly Property WorldName As String
    ReadOnly Property AccessRight As AccessRight
    ReadOnly Property Encryption As String
    ReadOnly Property Plays As Integer
    ReadOnly Property Owner As String
    ReadOnly Property GravityMultiplayer As Double
    ReadOnly Property IsTutorialRoom As Boolean
    ReadOnly Property AllowPotions As Boolean

    ReadOnly Property MyPlayer As Player
    ReadOnly Property RedAuraPotionCount As Integer
    ReadOnly Property BlueAuraPotionCount As Integer
    ReadOnly Property YellowAuraPotionCount As Integer
End Interface
