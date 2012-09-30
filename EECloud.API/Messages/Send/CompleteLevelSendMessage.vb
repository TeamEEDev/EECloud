Imports PlayerIOClient

Public Class CompleteLevelSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create("levelcomplete")
    End Function
End Class
