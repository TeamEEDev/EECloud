Public Interface IPluginObject
    Sub Start()
    Sub [Stop]()
    Sub Connect(ByVal creator As IConnectionFactory)
    ReadOnly Property Attribute As PluginAttribute
    ReadOnly Property Started As Boolean
    ReadOnly Property Name As String
End Interface
