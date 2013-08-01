Imports PlayerIOClient

Public NotInheritable Class Init2SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("init2")
    End Function
End Class
