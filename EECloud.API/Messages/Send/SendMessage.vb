Public MustInherit Class SendMessage
    Inherits EventArgs
    Friend MustOverride Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
End Class
