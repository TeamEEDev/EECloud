Imports PlayerIOClient

Public NotInheritable Class InitSendMessage
    Inherits SendMessage

    'No arguments

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("init")
    End Function
End Class
