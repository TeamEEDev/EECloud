Friend NotInheritable Class PluginObject
    Implements IPluginObject

#Region "Fields"
    Private myPlugin As IPlugin
    Private ReadOnly myPluginType As Type
    Private ReadOnly myLockObj As New Object
    Private ReadOnly myCloneFactory As IClientCloneFactory
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
        If GetType(IPlugin).IsAssignableFrom(plugin) Then
            myPluginType = plugin
            Enable(cloneFactory)
        Else
            Throw New EECloudException(ErrorCode.InvalidPlugin, "Type does not inherit from EECloud.API.IPlugin")
        End If
    End Sub

    Private Sub Enable(cloneFactory As IClientCloneFactory)
        SyncLock myLockObj
            If Not Started Then
                Cloud.Logger.Log(LogPriority.Info, String.Format("Enabling {0}...", myPluginType.Name))
                Try
                    myPlugin = CType(Activator.CreateInstance(myPluginType, True), IPlugin)
                    myPlugin.Enable(cloneFactory, Me)
                Catch ex As Exception
                    Cloud.Logger.Log(LogPriority.Error, String.Format("Failed to start plugin {0}. Disabling...", myPluginType.Name))
                    Cloud.Logger.LogEx(ex)
                    [Stop]()
                End Try
            Else
                Throw New EECloudException(ErrorCode.PluginLoadError, "Plugin already loaded.")
            End If
        End SyncLock
    End Sub

    Friend Sub [Stop]() Implements IPluginObject.Stop
        SyncLock myLockObj
            If Started Then
                Cloud.Logger.Log(LogPriority.Info, String.Format("Disabling {0}...", myPluginType.Name))
                Try
                    myPlugin.Disable()
                Catch ex As Exception
                    Cloud.Logger.Log(LogPriority.Error, String.Format("Failed to disable Plugin {0}.", myPluginType.Name))
                    Cloud.Logger.LogEx(ex)
                Finally
                    myPlugin = Nothing
                End Try
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
            Enable(myCloneFactory)
        End If
    End Sub

#End Region
End Class
