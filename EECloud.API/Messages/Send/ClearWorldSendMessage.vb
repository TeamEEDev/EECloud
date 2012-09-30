Imports PlayerIOClient

Public Class ClearWorldSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create("clear")
    End Function
End Class
