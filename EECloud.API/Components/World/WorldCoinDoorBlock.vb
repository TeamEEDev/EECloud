Public Class WorldCoinDoorBlock
    Inherits WorldBlock

    Friend Sub New(layer As Layer, x As Integer, y As Integer, block As CoinDoorBlockType, coinsToCollect As Integer)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.myCoinsToCollect = coinsToCollect
    End Sub

    Private myCoinsToCollect As Integer
    Public ReadOnly Property CoinsToCollect As Integer
        Get
            Return myCoinsToCollect
        End Get
    End Property
End Class
