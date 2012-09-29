Public Interface ICreator
    Function GenerateConnection(Of TPlayer As {Player, New})(plugin As IPluginObject) As IConnection(Of TPlayer)
End Interface
