Public Class TouchDiamond_SendMessage
    Inherits SendMessage
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer
    Public Sub New(x As Integer, y As Integer)
        Me.X = x
        Me.Y = y
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("diamondtouch", X, Y)
    End Function
End Class
