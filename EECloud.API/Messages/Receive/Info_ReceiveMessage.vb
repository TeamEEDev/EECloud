Public Class Info_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly Title As String '0
    Public ReadOnly Text As String '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        Title = message.GetString(0)
        Text = message.GetString(1)
    End Sub
End Class
