Public Interface IPluginManager
    Sub Load(Plugin As Type)
    Sub Unload(Plugin As IPlugin)
    Sub ReloadAll()
    ReadOnly Property PluginTypes As IEnumerable(Of Type)
End Interface
