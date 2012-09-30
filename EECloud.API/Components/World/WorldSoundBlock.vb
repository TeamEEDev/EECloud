Friend NotInheritable Class WorldSoundBlock
    Inherits WorldBlock

    Friend Sub New(layer As Layer, block As SoundBlockType, soundID As Integer)
        MyBase.New(layer, CType(block, BlockType))

        mySoundID = soundID
    End Sub

    Private ReadOnly mySoundID As Integer

    Public ReadOnly Property SoundID As Integer
        Get
            Return mySoundID
        End Get
    End Property
End Class
