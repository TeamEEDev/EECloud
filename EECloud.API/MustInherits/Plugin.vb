Public MustInherit Class Plugin(Of TPlayer As {Player, New}, TProtocol)
    Inherits PluginBase(Of TPlayer, TProtocol)
    Implements IPlugin

#Region "Fields"
    Private myCloneFactory As IClientCloneFactory
#End Region

#Region "Events"
    Friend Event Disabling As EventHandler Implements IPlugin.Disabling
#End Region

#Region "Properties"
    Private myPluginObject As IPluginObject

    Public ReadOnly Property PluginObject As IPluginObject
        Get
            Return myPluginObject
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New()
        If Not GetType(TProtocol).IsAssignableFrom(Me.GetType) Then
            Throw New NotSupportedException("The plugin must implement or inherit TProtocol.")
        End If
    End Sub

    Friend Overloads Sub Enable(cloneFactory As IClientCloneFactory, pluginObj As IPluginObject) Implements IPlugin.Enable
        myCloneFactory = cloneFactory
        myPluginObject = pluginObj
        Enable(cloneFactory.GetClient(Of TPlayer)(pluginObj), Me)
    End Sub


    Protected Overrides Sub Disable() Implements IPlugin.Disable
        RaiseEvent Disabling(Me, EventArgs.Empty)
        OnDisable()
        myCloneFactory.DisposeClient(Of TPlayer)(Client)
    End Sub

    Protected Overrides Function EnablePart(Of TPart As {PluginPart(Of TPlayer, TProtocol), New})() As TPart
        Dim part As New TPart
        part.Enable(Client, Me)
        Return part
    End Function

#End Region
End Class
