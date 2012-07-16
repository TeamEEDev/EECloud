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
        Public ReadOnly Layer As Layer
        Public ReadOnly X As Integer
        Public ReadOnly Y As Integer
        Public ReadOnly ID As Integer
        Public Sub New(PLayer As Layer, PX As Integer, PY As Integer, PID As Integer)
            Layer = PLayer
            X = PX
            Y = PY
            ID = PID
        End Sub

        Public Overrides Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
            Return PlayerIOClient.Message.Create(Meta.Encryption, Meta.BlockManager.CorrectLayer(ID, Layer), X, Y, ID)
        End Function
    End Class

    Public Class CoindoorPlace_SendMessage
        Inherits BlockPlace_SendMessage
        Public ReadOnly CoinsToCollect As Integer

        Public Sub New(PLayer As Layer, PX As Integer, PY As Integer, PID As Integer, PCoinsToCollect As Integer)
            MyBase.New(PLayer, PX, PY, PID)
            CoinsToCollect = PCoinsToCollect
        End Sub

        Public Overrides Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
            If Meta.BlockManager.IsCoindoor(ID) Then
                Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(Meta)
                myMessage.Add(CoinsToCollect)
                Return myMessage
            Else
                Return MyBase.GetMessage(Meta)
            End If
        End Function
    End Class

    Public Class SoundPlace_SendMessage
        Inherits BlockPlace_SendMessage
        Public ReadOnly BeatID As Integer

        Public Sub New(PLayer As Layer, PX As Integer, PY As Integer, PID As Integer, PBeatID As Integer)
            MyBase.New(PLayer, PX, PY, PID)
            BeatID = PBeatID
        End Sub

        Public Overrides Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
            If Meta.BlockManager.IsSound(ID) Then
                Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(Meta)
                myMessage.Add(BeatID)
                Return myMessage
            Else
                Return MyBase.GetMessage(Meta)
            End If
        End Function
    End Class

    Public Class LabelPlace_SendMessage
        Inherits BlockPlace_SendMessage
        Public ReadOnly Text As String

        Public Sub New(PLayer As Layer, PX As Integer, PY As Integer, PID As Integer, PText As String)
            MyBase.New(PLayer, PX, PY, PID)
            Text = PText
        End Sub

        Public Overrides Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
            If Meta.BlockManager.IsLabel(ID) Then
                Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(Meta)
                myMessage.Add(Text)
                Return myMessage
            Else
                Return MyBase.GetMessage(Meta)
            End If
        End Function
    End Class

    Public Class PortalPlace_SendMessage
        Inherits BlockPlace_SendMessage
        Public ReadOnly PortalID As Integer
        Public ReadOnly PortalTarget As Integer
        Public ReadOnly PortalRotation As Integer

        Public Sub New(PLayer As Layer, PX As Integer, PY As Integer, PID As Integer, PPortalID As Integer, PPortalTarget As Integer, PPortalRotation As Integer)
            MyBase.New(PLayer, PX, PY, PID)
            PortalID = PPortalID
            PortalTarget = PPortalTarget
            PortalRotation = PPortalRotation
        End Sub

        Public Overrides Function GetMessage(Meta As SendMessageMeta) As PlayerIOClient.Message
            If Meta.BlockManager.IsPortal(ID) Then
                Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(Meta)
                myMessage.Add(PortalRotation)
                myMessage.Add(PortalID)
                myMessage.Add(PortalTarget)
                Return myMessage
            Else
                Return MyBase.GetMessage(Meta)
            End If
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
