Imports PlayerIOClient

Public NotInheritable Class TeleportReceiveMessage
    Inherits ReceiveMessage

    '0
    Public ReadOnly ResetCoins As Boolean

    Public ReadOnly Coordinates As New Dictionary(Of Integer, Point)

    Friend Sub New(message As Message)
        MyBase.New(message)

        ResetCoins = message.GetBoolean(0)

        For i As UInteger = 1 To message.Count - 1UI Step 3
            Coordinates.Add(message.GetInteger(i), New Point(message.GetInteger(i + 1UI), message.GetInteger(i + 2UI)))
        Next
    End Sub
End Class
