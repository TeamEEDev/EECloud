Public MustInherit Class Plugin(Of TPlayer As {Player, New})
    Implements IPlugin
    Protected WithEvents Connection As IConnection(Of TPlayer)

    Friend Sub Enable() Implements IPlugin.Enable
        OnEnable()
    End Sub

    Friend Sub Enable(creator As IConnectionFactory, pluginObj As IPluginObject) Implements IPlugin.Enable
        Connection = creator.GetConnection(Of TPlayer)(pluginObj)
        OnEnable()
        OnConnect()
    End Sub

    Friend Sub Connect(creator As IConnectionFactory, pluginObj As IPluginObject) Implements IPlugin.Connect
        Connection = creator.GetConnection(Of TPlayer)(pluginObj)
        OnConnect()
    End Sub

    Friend Sub Disable() Implements IPlugin.Disable
        OnDisable()
    End Sub

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnConnect()
    Protected MustOverride Sub OnDisable()
End Class
