Imports PlayerIOClient

Public NotInheritable Class PotionReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly UserID As Integer
    '1
    Public ReadOnly Potion As Potion
    '2
    Public ReadOnly Enabled As Boolean
    '3
    Public ReadOnly Timeout As Integer

    Friend Sub New(message As Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Potion = DirectCast(message.GetInteger(1), Potion)
        Enabled = message.GetBoolean(2)
        Timeout = message.GetInteger(3)
    End Sub
End Class
