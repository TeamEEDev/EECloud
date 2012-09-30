Public Interface IPlayerManager (Of P As {Player, New})
    ReadOnly Property Players(number As Integer) As P
    ReadOnly Property Players As IEnumerable(Of P)
    ReadOnly Property Crown As P
End Interface
