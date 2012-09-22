Friend Class ConnectionHandle
    Inherits Connection(Of Player)
    Implements IConnectionHandle

    Sub New()
        MyBase.New(Nothing)
    End Sub
End Class
