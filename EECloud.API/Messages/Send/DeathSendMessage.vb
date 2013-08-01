Imports PlayerIOClient

Public Class DeathSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("death")
    End Function
End Class
