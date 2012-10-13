Public Interface IPluginManager
    ReadOnly Property Plugins As IReadOnlyCollection(Of IPluginObject)
    Sub Load(ByVal t As Type)
End Interface
