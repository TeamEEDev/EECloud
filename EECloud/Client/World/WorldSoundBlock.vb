Friend NotInheritable Class WorldSoundBlock
    Inherits WorldBlock
    Implements IWorldSoundBlock

    Friend Sub New(block As SoundBlockType, soundID As Integer)
        MyBase.New(CType(block, BlockType))

        mySoundID = soundID
    End Sub

    Private ReadOnly mySoundID As Integer

    Public ReadOnly Property SoundID As Integer Implements IWorldSoundBlock.SoundID
        Get
            Return mySoundID
        End Get
    End Property
End Class
