Public NotInheritable Class WorldCoinDoorBlock
    Inherits WorldBlock
    Implements IWorldCoinDoorBlock

#Region "Properties"

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return BlockType.CoinDoor
        End Get
    End Property

    Private ReadOnly myCoinsToCollect As Integer

    Public ReadOnly Property CoinsToCollect As Integer Implements IWorldCoinDoorBlock.CoinsToCollect
        Get
            Return myCoinsToCollect
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(block As CoinDoorBlock, coinsToCollect As Integer)
        MyBase.New(DirectCast(block, Block))
        myCoinsToCollect = coinsToCollect
    End Sub

#End Region
End Class
