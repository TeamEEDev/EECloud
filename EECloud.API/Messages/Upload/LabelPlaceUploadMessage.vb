Imports PlayerIOClient

Public NotInheritable Class LabelPlaceUploadMessage
    Inherits BlockPlaceUploadMessage
    Public ReadOnly Text As String

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As LabelBlock, text As String)
        MyBase.New(layer, x, y, CType(block, Block))
        Me.Text = text
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        If IsLabel(Block) Then
            Dim message As Message = MyBase.GetMessage(game)
            message.Add(Text)
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
