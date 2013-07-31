Public Class CommandException
    Inherits Exception

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, e As Exception)
        MyBase.New(message, e)
    End Sub

End Class
