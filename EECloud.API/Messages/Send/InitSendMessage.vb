Imports PlayerIOClient

Public Class InitSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("init")
    End Function
End Class
