Public Interface IGame
    Property WorldName As String
    WriteOnly Property Location As Location
    WriteOnly Property Smiley As Smiley
    WriteOnly Property GodMode As Boolean

    ReadOnly Property AccessRight As AccessRight
    ReadOnly Property Encryption As String
    ReadOnly Property Plays As Integer
    ReadOnly Property Owner As String
    ReadOnly Property MyPlayer As Player
    ReadOnly Property RedAuraPotionCount As Integer
    ReadOnly Property BlueAuraPotionCount As Integer
    ReadOnly Property YellowAuraPotionCount As Integer
    ReadOnly Property GravityMultiplayer As Double
    ReadOnly Property IsTutorialRoom As Boolean
    ReadOnly Property AllowPotions As Boolean
End Interface
