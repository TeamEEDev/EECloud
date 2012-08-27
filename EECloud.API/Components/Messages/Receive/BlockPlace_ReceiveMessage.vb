Public Class BlockPlace_ReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly Layer As Layer '0
    Public ReadOnly PosX As Integer '1
    Public ReadOnly PosY As Integer '2
    Public ReadOnly Block As BlockType '3

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        Layer = CType(message.Item(0), Layer)
        PosX = message.GetInteger(1)
        PosY = message.GetInteger(2)
        Block = CType(message.GetInteger(3), BlockType)
    End Sub

    Protected Sub New(message As PlayerIOClient.Message, layer As Layer, posX As Integer, posY As Integer, block As BlockType)
        MyBase.New(message)

        Me.Layer = layer
        Me.PosX = posX
        Me.PosY = posY
        Me.Block = block
    End Sub
End Class
