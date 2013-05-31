Imports System.Text.RegularExpressions

<AttributeUsage(AttributeTargets.Class)>
Public NotInheritable Class PluginAttribute
    Inherits Attribute

#Region "Properties"
    
    ''' <summary>
    ''' A list of people who've worked on this plugin.
    ''' </summary>
    Public Property Authors As String()
    
    ''' <summary>
    ''' A short text describing the fuctionality of this plugin.
    ''' </summary>
    Public Property Description As String = "No description"
    
    ''' <summary>
    ''' The plugin's version
    ''' </summary>
    Public Property Version As String = "1.0.0.0"
    
    ''' <summary>
    ''' The category of this plugin.
    ''' </summary>
    Public Property Category As PluginCategory
    
    ''' <summary>
    ''' Determines whether this plugin should be started automatically once loaded at startup. Defaults to true.
    ''' </summary>
    Public Property IsStartup As Boolean = True
    
    ''' <summary>
    ''' Determines whether the plugin should be loaded into the Plugin Manager to allow "!enable PluginName". Defaults to true.
    ''' </summary>
    Public Property StartupLoaded As Boolean = True
    
    ''' <summary>
    ''' If not null, the plugin will start up only in the specified worlds.
    ''' </summary>
    Public Property StartupRooms As String()

    Private myChatName As String = Nothing
    
    ''' <summary>
    ''' The chat name used whenever the chatter object is used to talk.
    ''' </summary>
    Public Property ChatName As String
        Get
            Return myChatName
        End Get
        Set(value As String)
            If value Is Nothing Then
                Throw New ArgumentNullException(value)
            End If

            If value.Length >= 2 AndAlso value.Length <= 15 Then
                Dim throwEx As Boolean
                For n = 0 To value.Length - 1
                    If Char.IsWhiteSpace(value(n)) Then
                        throwEx = True
                        Exit For
                    End If
                Next

                If Not throwEx Then
                    myChatName = value
                    Exit Property
                End If
            End If

            Throw New FormatException("Chat names may contain any characters but whitespace characters (line breaks, tabs, spaces or hard spaces). They must have a minimum length of 2 characters and a maximum of 15.")
        End Set
    End Property

#End Region

End Class
