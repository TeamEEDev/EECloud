Public Class BlockPlaceEventArgs
    Inherits EventArgs

#Region "Properties"

    Private ReadOnly myX As Integer

    Public ReadOnly Property X As Integer
        Get
            Return myX
        End Get
    End Property

    Private ReadOnly myY As Integer

    Public ReadOnly Property y As Integer
        Get
            Return myY
        End Get
    End Property

    Private ReadOnly myBlock As IWorldBlock

    Public ReadOnly Property Block As IWorldBlock
        Get
            Return myBlock
        End Get
    End Property

    Private ReadOnly myLayer As Layer

    Public ReadOnly Property Layer As Layer
        Get
            Return myLayer
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(x As Integer, y As Integer, ByVal layer As Layer, block As IWorldBlock)
        myX = x
        myY = y
        myBlock = block
        myLayer = layer
    End Sub

#End Region
End Class
