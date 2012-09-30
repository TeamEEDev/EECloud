Imports PlayerIOClient

Public MustInherit Class SendMessage
    Inherits EventArgs
    Friend MustOverride Function GetMessage(connection As IConnection(Of player)) As Message
End Class
