Public Class AutoText_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly UserID As Integer '0
    Public ReadOnly Text As String '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Text = message.GetString(1)
    End Sub
End Class
