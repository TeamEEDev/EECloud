Imports System.Reflection
Imports System.Threading.Tasks

Public NotInheritable Class Connection
    Implements IConnection

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)
    Private WithEvents myConnection As PlayerIOClient.Connection
    Private ReadOnly myMessageDictionary As New Dictionary(Of String, Type)
    Private myExpectingDisconnect As Boolean
    Private Const GameID As String = "everybody-edits-su9rn58o40itdbnw69plyw"
    Private Const NormalRoom As String = "Everybodyedits"
    Private Const GameVersionSetting As String = "GameVersion"
    Private Shared myGameVersionNumber As Integer = 0
#End Region

#Region "Properties"

    Friend ReadOnly Property Connected As Boolean Implements IConnection.Connected
        Get
            If myConnection IsNot Nothing Then
                Return myConnection.Connected
            Else
                Return False
            End If
        End Get
    End Property

    Private myWorldID As String

    Friend ReadOnly Property WorldID As String Implements IConnection.WorldID
        Get
            Return myWorldID
        End Get
    End Property

#End Region

#Region "Events"
    Public Event Disconnect(sender As Object, e As DisconnectEventArgs) Implements IConnection.Disconnect

    Public Event Disconnecting(sender As Object, e As EventArgs) Implements IConnection.Disconnecting

    Public Event ReceiveAccess(sender As Object, e As AccessReceiveMessage) Implements IConnection.ReceiveAccess

    Public Event ReceiveAdd(sender As Object, e As AddReceiveMessage) Implements IConnection.ReceiveAdd

    Public Event ReceiveAutoText(sender As Object, e As AutoTextReceiveMessage) Implements IConnection.ReceiveAutoText

    Public Event ReceiveBlockPlace(sender As Object, e As BlockPlaceReceiveMessage) Implements IConnection.ReceiveBlockPlace

    Public Event ReceiveClear(sender As Object, e As ClearReceiveMessage) Implements IConnection.ReceiveClear

    Public Event ReceiveCoin(sender As Object, e As CoinReceiveMessage) Implements IConnection.ReceiveCoin

    Public Event ReceiveCoinDoorPlace(sender As Object, e As CoinDoorPlace_ReceiveMessage) Implements IConnection.ReceiveCoinDoorPlace

    Public Event ReceiveCrown(sender As Object, e As CrownReceiveMessage) Implements IConnection.ReceiveCrown

    Public Event ReceiveFace(sender As Object, e As FaceReceiveMessage) Implements IConnection.ReceiveFace

    Public Event ReceiveGiveFireWizard(sender As Object, e As GiveFireWizardReceiveMessage) Implements IConnection.ReceiveGiveFireWizard

    Public Event ReceiveGiveGrinch(sender As Object, e As GiveGrinchReceiveMessage) Implements IConnection.ReceiveGiveGrinch

    Public Event ReceiveGiveWitch(sender As Object, e As GiveWitchReceiveMessage) Implements IConnection.ReceiveGiveWitch

    Public Event ReceiveGiveWizard(sender As Object, e As GiveWizardReceiveMessage) Implements IConnection.ReceiveGiveWizard

    Public Event ReceiveGodMode(sender As Object, e As GodModeReceiveMessage) Implements IConnection.ReceiveGodMode

    Public Event ReceiveGroupDisallowedJoin(sender As Object, e As GroupDisallowedJoinReceiveMessage) Implements IConnection.ReceiveGroupDisallowedJoin

    Public Event ReceiveHideKey(sender As Object, e As HideKeyReceiveMessage) Implements IConnection.ReceiveHideKey

    Public Event ReceiveInfo(sender As Object, e As InfoReceiveMessage) Implements IConnection.ReceiveInfo

    Public Event ReceiveInit(sender As Object, e As InitReceiveMessage) Implements IConnection.ReceiveInit

    Public Event ReceiveLabelPlace(sender As Object, e As LabelPlaceReceiveMessage) Implements IConnection.ReceiveLabelPlace

    Public Event ReceiveLeft(sender As Object, e As LeftReceiveMessage) Implements IConnection.ReceiveLeft

    Public Event ReceiveLostAccess(sender As Object, e As LostAccessReceiveMessage) Implements IConnection.ReceiveLostAccess

    Public Event ReceiveMessage(sender As Object, e As ReceiveMessage) Implements IConnection.ReceiveMessage

    Public Event ReceiveModMode(sender As Object, e As ModModeReceiveMessage) Implements IConnection.ReceiveModMode

    Public Event ReceiveMove(sender As Object, e As MoveReceiveMessage) Implements IConnection.ReceiveMove

    Public Event ReceivePortalPlace(sender As Object, e As PortalPlaceReceiveMessage) Implements IConnection.ReceivePortalPlace

    Public Event ReceiveRefreshShop(sender As Object, e As RefreshShopReceiveMessage) Implements IConnection.ReceiveRefreshShop

    Public Event ReceiveReset(sender As Object, e As ResetReceiveMessage) Implements IConnection.ReceiveReset

    Public Event ReceiveSaveDone(sender As Object, e As SaveDoneReceiveMessage) Implements IConnection.ReceiveSaveDone

    Public Event ReceiveSay(sender As Object, e As SayReceiveMessage) Implements IConnection.ReceiveSay

    Public Event ReceiveSayOld(sender As Object, e As SayOld_ReceiveMessage) Implements IConnection.ReceiveSayOld

    Public Event ReceiveShowKey(sender As Object, e As ShowKeyReceiveMessage) Implements IConnection.ReceiveShowKey

    Public Event ReceiveSilverCrown(sender As Object, e As SilverCrownReceiveMessage) Implements IConnection.ReceiveSilverCrown

    Public Event ReceiveSoundPlace(sender As Object, e As SoundPlaceReceiveMessage) Implements IConnection.ReceiveSoundPlace

    Public Event ReceiveTeleport(sender As Object, e As TeleportReceiveMessage) Implements IConnection.ReceiveTeleport

    Public Event ReceiveUpdateMeta(sender As Object, e As UpdateMetaReceiveMessage) Implements IConnection.ReceiveUpdateMeta

    Public Event ReceiveUpgrade(sender As Object, e As UpgradeReceiveMessage) Implements IConnection.ReceiveUpgrade

    Public Event ReceiveWrite(sender As Object, e As WriteReceiveMessage) Implements IConnection.ReceiveWrite

    Public Event SendAccess(sender As Object, e As SendEventArgs(Of AccessSendMessage)) Implements IConnection.SendAccess

    Public Event SendAutoSay(sender As Object, e As SendEventArgs(Of AutoSaySendMessage)) Implements IConnection.SendAutoSay

    Public Event SendBlockPlace(sender As Object, e As SendEventArgs(Of BlockPlaceSendMessage)) Implements IConnection.SendBlockPlace

    Public Event SendChangeFace(sender As Object, e As SendEventArgs(Of ChangeFaceSendMessage)) Implements IConnection.SendChangeFace

    Public Event SendChangeWorldEditKey(sender As Object, e As SendEventArgs(Of ChangeWorldEditKeySendMessage)) Implements IConnection.SendChangeWorldEditKey

    Public Event SendChangeWorldName(sender As Object, e As SendEventArgs(Of ChangeWorldNameSendMessage)) Implements IConnection.SendChangeWorldName

    Public Event SendClearWorld(sender As Object, e As SendEventArgs(Of ClearWorldSendMessage)) Implements IConnection.SendClearWorld

    Public Event SendCoin(sender As Object, e As SendEventArgs(Of CoinSendMessage)) Implements IConnection.SendCoin

    Public Event SendCoindoorPlace(sender As Object, e As SendEventArgs(Of CoinDoorPlaceSendMessage)) Implements IConnection.SendCoindoorPlace

    Public Event SendCompleteLevel(sender As Object, e As SendEventArgs(Of CompleteLevelSendMessage)) Implements IConnection.SendCompleteLevel

    Public Event SendGetCrown(sender As Object, e As SendEventArgs(Of GetCrownSendMessage)) Implements IConnection.SendGetCrown

    Public Event SendGodMode(sender As Object, e As SendEventArgs(Of GodModeSendMessage)) Implements IConnection.SendGodMode

    Public Event SendInit(sender As Object, e As SendEventArgs(Of InitSendMessage)) Implements IConnection.SendInit

    Public Event SendInit2(sender As Object, e As SendEventArgs(Of Init2SendMessage)) Implements IConnection.SendInit2

    Public Event SendKillWorld(sender As Object, e As SendEventArgs(Of KillWorldSendMessage)) Implements IConnection.SendKillWorld

    Public Event SendLabelPlace(sender As Object, e As SendEventArgs(Of LabelPlaceSendMessage)) Implements IConnection.SendLabelPlace

    Public Event SendMessage(sender As Object, e As SendMessage) Implements IConnection.SendMessage

    Public Event SendModMode(sender As Object, e As SendEventArgs(Of ModModeSendMessage)) Implements IConnection.SendModMode

    Public Event SendMove(sender As Object, e As SendEventArgs(Of MoveSendMessage)) Implements IConnection.SendMove

    Public Event SendPortalPlace(sender As Object, e As SendEventArgs(Of PortalPlaceSendMessage)) Implements IConnection.SendPortalPlace

    Public Event SendPressBlueKey(sender As Object, e As SendEventArgs(Of PressBlueKeySendMessage)) Implements IConnection.SendPressBlueKey

    Public Event SendPressGreenKey(sender As Object, e As SendEventArgs(Of PressGreenKeySendMessage)) Implements IConnection.SendPressGreenKey

    Public Event SendPressRedKey(sender As Object, e As SendEventArgs(Of PressRedKeySendMessage)) Implements IConnection.SendPressRedKey

    Public Event SendSaveWorld(sender As Object, e As SendEventArgs(Of SaveWorldSendMessage)) Implements IConnection.SendSaveWorld

    Public Event SendSay(sender As Object, e As SendEventArgs(Of SaySendMessage)) Implements IConnection.SendSay

    Public Event SendSoundPlace(sender As Object, e As SendEventArgs(Of SoundPlaceSendMessage)) Implements IConnection.SendSoundPlace

    Public Event SendTouchDiamond(sender As Object, e As SendEventArgs(Of TouchDiamondSendMessage)) Implements IConnection.SendTouchDiamond

