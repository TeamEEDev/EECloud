Imports PlayerIOClient

Public Class InitSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create("init")
    End Function
End Class
