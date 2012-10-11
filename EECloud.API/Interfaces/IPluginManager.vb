Public Interface IPluginManager
    ReadOnly Property Plugins As IReadOnlyCollection(Of IPluginObject)
    Function Load(t As Type) As IPluginObject
End Interface
