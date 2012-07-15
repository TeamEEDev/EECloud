Namespace Interfaces
    Public MustInherit Class BasePlugin
        MustOverride Sub OnEnable()
        MustOverride Sub OnDisable()
        MustOverride Sub AttemptSetup(Host As CloudPluginHost)
    End Class
End Namespace

