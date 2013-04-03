''' <summary>
''' Represents a CoinDoorBlock in a world
''' </summary>
''' <remarks></remarks>
Public Interface IWorldCoinDoorBlock
    Inherits IWorldBlock

    ''' <summary>
    ''' Returns the CoinsToCollect associated with a coin door
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property CoinsToCollect As Integer
End Interface
