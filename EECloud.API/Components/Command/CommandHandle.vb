Public Class CommandHandle
    Friend Sub New(action As Action(Of Command), syntax As CommandSyntax)
        Me.myAction = action
        Me.mySyntax = syntax
    End Sub

    Private myAction As Action(Of Command)
    Public ReadOnly Property Action As Action(Of Command)
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
End Class
