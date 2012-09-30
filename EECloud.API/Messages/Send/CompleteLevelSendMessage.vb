Imports PlayerIOClient

Public Class CompleteLevelSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("levelcomplete")
    End Function
End Class
