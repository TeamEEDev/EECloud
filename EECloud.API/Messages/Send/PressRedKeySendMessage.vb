Imports PlayerIOClient

Public Class PressRedKeySendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create(world.Encryption & "r")
    End Function
End Class
