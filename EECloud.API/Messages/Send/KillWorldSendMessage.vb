Imports PlayerIOClient

Public Class KillWorldSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create("kill")
    End Function
End Class
