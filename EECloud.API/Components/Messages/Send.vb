
Public MustInherit Class SendMessage
    Inherits EventArgs
    Friend MustOverride Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
End Class

Public Class Init_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("init")
    End Function
End Class

Public Class Init2_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("init2")
    End Function
End Class

Public Class BlockPlace_SendMessage
    Inherits SendMessage
    Public ReadOnly Layer As Layer
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer
    Public ReadOnly Block As BlockType
    Public Sub New(layer As Layer, x As Integer, y As Integer, block As BlockType)
        Me.Layer = layer
        Me.X = x
        Me.Y = y
        Me.Block = block
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(connection.Encryption, CorrectLayer(Block, Layer), X, Y, Block)
    End Function
End Class

Public Class CoinDoorPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly CoinsToCollect As Integer
    Public Sub New(layer As Layer, x As Integer, y As Integer, block As CoindoorBlockType, coinsToCollect As Integer)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.CoinsToCollect = coinsToCollect
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        If IsCoinDoor(Block) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(connection)
            myMessage.Add(CoinsToCollect)
            Return myMessage
        Else
            Return MyBase.GetMessage(connection)
        End If
    End Function
End Class

Public Class SoundPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly SoundID As Integer
    Public Sub New(layer As Layer, x As Integer, y As Integer, block As SoundBlockType, soundID As Integer)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.SoundID = soundID
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        If IsSound(Block) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(connection)
            myMessage.Add(SoundID)
            Return myMessage
        Else
            Return MyBase.GetMessage(connection)
        End If
    End Function
End Class

Public Class PortalPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly PortalID As Integer
    Public ReadOnly PortalTarget As Integer
    Public ReadOnly PortalRotation As PortalRotation
    Public Sub New(layer As Layer, x As Integer, y As Integer, block As PortalBlockType, portalID As Integer, portalTarget As Integer, portalRotation As PortalRotation)
        MyBase.New(layer, x, y, CType(block, BlockType))

        Me.PortalID = portalID
        Me.PortalTarget = portalTarget
        Me.PortalRotation = portalRotation
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        If IsPortal(Block) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(connection)
            myMessage.Add(PortalRotation)
            myMessage.Add(PortalID)
            myMessage.Add(PortalTarget)
            Return myMessage
        Else
            Return MyBase.GetMessage(connection)
        End If
    End Function
End Class

Public Class LabelPlace_SendMessage
    Inherits BlockPlace_SendMessage
    Public ReadOnly Text As String
    Public Sub New(layer As Layer, x As Integer, y As Integer, block As LabelBlockType, text As String)
        MyBase.New(layer, x, y, CType(block, BlockType))
        Me.Text = text
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        If IsLabel(Block) Then
            Dim myMessage As PlayerIOClient.Message = MyBase.GetMessage(connection)
            myMessage.Add(Text)
            Return myMessage
        Else
            Return MyBase.GetMessage(connection)
        End If
    End Function
End Class

Public Class Coin_SendMessage
    Inherits SendMessage
    Public ReadOnly Coins As Integer
    Public Sub New(coins As Integer)
        Me.Coins = coins
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("c", Coins)
    End Function
End Class

Public Class PressRedKey_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(connection.Encryption & "r")
    End Function
End Class

Public Class PressGreenKey_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(connection.Encryption & "g")
    End Function
End Class

Public Class PressBlueKey_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(connection.Encryption & "b")
    End Function
End Class

Public Class GetCrown_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(connection.Encryption & "k")
    End Function
End Class

Public Class TouchDiamond_SendMessage
    Inherits SendMessage
    Public ReadOnly X As Integer
    Public ReadOnly Y As Integer
    Public Sub New(x As Integer, y As Integer)
        Me.X = x
        Me.Y = y
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("diamondtouch", X, Y)
    End Function
End Class

Public Class CompleteLevel_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("levelcomplete")
    End Function
End Class

Public Class GodMode_SendMessage
    Inherits SendMessage
    Public ReadOnly GodModeEnabled As Boolean
    Public Sub New(godModeEnabled As Boolean)
        Me.GodModeEnabled = godModeEnabled
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("god", GodModeEnabled)
    End Function
End Class

Public Class ModMode_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
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
    Public Sub New(posX As Integer, posY As Integer, speedX As Double, speedY As Double, modifierX As Double, modifierY As Double, horizontal As Double, vertical As Double)
        Me.PosX = posX
        Me.PosY = posY
        Me.SpeedX = speedX
        Me.SpeedY = speedY
        Me.ModifierX = modifierX
        Me.ModifierY = modifierY
        Me.Horizontal = horizontal
        Me.Vertical = vertical
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("m", PosX, PosY, SpeedX, SpeedY, ModifierX, ModifierY, Horizontal, Vertical)
    End Function
End Class

Public Class Say_SendMessage
    Inherits SendMessage
    Public ReadOnly Text As String
    Public Sub New(text As String)
        Me.Text = text
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("say", Text)
    End Function
End Class

Public Class AutoSay_SendMessage
    Inherits SendMessage
    Public ReadOnly Text As AutoText
    Public Sub New(text As AutoText)
        Me.Text = text
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("autosay", Text)
    End Function
End Class

Public Class Access_SendMessage
    Inherits SendMessage
    Public ReadOnly EditKey As String
    Public Sub New(editKey As String)
        Me.EditKey = editKey
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("access", EditKey)
    End Function
End Class

Public Class ChangeFace_SendMessage
    Inherits SendMessage
    Public ReadOnly Face As Smiley
    Public Sub New(face As Smiley)
        Me.Face = face
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create(connection.Encryption & "f", Face)
    End Function
End Class

Public Class SaveWorld_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("save")
    End Function
End Class

Public Class ChangeWorldName_SendMessage
    Inherits SendMessage
    Public ReadOnly WorldName As String
    Public Sub New(worldName As String)
        Me.WorldName = worldName
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("name", WorldName)
    End Function
End Class

Public Class ChangeWorldEditKey_SendMessage
    Inherits SendMessage
    Public ReadOnly EditKey As String
    Public Sub New(editKey As String)
        Me.EditKey = editKey
    End Sub

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("key", EditKey)
    End Function
End Class

Public Class ClearWorld_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("clear")
    End Function
End Class

Public Class KillWorld_SendMessage
    Inherits SendMessage
    'No arguments

    Friend Overrides Function GetMessage(connection As IInternalConnection) As PlayerIOClient.Message
        Return PlayerIOClient.Message.Create("kill")
    End Function
End Class