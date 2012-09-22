Friend Class CommandHandle
    Friend Sub New(action As Action(Of ICommand), syntax As CommandSyntax)
        Me.myAction = action
        Me.mySyntax = syntax
    End Sub

    Private myAction As Action(Of ICommand)
    Public ReadOnly Property Action As Action(Of ICommand)
        Get
            Return myAction
        End Get
    End Property

    Private mySyntax As CommandSyntax
    Public ReadOnly Property Syntax As CommandSyntax
        Get
            Return mySyntax
        End Get
    End Property

    Private myAccessRight As AccessRight
    Public ReadOnly Property AccessRight As AccessRight
        Get
            Return myAccessRight
        End Get
    End Property
End Class
