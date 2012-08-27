Public MustInherit Class SendEventArgs(Of T As SendMessage)
    Inherits EventArgs

    MustOverride ReadOnly Property Message As T

    MustOverride ReadOnly Property Handled As Boolean

    MustOverride Function GetHandle() As ISendMessageHandle(Of T)
End Class
