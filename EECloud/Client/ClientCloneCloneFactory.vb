Friend NotInheritable Class ClientCloneCloneFactory
    Implements IClientCloneFactory


#Region "Fields"
    Private ReadOnly myInternalConnection As InternalClient
#End Region

#Region "Methods"

    Sub New(internalConnection As InternalClient)
        myInternalConnection = internalConnection
    End Sub

    Friend Function GetClient(Of TPlayer As {New, Player})(plugin As IPluginObject) As IClient(Of TPlayer) Implements IClientCloneFactory.GetClient
        Return New Client(Of TPlayer)(myInternalConnection, plugin)
    End Function

    Public Sub DisposeClient(Of TPlayer As {New, Player})(client As IClient(Of TPlayer)) Implements IClientCloneFactory.DisposeClient
        Dim newClient As Client(Of TPlayer) = TryCast(client, Client(Of TPlayer))
        If newClient IsNot Nothing Then
            newClient.dispose()
        End If
    End Sub

#End Region
End Class
