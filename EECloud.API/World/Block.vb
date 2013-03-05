Namespace World
    Public Class Block
        Implements IBlock

#Region "Properties"

        Public Overridable ReadOnly Property BlockType As BlockType Implements IBlock.BlockType
            Get
                Return BlockType.Normal
            End Get
        End Property

        Private ReadOnly myBlock As Block

        Public ReadOnly Property Block As Block Implements IBlock.Block
            Get
                Return myBlock
            End Get
        End Property

#End Region

#Region "Methods"

        Public Sub New(block As Block)
            myBlock = block
        End Sub

#End Region
    End Class
End Namespace
