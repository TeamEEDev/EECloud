Public Interface IWorldPortalBlock
    Inherits IWorldBlock
    ReadOnly Property PortalRotation As PortalRotation
    ReadOnly Property PortalID As Integer
    ReadOnly Property PortalTarget As Integer
End Interface
