Public MustInherit Class PluginPart(Of TPlayer As {Player, New}, TProtocol)
    Inherits PluginBase(Of TPlayer, TProtocol)

#Region "Fields"
    Private WithEvents myPluginHost As IPlugin
#End Region

#Region "Properties"

    Private myHost As TProtocol

    Protected ReadOnly Property Host As TProtocol
        Get
            Return myHost
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Overrides Sub Enable(client As IClient(Of TPlayer), host As IPlugin)
        myPluginHost = host
        myHost = CType(host, TProtocol)

        MyBase.Enable(client, host)
    End Sub

    Protected Overrides Function EnablePart(Of TPart As {PluginPart(Of TPlayer, TProtocol), New})() As TPart
        Dim part As New TPart
        part.Enable(Client, myPluginHost)
        Return part
    End Function

    Protected Overrides Sub Disable() Handles myPluginHost.Disabling
        OnDisable()
    End Sub

#End Region
End Class