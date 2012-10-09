Public MustInherit Class Plugin(Of TPlayer As {Player, New})
    Implements IPlugin
    Protected WithEvents Client As IClient(Of TPlayer)

    Friend Sub Enable(creator As IClientGenerator, pluginObj As IPluginObject) Implements IPlugin.Enable
        Client = creator.GetConnection(Of TPlayer)(pluginObj, Me)
        If Client.Connection.Connected Then
            OnConnect()
        Else
            AddHandler Client.Connection.ReceiveInit, AddressOf Connect
        End If

        OnEnable()
    End Sub

    Friend Sub Disable() Implements IPlugin.Disable
        OnDisable()
    End Sub

    Private Sub Connect(sender As Object, e As InitReceiveMessage)
        RemoveHandler Client.Connection.ReceiveInit, AddressOf Connect
        OnConnect()
    End Sub

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnDisable()
    Protected MustOverride Sub OnConnect()
End Class
