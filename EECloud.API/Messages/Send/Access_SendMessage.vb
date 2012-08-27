Public Class Access_SendMessage
    Inherits SendMessage
    Public ReadOnly EditKey As String
    Public Sub New(editKey As String)
        Me.EditKey = editKey
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("access", EditKey)
    End Function
End Class
