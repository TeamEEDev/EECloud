﻿Imports PlayerIOClient

Public NotInheritable Class CoinSendMessage
    Inherits SendMessage

    Public ReadOnly Coins As Integer
    Public ReadOnly CoinX As Integer
    Public ReadOnly CoinY As Integer

    Public Sub New(coins As Integer, coinX As Integer, coinY As Integer)
        Me.Coins = coins
        Me.CoinX = coinX
        Me.CoinY = CoinY
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("c", Coins, CoinX, CoinY)
    End Function
End Class
