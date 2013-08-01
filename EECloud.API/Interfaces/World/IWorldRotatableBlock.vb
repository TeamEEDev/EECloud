''' <summary>
''' Represents a RotatableBlock in a world
''' </summary>
Public Interface IWorldRotatableBlock

    Inherits IWorldBlock

    ''' <summary>
    ''' Returns the rotation associated with this RotatableBlock.
    ''' </summary>
    ReadOnly Property Rotation As Integer

End Interface
