Imports PlayerIOClient

Public Class PressBlueKeySendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create(connection.World.Encryption & "b")
    End Function
End Class
