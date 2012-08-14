Public Class WorldSoundBlock
    Inherits WorldBlock

    Friend Sub New(layer As Layer, x As Integer, y As Integer, block As SoundBlockType, soundID As Integer)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.mySoundID = soundID
    End Sub

    Private mySoundID As Integer
    Public ReadOnly Property SoundID As Integer
        Get
            Return mySoundID
        End Get
    End Property
End Class
