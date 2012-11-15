Friend NotInheritable Class PluginObject
    Implements IPluginObject


#Region "Fields"
    Private myPlugin As IPlugin
    Private ReadOnly myPluginType As Type
    Private ReadOnly myLockObj As New Object
    Private ReadOnly myCloneFactory As IClientCloneFactory
#End Region

#Region "Events"

    Friend Event OnDisable(sender As Object, e As EventArgs) Implements IPluginObject.OnDisable

    Friend Event OnEnable(sender As Object, e As EventArgs) Implements IPluginObject.OnEnable

#End Region

#Region "Properties"
    Private ReadOnly myAttribute As PluginAttribute

    Friend ReadOnly Property Attribute As PluginAttribute Implements IPluginObject.Attribute
        Get
            Return myAttribute
        End Get
    End Property

    Friend ReadOnly Property Started As Boolean Implements IPluginObject.Started
        Get
            Return myPlugin IsNot Nothing
        End Get
    End Property

    Friend ReadOnly Property Name As String Implements IPluginObject.Name
        Get
            Return myPluginType.Name
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(plugin As Type, ByVal attribute As PluginAttribute, ByVal cloneFactory As IClientCloneFactory)
        myAttribute = attribute
        myCloneFactory = cloneFactory
        myPluginType = plugin
        If GetType(IPlugin).IsAssignableFrom(plugin) Then
            If attribute.IsStartup Then
                Enable()
            End If
        Else
            Throw New EECloudException(ErrorCode.InvalidPlugin, "Type does not inherit from EECloud.API.IPlugin")
        End If
    End Sub

    Private Sub Enable()
        SyncLock myLockObj
            If Not Started Then
                myPlugin = CType(Activator.CreateInstance(myPluginType, True), IPlugin)
                myPlugin.Enable(myCloneFactory, Me)

                RaiseEvent OnEnable(Me, EventArgs.Empty)
            Else
                Throw New EECloudException(ErrorCode.PluginLoadError, "Plugin already loaded.")
            End If
        End SyncLock
    End Sub

    Friend Sub [Stop]() Implements IPluginObject.Stop
        SyncLock myLockObj
            If Started Then
                myPlugin.Disable()
                myPlugin = Nothing

                RaiseEvent OnDisable(Me, EventArgs.Empty)
            Else
                Throw New EECloudException(ErrorCode.PluginUnloadError, "Plugin must be loaded first.")
            End If
        End SyncLock
    End Sub

    Friend Sub Restart() Implements IPluginObject.Restart
        If Started Then
            [Stop]()
        End If
        If Not Started Then
            Enable()
        End If
    End Sub

#End Region
End Class
