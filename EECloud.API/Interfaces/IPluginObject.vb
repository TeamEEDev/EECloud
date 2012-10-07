Public Interface IPluginObject
    Sub Restart()
    Sub [Stop]()
    ReadOnly Property Attribute As PluginAttribute
    ReadOnly Property Started As Boolean
    ReadOnly Property Name As String
End Interface
