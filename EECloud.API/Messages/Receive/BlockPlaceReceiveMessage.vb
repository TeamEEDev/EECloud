Imports PlayerIOClient

Public Class BlockPlaceReceiveMessage
    Inherits ReceiveMessage
    Public ReadOnly Layer As Layer
    '0
    Public ReadOnly PosX As Integer
    '1
    Public ReadOnly PosY As Integer
    '2
    Public ReadOnly Block As Block
    '3

    Friend Sub New(message As Message)
        MyBase.New(message)

        Layer = CType(message.GetInteger(0), Layer)
        PosX = message.GetInteger(1)
        PosY = message.GetInteger(2)
        Block = CType(message.GetInteger(3), Block)
    End Sub

    Protected Sub New(message As Message, layer As Layer, posX As Integer, posY As Integer, block As Block)
        MyBase.New(message)

        Me.Layer = layer
        Me.PosX = posX
        Me.PosY = posY
        Me.Block = block
    End Sub
End Class
