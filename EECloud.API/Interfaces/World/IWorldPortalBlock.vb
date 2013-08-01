''' <summary>
''' Represents a PortalBlock in a world
''' </summary>
Public Interface IWorldPortalBlock

    Inherits IWorldBlock

    ''' <summary>
    ''' Returns the rotation of this PortalBlock.
    ''' </summary>
    ReadOnly Property PortalRotation As PortalRotation

    ''' <summary>
    ''' Returns the PortalID associated with this PortalBlock.
    ''' </summary>
    ReadOnly Property PortalID As Integer

    ''' <summary>
    ''' Returns the PortalTarget associated with this PortalBlock.
    ''' </summary>
    ReadOnly Property PortalTarget As Integer

End Interface
