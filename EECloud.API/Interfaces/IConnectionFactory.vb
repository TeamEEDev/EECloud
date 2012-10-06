Friend Interface IConnectionFactory
    Function GetConnection(Of TPlayer As {Player, New})(plugin As IPluginObject, ByVal instance As Object) As IConnection(Of TPlayer)
End Interface
