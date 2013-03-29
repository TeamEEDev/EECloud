Imports System.Reflection

Friend NotInheritable Class PluginManager
    Implements IPluginManager

#Region "Fields"
    Private ReadOnly myCloneFactory As IClientCloneFactory
#End Region

#Region "Properties"

    Friend ReadOnly Property Plugin(name As String) As IPluginObject Implements IPluginManager.Plugin
        Get
            For Each p In myPluginsList
                If p.Name.Equals(name, StringComparison.OrdinalIgnoreCase) OrElse p.Attribute.ChatName.Equals(name, StringComparison.OrdinalIgnoreCase) Then
                    Return p
                End If
            Next
            Return Nothing
        End Get
    End Property

    Private ReadOnly myPluginsList As New List(Of IPluginObject)

    Friend ReadOnly Property Plugins As IReadOnlyCollection(Of IPluginObject) Implements IPluginManager.Plugins
        Get
            Return myPluginsList.AsReadOnly
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(cloneFactory As IClientCloneFactory)
        myCloneFactory = cloneFactory
    End Sub

    Friend Sub Load(t As Type) Implements IPluginManager.Load
        SyncLock myPluginsList
            If Not t.Namespace = "EECloud" AndAlso Not t.Namespace.StartsWith("EECloud.", StringComparison.Ordinal) Then
                If GetType(IPlugin).IsAssignableFrom(t) Then
                    Dim attributes As PluginAttribute() = t.GetCustomAttributes(GetType(PluginAttribute), True)

                    If attributes IsNot Nothing AndAlso attributes.Length = 1 Then
                        Dim pluginObj As IPluginObject = New PluginObject(t, attributes(0), myCloneFactory)
                        myPluginsList.Add(pluginObj)
                        Exit Sub
                    End If
                End If
            End If

            Throw New EECloudException(ErrorCode.InvalidPlugin)
        End SyncLock
    End Sub

    Public Sub Load(assembly As Assembly) Implements IPluginManager.Load
        'Checking for valid plugins
        Dim plugins1 As IEnumerable(Of Type) =
            From type As Type In assembly.GetTypes
            Where GetType(IPlugin).IsAssignableFrom(type)
            Let attributes As PluginAttribute() = type.GetCustomAttributes(GetType(PluginAttribute), True)
            Where attributes IsNot Nothing AndAlso attributes.Length = 1
            Let attribute As PluginAttribute = attributes(0)
            Where attribute.StartupLoaded AndAlso (attribute.StartupRooms Is Nothing OrElse attribute.StartupRooms.Length = 0 OrElse attribute.StartupRooms.Contains(Cloud.StartupWorldID))
            Select type

        'Activating valid plugins
        Using enumerator As IEnumerator(Of Type) = plugins1.GetEnumerator()
            Do
                Try
                    'Exit the loop if there are no more elements in the collection
                    If Not enumerator.MoveNext() Then Exit Do

                    Cloud.Logger.Log(LogPriority.Info, String.Format("Enabling {0}...", enumerator.Current.Name))
                    Load(enumerator.Current)
                Catch ex As Exception
                    Cloud.Logger.LogEx(ex)
                End Try
            Loop
        End Using
    End Sub

#End Region
End Class
