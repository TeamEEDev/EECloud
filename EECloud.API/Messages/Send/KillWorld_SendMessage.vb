Public Class KillWorld_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("kill")
    End Function
End Class
