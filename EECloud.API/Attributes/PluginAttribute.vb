Imports System.Text.RegularExpressions

<AttributeUsage(AttributeTargets.Class)>
Public NotInheritable Class PluginAttribute
    Inherits Attribute

#Region "Properties"

    Public Property Authors As String()
    Public Property Description As String = "No description"
    Public Property Version As String = "1.0.0.0"
    Public Property Category As PluginCategory
    Public Property IsStartup As Boolean = True
    Public Property StartupLoaded As Boolean = True
    Public Property StartupRooms As String()

    Private myChatName As String = Nothing

    Public Property ChatName As String
        Get
            Return myChatName
        End Get
        Set(value As String)
            If Regex.Match(value, "^\S{2,15}$").Success Then
                myChatName = value
            Else
                Throw New FormatException("Chat names may contain any characters but white-space characters(line breaks, tabs, spaces, hard spaces). They must have a minimum lenght of 2 Characters and a maximum of 15.")
            End If
        End Set
    End Property

#End Region
End Class
