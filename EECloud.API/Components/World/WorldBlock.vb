Public Class WorldBlock

#Region "Properties"
    Private myLayer As Layer
    Public ReadOnly Property Layer As Layer
        Get
            Return myLayer
        End Get
    End Property

    Private myBlock As BlockType
    Public ReadOnly Property Block As BlockType
        Get
            Return myBlock
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New(layer As Layer, x As Integer, y As Integer, block As BlockType)
        Me.myBlock = block
    End Sub

    Public Shared Operator =(b1 As WorldBlock, b2 As WorldBlock) As Boolean
        Return b1.myBlock = b2.myBlock AndAlso b1.myLayer = b2.myLayer
    End Operator

    Public Shared Operator <>(b1 As WorldBlock, b2 As WorldBlock) As Boolean
        Return b1.myBlock <> b2.myBlock OrElse b1.myLayer <> b2.myLayer
    End Operator
#End Region
End Class
