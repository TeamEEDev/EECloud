Imports PlayerIOClient

Public NotInheritable Class SoundPlaceSendMessage
    Inherits BlockPlaceSendMessage

    Public ReadOnly SoundID As Integer

    Public Sub New(layer As Layer, x As Integer, y As Integer, block As SoundBlock, soundID As Integer)
        MyBase.New(layer, x, y, DirectCast(block, Block))

        Me.SoundID = soundID
    End Sub

    Friend Overrides Function GetMessage(game As IGame) As Message
        If IsSound(Block) Then
            Dim message As Message = MyBase.GetMessage(game)
            message.Add(SoundID)
            Return message
        Else
            Return MyBase.GetMessage(game)
        End If
    End Function
End Class
