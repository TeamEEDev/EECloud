Friend MustInherit Class BaseGlobalComponent
    Protected WithEvents myBot As IBot
    Protected Friend Sub New(bot As IBot)
        myBot = bot
    End Sub
End Class
