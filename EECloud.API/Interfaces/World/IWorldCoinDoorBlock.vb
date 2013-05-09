''' <summary>
''' Represents a CoinDoorBlock in a world
''' </summary>
Public Interface IWorldCoinDoorBlock

    Inherits IWorldBlock

    ''' <summary>
    ''' Returns the amount of coins to collect to activate this CoinDoorBlock.
    ''' </summary>
    ReadOnly Property CoinsToCollect As Integer

End Interface
