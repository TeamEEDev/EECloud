Module Utils

#Region "Properties"

    Friend ReadOnly Property CorrectLayer(id As Block, layer As Layer) As Layer
        Get
            If (id > 0 AndAlso id < 500) Or id = 1000 Then
                Return layer.Foreground
            ElseIf id >= 500 AndAlso id < 1000 Then
                Return layer.Background
            Else
                Return layer
            End If
        End Get
    End Property

    Friend ReadOnly Property IsCoinDoor(id As Block) As Boolean
        Get
            Return id = Block.BlockDoorCoinDoor OrElse id = Block.BlockGateCoinGate
        End Get
    End Property

    Friend ReadOnly Property IsRotatable(id As Block) As Boolean
        Get
            Return id = Block.BlockHazardSpike
        End Get
    End Property

    Friend ReadOnly Property IsSound(id As Block) As Boolean
        Get
            Return id = Block.BlockMusicPiano OrElse id = Block.BlockMusicDrum
        End Get
    End Property

    Friend ReadOnly Property IsPortal(id As Block) As Boolean
        Get
            Return id = Block.BlockPortal
        End Get
    End Property

    Friend ReadOnly Property IsLabel(id As Block) As Boolean
        Get
            Return id = Block.BlockLabel
        End Get
    End Property

#End Region
End Module
