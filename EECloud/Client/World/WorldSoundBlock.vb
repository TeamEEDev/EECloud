Friend NotInheritable Class WorldSoundBlock
    Implements IWorldBlock

#Region "Properties"

    Public ReadOnly Property BlockType As BlockType Implements IWorldBlock.BlockType
        Get
            Return BlockType.Sound
        End Get
    End Property

    Private ReadOnly myBlock As Block

    Public ReadOnly Property Block As Block Implements IWorldBlock.Block
        Get
            Return myBlock
        End Get
    End Property

    Private ReadOnly mySoundID As Integer

    Public ReadOnly Property SoundID As Integer Implements IWorldBlock.SoundID
        Get
            Return mySoundID
        End Get
    End Property

    Public ReadOnly Property CoinsToCollect As Integer Implements IWorldBlock.CoinsToCollect
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property PortalID As Integer Implements IWorldBlock.PortalID
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property PortalRotation As PortalRotation Implements IWorldBlock.PortalRotation
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property PortalTarget As Integer Implements IWorldBlock.PortalTarget
        Get
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property Text As String Implements IWorldBlock.Text
        Get
            Return Nothing
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(block As SoundBlock, soundID As Integer)
        myBlock = CType(block, Block)
        mySoundID = soundID
    End Sub

#End Region
End Class
