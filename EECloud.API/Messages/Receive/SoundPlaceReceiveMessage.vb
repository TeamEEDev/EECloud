Imports PlayerIOClient

Public NotInheritable Class SoundPlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage
    Public Shadows ReadOnly SoundBlock As CoinDoorBlock
    '2
    Public ReadOnly SoundID As Integer
    '3

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), Block))
        SoundBlock = CType(message.GetInteger(2), CoinDoorBlock)
        SoundID = message.GetInteger(3)
    End Sub
End Class
