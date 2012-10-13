Imports PlayerIOClient

Public NotInheritable Class CoinSendMessage
    Inherits SendMessage
    Public ReadOnly Coins As Integer

    Public Sub New(coins As Integer)
        Me.Coins = coins
    End Sub

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create("c", Coins)
    End Function
End Class
