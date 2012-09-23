Public Interface IPluginManager
    ReadOnly Property Plugins As IEnumerable(Of IPluginObject)
    Function Add(t As Type) As IPluginObject
End Interface
