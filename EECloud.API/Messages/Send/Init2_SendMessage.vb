Imports PlayerIOClient

Public Class Init2_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("init2")
    End Function
End Class
