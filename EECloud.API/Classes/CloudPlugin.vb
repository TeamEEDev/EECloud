Public MustInherit Class CloudPlugin
    Implements IPlugin(Of IPlayer)

    Private myHost As IBot
    Public Sub AttemptSetup(Host As IBot) Implements IPlugin(Of IPlayer).AttemptSetup
        myHost = Host
    End Sub

    Public MustOverride Sub OnDisable() Implements IPlugin(Of IPlayer).OnDisable
    Public MustOverride Sub OnEnable() Implements IPlugin(Of IPlayer).OnEnable
End Class
