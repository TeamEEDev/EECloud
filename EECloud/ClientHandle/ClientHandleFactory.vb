Friend NotInheritable Class ClientHandleFactory
    Implements IClientHandleFactory

    Friend Function GetConnectionHandle() As IClientHandle Implements IClientHandleFactory.GetConnectionHandle
        Return New ClientHandle()
    End Function
End Class
