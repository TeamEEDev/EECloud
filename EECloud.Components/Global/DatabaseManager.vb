Public Class DatabaseManager
    Implements IDatabaseManager

    Public Property Client As Client Implements IDatabaseManager.Client

    Public Function GetObject(Table As String, Key As String) As DatabaseObject Implements IDatabaseManager.GetObject

    End Function

    Public Sub SetObject(Table As String, Key As String, Obj As DatabaseObject) Implements IDatabaseManager.SetObject

    End Sub

    Public Sub SetProperty(Table As String, Key As String, PropertyName As String, Value As Object) Implements IDatabaseManager.SetProperty

    End Sub

    Public Sub SetRelativeNumber(Table As String, Key As String, PropertyName As String, RelativeValue As Integer) Implements IDatabaseManager.SetRelativeNumber

    End Sub
End Class
