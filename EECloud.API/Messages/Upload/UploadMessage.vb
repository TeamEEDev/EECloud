Public MustInherit Class UploadMessage
    Inherits SendMessage
    Friend MustOverride Sub SendMessage(connection As IConnection)
End Class
