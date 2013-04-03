''' <summary>
''' Represents a Block in a world
''' </summary>
''' <remarks></remarks>
    Public Interface IWorldBlock
    ''' <summary>
    ''' Returns the BlockType of the current block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Block As Block
                                
    ''' <summary>
    ''' Returns the type of this block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property BlockType As BlockType
End Interface
