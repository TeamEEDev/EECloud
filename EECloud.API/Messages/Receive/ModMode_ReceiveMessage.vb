Public Class ModMode_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer '0

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
    End Sub
End Class
