Imports PlayerIOClient

Public Class RotatablePlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage
    Public Shadows ReadOnly RotatableBlock As RotatableBlock
    '2
    Public ReadOnly Rotation As Integer
    '3

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), Block))

        RotatableBlock = CType(message.GetInteger(2), RotatableBlock)
        Rotation = message.GetInteger(3)
    End Sub
End Class
