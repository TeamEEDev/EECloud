<AttributeUsage(AttributeTargets.Class)>
Public Class PluginAttribute
    Inherits System.Attribute
    Public Property Authors As String()
    Public Property Description As String = String.Empty
    Public Property Version As String = String.Empty
    Public Property Category As PluginCategory
    Public Property StartupPriority As PluginStartupPriority
End Class
