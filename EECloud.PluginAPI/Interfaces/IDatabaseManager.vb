Public Interface IDatabaseManager
    Property Client As PlayerIOClient.Client
    Sub SetObject(Table As String, Key As String, Obj As PlayerIOClient.DatabaseObject)
    Sub GetObject(Table As String, Key As String)
    Sub SetProperty(Table As String, Key As String, PropertyName As String, Value As Object)
    Sub SetRelativeNumber(Table As String, Key As String, PropertyName As String, RelativeValue As Integer)
End Interface
