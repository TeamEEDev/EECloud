﻿Public NotInheritable Class Service
    Inherits BaseGlobalComponent
    Implements IService

    Public Sub New(PBot As Bot)
        MyBase.New(PBot)
        myServiceClient = PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(Config.TBPGameID, myBot.LicenceUsername, myBot.LicenceKey)
    End Sub

    Private myServiceClient As PlayerIOClient.Client
    Public ReadOnly Property ServiceClient As PlayerIOClient.Client Implements IService.ServiceClient
        Get
            Return myServiceClient
        End Get
    End Property
End Class