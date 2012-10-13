Imports PlayerIOClient

Public NotInheritable Class LabelPlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage
    Public ReadOnly Text As String
    '3

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), Block))

        Text = message.GetString(3)
    End Sub
End Class
