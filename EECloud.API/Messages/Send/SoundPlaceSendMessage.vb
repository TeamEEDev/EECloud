Imports PlayerIOClient

Public Class SoundPlaceSendMessage
    Inherits BlockPlaceSendMessage
    Public ReadOnly SoundID As Integer

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As SoundBlock, soundID As Integer)
        MyBase.New(layer, x, y, CType(block, Block))

        Me.SoundID = soundID
    End Sub

    Friend Overrides Function GetMessage(world As IWorld) As Message
        If IsSound(Block) Then
            Dim message As Message = MyBase.GetMessage(world)
            message.Add(SoundID)
            Return message
        Else
            Return MyBase.GetMessage(world)
        End If
    End Function
End Class
