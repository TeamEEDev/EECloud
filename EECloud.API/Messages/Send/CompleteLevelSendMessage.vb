Imports PlayerIOClient

Public NotInheritable Class CompleteLevelSendMessage
    Inherits SendMessage

    'No arguments

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("levelcomplete")
    End Function
End Class
