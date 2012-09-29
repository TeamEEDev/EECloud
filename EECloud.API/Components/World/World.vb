Public Class World
#Region "Fields"
    Private Const INIT_OFFSET As UInteger = 14
    Private Blocks(,,) As WorldBlock
    Private myConnection As IConnection(Of Player)
#End Region

#Region "Properties"
    Private myEncryption As String
    Public ReadOnly Property Encryption As String
        Get
            Return myEncryption
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New(connection As IConnection(Of Player), initMessage As Init_ReceiveMessage)
        Me.myConnection = connection
        Blocks = ParseWorld(initMessage.PlayerIOMessage, initMessage.SizeX, initMessage.SizeY, INIT_OFFSET)
    End Sub

    Private Function ParseWorld(m As PlayerIOClient.Message, sizeX As Integer, sizeY As Integer, offset As UInteger) As WorldBlock(,,)
        Dim value(1, sizeX, sizeY) As WorldBlock
        For pointer As UInteger = offset To CUInt(m.Count - 1) Step 0
            Dim myBlock As BlockType = CType(m.Item(pointer), BlockType)
            pointer = CUInt(pointer + 1)
            Dim myLayer As Layer = CType(m.Item(pointer), Layer)
            pointer = CUInt(pointer + 1)
            Dim myByteArrayX As Byte() = m.GetByteArray(pointer)
            pointer = CUInt(pointer + 1)
            Dim myByteArrayY As Byte() = m.GetByteArray(pointer)
            pointer = CUInt(pointer + 1)

            Select Case myBlock
                Case BlockType.Block_Door_CoinDoor Or BlockType.Block_Gate_CoinGate
                    Dim myCoinsToCollect As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To myByteArrayX.Length - 1 Step 2
                        Dim myX = myByteArrayX(i) * 256 + myByteArrayX(i + 1)
                        Dim myY = myByteArrayY(i) * 256 + myByteArrayY(i + 1)
                        value(myLayer, myX, myY) = New WorldCoinDoorBlock(myLayer, myX, myY, CType(myBlock, CoinDoorBlockType), myCoinsToCollect)
                    Next
                Case BlockType.Block_Music_Piano Or BlockType.Block_Music_Drum
                    Dim mySoundID As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To myByteArrayX.Length - 1 Step 2
                        Dim myX = myByteArrayX(i) * 256 + myByteArrayX(i + 1)
                        Dim myY = myByteArrayY(i) * 256 + myByteArrayY(i + 1)
                        value(myLayer, myX, myY) = New WorldSoundBlock(myLayer, myX, myY, CType(myBlock, SoundBlockType), mySoundID)
                    Next
                Case BlockType.Block_Portal
                    Dim myPortalRotation As PortalRotation = CType(m.GetInteger(pointer), PortalRotation)
                    pointer = CUInt(pointer + 1)
                    Dim myPortalID As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    Dim myPortalTarget As Integer = m.GetInteger(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To myByteArrayX.Length - 1 Step 2
                        Dim myX = myByteArrayX(i) * 256 + myByteArrayX(i + 1)
                        Dim myY = myByteArrayY(i) * 256 + myByteArrayY(i + 1)
                        value(myLayer, myX, myY) = New WorldPortalBlock(myLayer, myX, myY, CType(myBlock, PortalBlockType), myPortalRotation, myPortalID, myPortalTarget)
                    Next
                Case BlockType.Block_Label
                    Dim myText As String = m.GetString(pointer)
                    pointer = CUInt(pointer + 1)
                    For i As Integer = 0 To myByteArrayX.Length - 1 Step 2
                        Dim myX = myByteArrayX(i) * 256 + myByteArrayX(i + 1)
                        Dim myY = myByteArrayY(i) * 256 + myByteArrayY(i + 1)
                        value(myLayer, myX, myY) = New WorldLabelBlock(myLayer, myX, myY, CType(myBlock, LabelBlockType), myText)
                    Next
                Case Else
                    For i As Integer = 0 To myByteArrayX.Length - 1 Step 2
                        Dim myX = myByteArrayX(i) * 256 + myByteArrayX(i + 1)
                        Dim myY = myByteArrayY(i) * 256 + myByteArrayY(i + 1)
                        value(myLayer, myX, myY) = New WorldBlock(myLayer, myX, myY, myBlock)
                    Next
            End Select
        Next
        Return value
    End Function

    Default Public ReadOnly Property Item(x As Integer, y As Integer, Optional layer As Layer = Layer.Foreground) As WorldBlock
        Get
            Return Blocks(layer, x, y)
        End Get
    End Property
#End Region
End Class
