Public Interface IPluginManager
    ReadOnly Property Plugins As IReadOnlyCollection(Of IPluginObject)
    ReadOnly Property Plugin(name As String) As IPluginObject
    Sub Load(ByVal t As Type)
End Interface
