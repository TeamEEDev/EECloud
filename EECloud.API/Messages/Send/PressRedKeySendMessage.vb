Imports PlayerIOClient

Public NotInheritable Class PressRedKeySendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create(game.Encryption & "r")
    End Function
End Class
