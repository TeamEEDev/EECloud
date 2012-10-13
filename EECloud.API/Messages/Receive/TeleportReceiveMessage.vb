Imports PlayerIOClient

Public NotInheritable Class TeleportReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly ResetCoins As Boolean
    '0
    Public ReadOnly Coordinates As New Dictionary(Of Integer, Location)

    Friend Sub New(message As Message)
        MyBase.New(message)

        ResetCoins = message.GetBoolean(0)

        For i As UInteger = 1 To CUInt(message.Count - 1) Step 3
            Coordinates.Add(message.GetInteger(i), New Location(message.GetInteger(CUInt(i + 1)), message.GetInteger(CUInt(i + 2))))
        Next
    End Sub
End Class
