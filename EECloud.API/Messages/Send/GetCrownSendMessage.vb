Imports PlayerIOClient

Public NotInheritable Class GetCrownSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create(world.Encryption & "k")
    End Function
End Class
