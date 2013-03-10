''' <summary>
'''     Represents a PortalBlock in a world
''' </summary>
''' <remarks></remarks>
Public Interface IWorldWorldPortalBlock
    Inherits IWorldBlock

    ''' <summary>
    '''     Returns the PortalTarget associated with a portal block
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property PortalTarget As String
End Interface
