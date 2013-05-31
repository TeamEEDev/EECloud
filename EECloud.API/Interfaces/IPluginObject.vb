Public Interface IPluginObject

    ReadOnly Property Attribute As PluginAttribute
    ReadOnly Property Started As Boolean
    ReadOnly Property Name As String

    Sub Restart()
    Sub [Stop]()

    Event OnEnable As EventHandler
    Event OnDisable As EventHandler

End Interface
