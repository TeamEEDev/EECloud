Imports PlayerIOClient

Public Class PotionReceiveMessage
    Inherits ReceiveMessage

    Public ReadOnly UserID As Integer
    '0
    Public ReadOnly Potion As Potion
    '1
    Public ReadOnly Enabled As Boolean
    '2

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Potion = CType(message.GetInteger(1), Potion)
        Enabled = message.GetBoolean(2)
    End Sub
End Class
