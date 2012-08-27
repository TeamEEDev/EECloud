Public Class SoundPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly SoundID As Integer
    Public Sub New(layer As Layer, x As Integer, y As Integer, block As SoundBlockType, soundID As Integer)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.SoundID = soundID
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        If IsSound(Block) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(connection)
            myMessage.Add(SoundID)
            Return myMessage
        Else
            Return MyBase.GetMessage(connection)
        End If
    End Function
End Class
