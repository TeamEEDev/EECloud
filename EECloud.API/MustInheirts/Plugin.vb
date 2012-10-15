Public MustInherit Class Plugin (Of TPlayer As {Player, New})
    Implements IPlugin

#Region "Properties"

    Private myClient As IClient(Of TPlayer)

    Public ReadOnly Property Client As IClient(Of TPlayer)
        Get
            Return myClient
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub Enable(cloneFactory As IClientCloneFactory, pluginObj As IPluginObject) Implements IPlugin.Enable
        myClient = cloneFactory.GetConnection (Of TPlayer)(pluginObj)
        If myClient.Connection.Connected Then
            OnConnect()
        Else
            AddHandler myClient.Connection.ReceiveInit, AddressOf Connect
        End If

        OnEnable()
    End Sub

    Friend Sub Disable() Implements IPlugin.Disable
        OnDisable()
    End Sub

    Private Sub Connect(sender As Object, e As InitReceiveMessage)
        RemoveHandler myClient.Connection.ReceiveInit, AddressOf Connect
        OnConnect()
    End Sub

    Protected MustOverride Sub OnEnable()
    Protected MustOverride Sub OnDisable()
    Protected MustOverride Sub OnConnect()
#End Region
End Class
