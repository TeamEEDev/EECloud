Public Interface IPluginObject
    Sub Start()
    Sub [Stop]()
    Sub Restart()
    ReadOnly Property Attribute As PluginAttribute
    ReadOnly Property Started As Boolean
End Interface
