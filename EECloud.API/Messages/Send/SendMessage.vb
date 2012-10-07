Imports PlayerIOClient

Public MustInherit Class SendMessage
    Inherits EventArgs
    Friend MustOverride Function GetMessage(world As IWorld) As Message
End Class
