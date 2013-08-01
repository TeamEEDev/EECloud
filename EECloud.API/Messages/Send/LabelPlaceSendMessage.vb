Imports PlayerIOClient

Public NotInheritable Class LabelPlaceSendMessage
    Inherits BlockPlaceSendMessage
    Public ReadOnly Text As String

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As LabelBlock, text As String)
        MyBase.New(layer, x, y, DirectCast(block, Block))
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
End Class
