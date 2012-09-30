Imports PlayerIOClient

Public Class ClearReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly RoomWidth As Integer
    '0
    Public ReadOnly RoomHeight As Integer
    '1

    Friend Sub New(message As Message)
        MyBase.New(message)

        RoomWidth = message.GetInteger(0)
        RoomHeight = message.GetInteger(1)
    End Sub
End Class
