Public Interface IPluginManager
    ReadOnly Property Plugins As IEnumerable(Of IPluginObject)
    Function Add(t As Type, ByVal factory As IConnectionFactory) As IPluginObject
End Interface
