Imports System.Text.RegularExpressions

<AttributeUsage(AttributeTargets.Class)>
Public NotInheritable Class PluginAttribute
    Inherits Attribute

#Region "Properties"
    
    ''' <summary>
    ''' A list of people who worked on this plugin.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Authors As String()
    
    ''' <summary>
    ''' A short text describing the fuctionality of this plugin.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Description As String = "No description"
    
    ''' <summary>
    ''' The plugin's version.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Version As String = "1.0.0.0"
    
    ''' <summary>
    ''' The category of this plugin.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Category As PluginCategory
    
    ''' <summary>
    ''' Determines whether this plugin should be started automatically once loaded at startup. Defaults to true.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsStartup As Boolean = True
    
    ''' <summary>
    ''' Determines whether the plugin should be loaded into the plugin manager to allow "!enable PluginName". Defaults to true.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartupLoaded As Boolean = True
    
    ''' <summary>
    ''' If not null, the plugin will start up only in the specified worlds.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StartupRooms As String()

    Private myChatName As String = Nothing
    
    ''' <summary>
    ''' The chat name used whenever the chatter object is used to talk.
    ''' </summary>
    ''' <remarks></remarks>
    Public Property ChatName As String
        Get
            Return myChatName
        End Get
        Set(value As String)
            If Regex.Match(value, "^\S{2,15}$").Success Then
                myChatName = value
            Else
                Throw New FormatException("Chat names may contain any characters but white-space characters (line breaks, tabs, spaces or hard spaces). They must have a minimum length of 2 characters and a maximum of 15.")
            End If
        End Set
    End Property

#End Region
End Class
