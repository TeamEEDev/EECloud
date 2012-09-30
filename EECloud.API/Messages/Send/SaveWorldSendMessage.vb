Imports PlayerIOClient

Public Class SaveWorldSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create("save")
    End Function
End Class
