Public MustInherit Class BlockManager
    Public MustOverride ReadOnly Property CorrectLayer(PID As Integer, PLayer As Layer) As Layer
    Public MustOverride ReadOnly Property IsSound(PID As Integer) As Boolean
    Public MustOverride ReadOnly Property IsCoindoor(PID As Integer) As Boolean
    Public MustOverride ReadOnly Property IsLabel(PID As Integer) As Boolean
    Public MustOverride ReadOnly Property IsPortal(PID As Integer) As Boolean
End Class
