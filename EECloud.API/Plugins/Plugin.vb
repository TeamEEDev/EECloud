Public MustInherit Class Plugin(Of TPlayer As {Player, New})
    Implements IPlugin
    Protected WithEvents Connection As IConnection(Of TPlayer)

    Friend Sub Enable(creator As IConnectionFactory, pluginObj As IPluginObject) Implements IPlugin.Enable
        Connection = creator.GetConnection(Of TPlayer)(pluginObj)
        If Connection.Connected Then
            OnConnect()
        Else
            AddHandler Connection.OnReceiveInit, AddressOf Connect
        End If

        OnEnable()
    End Sub

    Friend Sub Disable() Implements IPlugin.Disable
        OnDisable()
    End Sub

    Private Sub Connect(sender As Object, e As InitReceiveMessage)
        RemoveHandler Connection.OnReceiveInit, AddressOf Connect
        OnConnect()
    End Sub

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnDisable()
    Protected MustOverride Sub OnConnect()
End Class
