Public MustInherit Class BlockManager
    Public MustOverride Function IsSound(ID As Integer) As Boolean
    Public MustOverride Function IsBackground(ID As Integer) As Boolean
    Public MustOverride Function IsForeground(ID As Integer) As Boolean
    Public MustOverride Function IsPortal(ID As Integer) As Boolean
    Public MustOverride Function IsCoindoor(ID As Integer) As Boolean
    Public MustOverride Function IsLabel(ID As Integer) As Boolean
End Class
