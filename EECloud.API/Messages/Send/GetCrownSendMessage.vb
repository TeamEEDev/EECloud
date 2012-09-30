Imports PlayerIOClient

Public Class GetCrownSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create(world.Encryption & "k")
    End Function
End Class
