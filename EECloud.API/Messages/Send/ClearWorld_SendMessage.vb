﻿Imports PlayerIOClient

Public Class ClearWorld_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("clear")
    End Function
End Class
