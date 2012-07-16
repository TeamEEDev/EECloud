Namespace Send
    Public MustInherit Class SendMessage
        Public MustOverride Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
    End Class

    Public Class Init_SendMessage
        Inherits SendMessage
        'No Arguments

        Public Overrides Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
            Return PlayerIOClient.Message.Create("init")
        End Function
    End Class

    Public Class Init2_SendMessage
        Inherits SendMessage
        'No Arguments

        Public Overrides Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
            Return PlayerIOClient.Message.Create("init2")
        End Function
    End Class

    Public Class BlockPlace_SendMessage
        Inherits SendMessage
        Public ReadOnly Coins As UInteger
        Public Sub New(PCoins As UInteger)
            Coins = PCoins
        End Sub

        Public Overrides Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
            Return PlayerIOClient.Message.Create(Meta.Encryption, Coins)
        End Function
    End Class

    Public Class CoindoorPlace_SendMessage
        Inherits SendMessage
        Public ReadOnly Coins As UInteger
        Public Sub New(PCoins As UInteger)
            Coins = PCoins
        End Sub

        Public Overrides Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
            Return PlayerIOClient.Message.Create(Meta.Encryption, Coins)
        End Function
    End Class

    Public Class Coin_SendMessage
        Inherits SendMessage
        Public ReadOnly Coins As UInteger
        Public Sub New(PCoins As UInteger)
            Coins = PCoins
        End Sub

        Public Overrides Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
            Return PlayerIOClient.Message.Create("c", Coins)
        End Function
    End Class
End Namespace