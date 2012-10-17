Imports PlayerIOClient

Public NotInheritable Class ClearWorldSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(ByVal game As IGame) As Message
        Return Message.Create("clear")
    End Function
End Class
