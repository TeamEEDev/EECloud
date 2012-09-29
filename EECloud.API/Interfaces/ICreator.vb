Public Interface ICreator
    Function GenerateConnection(Of P As {Player, New})(plugin As IPluginObject) As IConnection(Of P)
End Interface
