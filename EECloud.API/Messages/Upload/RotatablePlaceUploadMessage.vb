Imports PlayerIOClient

Public Class RotatablePlaceUploadMessage
    Inherits BlockPlaceUploadMessage
    Public ReadOnly Rotation As BlockRotation

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As RotatableBlock, rotation As BlockRotation)
        MyBase.New(layer, x, y, DirectCast(block, Block))

        Me.Rotation = rotation
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        If IsRotatable(Block) Then
            Dim message As Message = MyBase.GetMessage(game)
            message.Add(CInt(Rotation))
            Return message
        Else
            Return MyBase.GetMessage(game)
        End If
    End Function

    Friend Overrides Function SendMessage(client As IClient(Of Player)) As Boolean
        client.Connection.Send(Me)
        Return True
    End Function
End Class
