Imports PlayerIOClient

Public NotInheritable Class ClearReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly RoomWidth As Integer
    '1
    Public ReadOnly RoomHeight As Integer

    Friend Sub New(message As Message)
        MyBase.New(message)

        RoomWidth = message.GetInteger(0)
        RoomHeight = message.GetInteger(1)
    End Sub
End Class
