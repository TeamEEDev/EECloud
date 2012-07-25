Public Interface IBlocks
    ReadOnly Property CorrectLayer(ID As Block, Layer As Layer) As Layer
    ReadOnly Property IsSound(ID As Block) As Boolean
    ReadOnly Property IsCoinDoor(ID As Block) As Boolean
    ReadOnly Property IsLabel(ID As Block) As Boolean
    ReadOnly Property IsPortal(ID As Block) As Boolean

    ReadOnly Property Encryption As String
End Interface
