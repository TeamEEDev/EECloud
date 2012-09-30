Imports PlayerIOClient

Public Class Init2SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create("init2")
    End Function
End Class
