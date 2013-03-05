Namespace World
    Public NotInheritable Class WorldLabelBlock
        Inherits Block
        Implements IWorldLabelBlock

#Region "Properties"

        Public Overrides ReadOnly Property BlockType As BlockType
            Get
                Return BlockType.Label
            End Get
        End Property

        Private ReadOnly myText As String

        Public ReadOnly Property Text As String Implements IWorldLabelBlock.Text
            Get
                Return myText
            End Get
        End Property

#End Region

#Region "Methods"

        Public Sub New(block As LabelBlock, text As String)
            MyBase.New(DirectCast(block, Block))
            myText = text
        End Sub

#End Region
    End Class
End Namespace
