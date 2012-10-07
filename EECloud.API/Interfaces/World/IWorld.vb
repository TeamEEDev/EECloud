Public Interface IWorld
    ReadOnly Property Encryption As String

    Default ReadOnly Property Item(x As Integer, y As Integer, Optional layer As Layer = Layer.Foreground) As IWorldBlock
End Interface
