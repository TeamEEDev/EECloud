Public MustInherit Class BlockManager
    Public MustOverride Property CorrectLayer(PID As Integer, PLayer As Layer) As Layer
    Public MustOverride Property IsSound(PID As Integer) As Boolean
    Public MustOverride Property IsCoindoor(PID As Integer) As Boolean
    Public MustOverride Property IsLabel(PID As Integer) As Boolean
    Public MustOverride Property IsPortal(PID As Integer) As Boolean
End Class
