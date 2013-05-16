Imports PlayerIOClient

Public Class AllowPotionsSendMessage
    Inherits SendMessage

    Public ReadOnly Allowed As Boolean

    Public Sub New(allowed As Boolean)
        Me.Allowed = allowed
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("allowpotions", Allowed)
    End Function
End Class
