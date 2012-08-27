Public Interface ISendMessageHandle(Of T As SendMessage)
    ReadOnly Property IsSent As Boolean

    Sub Send()
End Interface
