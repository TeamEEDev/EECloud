Public Interface IGame

    ReadOnly Property WorldName As String
    ReadOnly Property Owner As String
    ReadOnly Property Plays As Integer
    ReadOnly Property CurrentWoots As Integer
    ReadOnly Property TotalWoots As Integer

    ReadOnly Property AccessRight As AccessRight
    ReadOnly Property Encryption As String

    ReadOnly Property GravityMultiplier As Double
    ReadOnly Property AllowPotions As Boolean
    ReadOnly Property IsTutorialRoom As Boolean

    ReadOnly Property MyPlayer As Player

End Interface
