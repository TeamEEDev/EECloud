Imports PlayerIOClient

Public Class ModMode_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("mod")
    End Function
End Class
