Public Class Teleport_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly ResetCoins As Boolean '0

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        ResetCoins = message.GetBoolean(0)
    End Sub
End Class
