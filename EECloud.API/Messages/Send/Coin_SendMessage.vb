Public Class Coin_SendMessage
    Inherits SendMessage
    Public ReadOnly Coins As Integer
    Public Sub New(coins As Integer)
        Me.Coins = coins
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("c", Coins)
    End Function
End Class