#End Region

#Region "Methods"

    Sub New(ByVal client As IClient(Of Player))
        myClient = client

        If myGameVersionNumber = 0 Then
            Try
                myGameVersionNumber = CInt(Cloud.Service.GetSetting(GameVersionSetting))
            Catch
                Cloud.Logger.Log(LogPriority.Warning, "Invalid GameVersion setting.")
            End Try
        End If
    End Sub

    Private Sub SetupConnection(connection As PlayerIOClient.Connection, id As String)
        'Setting variables
        myConnection = connection
        myWorldID = id

        'Registering messages
        RegisterMessage("groupdisallowedjoin", GetType(GroupDisallowedJoinReceiveMessage))
        RegisterMessage("info", GetType(InfoReceiveMessage))
        RegisterMessage("upgrade", GetType(UpgradeReceiveMessage))
        RegisterMessage("init", GetType(InitReceiveMessage))

        'Initing Client
        Send(New InitSendMessage)
    End Sub

    Private Function GetIOConnection(ioClient As PlayerIOClient.Client, id As String) As PlayerIOClient.Connection
        Try
            Return ioClient.Multiplayer.CreateJoinRoom(id, NormalRoom & myGameVersionNumber, True, Nothing, Nothing)
        Catch ex As PlayerIOClient.PlayerIOError
            If ex.ErrorCode = PlayerIOClient.ErrorCode.UnknownRoomType Then
                UpdateVersion(ex)
                Return GetIOConnection(ioClient, id)
            Else
                Throw New EECloudPlayerIOException(ex)
            End If
        End Try
    End Function

    Private Sub UpdateVersion(ex As PlayerIOClient.PlayerIOError)
        Dim errorMessage() As String = ex.Message.Split("["c)(1).Split(CChar(" "))
        For N = errorMessage.Length - 1 To 0 Step -1
            Dim currentRoomType As String
            currentRoomType = errorMessage(N)
            If currentRoomType.StartsWith(NormalRoom, StringComparison.Ordinal) Then
                myGameVersionNumber = CInt(currentRoomType.Substring(NormalRoom.Length, currentRoomType.Length - NormalRoom.Length - 1))
                Cloud.Service.SetSetting(GameVersionSetting, CStr(myGameVersionNumber))
                Exit Sub
            End If
        Next
        Throw New EECloudException(ErrorCode.GameVersionNotInList, "Unable to get room version")
    End Sub

    Private Function RaiseSendEvent(message As SendMessage) As Boolean
        RaiseEvent SendMessage(Me, message)
        Select Case message.GetType
            Case GetType(InitSendMessage)
                Dim eventArgs As New SendEventArgs(Of InitSendMessage)(CType(message, InitSendMessage))
                RaiseEvent SendInit(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(Init2SendMessage)
                Dim eventArgs As New SendEventArgs(Of Init2SendMessage)(CType(message, Init2SendMessage))
                RaiseEvent SendInit2(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(BlockPlaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of BlockPlaceSendMessage)(CType(message, BlockPlaceSendMessage))
                RaiseEvent SendBlockPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(CoinDoorPlaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of CoinDoorPlaceSendMessage)(CType(message, CoinDoorPlaceSendMessage))
                RaiseEvent SendCoindoorPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(SoundPlaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of SoundPlaceSendMessage)(CType(message, SoundPlaceSendMessage))
                RaiseEvent SendSoundPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PortalPlaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of PortalPlaceSendMessage)(CType(message, PortalPlaceSendMessage))
                RaiseEvent SendPortalPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(LabelPlaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of LabelPlaceSendMessage)(CType(message, LabelPlaceSendMessage))
                RaiseEvent SendLabelPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(CoinSendMessage)
                Dim eventArgs As New SendEventArgs(Of CoinSendMessage)(CType(message, CoinSendMessage))
                RaiseEvent SendCoin(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressRedKeySendMessage)
                Dim eventArgs As New SendEventArgs(Of PressRedKeySendMessage)(CType(message, PressRedKeySendMessage))
                RaiseEvent SendPressRedKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressGreenKeySendMessage)
                Dim eventArgs As New SendEventArgs(Of PressGreenKeySendMessage)(CType(message, PressGreenKeySendMessage))
                RaiseEvent SendPressGreenKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressBlueKeySendMessage)
                Dim eventArgs As New SendEventArgs(Of PressBlueKeySendMessage)(CType(message, PressBlueKeySendMessage))
                RaiseEvent SendPressBlueKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(GetCrownSendMessage)
                Dim eventArgs As New SendEventArgs(Of GetCrownSendMessage)(CType(message, GetCrownSendMessage))
                RaiseEvent SendGetCrown(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(TouchDiamondSendMessage)
                Dim eventArgs As New SendEventArgs(Of TouchDiamondSendMessage)(CType(message, TouchDiamondSendMessage))
                RaiseEvent SendTouchDiamond(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(CompleteLevelSendMessage)
                Dim eventArgs As New SendEventArgs(Of CompleteLevelSendMessage)(CType(message, CompleteLevelSendMessage))
                RaiseEvent SendCompleteLevel(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(GodModeSendMessage)
                Dim eventArgs As New SendEventArgs(Of GodModeSendMessage)(CType(message, GodModeSendMessage))
                RaiseEvent SendGodMode(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ModModeSendMessage)
                Dim eventArgs As New SendEventArgs(Of ModModeSendMessage)(CType(message, ModModeSendMessage))
                RaiseEvent SendModMode(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(MoveSendMessage)
                Dim eventArgs As New SendEventArgs(Of MoveSendMessage)(CType(message, MoveSendMessage))
                RaiseEvent SendMove(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(SaySendMessage)
                Dim eventArgs As New SendEventArgs(Of SaySendMessage)(CType(message, SaySendMessage))
                RaiseEvent SendSay(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(AutoSaySendMessage)
                Dim eventArgs As New SendEventArgs(Of AutoSaySendMessage)(CType(message, AutoSaySendMessage))
                RaiseEvent SendAutoSay(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(AccessSendMessage)
                Dim eventArgs As New SendEventArgs(Of AccessSendMessage)(CType(message, AccessSendMessage))
                RaiseEvent SendAccess(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeFaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of ChangeFaceSendMessage)(CType(message, ChangeFaceSendMessage))
                RaiseEvent SendChangeFace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(SaveWorldSendMessage)
                Dim eventArgs As New SendEventArgs(Of SaveWorldSendMessage)(CType(message, SaveWorldSendMessage))
                RaiseEvent SendSaveWorld(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeWorldNameSendMessage)
                Dim eventArgs As New SendEventArgs(Of ChangeWorldNameSendMessage)(CType(message, ChangeWorldNameSendMessage))
                RaiseEvent SendChangeWorldName(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeWorldEditKeySendMessage)
                Dim eventArgs As New SendEventArgs(Of ChangeWorldEditKeySendMessage)(CType(message, ChangeWorldEditKeySendMessage))
                RaiseEvent SendChangeWorldEditKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ClearWorldSendMessage)
                Dim eventArgs As New SendEventArgs(Of ClearWorldSendMessage)(CType(message, ClearWorldSendMessage))
                RaiseEvent SendClearWorld(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(KillWorldSendMessage)
                Dim eventArgs As New SendEventArgs(Of KillWorldSendMessage)(CType(message, KillWorldSendMessage))
                RaiseEvent SendKillWorld(Me, eventArgs)
                Return eventArgs.Handled
            Case Else
                Return False
        End Select
    End Function

    Private Async Sub Connection_ReceiveMessage(sender As Object, e As ReceiveMessage) Handles Me.ReceiveMessage
        Select Case e.GetType
            Case GetType(InitReceiveMessage)
                Dim m As InitReceiveMessage = CType(e, InitReceiveMessage)
                UnRegisterMessage("init")
                UnRegisterMessage("groupdisallowedjoin")
                RegisterMessages()
                Send(New Init2SendMessage)
                RaiseEvent ReceiveInit(Me, m)

            Case GetType(GroupDisallowedJoinReceiveMessage)
                Dim m As GroupDisallowedJoinReceiveMessage = CType(e, GroupDisallowedJoinReceiveMessage)
                RaiseEvent ReceiveGroupDisallowedJoin(Me, m)

            Case GetType(InfoReceiveMessage)
                Dim m As InfoReceiveMessage = CType(e, InfoReceiveMessage)
                RaiseEvent ReceiveInfo(Me, m)

            Case GetType(UpgradeReceiveMessage)
                Dim m As UpgradeReceiveMessage = CType(e, UpgradeReceiveMessage)
                myGameVersionNumber += 1
                Cloud.Logger.Log(LogPriority.Info, "The game has been updated!")
                Await Cloud.Service.SetSettingAsync("GameVersion", CStr(myGameVersionNumber))
                RaiseEvent ReceiveUpgrade(Me, m)

            Case GetType(UpdateMetaReceiveMessage)
                Dim m As UpdateMetaReceiveMessage = CType(e, UpdateMetaReceiveMessage)
                RaiseEvent ReceiveUpdateMeta(Me, m)

            Case GetType(AddReceiveMessage)
                Dim m As AddReceiveMessage = CType(e, AddReceiveMessage)
                RaiseEvent ReceiveAdd(Me, m)

            Case GetType(LeftReceiveMessage)
                Dim m As LeftReceiveMessage = CType(e, LeftReceiveMessage)
                RaiseEvent ReceiveLeft(Me, m)

            Case GetType(MoveReceiveMessage)
                Dim m As MoveReceiveMessage = CType(e, MoveReceiveMessage)
                RaiseEvent ReceiveMove(Me, m)

            Case GetType(CoinReceiveMessage)
                Dim m As CoinReceiveMessage = CType(e, CoinReceiveMessage)
                RaiseEvent ReceiveCoin(Me, m)

            Case GetType(CrownReceiveMessage)
                Dim m As CrownReceiveMessage = CType(e, CrownReceiveMessage)
                RaiseEvent ReceiveCrown(Me, m)

            Case GetType(SilverCrownReceiveMessage)
                Dim m As SilverCrownReceiveMessage = CType(e, SilverCrownReceiveMessage)
                RaiseEvent ReceiveSilverCrown(Me, m)

            Case GetType(FaceReceiveMessage)
                Dim m As FaceReceiveMessage = CType(e, FaceReceiveMessage)
                RaiseEvent ReceiveFace(Me, m)

            Case GetType(ShowKeyReceiveMessage)
                Dim m As ShowKeyReceiveMessage = CType(e, ShowKeyReceiveMessage)
                RaiseEvent ReceiveShowKey(Me, m)

            Case GetType(HideKeyReceiveMessage)
                Dim m As HideKeyReceiveMessage = CType(e, HideKeyReceiveMessage)
                RaiseEvent ReceiveHideKey(Me, m)

            Case GetType(SayReceiveMessage)
                Dim m As SayReceiveMessage = CType(e, SayReceiveMessage)
                RaiseEvent ReceiveSay(Me, m)

            Case GetType(SayOld_ReceiveMessage)
                Dim m As SayOld_ReceiveMessage = CType(e, SayOld_ReceiveMessage)
                RaiseEvent ReceiveSayOld(Me, m)

            Case GetType(AutoTextReceiveMessage)
                Dim m As AutoTextReceiveMessage = CType(e, AutoTextReceiveMessage)
                RaiseEvent ReceiveAutoText(Me, m)

            Case GetType(WriteReceiveMessage)
                Dim m As WriteReceiveMessage = CType(e, WriteReceiveMessage)
                RaiseEvent ReceiveWrite(Me, m)

            Case GetType(BlockPlaceReceiveMessage)
                Dim m As BlockPlaceReceiveMessage = CType(e, BlockPlaceReceiveMessage)
                RaiseEvent ReceiveBlockPlace(Me, m)

            Case GetType(CoinDoorPlace_ReceiveMessage)
                Dim m As CoinDoorPlace_ReceiveMessage = CType(e, CoinDoorPlace_ReceiveMessage)
                RaiseEvent ReceiveCoinDoorPlace(Me, m)

            Case GetType(SoundPlaceReceiveMessage)
                Dim m As SoundPlaceReceiveMessage = CType(e, SoundPlaceReceiveMessage)
                RaiseEvent ReceiveSoundPlace(Me, m)

            Case GetType(PortalPlaceReceiveMessage)
                Dim m As PortalPlaceReceiveMessage = CType(e, PortalPlaceReceiveMessage)
                RaiseEvent ReceivePortalPlace(Me, m)

            Case GetType(LabelPlaceReceiveMessage)
                Dim m As LabelPlaceReceiveMessage = CType(e, LabelPlaceReceiveMessage)
                RaiseEvent ReceiveLabelPlace(Me, m)

            Case GetType(GodModeReceiveMessage)
                Dim m As GodModeReceiveMessage = CType(e, GodModeReceiveMessage)
                RaiseEvent ReceiveGodMode(Me, m)

            Case GetType(ModModeReceiveMessage)
                Dim m As ModModeReceiveMessage = CType(e, ModModeReceiveMessage)
                RaiseEvent ReceiveModMode(Me, m)

            Case GetType(AccessReceiveMessage)
                Dim m As AccessReceiveMessage = CType(e, AccessReceiveMessage)
                RaiseEvent ReceiveAccess(Me, m)

            Case GetType(LostAccessReceiveMessage)
                Dim m As LostAccessReceiveMessage = CType(e, LostAccessReceiveMessage)
                RaiseEvent ReceiveLostAccess(Me, m)

            Case GetType(TeleportReceiveMessage)
                Dim m As TeleportReceiveMessage = CType(e, TeleportReceiveMessage)
                RaiseEvent ReceiveTeleport(Me, m)

            Case GetType(ResetReceiveMessage)
                Dim m As ResetReceiveMessage = CType(e, ResetReceiveMessage)
                RaiseEvent ReceiveReset(Me, m)

            Case GetType(ClearReceiveMessage)
                Dim m As ClearReceiveMessage = CType(e, ClearReceiveMessage)
                RaiseEvent ReceiveClear(Me, m)

            Case GetType(SaveDoneReceiveMessage)
                Dim m As SaveDoneReceiveMessage = CType(e, SaveDoneReceiveMessage)
                RaiseEvent ReceiveSaveDone(Me, m)

            Case GetType(RefreshShopReceiveMessage)
                Dim m As RefreshShopReceiveMessage = CType(e, RefreshShopReceiveMessage)
                RaiseEvent ReceiveRefreshShop(Me, m)

            Case GetType(GiveWizardReceiveMessage)
                Dim m As GiveWizardReceiveMessage = CType(e, GiveWizardReceiveMessage)
                RaiseEvent ReceiveGiveWizard(Me, m)

            Case GetType(GiveFireWizardReceiveMessage)
                Dim m As GiveFireWizardReceiveMessage = CType(e, GiveFireWizardReceiveMessage)
                RaiseEvent ReceiveGiveFireWizard(Me, m)

            Case GetType(GiveWitchReceiveMessage)
                Dim m As GiveWitchReceiveMessage = CType(e, GiveWitchReceiveMessage)
                RaiseEvent ReceiveGiveWitch(Me, m)

            Case GetType(GiveGrinchReceiveMessage)
                Dim m As GiveGrinchReceiveMessage = CType(e, GiveGrinchReceiveMessage)
                RaiseEvent ReceiveGiveGrinch(Me, m)
        End Select
    End Sub

    Private Sub myConnection_OnDisconnect(sender As Object, message As String) Handles myConnection.OnDisconnect
        UnRegisterAll()
        RaiseEvent Disconnect(Me, New DisconnectEventArgs(myExpectingDisconnect))
        myExpectingDisconnect = False
    End Sub

    Private Sub myConnection_OnMessage(sender As Object, e As PlayerIOClient.Message) Handles myConnection.OnMessage
        Try
            If myMessageDictionary.ContainsKey(e.Type) Then
                Dim messageType As Type = myMessageDictionary(e.Type)
                Dim constructorInfo As ConstructorInfo = messageType.GetConstructor(BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, New Type() {GetType(PlayerIOClient.Message)}, Nothing)
                Dim message As ReceiveMessage = CType(constructorInfo.Invoke(New Object() {e}), ReceiveMessage)
                RaiseEvent ReceiveMessage(Me, message)
            Else
                Cloud.Logger.Log(LogPriority.Warning, "Received not registered message: " & e.Type)
            End If
        Catch ex As KeyNotFoundException
            Cloud.Logger.Log(LogPriority.Error, "Failed to parse message: " & e.Type)
            Cloud.Logger.LogEx(ex)
        End Try
    End Sub

#Region "IConnection Support"

    Friend Async Function ConnectAsync(username As String, password As String, id As String) As Task Implements IConnection.ConnectAsync
        If Not Connected Then
            Await Task.Run(
                Sub()
                    Try
                        Dim ioClient As PlayerIOClient.Client = PlayerIOClient.PlayerIO.QuickConnect.SimpleConnect(GameID, username, password)
                        Dim ioConnection As PlayerIOClient.Connection = GetIOConnection(ioClient, id)
                        SetupConnection(ioConnection, id)
                    Catch ex As PlayerIOClient.PlayerIOError
                        Throw New EECloudPlayerIOException(ex)
                    End Try
                End Sub)
        Else
            Throw New Exception("Can not create a new Client while an other Client already exists")
        End If
    End Function

    Friend Sub Send(message As SendMessage) Implements IConnection.Send
        If myConnection IsNot Nothing Then
            If Not RaiseSendEvent(message) Then
                myConnection.Send(message.GetMessage(myClient.World))
            End If
        End If
    End Sub

    Friend Sub Close() Implements IConnection.Close
        If myConnection IsNot Nothing Then
            RaiseEvent Disconnecting(Me, EventArgs.Empty)
            myConnection.Disconnect()
        End If
    End Sub

#End Region

#Region "Message Register"

    Private myRegisteredMessages As Boolean

    Private Sub RegisterMessages()
        If myRegisteredMessages = False Then
            myRegisteredMessages = True
            RegisterMessage("updatemeta", GetType(UpdateMetaReceiveMessage))
            RegisterMessage("add", GetType(AddReceiveMessage))
            RegisterMessage("left", GetType(LeftReceiveMessage))
            RegisterMessage("m", GetType(MoveReceiveMessage))
            RegisterMessage("c", GetType(CoinReceiveMessage))
            RegisterMessage("k", GetType(CrownReceiveMessage))
            RegisterMessage("ks", GetType(SilverCrownReceiveMessage))
            RegisterMessage("face", GetType(FaceReceiveMessage))
            RegisterMessage("show", GetType(ShowKeyReceiveMessage))
            RegisterMessage("hide", GetType(HideKeyReceiveMessage))
            RegisterMessage("say", GetType(SayReceiveMessage))
            RegisterMessage("say_old", GetType(SayOld_ReceiveMessage))
            RegisterMessage("autotext", GetType(AutoTextReceiveMessage))
            RegisterMessage("write", GetType(WriteReceiveMessage))
            RegisterMessage("b", GetType(BlockPlaceReceiveMessage))
            RegisterMessage("bc", GetType(CoinDoorPlace_ReceiveMessage))
            RegisterMessage("bs", GetType(SoundPlaceReceiveMessage))
            RegisterMessage("pt", GetType(PortalPlaceReceiveMessage))
            RegisterMessage("lb", GetType(LabelPlaceReceiveMessage))
            RegisterMessage("god", GetType(GodModeReceiveMessage))
            RegisterMessage("mod", GetType(ModModeReceiveMessage))
            RegisterMessage("access", GetType(AccessReceiveMessage))
            RegisterMessage("lostaccess", GetType(LostAccessReceiveMessage))
            RegisterMessage("tele", GetType(TeleportReceiveMessage))
            RegisterMessage("reset", GetType(ResetReceiveMessage))
            RegisterMessage("clear", GetType(ClearReceiveMessage))
            RegisterMessage("saved", GetType(SaveDoneReceiveMessage))
            RegisterMessage("refreshshop", GetType(RefreshShopReceiveMessage))
            RegisterMessage("givewizard", GetType(GiveWizardReceiveMessage))
            RegisterMessage("givewizard2", GetType(GiveFireWizardReceiveMessage))
            RegisterMessage("givewitch", GetType(GiveWitchReceiveMessage))
            RegisterMessage("givegrinch", GetType(GiveGrinchReceiveMessage))
        End If
    End Sub

    Private Sub RegisterMessage(str As String, type As Type)
        Try
            If Not type.IsSubclassOf(GetType(ReceiveMessage)) Then
                Throw New InvalidOperationException("Invalid message class! Must inherit " & GetType(ReceiveMessage).ToString)
            Else
                myMessageDictionary.Add(str, type)
            End If
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to register message: " & str)
        End Try
    End Sub

    Private Sub UnRegisterMessage(pString As String)
        Try
            myMessageDictionary.Remove(pString)
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to unregister message: " & pString)
        End Try
    End Sub

    Private Sub UnRegisterAll()
        myRegisteredMessages = False
        myMessageDictionary.Clear()
    End Sub

#End Region

#End Region
End Class
