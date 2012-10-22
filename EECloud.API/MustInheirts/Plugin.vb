Public MustInherit Class Plugin(Of TPlayer As {Player, New})
    Inherits PluginPart(Of TPlayer)
    Implements IPlugin, IClient(Of TPlayer)

#Region "Fields"
    Private myCloneFactory As IClientCloneFactory

    Private myPluginParts As New List(Of PluginPart(Of TPlayer))
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

    Friend Overloads Sub Enable(cloneFactory As IClientCloneFactory, pluginObj As IPluginObject) Implements IPlugin.Enable
        myCloneFactory = cloneFactory
        myPluginObject = pluginObj
        Enable(cloneFactory.GetClient(Of TPlayer)(pluginObj))
    End Sub

    Friend Overrides Sub Disable() Implements IPlugin.Disable
        For Each part In myPluginParts
            part.Disable()
        Next
        myCloneFactory.DisposeClient(Of TPlayer)(Client)
        MyBase.Disable()
    End Sub

    Public Function EnablePart(Of TPart As {PluginPart(Of TPlayer), New})() As TPart
        Dim part As New TPart
        part.Enable(Client)
        myPluginParts.Add(part)
        Return part
    End Function

    Public Sub DisablePart(Of TPart As {PluginPart(Of TPlayer), New})(part As TPart)
        If myPluginParts.Contains(part) Then
            myPluginParts.Remove(part)
        End If
        part.Disable()
    End Sub

#End Region
End Class
