Imports PlayerIOClient

Public Class AllowPotionsReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly Allowed As Boolean
    '0

    Friend Sub New(message As Message)
        MyBase.New(message)

        Allowed = message.GetBoolean(0)
    End Sub
End Class
