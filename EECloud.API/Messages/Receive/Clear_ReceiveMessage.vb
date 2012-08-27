Public Class Clear_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly RoomWidth As Integer '0
    Public ReadOnly RoomHeight As Integer '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        RoomWidth = message.GetInteger(0)
        RoomHeight = message.GetInteger(1)
    End Sub
End Class
