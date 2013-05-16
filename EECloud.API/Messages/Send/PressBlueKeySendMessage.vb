Imports PlayerIOClient

Public NotInheritable Class PressBlueKeySendMessage
    Inherits SendMessage

    'No arguments

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create(game.Encryption & "b")
    End Function
End Class
