Public MustInherit Class Plugin(Of P As {Player, New})
    Implements IPlugin
    Protected WithEvents Connection As IConnection(Of P)
    Protected Chatter As IChatter

    Friend Sub Enable() Implements IPlugin.Enable
        OnEnable()
    End Sub

    Friend Sub Enable(creator As ICreator) Implements IPlugin.Enable
        Me.Connection = creator.GenerateConnection(Of P)()
        OnEnable()
        OnConnect()
    End Sub

    Friend Sub Connect(creator As ICreator) Implements IPlugin.Connect
        Me.Connection = creator.GenerateConnection(Of P)()
        OnConnect()
    End Sub

    Friend Sub Disable() Implements IPlugin.Disable
        OnDisable()
    End Sub

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnConnect()
    Protected MustOverride Sub OnDisable()
End Class
