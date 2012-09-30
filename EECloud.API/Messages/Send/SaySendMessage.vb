Imports PlayerIOClient

Public Class SaySendMessage
    Inherits SendMessage
    Public ReadOnly Text As String

    Public Sub New(text As String)
        Me.Text = text
    End Sub

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create("say", Text)
    End Function
End Class
