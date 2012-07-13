Namespace EECloudAPI.Messages
    Public MustInherit Class Message
        Public Message As PlayerIOClient.Message

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
        Public Title As String '0
        Public Text As String '1
        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
            Title = PMessage.Item(0)
            Text = PMessage.Item(1)
        End Sub
    End Class

    Public Class Init_Message
        Inherits Message
        Public UsernameOwner As String '0
        Public WorldName As String '1
        Public Plays As UInteger '2
        Public Encryption As String '3
        Public UserID As UInteger '4
        Public SpawnX As Integer '5
        Public SpawnY As Integer '6
        Public Username As String '7
        Public CanEdit As Boolean '8
        Public IsOwner As Boolean '9
        Public SizeX As Integer '10
        Public SizeY As Integer '11
        Public IsTutorialRoom As Boolean '12
        Public WorldData As Message '13-??

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

    Public Class Givewizard_Message
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

    Public Class AutoText_Message
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
