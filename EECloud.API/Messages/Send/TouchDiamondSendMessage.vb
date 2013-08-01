Imports PlayerIOClient

Public NotInheritable Class TouchDiamondSendMessage
    Inherits SendMessage
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer

    Public Sub New(x As Integer, y As Integer)
        Me.X = x
        Me.Y = y
    End Sub


    Friend Overrides Function GetMessage(game As IGame) As Message
        Return Message.Create("diamondtouch", X, Y)
    End Function
End Class
