Public Class AutoSay_SendMessage
    Inherits SendMessage
    Public ReadOnly Text As AutoText
    Public Sub New(text As AutoText)
        Me.Text = text
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("autosay", Text)
    End Function
End Class
