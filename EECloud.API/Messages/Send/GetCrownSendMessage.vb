Imports PlayerIOClient

Public NotInheritable Class GetCrownSendMessage
    Inherits SendMessage

    'No arguments

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create(game.Encryption & "k")
    End Function
End Class
