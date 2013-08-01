Imports PlayerIOClient

Public Class RotatablePlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage

    '2
    Public Shadows ReadOnly RotatableBlock As RotatableBlock
    '3
    Public ReadOnly Rotation As Integer

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), DirectCast(message.GetInteger(2), Block))

        RotatableBlock = DirectCast(message.GetInteger(2), RotatableBlock)
        Rotation = message.GetInteger(3)
    End Sub
End Class
