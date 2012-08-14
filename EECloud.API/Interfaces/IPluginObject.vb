Public Interface IPluginObject
    Sub Start()
    Sub [Stop]()
    ReadOnly Property Attribute As PluginAttribute
    ReadOnly Property Started As Boolean
End Interface
