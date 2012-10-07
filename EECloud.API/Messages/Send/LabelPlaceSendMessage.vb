Imports PlayerIOClient

Public Class LabelPlaceSendMessage
    Inherits BlockPlaceSendMessage
    Public ReadOnly Text As String

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As LabelBlockType, text As String)
        MyBase.New(layer, x, y, CType(block, BlockType))
        Me.Text = text
    End Sub

    Friend Overrides Function GetMessage(world As IWorld) As Message
        If IsLabel(Block) Then
            Dim message As Message = MyBase.GetMessage(world)
            message.Add(Text)
            Return message
        Else
            Return MyBase.GetMessage(world)
        End If
    End Function
End Class
