Imports PlayerIOClient

Public Class BlockPlace_SendMessage
    Inherits SendMessage
    Public ReadOnly Layer As Layer
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer
    Public ReadOnly Block As BlockType

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As BlockType)
        Me.Layer = layer
        Me.X = x
        Me.Y = y
        Me.Block = block
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of Player)) As Message
        Return Message.Create(connection.World.Encryption, CorrectLayer(Block, Layer), X, Y, Block)
    End Function
End Class
