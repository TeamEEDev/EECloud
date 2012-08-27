Public Class GetCrown_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(connection.Encryption & "k")
    End Function
End Class
