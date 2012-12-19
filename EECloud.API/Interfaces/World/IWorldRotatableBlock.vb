''' <summary>
'''     Represents a SoundBlock in a world
''' </summary>
''' <remarks></remarks>
Public Interface IWorldRotatableBlock
    Inherits IWorldBlock

    ''' <summary>
    '''     Returns the SoundID associated with a note block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Rotation As Integer
End Interface

