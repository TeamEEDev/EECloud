Imports PlayerIOClient

Public MustInherit Class SendMessage
    Inherits EventArgs
    Friend MustOverride Function GetMessage(world As World) As Message
End Class
