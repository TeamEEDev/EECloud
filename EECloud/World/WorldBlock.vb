Public Class WorldBlock
    Implements IWorldBlock

#Region "Properties"

    Private ReadOnly myBlock As BlockType

    Public ReadOnly Property Block As BlockType Implements IWorldBlock.Block
        Get
            Return myBlock
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(block As BlockType)
        myBlock = block
    End Sub

    Public Shared Operator =(b1 As WorldBlock, b2 As WorldBlock) As Boolean
        Return b1.myBlock = b2.myBlock
    End Operator

    Public Shared Operator <>(b1 As WorldBlock, b2 As WorldBlock) As Boolean
        Return b1.myBlock <> b2.myBlock
    End Operator

#End Region
End Class
