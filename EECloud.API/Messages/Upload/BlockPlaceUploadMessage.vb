Imports PlayerIOClient

Public Class BlockPlaceUploadMessage
    Inherits UploadMessage
    Public ReadOnly Layer As Layer
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer
    Public ReadOnly Block As Block
    Protected UploadCheck As Byte = 0

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As Block)
        Me.Layer = layer
        Me.X = x
        Me.Y = y
        Me.Block = block
    End Sub

    Friend Overrides Function GetMessage(ByVal game As IGame) As Message
        Return Message.Create(game.Encryption, CInt(CorrectLayer(Block, Layer)), X, Y, CInt(Block))
    End Function

    Friend Overrides Function SendMessage(client As IClient(Of Player)) As Boolean
        If Not client.World(X, Y, Layer).Block = Block Then
            client.Connection.Send(Me)
            Return True
        Else
            Return False
        End If
    End Function

    Friend Overrides Function IsUploaded(message As BlockPlaceReceiveMessage) As Boolean
        If UploadCheck <= 5 Then
            UploadCheck = CByte(UploadCheck + 1)
            Return X = message.PosX AndAlso Y = message.PosY AndAlso Layer = message.Layer
        Else
            Cloud.Logger.Log(LogPriority.Warning, String.Format("Block failed to upload with ID {0}, at postion {1} x {2}.", Block, X, Y))
            Return True
        End If
    End Function
End Class
