Public NotInheritable Class WorldCoinDoorBlock
    Inherits WorldBlock
    Implements IWorldCoinDoorBlock

    Friend Sub New(block As CoinDoorBlockType, coinsToCollect As Integer)
        MyBase.New(CType(block, BlockType))

        myCoinsToCollect = coinsToCollect
    End Sub

    Private ReadOnly myCoinsToCollect As Integer

    Public ReadOnly Property CoinsToCollect As Integer Implements IWorldCoinDoorBlock.CoinsToCollect
        Get
            Return myCoinsToCollect
        End Get
    End Property
End Class
