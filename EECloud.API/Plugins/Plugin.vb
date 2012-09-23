Public MustInherit Class Plugin(Of P As {Player, New})
    Implements IPlugin
    Private myConnection As IConnection(Of P)


    Friend Sub SetupPlugin(creator As ICreator) Implements IPlugin.SetupPlugin
        myConnection = creator.GenerateConnection(Of P)()
        OnEnable()
    End Sub

    Friend Sub Disable() Implements IPlugin.Disable
        OnDisable()
    End Sub

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnConnect(mainConnection As IConnection(Of P))
    Protected MustOverride Sub OnDisable()
End Class
