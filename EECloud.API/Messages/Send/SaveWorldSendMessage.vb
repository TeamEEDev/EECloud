Imports PlayerIOClient

Public Class SaveWorldSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("save")
    End Function
End Class
