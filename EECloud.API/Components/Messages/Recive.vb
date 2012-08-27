Public Class Info_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly Title As String '0
    Public ReadOnly Text As String '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        Title = message.GetString(0)
        Text = message.GetString(1)
    End Sub
End Class

Public Class Init_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UsernameOwner As String '0
    Public ReadOnly WorldName As String '1
    Public ReadOnly Plays As Integer '2
    Public ReadOnly Encryption As String '3
    Public ReadOnly UserID As Integer '4
    Public ReadOnly SpawnX As Integer '5
    Public ReadOnly SpawnY As Integer '6
    Public ReadOnly Username As String '7
    Public ReadOnly CanEdit As Boolean '8
    Public ReadOnly IsOwner As Boolean '9
    Public ReadOnly SizeX As Integer '10
    Public ReadOnly SizeY As Integer '11
    Public ReadOnly IsTutorialRoom As Boolean '12

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UsernameOwner = message.GetString(0)
        WorldName = message.GetString(1)
        Plays = CInt(message.GetString(2))
        Encryption = message.GetString(3)
        UserID = message.GetInteger(4)
        SpawnX = message.GetInteger(5)
        SpawnY = message.GetInteger(6)
        Username = message.GetString(7)
        CanEdit = message.GetBoolean(8)
        IsOwner = message.GetBoolean(9)
        SizeX = message.GetInteger(10)
        SizeY = message.GetInteger(11)
        IsTutorialRoom = message.GetBoolean(12)
    End Sub
End Class

Public Class UpdateMeta_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly Owner As String '0
    Public ReadOnly Title As String '1
    Public ReadOnly Plays As Integer '2

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        Owner = message.GetString(0)
        Title = message.GetString(1)
        Plays = message.GetInteger(2)
    End Sub
End Class

Public Class Add_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0
    Public ReadOnly Username As String '1
    Public ReadOnly Face As Smiley '2
    Public ReadOnly PlayerPosX As Integer '3
    Public ReadOnly PlayerPosY As Integer '4
    Public ReadOnly IsGod As Boolean '5
    Public ReadOnly IsMod As Boolean '6
    Public ReadOnly HasChat As Boolean '7
    Public ReadOnly Coins As Integer '8
    Public ReadOnly IsMyFriend As Boolean '9

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Username = message.GetString(1)
        Face = CType(message.GetInteger(2), Smiley)
        PlayerPosX = message.GetInteger(3)
        PlayerPosY = message.GetInteger(4)
        IsGod = message.GetBoolean(5)
        IsMod = message.GetBoolean(6)
        HasChat = message.GetBoolean(7)
        Coins = message.GetInteger(8)
        IsMyFriend = message.GetBoolean(9)
    End Sub
End Class

Public Class Left_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
    End Sub
End Class

Public Class Move_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0
    Public ReadOnly PlayerPosX As Integer '1
    Public ReadOnly PlayerPosY As Integer '2
    Public ReadOnly SpeedX As Double  '3
    Public ReadOnly SpeedY As Double '4
    Public ReadOnly ModifierX As Double '5
    Public ReadOnly ModifierY As Double '6
    Public ReadOnly Horizontal As Double '7
    Public ReadOnly Vertical As Double '8
    Public ReadOnly Coins As Integer '9

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        PlayerPosX = message.GetInteger(1)
        PlayerPosY = message.GetInteger(2)
        SpeedX = message.GetDouble(3)
        SpeedY = message.GetDouble(4)
        ModifierX = message.GetDouble(5)
        ModifierY = message.GetDouble(6)
        Horizontal = message.GetDouble(7)
        Vertical = message.GetDouble(8)
        Coins = message.GetInteger(9)
    End Sub
End Class

Public Class Coin_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0
    Public ReadOnly Coins As Integer '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Coins = message.GetInteger(1)
    End Sub
End Class

Public Class Crown_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
    End Sub
End Class

Public Class SilverCrown_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
    End Sub
End Class

Public Class Face_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0
    Public ReadOnly Face As Smiley  '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Face = CType(message.GetInteger(1), Smiley)
    End Sub
End Class

Public Class ShowKey_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly KeyColor As DoorID '0

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        KeyColor = CType([Enum].Parse(GetType(DoorID), message.GetString(0), True), DoorID)
    End Sub
End Class

Public Class HideKey_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly KeyColor As DoorID '0

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        KeyColor = CType([Enum].Parse(GetType(DoorID), message.GetString(0), True), DoorID)
    End Sub
End Class

