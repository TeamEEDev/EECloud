Imports System.Text.RegularExpressions

<AttributeUsage(AttributeTargets.Class)>
Public NotInheritable Class PluginAttribute
    Inherits Attribute

#Region "Properties"

    Public Property Authors As String()
    Public Property Description As String = String.Empty
    Public Property Version As String = String.Empty
    Public Property Category As PluginCategory
    Public Property IsStartup As Boolean = True

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
