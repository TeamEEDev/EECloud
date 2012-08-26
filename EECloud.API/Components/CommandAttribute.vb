Public Class CommandAttribute
    Inherits Attribute

    Sub New(type As String)
        Me.myType = type
    End Sub

    Dim myType As String
    Public ReadOnly Property Type As String
        Get
            Return myType
        End Get
    End Property
End Class
