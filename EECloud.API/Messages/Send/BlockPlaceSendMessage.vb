Imports PlayerIOClient

Public Class BlockPlaceSendMessage
    Inherits SendMessage
    Public ReadOnly Layer As Layer
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer
    Public ReadOnly Block As Block

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As Block)
        Me.Layer = layer
        Me.X = x
        Me.Y = y
        Me.Block = block
    End Sub

    Friend Overrides Function GetMessage(world As IWorld) As Message
        Return Message.Create(world.Encryption, CInt(CorrectLayer(Block, Layer)), X, Y, CInt(Block))
    End Function
End Class
