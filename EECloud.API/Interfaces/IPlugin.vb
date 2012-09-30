Friend Interface IPlugin 'Just because generics suck atm
    Sub Enable()
    Sub Enable(creator As IConnectionFactory, pluginObj As IPluginObject)
    Sub Connect(creator As IConnectionFactory, pluginObj As IPluginObject)
    Sub Disable()
End Interface
