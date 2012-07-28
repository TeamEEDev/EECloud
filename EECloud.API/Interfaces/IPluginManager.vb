Public Interface IPluginManager
    Sub Load(plugin As IPlugin)
    Sub Unload(plugin As IPlugin)

    ReadOnly Property PluginTypes As IEnumerable(Of Type)
End Interface
