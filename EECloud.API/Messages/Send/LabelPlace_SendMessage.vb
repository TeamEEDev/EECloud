Imports PlayerIOClient

Public Class LabelPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly Text As String

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As LabelBlockType, text As String)
        MyBase.New(layer, x, y, CType(block, BlockType))
        Me.Text = text
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        If IsLabel(Block) Then
            Dim myMessage As Message = MyBase.GetMessage(connection)
            myMessage.Add(Text)
            Return myMessage
        Else
            Return MyBase.GetMessage(connection)
        End If
    End Function
End Class
