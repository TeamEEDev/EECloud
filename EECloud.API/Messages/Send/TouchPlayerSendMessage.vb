Imports PlayerIOClient

Public Class TouchPlayerSendMessage
    Inherits SendMessage

    Public ReadOnly UserID As Integer
    Public ReadOnly Reason As Potion

    Public Sub New(userID As Integer, reason As Potion)
        Me.UserID = userID
        Me.Reason = reason
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("touch", UserID, Reason)
    End Function
End Class
