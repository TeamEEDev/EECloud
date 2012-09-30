Imports PlayerIOClient

Public Class ChangeWorldEditKey_SendMessage
    Inherits SendMessage
    Public ReadOnly EditKey As String

    Public Sub New(editKey As String)
        Me.EditKey = editKey
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        Return Message.Create("key", EditKey)
    End Function
End Class
