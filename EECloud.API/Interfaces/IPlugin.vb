Friend Interface IPlugin 'Just because generics suck atm
    Sub Enable()
    Sub Enable(creator As ICreator)
    Sub Connect(creator As ICreator)
    Sub Disable()
End Interface
