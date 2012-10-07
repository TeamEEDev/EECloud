Imports PlayerIOClient

Public Class PressBlueKeySendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create(world.Encryption & "b")
    End Function
End Class
