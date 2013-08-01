Imports PlayerIOClient

Public NotInheritable Class SaveWorldSendMessage
    Inherits SendMessage

    'No arguments

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("save")
    End Function
End Class
