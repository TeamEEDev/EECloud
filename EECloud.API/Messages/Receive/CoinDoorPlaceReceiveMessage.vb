Imports PlayerIOClient

Public NotInheritable Class CoinDoorPlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage
    Public ReadOnly CoinDoorBlock As CoinDoorBlock
    '2
    Public ReadOnly CoinsToOpen As Integer
    '3

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), Block))

        CoinDoorBlock = CType(message.GetInteger(2), CoinDoorBlock)
        CoinsToOpen = message.GetInteger(3)
    End Sub
End Class
