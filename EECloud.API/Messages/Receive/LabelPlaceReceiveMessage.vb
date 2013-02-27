Imports PlayerIOClient

Public NotInheritable Class LabelPlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage
    Public ReadOnly LabelBlock As LabelBlock
    '2
    Public ReadOnly Text As String
    '3

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), DirectCast(message.GetInteger(2), Block))

        LabelBlock = DirectCast(message.GetInteger(2), LabelBlock)
        Text = message.GetString(3)
    End Sub
End Class
