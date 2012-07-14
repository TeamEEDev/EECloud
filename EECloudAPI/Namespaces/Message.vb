Namespace Messages
    Public MustInherit Class Message
        Public ReadOnly Message As PlayerIOClient.Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            Message = PMessage
        End Sub
    End Class

    Public Class GroupDisallowedJoin_Message
        Inherits Message
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Upgrade_Message
        Inherits Message
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Info_Message
        Inherits Message
        Private ReadOnly Title As String '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            Title = CStr(PMessage.Item(0))
            Text = CStr(PMessage.Item(1))
        End Sub
    End Class

    Public Class Init_Message
        Inherits Message
        Private ReadOnly UsernameOwner As String '0
        Private ReadOnly WorldName As String '1
        Private ReadOnly Plays As UInteger '2
        Private ReadOnly Encryption As String '3
        Private ReadOnly UserID As Integer '4
        Private ReadOnly SpawnX As Integer '5
        Private ReadOnly SpawnY As Integer '6
        Private ReadOnly Username As String '7
        Private ReadOnly CanEdit As Boolean '8
        Private ReadOnly IsOwner As Boolean '9
        Private ReadOnly SizeX As Integer '10
        Private ReadOnly SizeY As Integer '11
        Private ReadOnly IsTutorialRoom As Boolean '12

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UsernameOwner = CStr(PMessage.Item(0))
            WorldName = CStr(PMessage.Item(1))
            Plays = CUInt(CStr(PMessage.Item(2)))
            Encryption = CStr(PMessage.Item(3))
            UserID = CInt(PMessage.Item(4))
            SpawnX = CInt(PMessage.Item(5))
            SpawnY = CInt(PMessage.Item(6))
            Username = CStr(PMessage.Item(7))
            CanEdit = CBool(PMessage.Item(8))
            IsOwner = CBool(PMessage.Item(9))
            SizeX = CInt(PMessage.Item(10))
            SizeY = CInt(PMessage.Item(11))
            IsTutorialRoom = CBool(PMessage.Item(12))
        End Sub
    End Class

    Public Class UpdateMeta_Message
        Inherits Message
        Private ReadOnly Owner As String '0
        Private ReadOnly Title As String '1
        Private ReadOnly Plays As Integer '2

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            Owner = CStr(PMessage.Item(0))
            Title = CStr(PMessage.Item(1))
            Plays = CInt(PMessage.Item(2))
        End Sub
    End Class

    Public Class Add_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly Username As String '1
        Private ReadOnly FaceID As Integer '2
        Private ReadOnly PlayerPosX As Integer '3
        Private ReadOnly PlayerPosY As Integer '4
        Private ReadOnly IsGod As Boolean '5
        Private ReadOnly IsMod As Boolean '6
        Private ReadOnly HasChat As Boolean '7
        Private ReadOnly Coins As Integer '8
        Private ReadOnly IsYourFriend As Boolean '9

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
            Username = CStr(PMessage.Item(1))
            FaceID = CInt(PMessage.Item(2))
            PlayerPosX = CInt(PMessage.Item(3))
            PlayerPosY = CInt(PMessage.Item(4))
            IsGod = CBool(PMessage.Item(5))
            IsMod = CBool(PMessage.Item(6))
            HasChat = CBool(PMessage.Item(7))
            Coins = CInt(PMessage.Item(8))
            IsYourFriend = CBool(PMessage.Item(9))
        End Sub
    End Class

    Public Class Left_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
        End Sub
    End Class

    Public Class Move_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly PlayerPosX As Integer '1
        Private ReadOnly PlayerPosY As Integer '2
        Private ReadOnly SpeedX As Single '3
        Private ReadOnly SpeedY As Single '4
        Private ReadOnly ModifierX As Single '5
        Private ReadOnly ModifierY As Single '6
        Private ReadOnly Horizontal As Single '7
        Private ReadOnly Vertical As Single '8
        Private ReadOnly Coins As Integer '9

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
            PlayerPosX = CInt(PMessage.Item(1))
            PlayerPosY = CInt(PMessage.Item(2))
            SpeedX = CSng(PMessage.Item(3))
            SpeedY = CSng(PMessage.Item(4))
            ModifierX = CSng(PMessage.Item(5))
            ModifierY = CSng(PMessage.Item(6))
            Horizontal = CSng(PMessage.Item(7))
            Vertical = CSng(PMessage.Item(8))
            Coins = CInt(PMessage.Item(9))
        End Sub
    End Class

    Public Class Coin_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly Coins As Integer '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
            Coins = CInt(PMessage.Item(1))
        End Sub
    End Class

    Public Class Crown_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
        End Sub
    End Class

    Public Class SilverCrown_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
        End Sub
    End Class

    Public Class Face_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly FaceID As Integer '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
            FaceID = CInt(PMessage.Item(1))
        End Sub
    End Class

    Public Class ShowKey_Message
        Inherits Message
        Private ReadOnly KeyColor As String '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            KeyColor = CStr(PMessage.Item(0))
        End Sub
    End Class

    Public Class HideKey_Message
        Inherits Message
        Private ReadOnly KeyColor As String '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            KeyColor = CStr(PMessage.Item(0))
        End Sub
    End Class

    Public Class Say_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
            Text = CStr(PMessage.Item(1))
        End Sub
    End Class

    Public Class SayOld_Message
        Inherits Message
        Private ReadOnly UserName As String '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserName = CStr(PMessage.Item(0))
            Text = CStr(PMessage.Item(1))
        End Sub
    End Class

    Public Class AutoText_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
            Text = CStr(PMessage.Item(1))
        End Sub
    End Class

    Public Class Write_Message
        Inherits Message
        Private ReadOnly Title As String '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            Title = CStr(PMessage.Item(0))
            Text = CStr(PMessage.Item(1))
        End Sub
    End Class

    Public Class BlockPlace_Message
        Inherits Message
        Private ReadOnly Layer As Layer '0
        Private ReadOnly PosX As Integer '1
        Private ReadOnly PosY As Integer '2
        Private ReadOnly BlockID As Integer '3

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            Layer = CType(PMessage.Item(0), Layer)
            PosX = CInt(PMessage.Item(1))
            PosY = CInt(PMessage.Item(2))
            BlockID = CInt(PMessage.Item(3))
        End Sub
    End Class

    Public Class CoinDoorPlace_Message
        Inherits Message
        Private ReadOnly PosX As Integer '0
        Private ReadOnly PosY As Integer '1
        Private ReadOnly BlockID As Integer '2
        Private ReadOnly CoinsToOpen As Integer '3

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            PosX = CInt(PMessage.Item(0))
            PosY = CInt(PMessage.Item(1))
            BlockID = CInt(PMessage.Item(2))
            CoinsToOpen = CInt(PMessage.Item(3))
        End Sub
    End Class

    Public Class SoundPlace_Message
        Inherits Message
        Private ReadOnly PosX As Integer '0
        Private ReadOnly PosY As Integer '1
        Private ReadOnly BlockID As Integer '2
        Private ReadOnly SoundID As Integer '3

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            PosX = CInt(PMessage.Item(0))
            PosY = CInt(PMessage.Item(1))
            BlockID = CInt(PMessage.Item(2))
            SoundID = CInt(PMessage.Item(3))
        End Sub
    End Class

    Public Class PortalPlace_Message
        Inherits Message
        Private ReadOnly PosX As Integer '0
        Private ReadOnly PosY As Integer '1
        Private ReadOnly BlockID As Integer '2
        Private ReadOnly Rotation As Integer '3
        Private ReadOnly ID As Integer '4
        Private ReadOnly Target As Integer '5

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            PosX = CInt(PMessage.Item(0))
            PosY = CInt(PMessage.Item(1))
            BlockID = CInt(PMessage.Item(2))
            Rotation = CInt(PMessage.Item(3))
            ID = CInt(PMessage.Item(4))
            Target = CInt(PMessage.Item(5))
        End Sub
    End Class

    Public Class LabelPlace_Message
        Inherits Message
        Private ReadOnly PosX As Integer '0
        Private ReadOnly PosY As Integer '1
        Private ReadOnly BlockID As Integer '2
        Private ReadOnly Text As String '3

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            PosX = CInt(PMessage.Item(0))
            PosY = CInt(PMessage.Item(1))
            BlockID = CInt(PMessage.Item(2))
            Text = CStr(PMessage.Item(3))
        End Sub
    End Class

    Public Class Godmode_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly IsGod As Boolean '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
            IsGod = CBool(PMessage.Item(1))
        End Sub
    End Class

    Public Class Modmode_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = CInt(PMessage.Item(0))
        End Sub
    End Class

    Public Class Access_Message
        Inherits Message
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class LostAccess_Message
        Inherits Message
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Teleport_Message
        Inherits Message
        Private ReadOnly ResetCoins As Boolean '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            ResetCoins = CBool(PMessage.Item(0))
        End Sub
    End Class

    Public Class Reset_Message
        Inherits Message
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Clear_Message
        Inherits Message
        Private ReadOnly RoomWidth As Integer '0
        Private ReadOnly RoomHeight As Integer '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            RoomWidth = CInt(PMessage.Item(0))
            RoomHeight = CInt(PMessage.Item(1))
        End Sub
    End Class

    Public Class SaveDone_Message
        Inherits Message
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class RefreshShop_Message
        Inherits Message
        'TODO: Add arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveWizard_Message
        Inherits Message
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveWizard2_Message
        Inherits Message
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveWitch_Message
        Inherits Message
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveGrinch_Message
        Inherits Message
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class
End Namespace
