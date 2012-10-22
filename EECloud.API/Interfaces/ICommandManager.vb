Public Interface ICommandManager
    ReadOnly Property Count As Integer
    Function Contains(cmd As String) As Boolean
    Function Contains(cmd As String, paramCount As Integer) As Boolean
    Sub Load(target As Object)
    Sub InvokeCommand(ByVal player As Player, ByVal msg As String, ByVal rights As Group)
End Interface
