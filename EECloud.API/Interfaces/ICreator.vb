Public Interface IConnectionFactory
    Function GetConnection(Of TPlayer As {Player, New})(plugin As IPluginObject) As IConnection(Of TPlayer)
End Interface
