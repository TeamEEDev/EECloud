Friend NotInheritable Class PluginObject
    Implements IPluginObject

#Region "Fields"
    Private myBot As IBot
    Private myPlugin As IPlugin
    Private ReadOnly myPluginType As Type
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
    Friend Sub New(bot As IBot, plugin As Type)
        If GetType(IPlugin).IsAssignableFrom(myPluginType) Then
            myPluginType = plugin
            myBot = bot
        Else
            Throw New EECloudException(ErrorCode.InvalidPlugin, "Type does not inherit from EECloud.API.IPlugin")
        End If
    End Sub

    Friend Sub Start() Implements IPluginObject.Start
        SyncLock myPlugin
            If Not Started Then
                myBot.Logger.Log(LogPriority.Info, String.Format("Enabling {0}...", myPluginType.Name))
                Try
                    myPlugin = CType(Activator.CreateInstance(myPluginType, True), IPlugin)
                    myPlugin.SetupPlugin(myBot)
                Catch ex As Exception
                    myBot.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled: {1} {2}", ex.ToString, ex.Message, ex.StackTrace))
                    myBot.Logger.Log(LogPriority.Error, String.Format("Failed to start plugin {0}. Disabling...", myPluginType.Name))
                    [Stop]()
                End Try
            Else
                Throw New EECloudException(ErrorCode.PluginLoadError, "Plugin already loaded.")
            End If
        End SyncLock
    End Sub


    Friend Sub [Stop]() Implements IPluginObject.Stop
        SyncLock myPlugin
            If Started Then
                myBot.Logger.Log(LogPriority.Info, String.Format("Disabling {0}...", myPluginType.Name))
                Try
                    myPlugin.Disable()
                Catch ex As Exception
                    myBot.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled: {1} {2}", ex.ToString, ex.Message, ex.StackTrace))
                    myBot.Logger.Log(LogPriority.Error, String.Format("Failed to disable Plugin {0}.", myPluginType.Name))
                Finally
                    myPlugin = Nothing
                End Try
            Else
                Throw New EECloudException(ErrorCode.PluginUnloadError, "Plugin must be loaded first.")
            End If
        End SyncLock
    End Sub

    Public Sub Restart() Implements IPluginObject.Restart
        If Started Then
            [Stop]()
        End If
        If Not Started Then
            Start()
        End If
    End Sub
#End Region


End Class
