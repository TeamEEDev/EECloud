﻿Imports PlayerIOClient

Friend NotInheritable Class World
    Implements IWorld

#Region "Fields"
    Private Const InitOffset As UInteger = 15
    Private myBlocks(,,) As IWorldBlock
    Private WithEvents myConnection As IConnection
#End Region

#Region "Properties"
    Private myEncryption As String

    Public ReadOnly Property Encryption As String Implements IWorld.Encryption
        Get
            Return myEncryption
        End Get
    End Property

    Private myAccessRight As AccessRight

    Public ReadOnly Property AccessRight As AccessRight Implements IWorld.AccessRight
        Get
            Return myAccessRight
        End Get
    End Property

    Public Property AccessRightInternal As AccessRight
        Get
            Return myAccessRight
        End Get
        Set(value As AccessRight)
            myAccessRight = value
        End Set
    End Property

    Private myPos As Location

    Public ReadOnly Property Pos As Location Implements IWorld.Pos
        Get
            Return myPos
        End Get
    End Property

    Private Property PosInternal As Location
        Get
            Return myPos
        End Get
        Set(value As Location)
            myPos = value
        End Set
    End Property

    Default Public ReadOnly Property Item(x As Integer, y As Integer, Optional layer As Layer = Layer.Foreground) As IWorldBlock Implements IWorld.Item
        Get
            Return myBlocks(layer, x, y)
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(connection As Connection, initMessage As InitReceiveMessage)
        myConnection = connection
        myEncryption = Derot(initMessage.Encryption)
        myPos = New Location(initMessage.SpawnX, initMessage.SpawnY)

        If initMessage.IsOwner Then
            myAccessRight = AccessRight.Owner
        ElseIf initMessage.CanEdit Then
            myAccessRight = AccessRight.Edit
        End If

        myBlocks = ParseWorld(initMessage.PlayerIOMessage, initMessage.SizeX, initMessage.SizeY, InitOffset)
    End Sub

    Public Sub New(client As IClient(Of Player))
        myConnection = client.Connection
    End Sub

    Private Shared Function ParseWorld(m As Message, sizeX As Integer, sizeY As Integer, offset As UInteger) As IWorldBlock(,,)
        Dim start As UInteger
        For i As UInteger = offset To CUInt(m.Count - 1)
            If TryCast(m.Item(i), String) IsNot Nothing AndAlso m.GetString(i) = "ws" Then
                start = CType((i + 1), UInteger)
                Exit For
            End If
        Next

        Dim value(1, sizeX - 1, sizeY - 1) As IWorldBlock
        For i = 0 To 1
            For j = 0 To sizeX - 1
                For k = 0 To sizeY - 1
                    value(i, j, k) = New WorldBlock(Block.BlockGravityNothing)
                Next
            Next
        Next

        Dim pointer As UInteger = start
        Do
            If TryCast(m.Item(pointer), String) IsNot Nothing AndAlso m.GetString(pointer) = "we" Then
                Exit Do
            End If

            Dim block1 As Block = CType(m.Item(pointer), Block)
            pointer = CUInt(pointer + 1)
            Dim layer As Layer = CType(m.Item(pointer), Layer)
            pointer = CUInt(pointer + 1)
            Dim byteArrayX As Byte() = m.GetByteArray(pointer)
            pointer = CUInt(pointer + 1)
            Dim byteArrayY As Byte() = m.GetByteArray(pointer)
            pointer = CUInt(pointer + 1)

            Select Case block1
                Case Block.BlockDoorCoinDoor, Block.BlockGateCoinGate
                    Dim coinsToCollect As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldCoinDoorBlock(CType(block1, CoinDoorBlock), coinsToCollect)
                    Next
                Case Block.BlockMusicPiano, Block.BlockMusicDrum
                    Dim soundID As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldSoundBlock(CType(block1, SoundBlock), soundID)
                    Next
                Case Block.BlockPortal
                    Dim portalRotation As PortalRotation = CType(m.GetInteger(pointer), PortalRotation)
                    pointer = CUInt(pointer + 1)
                    Dim portalID As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    Dim portalTarget As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldPortalBlock(CType(block1, PortalBlock), portalRotation, portalID, portalTarget)
                    Next
                Case Block.BlockLabel
                    Dim text As String = m.GetString(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldLabelBlock(CType(block1, LabelBlock), text)
                    Next
                Case Else
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldBlock(block1)
                    Next
            End Select
        Loop
        Return value
    End Function

    Private Sub myConnection_OnReceiveAccess(sender As Object, e As AccessReceiveMessage) Handles myConnection.ReceiveAccess
        myAccessRight = AccessRight.Edit
    End Sub

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit
        myEncryption = Derot(e.Encryption)
        myBlocks = ParseWorld(e.PlayerIOMessage, e.SizeX, e.SizeY, InitOffset)
    End Sub

#End Region
End Class
