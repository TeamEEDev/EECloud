Public MustInherit Class SendMessage
    Inherits EventArgs
    Friend MustOverride Function GetMessage(connection As IConnection(Of player)) As PlayerIOClient.Message
End Class
