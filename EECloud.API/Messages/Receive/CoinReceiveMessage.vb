Imports PlayerIOClient

Public NotInheritable Class CoinReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly UserID As Integer
    '1
    Public ReadOnly Coins As Integer

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Coins = message.GetInteger(1)
    End Sub
End Class
