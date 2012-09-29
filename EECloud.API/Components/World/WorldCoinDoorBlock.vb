Public NotInheritable Class WorldCoinDoorBlock
    Inherits WorldBlock

    Friend Sub New(layer As Layer, block As CoinDoorBlockType, coinsToCollect As Integer)
        MyBase.New(layer, CType(block, BlockType))

        myCoinsToCollect = coinsToCollect
    End Sub

    Private ReadOnly myCoinsToCollect As Integer
    Public ReadOnly Property CoinsToCollect As Integer
        Get
            Return myCoinsToCollect
        End Get
    End Property
End Class
