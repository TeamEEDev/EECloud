''' <summary>
''' Represents a Block in a world object
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

    ''' <summary>
    ''' Returns the CoinsToCollect associated with a coin door
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CoinsToCollect As Integer

    ''' <summary>
    ''' Returns the PortalRotation associated with a portal block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PortalRotation As PortalRotation

    ''' <summary>
    ''' Returns the PortalID associated with a portal block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PortalID As Integer

    ''' <summary>
    ''' Returns the PortalTarget associated with a portal block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PortalTarget As Integer

    ''' <summary>
    ''' Returns the SoundID associated with a note block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SoundID As Integer

    ''' <summary>
    ''' Returns the Text associated with a label block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Text As String
End Interface
