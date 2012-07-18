Public Interface IBlockManager
    ReadOnly Property CorrectLayer(PID As Integer, PLayer As Layer) As Layer
    ReadOnly Property IsSound(PID As Integer) As Boolean
    ReadOnly Property IsCoinDoor(PID As Integer) As Boolean
    ReadOnly Property IsLabel(PID As Integer) As Boolean
    ReadOnly Property IsPortal(PID As Integer) As Boolean
End Interface
