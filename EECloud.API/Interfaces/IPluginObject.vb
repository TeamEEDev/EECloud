Public Interface IPluginObject
    Event OnEnable As EventHandler
    Event OnDisable As EventHandler
    Sub Restart()
    Sub [Stop]()
    ReadOnly Property Attribute As PluginAttribute
    ReadOnly Property Started As Boolean
    ReadOnly Property Name As String
End Interface
