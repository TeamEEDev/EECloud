﻿Imports PlayerIOClient

Public Class CoinDoorPlace_ReceiveMessage
    Inherits BlockPlace_ReceiveMessage
    Public ReadOnly CoinsToOpen As Integer
    '3

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), BlockType))

        CoinsToOpen = message.GetInteger(3)
    End Sub
End Class
