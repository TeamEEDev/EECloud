Imports PlayerIOClient

Public Class ModModeSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create("mod")
    End Function
End Class
