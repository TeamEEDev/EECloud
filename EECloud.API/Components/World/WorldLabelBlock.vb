Public NotInheritable Class WorldLabelBlock
    Inherits WorldBlock

    Friend Sub New(layer As Layer, block As LabelBlockType, text As String)
        MyBase.New(layer, CType(block, BlockType))

        myText = text
    End Sub

    Private ReadOnly myText As String

    Public ReadOnly Property Text As String
        Get
            Return myText
        End Get
    End Property
End Class
