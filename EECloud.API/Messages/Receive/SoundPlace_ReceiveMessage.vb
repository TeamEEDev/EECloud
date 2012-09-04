Public Class SoundPlace_ReceiveMessage
    Inherits BlockPlace_ReceiveMessage
    Public Shadows ReadOnly SoundBlock As CoinDoorBlockType '2
    Public ReadOnly SoundID As Integer '3

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message, API.Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), BlockType))
        SoundBlock = CType(message.GetInteger(2), CoinDoorBlockType)
        SoundID = message.GetInteger(3)
    End Sub
End Class
