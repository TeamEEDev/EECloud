Imports PlayerIOClient

Public Class ModModeSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create("mod")
    End Function
End Class
