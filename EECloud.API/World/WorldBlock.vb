Public Class WorldBlock
    Implements IWorldBlock

#Region "Properties"

    Private ReadOnly myBlock As Block

    Public ReadOnly Property Block As Block Implements IWorldBlock.Block
        Get
            Return myBlock
        End Get
    End Property

    Public Overridable ReadOnly Property BlockType As BlockType Implements IWorldBlock.BlockType
        Get
            Return BlockType.Normal
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(block As Block)
        myBlock = block
    End Sub

#End Region
End Class
