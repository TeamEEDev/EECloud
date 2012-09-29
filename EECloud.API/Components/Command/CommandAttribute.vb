<AttributeUsage(AttributeTargets.Method)>
Public NotInheritable Class CommandAttribute
    Inherits Attribute

    Sub New(type As String, minPermission As Group)
        myType = type
        myMinPermission = minPermission
    End Sub

    Private ReadOnly myType As String
    Public ReadOnly Property Type As String
        Get
            Return myType
        End Get
    End Property

    Private ReadOnly myMinPermission As Group
    Public ReadOnly Property MinPermission As Group
        Get
            Return myMinPermission
        End Get
    End Property
    Public Property AccessRight As AccessRight

    Public Property Aliases As String()
End Class
