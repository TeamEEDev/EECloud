Public Interface IBlockManager
    Sub AttemptSetup(Connection As IConnection)

    ReadOnly Property CorrectLayer(PID As Integer, PLayer As Layer) As Layer
    ReadOnly Property IsSound(PID As Integer) As Boolean
    ReadOnly Property IsCoinDoor(PID As Integer) As Boolean
    ReadOnly Property IsLabel(PID As Integer) As Boolean
    ReadOnly Property IsPortal(PID As Integer) As Boolean

    ReadOnly Property Encryption As String
End Interface
