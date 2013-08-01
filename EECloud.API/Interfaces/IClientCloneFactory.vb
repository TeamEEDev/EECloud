Friend Interface IClientCloneFactory

    Function GetClient(Of TPlayer As {Player, New})(plugin As IPluginObject) As IClient(Of TPlayer)
    Sub DisposeClient(Of TPlayer As {Player, New})(client As IClient(Of TPlayer))

End Interface
