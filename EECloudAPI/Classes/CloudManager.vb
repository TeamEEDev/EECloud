Public MustInherit Class CloudManager
    Default Public MustOverride ReadOnly Property Item(Index As Integer) As CloudConnection
    Public MustOverride ReadOnly Property Count As Integer
    Public MustOverride Property Main As CloudConnection
    Public MustOverride Sub Add(PConnection As CloudConnection)
    Public MustOverride Sub Remove(PConnection As CloudConnection)
End Class
