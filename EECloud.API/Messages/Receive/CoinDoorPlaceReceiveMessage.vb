Imports PlayerIOClient

Public NotInheritable Class CoinDoorPlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage

    '2
    Public ReadOnly CoinDoorBlock As CoinDoorBlock
    '3
    Public ReadOnly CoinsToOpen As Integer

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), DirectCast(message.GetInteger(2), Block))

        CoinDoorBlock = DirectCast(message.GetInteger(2), CoinDoorBlock)
        CoinsToOpen = message.GetInteger(3)
    End Sub
End Class
