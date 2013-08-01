Imports PlayerIOClient

Public MustInherit Class SendMessage
    Inherits EventArgs

    Friend MustOverride Function GetMessage(game As IGame) As Message
End Class
