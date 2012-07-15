Namespace Send
    Public MustInherit Class SendMessage
        Public MustOverride Function GetMessage() As PlayerIOClient.Message
    End Class

    Public Class Init_SendMessage
        Inherits SendMessage
        'No Arguments

        Public Overrides Function GetMessage() As PlayerIOClient.Message

        End Function
    End Class

    Public Class Init2_SendMessage
        Inherits SendMessage
        'No Arguments

        Public Overrides Function GetMessage() As PlayerIOClient.Message

        End Function
    End Class

    Public Class Coin_SendMessage
        Inherits SendMessage
        Public ReadOnly Coins As UInteger
        Public Sub New(PCoins As UInteger)
            Coins = PCoins
        End Sub

        Public Overrides Function GetMessage() As PlayerIOClient.Message

        End Function
    End Class
End Namespace