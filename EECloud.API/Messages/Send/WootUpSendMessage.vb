Imports PlayerIOClient

Public Class WootUpSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(ByVal game As IGame) As Message
        Return Message.Create("wootup")
    End Function
End Class
