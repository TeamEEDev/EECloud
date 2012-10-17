Imports PlayerIOClient

Public Class BlockPlaceUploadMessage
    Inherits UploadMessage
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

    Friend Overrides Function GetMessage(ByVal game As IGame) As Message
        Return Message.Create(game.Encryption, CInt(CorrectLayer(Block, Layer)), X, Y, CInt(Block))
    End Function

    Friend Overrides Sub SendMessage(client As IClient(Of Player))
        If Not client.World(X, Y, Layer).Block = Block Then
            client.Connection.Send(Me)
        End If
    End Sub

    Friend Overrides Function IsUploaded(message As BlockPlaceReceiveMessage) As Boolean
        Return X = message.PosX AndAlso Y = message.PosY AndAlso Layer = message.Layer
    End Function
End Class
