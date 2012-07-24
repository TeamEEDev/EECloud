Public MustInherit Class SendMessage
    Public MustOverride Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
End Class

Public Class Init_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("init")
    End Function
End Class

Public Class Init2_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("init2")
    End Function
End Class

Public Class BlockPlace_SendMessage
    Inherits SendMessage
    Public ReadOnly Layer As Layer
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer
    Public ReadOnly ID As Block
    Public Sub New(PLayer As Layer, PX As Integer, PY As Integer, PBlock As Block)
        Layer = PLayer
        X = PX
        Y = PY
        ID = PBlock
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(Connection.BlockManager.Encryption, Connection.BlockManager.CorrectLayer(ID, Layer), X, Y, ID)
    End Function
End Class

Public Class CoinDoorPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly CoinsToCollect As Integer
    Public Sub New(PLayer As Layer, PX As Integer, PY As Integer, PBlock As Block, PCoinsToCollect As Integer)
        MyBase.New(PLayer, PX, PY, PBlock)
        CoinsToCollect = PCoinsToCollect
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        If Connection.BlockManager.IsCoinDoor(ID) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(Connection)
            myMessage.Add(CoinsToCollect)
            Return myMessage
        Else
            Return MyBase.GetMessage(Connection)
        End If
    End Function
End Class

Public Class SoundPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly SoundID As Integer
    Public Sub New(PLayer As Layer, PX As Integer, PY As Integer, PBlock As Block, PSoundID As Integer)
        MyBase.New(PLayer, PX, PY, PBlock)
        SoundID = PSoundID
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        If Connection.BlockManager.IsSound(ID) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(Connection)
            myMessage.Add(SoundID)
            Return myMessage
        Else
            Return MyBase.GetMessage(Connection)
        End If
    End Function
End Class

Public Class PortalPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly PortalID As Integer
    Public ReadOnly PortalTarget As Integer
    Public ReadOnly PortalRotation As PortalRotation
    Public Sub New(PLayer As Layer, PX As Integer, PY As Integer, PBlock As Block, PPortalID As Integer, PPortalTarget As Integer, PPortalRotation As PortalRotation)
        MyBase.New(PLayer, PX, PY, PBlock)
        PortalID = PPortalID
        PortalTarget = PPortalTarget
        PortalRotation = PPortalRotation
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        If Connection.BlockManager.IsPortal(ID) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(Connection)
            myMessage.Add(PortalRotation)
            myMessage.Add(PortalID)
            myMessage.Add(PortalTarget)
            Return myMessage
        Else
            Return MyBase.GetMessage(Connection)
        End If
    End Function
End Class

Public Class LabelPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly Text As String
    Public Sub New(PLayer As Layer, PX As Integer, PY As Integer, PBlock As Block, PText As String)
        MyBase.New(PLayer, PX, PY, PBlock)
        Text = PText
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        If Connection.BlockManager.IsLabel(ID) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(Connection)
            myMessage.Add(Text)
            Return myMessage
        Else
            Return MyBase.GetMessage(Connection)
        End If
    End Function
End Class

Public Class Coin_SendMessage
    Inherits SendMessage
    Public ReadOnly Coins As Integer
    Public Sub New(PCoins As Integer)
        Coins = PCoins
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("c", Coins)
    End Function
End Class

Public Class PressRedKey_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(Connection.BlockManager.Encryption & "r")
    End Function
End Class

Public Class PressGreenKey_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(Connection.BlockManager.Encryption & "g")
    End Function
End Class

Public Class PressBlueKey_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(Connection.BlockManager.Encryption & "b")
    End Function
End Class

Public Class GetCrown_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(Connection.BlockManager.Encryption & "k")
    End Function
End Class

Public Class TouchDiamond_SendMessage
    Inherits SendMessage
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer
    Public Sub New(PX As Integer, PY As Integer)
        X = PX
        Y = PY
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("diamondtouch", X, Y)
    End Function
End Class

Public Class CompleteLevel_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("levelcomplete")
    End Function
End Class

Public Class GodMode_SendMessage
    Inherits SendMessage
    Public ReadOnly GodModeEnabled As Boolean
    Public Sub New(PGodModeEnabled As Boolean)
        GodModeEnabled = PGodModeEnabled
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("god", GodModeEnabled)
    End Function
End Class

Public Class ModMode_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("mod")
    End Function
End Class

Public Class Move_SendMessage
    Inherits SendMessage
    Public ReadOnly PosX As Integer
    Public ReadOnly PosY As Integer
    Public ReadOnly SpeedX As Double
    Public ReadOnly SpeedY As Double
    Public ReadOnly ModifierX As Double
    Public ReadOnly ModifierY As Double
    Public ReadOnly Horizontal As Double
    Public ReadOnly Vertical As Double
    Public Sub New(PPosX As Integer, PPosY As Integer, PSpeedX As Double, PSpeedY As Double, PModifierX As Double, PModifierY As Double, PHorizontal As Double, PVertical As Double)
        PosX = PPosX
        PosY = PPosY
        SpeedX = PSpeedX
        SpeedY = PSpeedY
        ModifierX = PModifierX
        ModifierY = PModifierY
        Horizontal = PHorizontal
        Vertical = PVertical
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("m", PosX, PosY, SpeedX, SpeedY, ModifierX, ModifierY, Horizontal, Vertical)
    End Function
End Class

Public Class Say_SendMessage
    Inherits SendMessage
    Public ReadOnly Text As String
    Public Sub New(PText As String)
        Text = PText
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("say", Text)
    End Function
End Class

Public Class AutoSay_SendMessage
    Inherits SendMessage
    Public ReadOnly TextID As AutoText
    Public Sub New(PTextID As AutoText)
        TextID = PTextID
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("autosay", TextID)
    End Function
End Class

Public Class Access_SendMessage
    Inherits SendMessage
    Public ReadOnly EditKey As String
    Public Sub New(PEditKey As String)
        EditKey = PEditKey
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("access", EditKey)
    End Function
End Class

Public Class ChangeFace_SendMessage
    Inherits SendMessage
    Public ReadOnly FaceID As Smiley
    Public Sub New(PFaceID As Smiley)
        FaceID = PFaceID
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(Connection.BlockManager.Encryption & "f", FaceID)
    End Function
End Class

Public Class SaveWorld_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("save")
    End Function
End Class

Public Class ChangeWorldName_SendMessage
    Inherits SendMessage
    Public ReadOnly WorldName As String
    Public Sub New(PWorldName As String)
        WorldName = PWorldName
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("name", WorldName)
    End Function
End Class

Public Class ChangeWorldEditKey_SendMessage
    Inherits SendMessage
    Public ReadOnly EditKey As String
    Public Sub New(PEditKey As String)
        EditKey = PEditKey
    End Sub

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("key", EditKey)
    End Function
End Class

Public Class ClearWorld_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("clear")
    End Function
End Class

Public Class KillWorld_SendMessage
    Inherits SendMessage
    'No arguments

    Public Overrides Function GetMessage(Connection As IConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("kill")
    End Function
End Class