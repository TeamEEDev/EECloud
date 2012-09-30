Imports PlayerIOClient

Public Class SoundPlaceSendMessage
    Inherits BlockPlaceSendMessage
    Public ReadOnly SoundID As Integer

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As SoundBlockType, soundID As Integer)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.SoundID = soundID
    End Sub

    Friend Overrides Function GetMessage(connection As IConnection(Of player)) As Message
        If IsSound(Block) Then
            Dim myMessage As Message = MyBase.GetMessage(connection)
            myMessage.Add(SoundID)
            Return myMessage
        Else
            Return MyBase.GetMessage(connection)
        End If
    End Function
End Class
