Friend MustInherit Class BaseGlobalComponent
    Protected WithEvents myBot As Bot
    Protected Friend Sub New(bot As Bot)
        myBot = bot
    End Sub
End Class
