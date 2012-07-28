Public MustInherit Class CloudPlugin
    Implements IPlugin

    Private myHost As IBot
    Public Sub AttemptSetup(Host As IBot) Implements IPlugin.AttemptSetup
        myHost = Host
    End Sub

    Public MustOverride Sub OnDisable() Implements IPlugin.OnDisable
    Public MustOverride Sub OnEnable() Implements IPlugin.OnEnable
End Class
