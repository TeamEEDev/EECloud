﻿Imports PlayerIOClient

Public Class RotatablePlaceUploadMessage
    Inherits BlockPlaceUploadMessage
    Public ReadOnly Rotation As Integer

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As RotatableBlock, rotation As Integer)
        MyBase.New(layer, x, y, CType(block, Block))

        Me.Rotation = rotation
    End Sub

    Friend Overrides Function GetMessage(ByVal game As IGame) As Message
        If IsCoinDoor(Block) Then
            Dim message As Message = MyBase.GetMessage(game)
            message.Add(Rotation)
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
