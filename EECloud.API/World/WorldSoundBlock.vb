Friend NotInheritable Class WorldSoundBlock
    Inherits WorldBlock
    Implements IWorldSoundBlock

#Region "Properties"

    Public Overrides ReadOnly Property BlockType As BlockType
        Get
            Return BlockType.Sound
        End Get
    End Property

    Private ReadOnly mySoundID As Integer

    Public ReadOnly Property SoundID As Integer Implements IWorldSoundBlock.SoundID
        Get
            Return mySoundID
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(block As SoundBlock, soundID As Integer)
        MyBase.New(CType(block, Block))
        mySoundID = soundID
    End Sub

#End Region
End Class
