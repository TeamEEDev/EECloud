''' <summary>
''' Represents a WorldPortalBlock in a world
''' </summary>
Public Interface IWorldWorldPortalBlock

    Inherits IWorldBlock

    ''' <summary>
    ''' Returns the PortalTarget associated with this WorldPortalBlock.
    ''' </summary>
    ReadOnly Property PortalTarget As String

End Interface
