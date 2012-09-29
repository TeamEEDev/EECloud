Public MustInherit Class Plugin(Of P As {Player, New})
    Implements IPlugin
    Protected WithEvents Connection As IConnection(Of P)
    Protected Chatter As IChatter

    Friend Sub Enable() Implements IPlugin.Enable
        OnEnable()
    End Sub

    Friend Sub Enable(creator As ICreator, pluginObj As IPluginObject) Implements IPlugin.Enable
        Me.Connection = creator.GenerateConnection(Of P)(pluginObj)
        OnEnable()
        OnConnect()
    End Sub

    Friend Sub Connect(creator As ICreator, pluginObj As IPluginObject) Implements IPlugin.Connect
        Me.Connection = creator.GenerateConnection(Of P)(pluginObj)
        OnConnect()
    End Sub

    Friend Sub Disable() Implements IPlugin.Disable
        OnDisable()
    End Sub

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnConnect()
    Protected MustOverride Sub OnDisable()
End Class
