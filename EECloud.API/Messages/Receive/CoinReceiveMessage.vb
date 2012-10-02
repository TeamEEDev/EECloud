﻿Imports PlayerIOClient

Public Class CoinReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer
    '0
    Public ReadOnly Coins As Integer
    '1

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Coins = message.GetInteger(1)
    End Sub
End Class