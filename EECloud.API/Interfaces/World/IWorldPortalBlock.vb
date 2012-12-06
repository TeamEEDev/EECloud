

''' <summary>
'''     Represents a PortalBlock in a world
''' </summary>
''' <remarks></remarks>
    Public Interface IWorldPortalBlock
    Inherits IWorldBlock
    
    ''' <summary>
    '''     Returns the PortalRotation associated with a portal block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PortalRotation As PortalRotation
    
    ''' <summary>
    '''     Returns the PortalID associated with a portal block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PortalID As Integer
    
    ''' <summary>
    '''     Returns the PortalTarget associated with a portal block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PortalTarget As Integer
End Interface
