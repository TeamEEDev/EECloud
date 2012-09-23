﻿Friend NotInheritable Class PluginObject
    Implements IPluginObject

#Region "Fields"
    Private myPlugin As IPlugin
    Private ReadOnly myPluginType As Type
    Private lockObj As New Object
#End Region

#Region "Properties"
    Private myAttribute As PluginAttribute
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
#End Region

#Region "Methods"
    Friend Sub New(plugin As Type)
        If GetType(IPlugin).IsAssignableFrom(plugin) Then
            myPluginType = plugin
            Enable(True)
        Else
            Throw New EECloudException(ErrorCode.InvalidPlugin, "Type does not inherit from EECloud.API.IPlugin")
        End If
    End Sub

    Private Sub Enable(isStartup As Boolean)
        SyncLock lockObj
            If Not Started Then
                Cloud.Logger.Log(LogPriority.Info, String.Format("Enabling {0}...", myPluginType.Name))
                Try
                    myPlugin = CType(Activator.CreateInstance(myPluginType, True), IPlugin)
                    myPlugin.Enable()
                Catch ex As Exception
                    Cloud.Logger.Log(LogPriority.Error, String.Format("Failed to start plugin {0}. Disabling...", myPluginType.Name))
                    Cloud.Logger.Log(ex)
                    [Stop]()
                End Try
            Else
                Throw New EECloudException(ErrorCode.PluginLoadError, "Plugin already loaded.")
            End If
        End SyncLock
    End Sub


    Friend Sub [Stop]() Implements IPluginObject.Stop
        SyncLock lockObj
            If Started Then
                Cloud.Logger.Log(LogPriority.Info, String.Format("Disabling {0}...", myPluginType.Name))
                Try
                    myPlugin.Disable()
                Catch ex As Exception
                    Cloud.Logger.Log(LogPriority.Error, String.Format("Failed to disable Plugin {0}.", myPluginType.Name))
                    Cloud.Logger.Log(ex)
                Finally
                    myPlugin = Nothing
                End Try
            Else
                Throw New EECloudException(ErrorCode.PluginUnloadError, "Plugin must be loaded first.")
            End If
        End SyncLock
    End Sub

    Public Sub Start() Implements IPluginObject.Start
        If Started Then
            [Stop]()
        End If
        If Not Started Then
            Enable(False)
        End If
    End Sub
#End Region


End Class
