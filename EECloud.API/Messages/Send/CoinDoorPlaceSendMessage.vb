Imports PlayerIOClient

Public Class CoinDoorPlaceSendMessage
    Inherits BlockPlaceSendMessage
    Public ReadOnly CoinsToCollect As Integer

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As CoinDoorBlockType, coinsToCollect As Integer)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.CoinsToCollect = coinsToCollect
    End Sub

    Friend Overrides Function GetMessage(world As World) As Message
        If IsCoinDoor(Block) Then
            Dim message As Message = MyBase.GetMessage(world)
            message.Add(CoinsToCollect)
            Return message
        Else
            Return MyBase.GetMessage(world)
        End If
    End Function
End Class
