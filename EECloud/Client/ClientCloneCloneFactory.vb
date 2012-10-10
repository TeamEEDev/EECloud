Friend NotInheritable Class ClientCloneCloneFactory
    Implements IClientCloneFactory

#Region "Fields"
    Private ReadOnly myInternalConnection As InternalClient
#End Region

#Region "Methods"

    Sub New(internalConnection As InternalClient)
        myInternalConnection = internalConnection
    End Sub

    Friend Function GetConnection(Of TPlayer As {New, Player})(plugin As IPluginObject, instance As Object) As IClient(Of TPlayer) Implements IClientCloneFactory.GetConnection
        Return New Client(Of TPlayer)(myInternalConnection, plugin)
    End Function

#End Region
End Class
