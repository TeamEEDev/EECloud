Namespace EECloudAPI.Messages
    Public MustInherit Class Message
        Public ReadOnly Message As PlayerIOClient.Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            Message = PMessage
        End Sub
    End Class

    Public Class GroupDisallowedJoin_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Upgrade_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Info_Message
        Inherits Message
        Public ReadOnly Title As String '0
        Public ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
            Title = PMessage.Item(0)
            Text = PMessage.Item(1)
        End Sub
    End Class

    Public Class Init_Message
        Inherits Message
        Public ReadOnly UsernameOwner As String '0
        Public ReadOnly WorldName As String '1
        Public ReadOnly Plays As UInteger '2
        Public ReadOnly Encryption As String '3
        Public ReadOnly UserID As UInteger '4
        Public ReadOnly SpawnX As Integer '5
        Public ReadOnly SpawnY As Integer '6
        Public ReadOnly Username As String '7
        Public ReadOnly CanEdit As Boolean '8
        Public ReadOnly IsOwner As Boolean '9
        Public ReadOnly SizeX As Integer '10
        Public ReadOnly SizeY As Integer '11
        Public ReadOnly IsTutorialRoom As Boolean '12

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class UpdateMeta_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Add_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Left_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Move_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Coin_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Crown_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class SilverCrown_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Face_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class ShowKey_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class HideKey_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Say_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class AutoText_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Write_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class BlockPlace_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class CoinDoorPlace_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class SoundPlace_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class PortalPlace_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class LabelPlace_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Godmode_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Modmode_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Access_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class LostAccess_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Teleport_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Reset_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Clear_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class SaveDone_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class RefreshShop_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class
End Namespace