Friend Interface IClientCloneFactory
    Function GetConnection (Of TPlayer As {Player, New})(plugin As IPluginObject) As IClient(Of TPlayer)
End Interface
