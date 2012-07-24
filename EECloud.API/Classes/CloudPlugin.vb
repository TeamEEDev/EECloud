Public MustInherit Class CloudPlugin
    Implements IPlugin(Of IPlayer)

    Private m_Host As IBot
    Public Sub AttemptSetup(Host As IBot) Implements IPlugin(Of IPlayer).AttemptSetup
        m_Host = Host
    End Sub

    Public MustOverride Sub OnDisable() Implements IPlugin(Of IPlayer).OnDisable
    Public MustOverride Sub OnEnable() Implements IPlugin(Of IPlayer).OnEnable
End Class
