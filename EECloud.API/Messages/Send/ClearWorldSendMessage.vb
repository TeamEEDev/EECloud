Imports PlayerIOClient

Public Class ClearWorldSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create("clear")
    End Function
End Class
