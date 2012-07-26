Friend NotInheritable Class Service
    Inherits BaseGlobalComponent
    Implements IService

    Public Sub New(PBot As Bot, PLicenceUsername As String, PLicencePassword As String)
        MyBase.New(PBot)
        myClient = PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(Config.TBPGameID, PLicenceUsername, PLicencePassword)
    End Sub

    Private myClient As PlayerIOClient.Client
    Public ReadOnly Property Client As Client Implements IService.Client
        Get
            Return myClient
        End Get
    End Property
End Class
