Imports PlayerIOClient

Public Class CheckpointSendMessage
    Inherits SendMessage
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer

    Public Sub New(x As Integer, y As Integer)
        Me.X = x
        Me.Y = y
    End Sub


    Friend Overrides Function GetMessage(ByVal game As IGame) As Message
        Return Message.Create("checkpoint", X, Y)
    End Function
End Class
