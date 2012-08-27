Public Class PressGreenKey_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(connection.Encryption & "g")
    End Function
End Class
