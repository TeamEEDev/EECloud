Imports PlayerIOClient

Public NotInheritable Class RefreshShopReceiveMessage
    Inherits ReceiveMessage

    'No arguments; this is just a request to refresh the shop on the client-side.

    Friend Sub New(message As Message)
        MyBase.New(message)
    End Sub
End Class
