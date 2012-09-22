Public Interface IConnection(Of P As {Player, New})
    Inherits IConnectionBase

    ReadOnly Property Players(number As Integer) As P
    ReadOnly Property Players As IEnumerable(Of P)
    ReadOnly Property Crown As P

    Sub Disconnect()
End Interface
