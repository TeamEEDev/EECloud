Public NotInheritable Class Service
    Inherits BaseGlobalComponent
    Implements IService

    Public Sub New(PBot As Bot, PLicenceUsername As String, PLicencePassword As String)
        MyBase.New(PBot)
        myServiceClient = PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(Config.TBPGameID, PLicenceUsername, PLicencePassword)
    End Sub

    Private myServiceClient As PlayerIOClient.Client
    Public ReadOnly Property ServiceClient As PlayerIOClient.Client Implements IService.ServiceClient
        Get
            Return myServiceClient
        End Get
    End Property
End Class
