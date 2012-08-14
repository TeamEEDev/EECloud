Public Class WorldBlock

#Region "Fields"
    Private WithEvents myConenction As Connection(Of Player)
#End Region

#Region "Properties"
    Private myX As Integer
    Public ReadOnly Property X As Integer
        Get
            Return myX
        End Get
    End Property

    Private myY As Integer
    Public ReadOnly Property Y As Integer
        Get
            Return myY
        End Get
    End Property

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
        Me.myX = x
        Me.myY = y
        Me.myBlock = block
    End Sub
#End Region
End Class
