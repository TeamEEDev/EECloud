Imports PlayerIOClient

Public Class PressRedKeySendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create(connection.World.Encryption & "r")
    End Function
End Class
