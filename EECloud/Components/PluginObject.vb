Friend NotInheritable Class PluginObject
    Implements IPluginObject

#Region "Fields"
    Private myPlugin As IPlugin
#End Region

#Region "Properties"
    Private myAttribute As PluginAttribute
    Friend ReadOnly Property Attribute As PluginAttribute Implements IPluginObject.Attribute
        Get
            Return myAttribute
        End Get
    End Property

    Private myStarted As Boolean
    Friend ReadOnly Property Started As Boolean Implements IPluginObject.Started
        Get
            Return myStarted
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New(Plugin As IPlugin)
        myPlugin = Plugin
    End Sub

    Friend Sub Start() Implements IPluginObject.Start

    End Sub


    Friend Sub [Stop]() Implements IPluginObject.Stop

    End Sub
#End Region
End Class
