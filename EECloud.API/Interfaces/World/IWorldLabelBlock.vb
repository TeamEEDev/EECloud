''' <summary>
''' Represents a LabelBlock in a world
''' </summary>
Public Interface IWorldLabelBlock

    Inherits IWorldBlock

    ''' <summary>
    ''' Returns the text associated with this LabelBlock.
    ''' </summary>
    ReadOnly Property Text As String

End Interface
