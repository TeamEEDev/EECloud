Imports PlayerIOClient

Public Class AutoSaySendMessage
    Inherits SendMessage
    Public ReadOnly Text As AutoText

    Public Sub New(text As AutoText)
        Me.Text = text
    End Sub

    Friend Overrides Function GetMessage(world As World) As Message
        Return Message.Create("autosay", Text)
    End Function
End Class
