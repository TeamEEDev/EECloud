Friend NotInheritable Class PluginManager
    Implements IPluginManager

#Region "Fields"
    Private ReadOnly myCloneFactory As IClientCloneFactory
#End Region

#Region "Properties"
    Private ReadOnly myPluginsList As New List(Of IPluginObject)

    Friend ReadOnly Property Plugins As IEnumerable(Of IPluginObject) Implements IPluginManager.Plugins
        Get
            Return myPluginsList
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(cloneFactory As IClientCloneFactory)
        myCloneFactory = cloneFactory
    End Sub

    Friend Function Add(t As Type) As IPluginObject Implements IPluginManager.Add
        If GetType(IPlugin).IsAssignableFrom(t) Then
            Dim attributes As Object() = t.GetCustomAttributes(GetType(PluginAttribute), True)
            If attributes IsNot Nothing AndAlso attributes.Length = 1 Then
                Dim pluginObj As IPluginObject = New PluginObject(t, CType(attributes(0), PluginAttribute), myCloneFactory)
                myPluginsList.Add(pluginObj)
                Return pluginObj
            End If
        End If
        Throw New EECloudException(ErrorCode.InvalidPlugin)
    End Function

#End Region
End Class
