Imports PlayerIOClient

Public NotInheritable Class Init2SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create("init2")
    End Function
End Class
