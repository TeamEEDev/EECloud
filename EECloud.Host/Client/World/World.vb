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
                Case Block.BlockHazardSpike, Block.BlockHazardFire
                    Dim rotation As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To byteArrayX.Length - 1 Step 2
                        Dim x = byteArrayX(i) * 256 + byteArrayX(i + 1)
                        Dim y = byteArrayY(i) * 256 + byteArrayY(i + 1)
                        value(layer, x, y) = New WorldRotatableBlock(CType(block1, RotatableBlock), rotation)
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

    'TODO: IMPLEMENT CLEAR

#End Region
End Class
