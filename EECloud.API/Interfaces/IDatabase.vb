Public Interface IDatabase
    Property Client As PlayerIOClient.Client
    Sub SetObject(Table As String, Key As String, Obj As PlayerIOClient.DatabaseObject)
    Sub SetProperty(Table As String, Key As String, PropertyName As String, Value As Object)
    Sub SetRelativeNumber(Table As String, Key As String, PropertyName As String, RelativeValue As Integer)
    Function GetObject(Table As String, Key As String) As PlayerIOClient.DatabaseObject
End Interface
