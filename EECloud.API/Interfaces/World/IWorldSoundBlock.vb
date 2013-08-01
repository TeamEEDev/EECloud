''' <summary>
''' Represents a SoundBlock in a world
''' </summary>
Public Interface IWorldSoundBlock

    Inherits IWorldBlock

    ''' <summary>
    ''' Returns the SoundID associated with this SoundBlock.
    ''' </summary>
    ReadOnly Property SoundID As Integer

End Interface
