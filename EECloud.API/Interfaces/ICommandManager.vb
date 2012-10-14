Public Interface ICommandManager
    Sub Load(target As Object)
    Sub InvokeCommand(ByVal player As Player, ByVal msg As String, ByVal rights As Group)
End Interface
