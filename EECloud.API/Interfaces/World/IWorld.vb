Public Interface IWorld
    ReadOnly Property Encryption As String
    ReadOnly Property AccessRight As AccessRight
    ReadOnly Property Pos As Location

    Default ReadOnly Property Item(x As Integer, y As Integer, Optional layer As Layer = Layer.Foreground) As IWorldBlock
End Interface
