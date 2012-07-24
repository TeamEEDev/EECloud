Friend NotInheritable Class Database
    Inherits BaseGlobalComponent
    Implements IDatabase

    Public Sub New(PBot As Bot)
        MyBase.New(PBot)
    End Sub

    Public Property Client As Client Implements IDatabase.Client

    Public Function GetObject(Table As String, Key As String) As DatabaseObject Implements IDatabase.GetObject

    End Function

    Public Sub SetObject(Table As String, Key As String, Obj As DatabaseObject) Implements IDatabase.SetObject

    End Sub

    Public Sub SetProperty(Table As String, Key As String, PropertyName As String, Value As Object) Implements IDatabase.SetProperty

    End Sub

    Public Sub SetRelativeNumber(Table As String, Key As String, PropertyName As String, RelativeValue As Integer) Implements IDatabase.SetRelativeNumber

    End Sub
End Class
