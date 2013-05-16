Imports PlayerIOClient

Public NotInheritable Class SoundPlaceReceiveMessage
    Inherits BlockPlaceReceiveMessage

    '2
    Public Shadows ReadOnly SoundBlock As SoundBlock
    '3
    Public ReadOnly SoundID As Integer

    Friend Sub New(message As Message)
        MyBase.New(message, Layer.Foreground, message.GetInteger(0), message.GetInteger(1), DirectCast(message.GetInteger(2), Block))

        SoundBlock = DirectCast(message.GetInteger(2), SoundBlock)
        SoundID = message.GetInteger(3)
    End Sub
End Class
