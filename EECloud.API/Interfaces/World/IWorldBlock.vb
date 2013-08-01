''' <summary>
''' Represents a Block in a world
''' </summary>
Public Interface IWorldBlock

    ''' <summary>
    ''' Returns the ID of this Block.
    ''' </summary>
    ReadOnly Property Block As Block

    ''' <summary>
    ''' Returns the type of this Block.
    ''' </summary>
    ReadOnly Property BlockType As BlockType

End Interface