Public Class Say_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0
    Public ReadOnly Text As String '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Text = message.GetString(1)
    End Sub
End Class

Public Class SayOld_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserName As String '0
    Public ReadOnly Text As String '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserName = message.GetString(0)
        Text = message.GetString(1)
    End Sub
End Class

Public Class AutoText_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0
    Public ReadOnly Text As String '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        Text = message.GetString(1)
    End Sub
End Class

Public Class Write_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly Title As String '0
    Public ReadOnly Text As String '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        Title = message.GetString(0)
        Text = message.GetString(1)
    End Sub
End Class

Public Class BlockPlace_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly Layer As Layer '0
    Public ReadOnly PosX As Integer '1
    Public ReadOnly PosY As Integer '2
    Public ReadOnly Block As BlockType '3

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        Layer = CType(message.Item(0), Layer)
        PosX = message.GetInteger(1)
        PosY = message.GetInteger(2)
        Block = CType(message.GetInteger(3), BlockType)
    End Sub

    Protected Sub New(message As PlayerIOClient.Message, layer As Layer, posX As Integer, posY As Integer, block As BlockType)
        MyBase.New(message)

        Me.Layer = layer
        Me.PosX = posX
        Me.PosY = posY
        Me.Block = block
    End Sub
End Class

Public Class CoinDoorPlace_ReciveMessage
    Inherits BlockPlace_ReciveMessage
    Public ReadOnly CoinsToOpen As Integer '3

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message, API.Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), BlockType))

        CoinsToOpen = message.GetInteger(3)
    End Sub
End Class

Public Class SoundPlace_ReciveMessage
    Inherits BlockPlace_ReciveMessage
    Public Shadows ReadOnly SoundBlock As CoindoorBlockType '2
    Public ReadOnly SoundID As Integer '3

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message, API.Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), BlockType))
        SoundBlock = CType(message.GetInteger(2), CoindoorBlockType)
        SoundID = message.GetInteger(3)
    End Sub
End Class

Public Class PortalPlace_ReciveMessage
    Inherits BlockPlace_ReciveMessage
    Public ReadOnly PortalRotation As PortalRotation '3
    Public ReadOnly PortalID As Integer '4
    Public ReadOnly PortalTarget As Integer '5

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message, API.Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), BlockType))

        PortalRotation = CType(message.GetInteger(3), PortalRotation)
        PortalID = message.GetInteger(4)
        PortalTarget = message.GetInteger(5)
    End Sub
End Class

Public Class LabelPlace_ReciveMessage
    Inherits BlockPlace_ReciveMessage
    Public ReadOnly Text As String '3

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message, API.Layer.Foreground, message.GetInteger(0), message.GetInteger(1), CType(message.GetInteger(2), BlockType))

        Text = message.GetString(3)
    End Sub
End Class

Public Class Godmode_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0
    Public ReadOnly IsGod As Boolean '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
        IsGod = message.GetBoolean(1)
    End Sub
End Class

Public Class Modmode_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly UserID As Integer '0

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        UserID = message.GetInteger(0)
    End Sub
End Class

Public Class Access_ReciveMessage
    Inherits ReciveMessage
    'No arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class

Public Class LostAccess_ReciveMessage
    Inherits ReciveMessage
    'No arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class

Public Class Teleport_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly ResetCoins As Boolean '0

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        ResetCoins = message.GetBoolean(0)
    End Sub
End Class

Public Class Reset_ReciveMessage
    Inherits ReciveMessage
    'No arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class

Public Class Clear_ReciveMessage
    Inherits ReciveMessage
    Public ReadOnly RoomWidth As Integer '0
    Public ReadOnly RoomHeight As Integer '1

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)

        RoomWidth = message.GetInteger(0)
        RoomHeight = message.GetInteger(1)
    End Sub
End Class

Public Class SaveDone_ReciveMessage
    Inherits ReciveMessage
    'No arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class

Public Class RefreshShop_ReciveMessage
    Inherits ReciveMessage
    'TODO: Add arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class

Public Class GiveWizard_ReciveMessage
    Inherits ReciveMessage
    'No arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class

Public Class GiveFireWizard_ReciveMessage
    Inherits ReciveMessage
    'No arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class

Public Class GiveWitch_ReciveMessage
    Inherits ReciveMessage
    'No arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class

Public Class GiveGrinch_ReciveMessage
    Inherits ReciveMessage
    'No arguments

    Friend Sub New(message As PlayerIOClient.Message)
        MyBase.New(message)
    End Sub
End Class