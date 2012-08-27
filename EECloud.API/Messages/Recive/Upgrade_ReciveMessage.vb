Public Class Upgrade_ReciveMessage
    Inherits ReciveMessage
    'No arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class
