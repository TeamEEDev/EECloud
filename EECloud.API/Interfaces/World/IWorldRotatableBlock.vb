''' <summary>
''' Represents a rotatable block in a world
''' </summary>
''' <remarks></remarks>
Public Interface IWorldRotatableBlock
    Inherits IWorldBlock

    ''' <summary>
    ''' Returns the rotation associated with a rotatable block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Rotation As Integer
End Interface

