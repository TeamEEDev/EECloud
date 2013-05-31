Imports PlayerIOClient

Public NotInheritable Class PressGreenKeySendMessage
    Inherits SendMessage

    'No arguments

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create(game.Encryption & "g")
    End Function
End Class
