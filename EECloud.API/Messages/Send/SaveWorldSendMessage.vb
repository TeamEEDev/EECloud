Imports PlayerIOClient

Public NotInheritable Class SaveWorldSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create("save")
    End Function
End Class
