Imports PlayerIOClient

Public NotInheritable Class PressPurpleSwitchSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(ByVal game As IGame) As Message
        Return Message.Create(game.Encryption & "sp")
    End Function
End Class
