Public Class Add_ReceiveMessage
    Inherits ReceiveMessage
    'No arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class
