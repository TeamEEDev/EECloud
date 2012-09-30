Imports PlayerIOClient

Public Class KillWorld_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("kill")
    End Function
End Class
