Public Class WorldRotatableBlock
    Inherits WorldBlock
    Implements IWorldRotatableBlock

#Region "Properties"

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return BlockType.Rotatable
        End Get
    End Property

    Private ReadOnly myRotation As Integer

    Public ReadOnly Property Rotation As Integer Implements IWorldRotatableBlock.Rotation
        Get
            Return myRotation
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(block As RotatableBlock, coinsToCollect As Integer)
        MyBase.New(DirectCast(block, Block))
        myRotation = coinsToCollect
    End Sub

#End Region
End Class
