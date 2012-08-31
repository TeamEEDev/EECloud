<AttributeUsage(AttributeTargets.Method)>
Public Class CommandAttribute
    Inherits Attribute

    Sub New(type As String, syntax As String, minPermission As Group)
        Me.myType = type
        Me.mySyntax = syntax
        Me.myMinPermission = minPermission
    End Sub

    Dim myType As String
    Public ReadOnly Property Type As String
        Get
            Return myType
        End Get
    End Property

    Private mySyntax As String
    Public ReadOnly Property Syntax As String
        Get
            Return mySyntax
        End Get
    End Property

    Private myMinPermission As Group
    Public ReadOnly Property MinPermission As Group
        Get
            Return myMinPermission
        End Get
    End Property

    Private myAccessRight As AccessRight
    Public ReadOnly Property AccessRight As AccessRight
        Get
            Return myAccessRight
        End Get
    End Property

    Public Property Aliases As String() = {}
End Class
