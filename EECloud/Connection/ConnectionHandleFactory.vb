Friend NotInheritable Class ConnectionHandleFactory
    Implements IConnectionHandleFactory

    Friend Function GetConnectionHandle() As IConnectionHandle Implements IConnectionHandleFactory.GetConnectionHandle
        Return New ConnectionHandle()
    End Function
End Class
