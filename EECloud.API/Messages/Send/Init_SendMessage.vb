Public Class Init_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("init")
    End Function
End Class
