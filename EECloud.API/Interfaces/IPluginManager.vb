Public Interface IPluginManager
    Sub Load(Plugin As Type)
    Sub Unload(Plugin As Type)
    Sub ReloadAll()
    ReadOnly Property PluginTypes As IEnumerable(Of Type)
End Interface
