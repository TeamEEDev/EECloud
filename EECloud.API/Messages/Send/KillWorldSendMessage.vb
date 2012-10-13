Imports PlayerIOClient

Public NotInheritable Class KillWorldSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create("kill")
    End Function
End Class
