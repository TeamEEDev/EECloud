﻿Imports PlayerIOClient

Public Class Init_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("init")
    End Function
End Class
