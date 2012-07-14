Namespace Recive
    Public MustInherit Class ReciveMessage
        Public ReadOnly Message As PlayerIOClient.Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            Message = PMessage
        End Sub
    End Class

    Public Class GroupDisallowedJoin_ReciveMessage
        Inherits ReciveMessage
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Upgrade_ReciveMessage
        Inherits ReciveMessage
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Info_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly Title As String '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            Title = PMessage.GetString(0)
            Text = PMessage.GetString(1)
        End Sub
    End Class

    Public Class Init_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UsernameOwner As String '0
        Private ReadOnly WorldName As String '1
        Private ReadOnly Plays As Integer '2
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

            UsernameOwner = PMessage.GetString(0)
            WorldName = PMessage.GetString(1)
            Plays = CInt(PMessage.GetString(2))
            Encryption = PMessage.GetString(3)
            UserID = PMessage.GetInteger(4)
            SpawnX = PMessage.GetInteger(5)
            SpawnY = PMessage.GetInteger(6)
            Username = PMessage.GetString(7)
            CanEdit = PMessage.GetBoolean(8)
            IsOwner = PMessage.GetBoolean(9)
            SizeX = PMessage.GetInteger(10)
            SizeY = PMessage.GetInteger(11)
            IsTutorialRoom = PMessage.GetBoolean(12)
        End Sub
    End Class

    Public Class UpdateMeta_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly Owner As String '0
        Private ReadOnly Title As String '1
        Private ReadOnly Plays As Integer '2

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            Owner = PMessage.GetString(0)
            Title = PMessage.GetString(1)
            Plays = PMessage.GetInteger(2)
        End Sub
    End Class

    Public Class Add_ReciveMessage
        Inherits ReciveMessage
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

            UserID = PMessage.GetInteger(0)
            Username = PMessage.GetString(1)
            FaceID = PMessage.GetInteger(2)
            PlayerPosX = PMessage.GetInteger(3)
            PlayerPosY = PMessage.GetInteger(4)
            IsGod = PMessage.GetBoolean(5)
            IsMod = PMessage.GetBoolean(6)
            HasChat = PMessage.GetBoolean(7)
            Coins = PMessage.GetInteger(8)
            IsYourFriend = PMessage.GetBoolean(9)
        End Sub
    End Class

    Public Class Left_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = PMessage.GetInteger(0)
        End Sub
    End Class

    Public Class Move_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserID As Integer '0
        Private ReadOnly PlayerPosX As Integer '1
        Private ReadOnly PlayerPosY As Integer '2
        Private ReadOnly SpeedX As Double  '3
        Private ReadOnly SpeedY As Double '4
        Private ReadOnly ModifierX As Double '5
        Private ReadOnly ModifierY As Double '6
        Private ReadOnly Horizontal As Double '7
        Private ReadOnly Vertical As Double '8
        Private ReadOnly Coins As Integer '9

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = PMessage.GetInteger(0)
            PlayerPosX = PMessage.GetInteger(1)
            PlayerPosY = PMessage.GetInteger(2)
            SpeedX = PMessage.GetDouble(3)
            SpeedY = PMessage.GetDouble(4)
            ModifierX = PMessage.GetDouble(5)
            ModifierY = PMessage.GetDouble(6)
            Horizontal = PMessage.GetDouble(7)
            Vertical = PMessage.GetDouble(8)
            Coins = PMessage.GetInteger(9)
        End Sub
    End Class

    Public Class Coin_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserID As Integer '0
        Private ReadOnly Coins As Integer '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = PMessage.GetInteger(0)
            Coins = PMessage.GetInteger(1)
        End Sub
    End Class

    Public Class Crown_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = PMessage.GetInteger(0)
        End Sub
    End Class

    Public Class SilverCrown_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = PMessage.GetInteger(0)
        End Sub
    End Class

    Public Class Face_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserID As Integer '0
        Private ReadOnly FaceID As Integer '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = PMessage.GetInteger(0)
            FaceID = PMessage.GetInteger(1)
        End Sub
    End Class

    Public Class ShowKey_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly KeyColor As String '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            KeyColor = PMessage.GetString(0)
        End Sub
    End Class

    Public Class HideKey_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly KeyColor As String '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            KeyColor = PMessage.GetString(0)
        End Sub
    End Class

    Public Class Say_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserID As Integer '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = PMessage.GetInteger(0)
            Text = PMessage.GetString(1)
        End Sub
    End Class

    Public Class SayOld_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserName As String '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserName = PMessage.GetString(0)
            Text = PMessage.GetString(1)
        End Sub
    End Class

    Public Class AutoText_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserID As Integer '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = PMessage.GetInteger(0)
            Text = PMessage.GetString(1)
        End Sub
    End Class

    Public Class Write_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly Title As String '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            Title = PMessage.GetString(0)
            Text = PMessage.GetString(1)
        End Sub
    End Class

    Public Class BlockPlace_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly Layer As Layer '0
        Private ReadOnly PosX As Integer '1
        Private ReadOnly PosY As Integer '2
        Private ReadOnly BlockID As Integer '3

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            Layer = CType(PMessage.Item(0), Layer)
            PosX = PMessage.GetInteger(1)
            PosY = PMessage.GetInteger(2)
            BlockID = PMessage.GetInteger(3)
        End Sub
    End Class

    Public Class CoinDoorPlace_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly PosX As Integer '0
        Private ReadOnly PosY As Integer '1
        Private ReadOnly BlockID As Integer '2
        Private ReadOnly CoinsToOpen As Integer '3

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            PosX = PMessage.GetInteger(0)
            PosY = PMessage.GetInteger(1)
            BlockID = PMessage.GetInteger(2)
            CoinsToOpen = PMessage.GetInteger(3)
        End Sub
    End Class

    Public Class SoundPlace_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly PosX As Integer '0
        Private ReadOnly PosY As Integer '1
        Private ReadOnly BlockID As Integer '2
        Private ReadOnly SoundID As Integer '3

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            PosX = PMessage.GetInteger(0)
            PosY = PMessage.GetInteger(1)
            BlockID = PMessage.GetInteger(2)
            SoundID = PMessage.GetInteger(3)
        End Sub
    End Class

    Public Class PortalPlace_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly PosX As Integer '0
        Private ReadOnly PosY As Integer '1
        Private ReadOnly BlockID As Integer '2
        Private ReadOnly Rotation As Integer '3
        Private ReadOnly ID As Integer '4
        Private ReadOnly Target As Integer '5

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            PosX = PMessage.GetInteger(0)
            PosY = PMessage.GetInteger(1)
            BlockID = PMessage.GetInteger(2)
            Rotation = PMessage.GetInteger(3)
            ID = PMessage.GetInteger(4)
            Target = PMessage.GetInteger(5)
        End Sub
    End Class

    Public Class LabelPlace_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly PosX As Integer '0
        Private ReadOnly PosY As Integer '1
        Private ReadOnly BlockID As Integer '2
        Private ReadOnly Text As String '3

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            PosX = PMessage.GetInteger(0)
            PosY = PMessage.GetInteger(1)
            BlockID = PMessage.GetInteger(2)
            Text = PMessage.GetString(3)
        End Sub
    End Class

    Public Class Godmode_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserID As Integer '0
        Private ReadOnly IsGod As Boolean '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = PMessage.GetInteger(0)
            IsGod = PMessage.GetBoolean(1)
        End Sub
    End Class

    Public Class Modmode_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            UserID = PMessage.GetInteger(0)
        End Sub
    End Class

    Public Class Access_ReciveMessage
        Inherits ReciveMessage
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class LostAccess_ReciveMessage
        Inherits ReciveMessage
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Teleport_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly ResetCoins As Boolean '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            ResetCoins = PMessage.GetBoolean(0)
        End Sub
    End Class

    Public Class Reset_ReciveMessage
        Inherits ReciveMessage
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Clear_ReciveMessage
        Inherits ReciveMessage
        Private ReadOnly RoomWidth As Integer '0
        Private ReadOnly RoomHeight As Integer '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            RoomWidth = PMessage.GetInteger(0)
            RoomHeight = PMessage.GetInteger(1)
        End Sub
    End Class

    Public Class SaveDone_ReciveMessage
        Inherits ReciveMessage
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class RefreshShop_ReciveMessage
        Inherits ReciveMessage
        'TODO: Add arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveWizard_ReciveMessage
        Inherits ReciveMessage
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveWizard2_ReciveMessage
        Inherits ReciveMessage
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveWitch_ReciveMessage
        Inherits ReciveMessage
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveGrinch_ReciveMessage
        Inherits ReciveMessage
        'No arguments

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class
End Namespace
