Friend NotInheritable Class Database
    Inherits BaseGlobalComponent
    Implements IDatabase

    Public Sub New(PBot As Bot)
        MyBase.New(PBot)
    End Sub

    Private myClient As PlayerIOClient.Client
    Public ReadOnly Property Client As Client Implements IDatabase.Client
        Get
            Return myClient
        End Get
    End Property
End Class
