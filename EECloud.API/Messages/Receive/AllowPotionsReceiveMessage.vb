Imports PlayerIOClient

Public Class AllowPotionsReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly Allowed As Boolean

    Friend Sub New(message As Message)
        MyBase.New(message)

        Allowed = message.GetBoolean(0)
    End Sub
End Class
