Imports PlayerIOClient

Public NotInheritable Class CoinDoorPlaceUploadMessage
    Inherits BlockPlaceUploadMessage
    Public ReadOnly CoinsToCollect As Integer

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As CoinDoorBlock, coinsToCollect As Integer)
        MyBase.New(layer, x, y, DirectCast(block, Block))

        Me.CoinsToCollect = coinsToCollect
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        If IsCoinDoor(Block) Then
            Dim message As Message = MyBase.GetMessage(game)
            message.Add(CoinsToCollect)
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
