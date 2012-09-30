Imports PlayerIOClient

Public Class TeleportReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly ResetCoins As Boolean
    '0

    Friend Sub New(message As Message)
        MyBase.New(message)

        ResetCoins = message.GetBoolean(0)
    End Sub
End Class
