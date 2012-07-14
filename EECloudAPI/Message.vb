Namespace EECloudAPI.Messages
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

            Title = PMessage.Item(0)
            Text = PMessage.Item(1)
        End Sub
    End Class

    Public Class Init_Message
        Inherits Message
        Private ReadOnly UsernameOwner As String '0
        Private ReadOnly WorldName As String '1
        Private ReadOnly Plays As UInteger '2
        Private ReadOnly Encryption As String '3
        Private ReadOnly UserID As UInteger '4
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
        End Sub
    End Class

    Public Class UpdateMeta_Message
        Inherits Message
        Private ReadOnly Owner As String '0
        Private ReadOnly Title As String '1
        Private ReadOnly Plays As Integer '2

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Add_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly UserName As String '1
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
        End Sub
    End Class

    Public Class Left_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Move_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly PlayerPosX As Integer '1
        Private ReadOnly PlayerPosY As Integer '2
        Private ReadOnly SpeedX As Double '3
        Private ReadOnly SpeedY As Double '4
        Private ReadOnly ModifierX As Double '5
        Private ReadOnly ModifierY As Double '6
        Private ReadOnly Horizontal As Double '7
        Private ReadOnly Vertical As Double '8
        Private ReadOnly Coins As Integer '9

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Coin_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly Coins As Integer '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Crown_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class SilverCrown_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Face_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly FaceID As Integer '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class ShowKey_Message
        Inherits Message
        Private ReadOnly KeyColor As String '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class HideKey_Message
        Inherits Message
        Private ReadOnly KeyColor As String '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Say_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class SayOld_Message
        Inherits Message
        Private ReadOnly UserName As String '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class AutoText_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Write_Message
        Inherits Message
        Private ReadOnly Title As String '0
        Private ReadOnly Text As String '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class BlockPlace_Message
        Inherits Message
        Private ReadOnly Layer As Integer '0
        Private ReadOnly PosX As Integer '1
        Private ReadOnly PosY As Integer '2
        Private ReadOnly BlockID As Integer '4

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
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
        End Sub
    End Class

    Public Class Godmode_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0
        Private ReadOnly IsGod As Boolean '1

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class Modmode_Message
        Inherits Message
        Private ReadOnly UserID As Integer '0

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
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
        'Private ReadOnly ? As Boolean '0
        Private ReadOnly UserIDs() As Integer '1; (4; 7; 10; ...)
        Private ReadOnly SpawnPosXs() As Integer '2; (5; 8; 11; ...)
        Private ReadOnly SpawnPosYs() As Integer '3; (6; 9; 12; ...)

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)

            ReDim UserIDs((PMessage.Count - 4) / 3)
            ReDim SpawnPosXs((PMessage.Count - 4) / 3)
            ReDim SpawnPosYs((PMessage.Count - 4) / 3)
            For N = 1 To PMessage.Count - 1 Step 3
                UserIDs(N - 1) = PMessage.Item(N)
                SpawnPosXs(N - 1) = PMessage.Item(N + 1)
                SpawnPosYs(N - 1) = PMessage.Item(N + 2)
            Next
        End Sub
    End Class

    Public Class Reset_Message
        Inherits Message
        Private ReadOnly RoomData As PlayerIOClient.Message

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

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveWizard_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveWizard2_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveWitch_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class

    Public Class GiveGrinch_Message
        Inherits Message

        Public Sub New(PMessage As PlayerIOClient.Message)
            MyBase.New(PMessage)
        End Sub
    End Class
End Namespace
