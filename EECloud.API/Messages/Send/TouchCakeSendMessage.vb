Imports PlayerIOClient

Public NotInheritable Class TouchCakeSendMessage
    Inherits SendMessage
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer

    Public Sub New(x As Integer, y As Integer)
        Me.X = x
        Me.Y = y
    End Sub

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create("caketouch", X, Y)
    End Function
End Class
