Public MustInherit Class ReciveMessage
    Inherits EventArgs
    <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)>
    Public ReadOnly PlayerIOMessage As PlayerIOClient.Message

    Friend Sub New(message As PlayerIOClient.Message)
        PlayerIOMessage = message
    End Sub
End Class
