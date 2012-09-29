Friend Interface IPlugin 'Just because generics suck atm
    Sub Enable()
    Sub Enable(creator As ICreator, pluginObj As IPluginObject)
    Sub Connect(creator As ICreator, pluginObj As IPluginObject)
    Sub Disable()
End Interface
