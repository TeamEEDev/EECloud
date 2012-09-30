Imports PlayerIOClient

Public Class PressGreenKeySendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create(world.Encryption & "g")
    End Function
End Class
