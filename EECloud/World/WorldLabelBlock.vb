Public NotInheritable Class WorldLabelBlock
    Inherits WorldBlock
    Implements IWorldLabelBlock

    Friend Sub New(block As LabelBlockType, text As String)
        MyBase.New(CType(block, BlockType))

        myText = text
    End Sub

    Private ReadOnly myText As String

    Public ReadOnly Property Text As String Implements IWorldLabelBlock.Text
        Get
            Return myText
        End Get
    End Property
End Class
