Imports System.IO
Imports System.Reflection

Friend NotInheritable Class PluginManager
    Implements IPluginManager

#Region "Properties"
    Private myPluginsList As New List(Of IPluginObject)
    Friend ReadOnly Property Plugins As IEnumerable(Of IPluginObject) Implements IPluginManager.Plugins
        Get
            Return myPluginsList
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New()

    End Sub

    Public Function Add(t As Type) As IPluginObject Implements IPluginManager.Add
        If GetType(IPlugin).IsAssignableFrom(t) Then
            Dim myAttributes As Object() = t.GetCustomAttributes(GetType(PluginAttribute), True)
            If myAttributes IsNot Nothing AndAlso myAttributes.Length = 1 Then
                Dim pluginObj As IPluginObject = New PluginObject(t)
                myPluginsList.Add(pluginObj)
                Return pluginObj
            End If
        End If
        Throw New EECloudException(ErrorCode.InvalidPlugin)
    End Function
#End Region


End Class
