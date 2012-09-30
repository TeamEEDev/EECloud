Imports PlayerIOClient

Public Class ModModeSendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("mod")
    End Function
End Class
