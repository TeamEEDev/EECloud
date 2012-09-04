Public Class CoinDoorPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly CoinsToCollect As Integer
    Public Sub New(layer As Layer, x As Integer, y As Integer, block As CoinDoorBlockType, coinsToCollect As Integer)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.CoinsToCollect = coinsToCollect
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As PlayerIOClient.Message
        If IsCoinDoor(Block) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(connection)
            myMessage.Add(CoinsToCollect)
            Return myMessage
        Else
            Return MyBase.GetMessage(connection)
        End If
    End Function
End Class
