Imports PlayerIOClient

Public NotInheritable Class KillWorldSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("kill")
    End Function
End Class
