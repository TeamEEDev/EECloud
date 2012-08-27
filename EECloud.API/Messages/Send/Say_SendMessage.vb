Public Class Say_SendMessage
    Inherits SendMessage
    Public ReadOnly Text As String
    Public Sub New(text As String)
        Me.Text = text
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("say", Text)
    End Function
End Class
