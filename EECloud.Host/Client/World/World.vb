Imports PlayerIOClient

Friend NotInheritable Class World
    Implements IWorld

#Region "Fields"
    Private Const InitOffset As UInteger = 17
    Private myBlocks(,,) As IWorldBlock
    Private WithEvents myConnection As IConnection
#End Region

#Region "Events"

    Friend Event BlockPlace(sender As Object, e As BlockPlaceEventArgs) Implements IWorld.BlockPlace

#End Region

#Region "Properties"

    Private mySizeX As Integer

    Friend ReadOnly Property SizeX As Integer Implements IWorld.SizeX
        Get
            Return mySizeX
        End Get
    End Property

    Private mySizeY As Integer

    Friend ReadOnly Property SizeY As Integer Implements IWorld.SizeY
        Get
            Return mySizeY
        End Get
    End Property

    Default Friend ReadOnly Property Item(x As Integer, y As Integer, Optional layer As Layer = Layer.Foreground) As IWorldBlock Implements IWorld.Item
        Get
            Return myBlocks(layer, x, y)
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(client As IClient(Of Player))
        myConnection = client.Connection
    End Sub

    Private Shared Function ParseWorld(m As Message, sizeX As Integer, sizeY As Integer, offset As UInteger) As IWorldBlock(,,)
        Dim start As UInteger
        For i As UInteger = offset To m.Count - 1UI
            If TryCast(m.Item(i), String) IsNot Nothing AndAlso m.GetString(i) = "ws" Then
                start = i + 1
                Exit For
            End If
        Next

        Dim value(1, sizeX - 1, sizeY - 1) As IWorldBlock
        ClearWorld(value, False)

        Dim block1 As Block
        Dim layer As Layer
        Dim byteArrayX As Byte()
        Dim byteArrayY As Byte()

        Dim pointer As UInteger = start
        Do
            If TryCast(m.Item(pointer), String) IsNot Nothing AndAlso m.GetString(pointer) = "we" Then
                Exit Do
            End If

            block1 = DirectCast(m.GetInteger(pointer), Block)
            layer = DirectCast(m.GetInteger(pointer + 1), Layer)
            byteArrayX = m.GetByteArray(pointer + 2)
            byteArrayY = m.GetByteArray(pointer + 3)
            pointer += 4

            Select Case block1
                Case Block.BlockDoorCoinDoor,
                     Block.BlockGateCoinGate
                    Dim coinsToCollect As Integer = m.GetInteger(pointer)
                    pointer += 1

                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        value(layer,
                              byteArrayX(i) * 256 + byteArrayX(i + 1),
                              byteArrayY(i) * 256 + byteArrayY(i + 1)) = New WorldCoinDoorBlock(DirectCast(block1, CoinDoorBlock), coinsToCollect)
                    Next

                Case Block.BlockMusicPiano,
                     Block.BlockMusicDrum
                    Dim soundID As Integer = m.GetInteger(pointer)
                    pointer += 1

                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        value(layer,
                              byteArrayX(i) * 256 + byteArrayX(i + 1),
                              byteArrayY(i) * 256 + byteArrayY(i + 1)) = New WorldSoundBlock(DirectCast(block1, SoundBlock), soundID)
                    Next

                Case Block.BlockHazardSpike,
                     Block.DecorationSciFi2013BlueSlope,
                     Block.DecorationSciFi2013BlueStraight,
                     Block.DecorationSciFi2013YellowSlope,
                     Block.DecorationSciFi2013YellowStraight,
                     Block.DecorationSciFi2013GreenSlope,
                     Block.DecorationSciFi2013GreenStraight
                    Dim rotation As Integer = m.GetInteger(pointer)
                    pointer += 1

                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        value(layer,
                              byteArrayX(i) * 256 + byteArrayX(i + 1),
                              byteArrayY(i) * 256 + byteArrayY(i + 1)) = New WorldRotatableBlock(DirectCast(block1, RotatableBlock), rotation)
                    Next

                Case Block.BlockPortal, Block.BlockInvisiblePortal
                    Dim portalRotation As PortalRotation = DirectCast(m.GetInteger(pointer), PortalRotation)
                    Dim portalID As Integer = m.GetInteger(pointer + 1)
                    Dim portalTarget As Integer = m.GetInteger(pointer + 2)
                    pointer += 3

                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        value(layer,
                              byteArrayX(i) * 256 + byteArrayX(i + 1),
                              byteArrayY(i) * 256 + byteArrayY(i + 1)) = New WorldPortalBlock(DirectCast(block1, PortalBlock), portalRotation, portalID, portalTarget)
                    Next

                Case Block.BlockWorldPortal
                    Dim portalTarget As String = m.GetString(pointer)
                    pointer += 1

                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        value(layer,
                              byteArrayX(i) * 256 + byteArrayX(i + 1),
                              byteArrayY(i) * 256 + byteArrayY(i + 1)) = New WorldWorldPortalBlock(DirectCast(block1, API.WorldPortalBlock), portalTarget)
                    Next

                Case Block.DecorationSign, Block.DecorationLabel
                    Dim text As String = m.GetString(pointer)
                    pointer += 1

                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        value(layer,
                              byteArrayX(i) * 256 + byteArrayX(i + 1),
                              byteArrayY(i) * 256 + byteArrayY(i + 1)) = New WorldLabelBlock(DirectCast(block1, LabelBlock), text)
                    Next

                Case Else
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        value(layer,
                              byteArrayX(i) * 256 + byteArrayX(i + 1),
                              byteArrayY(i) * 256 + byteArrayY(i + 1)) = New WorldBlock(block1)
                    Next
            End Select
        Loop

        Return value
    End Function

    Private Shared Sub ClearWorld(ByRef blockArray As IWorldBlock(,,), Optional drawBorder As Boolean = True)
        Dim sizeXMinusSomething = blockArray.GetLength(1) - 1
        Dim sizeYMinus1 = blockArray.GetLength(2) - 1

        '<Fill the middle with GravityNothing blocks>
        For l = Layer.Background To Layer.Foreground Step -1
            For x = 1 To sizeXMinusSomething
                For y = 1 To sizeYMinus1
                    blockArray(l, x, y) = New WorldBlock(Block.BlockGravityNothing) 'Create a new instance for every block
                Next
            Next
        Next
        '</Fill the middle with GravityNothing blocks>

        '<Border drawing>
        Dim blockToDraw As Block
        If drawBorder Then
            blockToDraw = Block.BlockBasicGrey
        Else
            blockToDraw = Block.BlockGravityNothing
        End If

        sizeXMinusSomething -= 1
        For l = IIf(drawBorder, Layer.Foreground, Layer.Background) To Layer.Foreground Step -1
            For y = sizeYMinus1 To 0 Step -1
                blockArray(0, 0, y) = New WorldBlock(blockToDraw)
                blockArray(0, sizeYMinus1, y) = New WorldBlock(blockToDraw)
            Next

            For x = 1 To sizeXMinusSomething
                blockArray(0, x, 0) = New WorldBlock(blockToDraw)
                blockArray(0, x, sizeYMinus1) = New WorldBlock(blockToDraw)
            Next
        Next
        '</Border drawing>
    End Sub

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit
        mySizeX = e.SizeX
        mySizeY = e.SizeY
        myBlocks = ParseWorld(e.PlayerIOMessage, e.SizeX, e.SizeY, InitOffset)
    End Sub

    Private Sub myConnection_ReceiveBlockPlace(sender As Object, e As BlockPlaceReceiveMessage) Handles myConnection.ReceiveBlockPlace
        Dim block As New WorldBlock(e.Block)
        myBlocks(e.Layer, e.PosX, e.PosY) = block
        RaiseEvent BlockPlace(Me, New BlockPlaceEventArgs(e.PosX, e.PosY, e.Layer))
    End Sub

    Private Sub myConnection_ReceiveCoinDoorPlace(sender As Object, e As CoinDoorPlaceReceiveMessage) Handles myConnection.ReceiveCoinDoorPlace
        Dim block As New WorldCoinDoorBlock(e.CoinDoorBlock, e.CoinsToOpen)
        myBlocks(e.Layer, e.PosX, e.PosY) = block
        RaiseEvent BlockPlace(Me, New BlockPlaceEventArgs(e.PosX, e.PosY, e.Layer))
    End Sub

    Private Sub myConnection_ReceiveLabelPlace(sender As Object, e As LabelPlaceReceiveMessage) Handles myConnection.ReceiveLabelPlace
        Dim block As New WorldLabelBlock(e.LabelBlock, e.Text)
        myBlocks(e.Layer, e.PosX, e.PosY) = block
        RaiseEvent BlockPlace(Me, New BlockPlaceEventArgs(e.PosX, e.PosY, e.Layer))
    End Sub

    Private Sub myConnection_ReceivePortalPlace(sender As Object, e As PortalPlaceReceiveMessage) Handles myConnection.ReceivePortalPlace
        Dim block As New WorldPortalBlock(e.PortalBlock, e.PortalRotation, e.PortalID, e.PortalTarget)
        myBlocks(e.Layer, e.PosX, e.PosY) = block
        RaiseEvent BlockPlace(Me, New BlockPlaceEventArgs(e.PosX, e.PosY, e.Layer))
    End Sub

    Private Sub myConnection_ReceiveWorldPortalPlace(sender As Object, e As WorldPortalPlaceReceiveMessage) Handles myConnection.ReceiveWorldPortalPlace
        Dim block As New WorldWorldPortalBlock(e.WorldPortalBlock, e.WorldPortalTarget)
        myBlocks(e.Layer, e.PosX, e.PosY) = block
        RaiseEvent BlockPlace(Me, New BlockPlaceEventArgs(e.PosX, e.PosY, e.Layer))
    End Sub

    Private Sub myConnection_ReceiveSoundPlace(sender As Object, e As SoundPlaceReceiveMessage) Handles myConnection.ReceiveSoundPlace
        Dim block As New WorldSoundBlock(e.SoundBlock, e.SoundID)
        myBlocks(e.Layer, e.PosX, e.PosY) = block
        RaiseEvent BlockPlace(Me, New BlockPlaceEventArgs(e.PosX, e.PosY, e.Layer))
    End Sub

    Private Sub myConnection_ReceiveRotatablePlace(sender As Object, e As RotatablePlaceReceiveMessage) Handles myConnection.ReceiveRotatablePlace
        Dim block As New WorldRotatableBlock(e.RotatableBlock, e.Rotation)
        myBlocks(e.Layer, e.PosX, e.PosY) = block
        RaiseEvent BlockPlace(Me, New BlockPlaceEventArgs(e.PosX, e.PosY, e.Layer))
    End Sub

    Private Sub myConnection_ReceiveReset(sender As Object, e As ResetReceiveMessage) Handles myConnection.ReceiveReset
        myBlocks = ParseWorld(e.PlayerIOMessage, mySizeX, mySizeY, 0)
    End Sub

    Private Sub myConnection_ReceiveClear(sender As Object, e As ClearReceiveMessage) Handles myConnection.ReceiveClear
        ClearWorld(myBlocks)
    End Sub

#End Region

End Class
