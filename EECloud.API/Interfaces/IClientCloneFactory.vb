Friend Interface IClientCloneFactory
    Function GetConnection(Of TPlayer As {Player, New})(plugin As IPluginObject, ByVal instance As Object) As IClient(Of TPlayer)
End Interface
