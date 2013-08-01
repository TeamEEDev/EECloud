Imports System.Reflection

Public Interface IPluginManager
    ReadOnly Property Plugins As IReadOnlyCollection(Of IPluginObject)
    ReadOnly Property Plugin(name As String) As IPluginObject
    Sub Load(t As Type)
    Sub Load(assembly As Assembly)
End Interface
