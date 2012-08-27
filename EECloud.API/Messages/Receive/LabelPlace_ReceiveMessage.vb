Public Class LabelPlace_ReceiveMessage
    Inherits BlockPlace_ReceiveMessage
    Public ReadOnly Text As String '3

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message, API.Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), BlockType))

        Text = message.GetString(3)
    End Sub
End Class
