﻿Imports PlayerIOClient

Public NotInheritable Class World
    Implements IWorld

#Region "Fields"
    Private Const InitOffset As UInteger = 14
    Private ReadOnly myBlocks(,,) As IWorldBlock
    Private myConnection As IConnection(Of Player)
#End Region

#Region "Properties"
    Private ReadOnly myEncryption As String

    Public ReadOnly Property Encryption As String Implements IWorld.Encryption
        Get
            Return myEncryption
        End Get
    End Property

    Default Public ReadOnly Property Item(x As Integer, y As Integer, Optional layer As Layer = Layer.Foreground) As IWorldBlock Implements IWorld.Item
        Get
            Return myBlocks(layer, x, y)
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(connection As IConnection(Of Player), initMessage As InitReceiveMessage)
        myConnection = connection
        myEncryption = Derot(initMessage.Encryption)
        myBlocks = ParseWorld(initMessage.PlayerIOMessage, initMessage.SizeX, initMessage.SizeY, InitOffset)
    End Sub

    Private Function ParseWorld(m As Message, sizeX As Integer, sizeY As Integer, offset As UInteger) As WorldBlock(,,)
        Dim value(1, sizeX, sizeY) As WorldBlock
        Dim pointer As UInteger = offset
        Do Until pointer >= CUInt(m.Count - 1)
            Dim block As BlockType = CType(m.Item(pointer), BlockType)
            pointer = CUInt(pointer + 1)
            Dim layer As Layer = CType(m.Item(pointer), Layer)
            pointer = CUInt(pointer + 1)
            Dim byteArrayX As Byte() = m.GetByteArray(pointer)
            pointer = CUInt(pointer + 1)
            Dim byteArrayY As Byte() = m.GetByteArray(pointer)
            pointer = CUInt(pointer + 1)

            Select Case block
                Case BlockType.BlockDoorCoinDoor Or BlockType.BlockGateCoinGate
                    Dim coinsToCollect As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldCoinDoorBlock(CType(block, CoinDoorBlockType), coinsToCollect)
                    Next
                Case BlockType.BlockMusicPiano Or BlockType.BlockMusicDrum
                    Dim soundID As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldSoundBlock(CType(block, SoundBlockType), soundID)
                    Next
                Case BlockType.BlockPortal
                    Dim portalRotation As PortalRotation = CType(m.GetInteger(pointer), PortalRotation)
                    pointer = CUInt(pointer + 1)
                    Dim portalID As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    Dim portalTarget As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldPortalBlock(CType(block, PortalBlockType), portalRotation, portalID, portalTarget)
                    Next
                Case BlockType.BlockLabel
                    Dim text As String = m.GetString(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldLabelBlock(CType(block, LabelBlockType), text)
                    Next
                Case Else
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldBlock(block)
                    Next
            End Select
        Loop
        Return value
    End Function

#End Region
End Class