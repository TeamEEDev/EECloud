Imports PlayerIOClient

Public Class ChangeWorldEditKeySendMessage
    Inherits SendMessage
    Public ReadOnly EditKey As String

    Public Sub New(editKey As String)
        Me.EditKey = editKey
    End Sub

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create("key", EditKey)
    End Function
End Class
