Public Interface IPluginManager
    Sub Load(plugin As Type)
    Sub Unload(plugin As Type)
    Sub ReloadAll()
    ReadOnly Property PluginTypes As IEnumerable(Of Type)
End Interface
