﻿Imports PlayerIOClient

Public Class ChangeWorldNameSendMessage
    Inherits SendMessage
    Public ReadOnly WorldName As String

    Public Sub New(worldName As String)
        Me.WorldName = worldName
    End Sub

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create("name", WorldName)
    End Function
End Class