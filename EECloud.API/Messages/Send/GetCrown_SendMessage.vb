Imports PlayerIOClient

Public Class GetCrown_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create(connection.World.Encryption & "k")
    End Function
End Class
