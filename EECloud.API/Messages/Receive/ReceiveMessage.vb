Imports System.ComponentModel
Imports PlayerIOClient

Public MustInherit Class ReceiveMessage
    Inherits EventArgs
    <EditorBrowsable(EditorBrowsableState.Advanced)>
    Public ReadOnly PlayerIOMessage As Message

    Friend Sub New(message As Message)
        PlayerIOMessage = message
    End Sub
End Class
