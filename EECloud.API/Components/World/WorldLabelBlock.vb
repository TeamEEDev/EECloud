Public Class WorldLabelBlock
    Inherits WorldBlock

    Friend Sub New(layer As Layer, x As Integer, y As Integer, block As LabelBlockType, text As String)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.myText = text
    End Sub

    Private myText As String
    Public ReadOnly Property Text As String
        Get
            Return myText
        End Get
    End Property
End Class
