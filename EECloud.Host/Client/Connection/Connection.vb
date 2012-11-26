﻿Imports PlayerIOClient
Imports System.Reflection

Friend NotInheritable Class Connection
    Implements IConnection

#Region "Fields"
    Private ReadOnly myLockObj As New Object
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
    Friend Event Disconnect(sender As Object, e As DisconnectEventArgs) Implements IConnection.Disconnect

    Friend Event Disconnecting(sender As Object, e As EventArgs) Implements IConnection.Disconnecting

    Friend Event ReceiveAccess(sender As Object, e As AccessReceiveMessage) Implements IConnection.ReceiveAccess

    Friend Event ReceiveAdd(sender As Object, e As AddReceiveMessage) Implements IConnection.ReceiveAdd

    Friend Event ReceiveAutoText(sender As Object, e As AutoTextReceiveMessage) Implements IConnection.ReceiveAutoText

    Friend Event ReceiveBlockPlace(sender As Object, e As BlockPlaceReceiveMessage) Implements IConnection.ReceiveBlockPlace

    Friend Event ReceiveClear(sender As Object, e As ClearReceiveMessage) Implements IConnection.ReceiveClear

    Friend Event ReceiveCoin(sender As Object, e As CoinReceiveMessage) Implements IConnection.ReceiveCoin

    Friend Event ReceiveCoinDoorPlace(sender As Object, e As CoinDoorPlaceReceiveMessage) Implements IConnection.ReceiveCoinDoorPlace

    Friend Event ReceiveCrown(sender As Object, e As CrownReceiveMessage) Implements IConnection.ReceiveCrown

    Friend Event ReceiveFace(sender As Object, e As FaceReceiveMessage) Implements IConnection.ReceiveFace

    Friend Event ReceiveGiveFireWizard(sender As Object, e As GiveFireWizardReceiveMessage) Implements IConnection.ReceiveGiveFireWizard

    Friend Event ReceiveGiveGrinch(sender As Object, e As GiveGrinchReceiveMessage) Implements IConnection.ReceiveGiveGrinch

    Friend Event ReceiveGiveWitch(sender As Object, e As GiveWitchReceiveMessage) Implements IConnection.ReceiveGiveWitch

    Friend Event ReceiveGiveWizard(sender As Object, e As GiveWizardReceiveMessage) Implements IConnection.ReceiveGiveWizard

    Friend Event ReceiveGodMode(sender As Object, e As GodModeReceiveMessage) Implements IConnection.ReceiveGodMode

    Friend Event ReceiveGroupDisallowedJoin(sender As Object, e As GroupDisallowedJoinReceiveMessage) Implements IConnection.ReceiveGroupDisallowedJoin

    Friend Event ReceiveHideKey(sender As Object, e As HideKeyReceiveMessage) Implements IConnection.ReceiveHideKey

    Friend Event ReceiveInfo(sender As Object, e As InfoReceiveMessage) Implements IConnection.ReceiveInfo

    Friend Event ReceiveInit(sender As Object, e As InitReceiveMessage) Implements IConnection.ReceiveInit

    Friend Event ReceiveLabelPlace(sender As Object, e As LabelPlaceReceiveMessage) Implements IConnection.ReceiveLabelPlace

    Friend Event ReceiveLeft(sender As Object, e As LeftReceiveMessage) Implements IConnection.ReceiveLeft

    Friend Event ReceiveLostAccess(sender As Object, e As LostAccessReceiveMessage) Implements IConnection.ReceiveLostAccess

    Friend Event ReceiveMessage(sender As Object, e As ReceiveMessage) Implements IConnection.ReceiveMessage

    Friend Event ReceiveModMode(sender As Object, e As ModModeReceiveMessage) Implements IConnection.ReceiveModMode

    Friend Event ReceiveMove(sender As Object, e As MoveReceiveMessage) Implements IConnection.ReceiveMove

    Friend Event ReceivePortalPlace(sender As Object, e As PortalPlaceReceiveMessage) Implements IConnection.ReceivePortalPlace

    Friend Event ReceivePotion(sender As Object, e As PotionReceiveMessage) Implements IConnection.ReceivePotion

    Friend Event ReceiveRefreshShop(sender As Object, e As RefreshShopReceiveMessage) Implements IConnection.ReceiveRefreshShop

    Friend Event ReceiveReset(sender As Object, e As ResetReceiveMessage) Implements IConnection.ReceiveReset

    Friend Event ReceiveSaveDone(sender As Object, e As SaveDoneReceiveMessage) Implements IConnection.ReceiveSaveDone

    Friend Event ReceiveSay(sender As Object, e As SayReceiveMessage) Implements IConnection.ReceiveSay

    Friend Event ReceiveSayOld(sender As Object, e As SayOldReceiveMessage) Implements IConnection.ReceiveSayOld

    Friend Event ReceiveShowKey(sender As Object, e As ShowKeyReceiveMessage) Implements IConnection.ReceiveShowKey

    Friend Event ReceiveSilverCrown(sender As Object, e As SilverCrownReceiveMessage) Implements IConnection.ReceiveSilverCrown

    Friend Event ReceiveSoundPlace(sender As Object, e As SoundPlaceReceiveMessage) Implements IConnection.ReceiveSoundPlace

    Friend Event ReceiveTeleport(sender As Object, e As TeleportReceiveMessage) Implements IConnection.ReceiveTeleport

    Friend Event ReceiveUpdateMeta(sender As Object, e As UpdateMetaReceiveMessage) Implements IConnection.ReceiveUpdateMeta

    Friend Event ReceiveUpgrade(sender As Object, e As UpgradeReceiveMessage) Implements IConnection.ReceiveUpgrade

    Friend Event ReceiveWrite(sender As Object, e As WriteReceiveMessage) Implements IConnection.ReceiveWrite

    Friend Event SendAccess(sender As Object, e As Cancelable(Of AccessSendMessage)) Implements IConnection.SendAccess

    Friend Event SendAutoSay(sender As Object, e As Cancelable(Of AutoSaySendMessage)) Implements IConnection.SendAutoSay

    Friend Event SendBlockPlace(sender As Object, e As Cancelable(Of BlockPlaceSendMessage)) Implements IConnection.SendBlockPlace

    Friend Event SendChangeFace(sender As Object, e As Cancelable(Of ChangeFaceSendMessage)) Implements IConnection.SendChangeFace

    Friend Event SendChangeWorldEditKey(sender As Object, e As Cancelable(Of ChangeWorldEditKeySendMessage)) Implements IConnection.SendChangeWorldEditKey

    Friend Event SendChangeWorldName(sender As Object, e As Cancelable(Of ChangeWorldNameSendMessage)) Implements IConnection.SendChangeWorldName

    Friend Event SendClearWorld(sender As Object, e As Cancelable(Of ClearWorldSendMessage)) Implements IConnection.SendClearWorld

    Friend Event SendCoin(sender As Object, e As Cancelable(Of CoinSendMessage)) Implements IConnection.SendCoin

    Friend Event SendCoindoorPlace(sender As Object, e As Cancelable(Of CoinDoorPlaceSendMessage)) Implements IConnection.SendCoindoorPlace

    Friend Event SendCompleteLevel(sender As Object, e As Cancelable(Of CompleteLevelSendMessage)) Implements IConnection.SendCompleteLevel

    Friend Event SendGetCrown(sender As Object, e As Cancelable(Of GetCrownSendMessage)) Implements IConnection.SendGetCrown

    Friend Event SendGodMode(sender As Object, e As Cancelable(Of GodModeSendMessage)) Implements IConnection.SendGodMode

    Friend Event SendInit(sender As Object, e As Cancelable(Of InitSendMessage)) Implements IConnection.SendInit

    Friend Event SendInit2(sender As Object, e As Cancelable(Of Init2SendMessage)) Implements IConnection.SendInit2

    Friend Event SendKillWorld(sender As Object, e As Cancelable(Of KillWorldSendMessage)) Implements IConnection.SendKillWorld

    Friend Event SendLabelPlace(sender As Object, e As Cancelable(Of LabelPlaceSendMessage)) Implements IConnection.SendLabelPlace

    Friend Event SendMessage(sender As Object, e As SendMessage) Implements IConnection.SendMessage

    Friend Event SendModMode(sender As Object, e As Cancelable(Of ModModeSendMessage)) Implements IConnection.SendModMode

    Friend Event SendMove(sender As Object, e As Cancelable(Of MoveSendMessage)) Implements IConnection.SendMove

    Friend Event SendPortalPlace(sender As Object, e As Cancelable(Of PortalPlaceSendMessage)) Implements IConnection.SendPortalPlace

    Friend Event SendPressBlueKey(sender As Object, e As Cancelable(Of PressBlueKeySendMessage)) Implements IConnection.SendPressBlueKey

    Friend Event SendPressGreenKey(sender As Object, e As Cancelable(Of PressGreenKeySendMessage)) Implements IConnection.SendPressGreenKey

    Friend Event SendPressRedKey(sender As Object, e As Cancelable(Of PressRedKeySendMessage)) Implements IConnection.SendPressRedKey

    Friend Event SendSaveWorld(sender As Object, e As Cancelable(Of SaveWorldSendMessage)) Implements IConnection.SendSaveWorld

    Friend Event SendSay(sender As Object, e As Cancelable(Of SaySendMessage)) Implements IConnection.SendSay

    Friend Event SendSoundPlace(sender As Object, e As Cancelable(Of SoundPlaceSendMessage)) Implements IConnection.SendSoundPlace

    Friend Event SendTouchDiamond(sender As Object, e As Cancelable(Of TouchDiamondSendMessage)) Implements IConnection.SendTouchDiamond

    Friend Event SendPotion(sender As Object, e As Cancelable(Of PotionSendMessage)) Implements IConnection.SendPotion

    Friend Event SendTouchCake(sender As Object, e As Cancelable(Of TouchCakeSendMessage)) Implements IConnection.SendTouchCake

    Friend Event PreviewDisconnect(sender As Object, e As DisconnectEventArgs) Implements IConnection.PreviewDisconnect

    Friend Event PreviewDisconnecting(sender As Object, e As EventArgs) Implements IConnection.PreviewDisconnecting

    Friend Event PreviewReceiveAccess(sender As Object, e As AccessReceiveMessage) Implements IConnection.PreviewReceiveAccess

    Friend Event PreviewReceiveAdd(sender As Object, e As AddReceiveMessage) Implements IConnection.PreviewReceiveAdd

    Friend Event PreviewReceiveAutoText(sender As Object, e As AutoTextReceiveMessage) Implements IConnection.PreviewReceiveAutoText

    Friend Event PreviewReceiveBlockPlace(sender As Object, e As BlockPlaceReceiveMessage) Implements IConnection.PreviewReceiveBlockPlace

    Friend Event PreviewReceiveClear(sender As Object, e As ClearReceiveMessage) Implements IConnection.PreviewReceiveClear

    Friend Event PreviewReceiveCoin(sender As Object, e As CoinReceiveMessage) Implements IConnection.PreviewReceiveCoin

    Friend Event PreviewReceiveCoinDoorPlace(sender As Object, e As CoinDoorPlaceReceiveMessage) Implements IConnection.PreviewReceiveCoinDoorPlace

    Friend Event PreviewReceiveCrown(sender As Object, e As CrownReceiveMessage) Implements IConnection.PreviewReceiveCrown

    Friend Event PreviewReceiveFace(sender As Object, e As FaceReceiveMessage) Implements IConnection.PreviewReceiveFace

    Friend Event PreviewReceiveGiveFireWizard(sender As Object, e As GiveFireWizardReceiveMessage) Implements IConnection.PreviewReceiveGiveFireWizard

    Friend Event PreviewReceiveGiveGrinch(sender As Object, e As GiveGrinchReceiveMessage) Implements IConnection.PreviewReceiveGiveGrinch

    Friend Event PreviewReceiveGiveWitch(sender As Object, e As GiveWitchReceiveMessage) Implements IConnection.PreviewReceiveGiveWitch

    Friend Event PreviewReceiveGiveWizard(sender As Object, e As GiveWizardReceiveMessage) Implements IConnection.PreviewReceiveGiveWizard

    Friend Event PreviewReceiveGodMode(sender As Object, e As GodModeReceiveMessage) Implements IConnection.PreviewReceiveGodMode

    Friend Event PreviewReceiveGroupDisallowedJoin(sender As Object, e As GroupDisallowedJoinReceiveMessage) Implements IConnection.PreviewReceiveGroupDisallowedJoin

    Friend Event PreviewReceiveHideKey(sender As Object, e As HideKeyReceiveMessage) Implements IConnection.PreviewReceiveHideKey

    Friend Event PreviewReceiveInfo(sender As Object, e As InfoReceiveMessage) Implements IConnection.PreviewReceiveInfo

    Friend Event PreviewReceiveInit(sender As Object, e As InitReceiveMessage) Implements IConnection.PreviewReceiveInit

    Friend Event PreviewReceiveLabelPlace(sender As Object, e As LabelPlaceReceiveMessage) Implements IConnection.PreviewReceiveLabelPlace

    Friend Event PreviewReceiveLeft(sender As Object, e As LeftReceiveMessage) Implements IConnection.PreviewReceiveLeft

    Friend Event PreviewReceiveLostAccess(sender As Object, e As LostAccessReceiveMessage) Implements IConnection.PreviewReceiveLostAccess

    Friend Event PreviewReceiveMessage(sender As Object, e As ReceiveMessage) Implements IConnection.PreviewReceiveMessage

    Friend Event PreviewReceiveModMode(sender As Object, e As ModModeReceiveMessage) Implements IConnection.PreviewReceiveModMode

    Friend Event PreviewReceiveMove(sender As Object, e As MoveReceiveMessage) Implements IConnection.PreviewReceiveMove

    Friend Event PreviewReceivePortalPlace(sender As Object, e As PortalPlaceReceiveMessage) Implements IConnection.PreviewReceivePortalPlace

    Friend Event PreviewReceivePotion(sender As Object, e As PotionReceiveMessage) Implements IConnection.PreviewReceivePotion

    Friend Event PreviewReceiveRefreshShop(sender As Object, e As RefreshShopReceiveMessage) Implements IConnection.PreviewReceiveRefreshShop

    Friend Event PreviewReceiveReset(sender As Object, e As ResetReceiveMessage) Implements IConnection.PreviewReceiveReset

    Friend Event PreviewReceiveSaveDone(sender As Object, e As SaveDoneReceiveMessage) Implements IConnection.PreviewReceiveSaveDone

    Friend Event PreviewReceiveSay(sender As Object, e As SayReceiveMessage) Implements IConnection.PreviewReceiveSay

    Friend Event PreviewReceiveSayOld(sender As Object, e As SayOldReceiveMessage) Implements IConnection.PreviewReceiveSayOld

    Friend Event PreviewReceiveShowKey(sender As Object, e As ShowKeyReceiveMessage) Implements IConnection.PreviewReceiveShowKey

    Friend Event PreviewReceiveSilverCrown(sender As Object, e As SilverCrownReceiveMessage) Implements IConnection.PreviewReceiveSilverCrown

    Friend Event PreviewReceiveSoundPlace(sender As Object, e As SoundPlaceReceiveMessage) Implements IConnection.PreviewReceiveSoundPlace

    Friend Event PreviewReceiveTeleport(sender As Object, e As TeleportReceiveMessage) Implements IConnection.PreviewReceiveTeleport

    Friend Event PreviewReceiveUpdateMeta(sender As Object, e As UpdateMetaReceiveMessage) Implements IConnection.PreviewReceiveUpdateMeta

    Friend Event PreviewReceiveUpgrade(sender As Object, e As UpgradeReceiveMessage) Implements IConnection.PreviewReceiveUpgrade

    Friend Event PreviewReceiveWrite(sender As Object, e As WriteReceiveMessage) Implements IConnection.PreviewReceiveWrite

    Friend Event InitComplete(sender As Object, e As EventArgs) Implements IConnection.InitComplete

    Friend Event PreviewReceiveAllowPotions(sender As Object, e As AllowPotionsReceiveMessage) Implements IConnection.PreviewReceiveAllowPotions

    Friend Event ReceiveAllowPotions(sender As Object, e As AllowPotionsReceiveMessage) Implements IConnection.ReceiveAllowPotions

    Friend Event SendAllowPotions(sender As Object, e As Cancelable(Of AllowPotionsSendMessage)) Implements IConnection.SendAllowPotions
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
        RegisterStartMessages()

        'Initing Client
        Send(New InitSendMessage)
    End Sub

    Private Function GetIOConnection(ioClient As Client, id As String) As PlayerIOClient.Connection
        Try
            Return ioClient.Multiplayer.CreateJoinRoom(id, NormalRoom & myGameVersionNumber, True, Nothing, Nothing)
        Catch ex As PlayerIOError
            Throw New EECloudPlayerIOException(ex)
        End Try
    End Function

    Private Shared Sub UpdateVersion(ex As PlayerIOError)
        Dim errorMessage() As String = ex.Message.Split("["c)(1).Split(CChar(" "))
        Dim idSet As Boolean
        For N = errorMessage.Length - 1 To 0 Step -1
            Dim currentRoomType As String
            currentRoomType = errorMessage(N)
            If currentRoomType.StartsWith(NormalRoom, StringComparison.Ordinal) Then
                Dim newNum As Integer = CInt(currentRoomType.Substring(NormalRoom.Length, currentRoomType.Length - NormalRoom.Length - 1))
                If newNum > myGameVersionNumber Then
                    myGameVersionNumber = newNum
                    Cloud.Service.SetSetting(GameVersionSetting, CStr(myGameVersionNumber))
                End If

                idSet = True
            End If
        Next

        If Not idSet Then
            Throw New EECloudException(API.ErrorCode.GameVersionNotInList, "Unable to get room version")
        End If
    End Sub

    Private Function RaiseSendEvent(message As SendMessage) As Boolean
        RaiseEvent SendMessage(Me, message)
        Select Case message.GetType
            Case GetType(InitSendMessage)
                Dim eventArgs As New Cancelable(Of InitSendMessage)(CType(message, InitSendMessage))
                RaiseEvent SendInit(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(Init2SendMessage)
                Dim eventArgs As New Cancelable(Of Init2SendMessage)(CType(message, Init2SendMessage))
                RaiseEvent SendInit2(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(BlockPlaceSendMessage)
                Dim eventArgs As New Cancelable(Of BlockPlaceSendMessage)(CType(message, BlockPlaceSendMessage))
                RaiseEvent SendBlockPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(CoinDoorPlaceSendMessage)
                Dim eventArgs As New Cancelable(Of CoinDoorPlaceSendMessage)(CType(message, CoinDoorPlaceSendMessage))
                RaiseEvent SendCoindoorPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(SoundPlaceSendMessage)
                Dim eventArgs As New Cancelable(Of SoundPlaceSendMessage)(CType(message, SoundPlaceSendMessage))
                RaiseEvent SendSoundPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PortalPlaceSendMessage)
                Dim eventArgs As New Cancelable(Of PortalPlaceSendMessage)(CType(message, PortalPlaceSendMessage))
                RaiseEvent SendPortalPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(LabelPlaceSendMessage)
                Dim eventArgs As New Cancelable(Of LabelPlaceSendMessage)(CType(message, LabelPlaceSendMessage))
                RaiseEvent SendLabelPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(CoinSendMessage)
                Dim eventArgs As New Cancelable(Of CoinSendMessage)(CType(message, CoinSendMessage))
                RaiseEvent SendCoin(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressRedKeySendMessage)
                Dim eventArgs As New Cancelable(Of PressRedKeySendMessage)(CType(message, PressRedKeySendMessage))
                RaiseEvent SendPressRedKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressGreenKeySendMessage)
                Dim eventArgs As New Cancelable(Of PressGreenKeySendMessage)(CType(message, PressGreenKeySendMessage))
                RaiseEvent SendPressGreenKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressBlueKeySendMessage)
                Dim eventArgs As New Cancelable(Of PressBlueKeySendMessage)(CType(message, PressBlueKeySendMessage))
                RaiseEvent SendPressBlueKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(GetCrownSendMessage)
                Dim eventArgs As New Cancelable(Of GetCrownSendMessage)(CType(message, GetCrownSendMessage))
                RaiseEvent SendGetCrown(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(TouchDiamondSendMessage)
                Dim eventArgs As New Cancelable(Of TouchDiamondSendMessage)(CType(message, TouchDiamondSendMessage))
                RaiseEvent SendTouchDiamond(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(CompleteLevelSendMessage)
                Dim eventArgs As New Cancelable(Of CompleteLevelSendMessage)(CType(message, CompleteLevelSendMessage))
                RaiseEvent SendCompleteLevel(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(GodModeSendMessage)
                Dim eventArgs As New Cancelable(Of GodModeSendMessage)(CType(message, GodModeSendMessage))
                RaiseEvent SendGodMode(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ModModeSendMessage)
                Dim eventArgs As New Cancelable(Of ModModeSendMessage)(CType(message, ModModeSendMessage))
                RaiseEvent SendModMode(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(MoveSendMessage)
                Dim eventArgs As New Cancelable(Of MoveSendMessage)(CType(message, MoveSendMessage))
                RaiseEvent SendMove(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(SaySendMessage)
                Dim eventArgs As New Cancelable(Of SaySendMessage)(CType(message, SaySendMessage))
                RaiseEvent SendSay(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(AutoSaySendMessage)
                Dim eventArgs As New Cancelable(Of AutoSaySendMessage)(CType(message, AutoSaySendMessage))
                RaiseEvent SendAutoSay(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(AccessSendMessage)
                Dim eventArgs As New Cancelable(Of AccessSendMessage)(CType(message, AccessSendMessage))
                RaiseEvent SendAccess(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeFaceSendMessage)
                Dim eventArgs As New Cancelable(Of ChangeFaceSendMessage)(CType(message, ChangeFaceSendMessage))
                RaiseEvent SendChangeFace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(SaveWorldSendMessage)
                Dim eventArgs As New Cancelable(Of SaveWorldSendMessage)(CType(message, SaveWorldSendMessage))
                RaiseEvent SendSaveWorld(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeWorldNameSendMessage)
                Dim eventArgs As New Cancelable(Of ChangeWorldNameSendMessage)(CType(message, ChangeWorldNameSendMessage))
                RaiseEvent SendChangeWorldName(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeWorldEditKeySendMessage)
                Dim eventArgs As New Cancelable(Of ChangeWorldEditKeySendMessage)(CType(message, ChangeWorldEditKeySendMessage))
                RaiseEvent SendChangeWorldEditKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ClearWorldSendMessage)
                Dim eventArgs As New Cancelable(Of ClearWorldSendMessage)(CType(message, ClearWorldSendMessage))
                RaiseEvent SendClearWorld(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(KillWorldSendMessage)
                Dim eventArgs As New Cancelable(Of KillWorldSendMessage)(CType(message, KillWorldSendMessage))
                RaiseEvent SendKillWorld(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PotionSendMessage)
                Dim eventArgs As New Cancelable(Of PotionSendMessage)(CType(message, PotionSendMessage))
                RaiseEvent SendPotion(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(TouchCakeSendMessage)
                Dim eventArgs As New Cancelable(Of TouchCakeSendMessage)(CType(message, TouchCakeSendMessage))
                RaiseEvent SendTouchCake(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(AllowPotionsSendMessage)
                Dim eventArgs As New Cancelable(Of AllowPotionsSendMessage)(CType(message, AllowPotionsSendMessage))
                RaiseEvent SendAllowPotions(Me, eventArgs)
                Return eventArgs.Handled

            Case Else
                Return False
        End Select
    End Function

    Private myInited As Boolean

    Private Sub Connection_ReceiveMessage(sender As Object, e As ReceiveMessage) Handles Me.ReceiveMessage
        Select Case e.GetType
            Case GetType(InitReceiveMessage)
                Dim m As InitReceiveMessage = CType(e, InitReceiveMessage)
                RaiseEvent PreviewReceiveInit(Me, m)
                RegisterMessages()
                Send(New Init2SendMessage)
                RaiseEvent ReceiveInit(Me, m)

            Case GetType(GroupDisallowedJoinReceiveMessage)
                Dim m As GroupDisallowedJoinReceiveMessage = CType(e, GroupDisallowedJoinReceiveMessage)
                RaiseEvent PreviewReceiveGroupDisallowedJoin(Me, m)
                RaiseEvent ReceiveGroupDisallowedJoin(Me, m)

            Case GetType(InfoReceiveMessage)
                Dim m As InfoReceiveMessage = CType(e, InfoReceiveMessage)
                RaiseEvent PreviewReceiveInfo(Me, m)
                RaiseEvent ReceiveInfo(Me, m)

            Case GetType(UpgradeReceiveMessage)
                Dim m As UpgradeReceiveMessage = CType(e, UpgradeReceiveMessage)
                RaiseEvent PreviewReceiveUpgrade(Me, m)
                myGameVersionNumber += 1
                Cloud.Logger.Log(LogPriority.Info, "The game has been updated!")
                Cloud.Service.SetSetting("GameVersion", CStr(myGameVersionNumber))
                RaiseEvent ReceiveUpgrade(Me, m)

            Case GetType(UpdateMetaReceiveMessage)
                Dim m As UpdateMetaReceiveMessage = CType(e, UpdateMetaReceiveMessage)
                RaiseEvent PreviewReceiveUpdateMeta(Me, m)
                RaiseEvent ReceiveUpdateMeta(Me, m)

            Case GetType(AddReceiveMessage)
                Dim m As AddReceiveMessage = CType(e, AddReceiveMessage)
                RaiseEvent PreviewReceiveAdd(Me, m)
                RaiseEvent ReceiveAdd(Me, m)

            Case GetType(LeftReceiveMessage)
                Dim m As LeftReceiveMessage = CType(e, LeftReceiveMessage)
                RaiseEvent PreviewReceiveLeft(Me, m)
                RaiseEvent ReceiveLeft(Me, m)

            Case GetType(MoveReceiveMessage)
                Dim m As MoveReceiveMessage = CType(e, MoveReceiveMessage)
                RaiseEvent PreviewReceiveMove(Me, m)
                RaiseEvent ReceiveMove(Me, m)

            Case GetType(CoinReceiveMessage)
                Dim m As CoinReceiveMessage = CType(e, CoinReceiveMessage)
                RaiseEvent PreviewReceiveCoin(Me, m)
                RaiseEvent ReceiveCoin(Me, m)

            Case GetType(CrownReceiveMessage)
                Dim m As CrownReceiveMessage = CType(e, CrownReceiveMessage)
                RaiseEvent PreviewReceiveCrown(Me, m)
                RaiseEvent ReceiveCrown(Me, m)
                If Not myInited Then
                    myInited = True
                    RaiseEvent InitComplete(Me, EventArgs.Empty)
                End If

            Case GetType(SilverCrownReceiveMessage)
                Dim m As SilverCrownReceiveMessage = CType(e, SilverCrownReceiveMessage)
                RaiseEvent PreviewReceiveSilverCrown(Me, m)
                RaiseEvent ReceiveSilverCrown(Me, m)

            Case GetType(FaceReceiveMessage)
                Dim m As FaceReceiveMessage = CType(e, FaceReceiveMessage)
                RaiseEvent PreviewReceiveFace(Me, m)
                RaiseEvent ReceiveFace(Me, m)

            Case GetType(ShowKeyReceiveMessage)
                Dim m As ShowKeyReceiveMessage = CType(e, ShowKeyReceiveMessage)
                RaiseEvent PreviewReceiveShowKey(Me, m)
                RaiseEvent ReceiveShowKey(Me, m)

            Case GetType(HideKeyReceiveMessage)
                Dim m As HideKeyReceiveMessage = CType(e, HideKeyReceiveMessage)
                RaiseEvent PreviewReceiveHideKey(Me, m)
                RaiseEvent ReceiveHideKey(Me, m)

            Case GetType(SayReceiveMessage)
                Dim m As SayReceiveMessage = CType(e, SayReceiveMessage)
                RaiseEvent PreviewReceiveSay(Me, m)
                RaiseEvent ReceiveSay(Me, m)

            Case GetType(SayOldReceiveMessage)
                Dim m As SayOldReceiveMessage = CType(e, SayOldReceiveMessage)
                RaiseEvent PreviewReceiveSayOld(Me, m)
                RaiseEvent ReceiveSayOld(Me, m)

            Case GetType(AutoTextReceiveMessage)
                Dim m As AutoTextReceiveMessage = CType(e, AutoTextReceiveMessage)
                RaiseEvent PreviewReceiveAutoText(Me, m)
                RaiseEvent ReceiveAutoText(Me, m)

            Case GetType(WriteReceiveMessage)
                Dim m As WriteReceiveMessage = CType(e, WriteReceiveMessage)
                RaiseEvent PreviewReceiveWrite(Me, m)
                RaiseEvent ReceiveWrite(Me, m)

            Case GetType(PotionReceiveMessage)
                Dim m As PotionReceiveMessage = CType(e, PotionReceiveMessage)
                RaiseEvent PreviewReceivePotion(Me, m)
                RaiseEvent ReceivePotion(Me, m)

            Case GetType(BlockPlaceReceiveMessage)
                Dim m As BlockPlaceReceiveMessage = CType(e, BlockPlaceReceiveMessage)
                RaiseEvent PreviewReceiveBlockPlace(Me, m)
                RaiseEvent ReceiveBlockPlace(Me, m)

            Case GetType(CoinDoorPlaceReceiveMessage)
                Dim m As CoinDoorPlaceReceiveMessage = CType(e, CoinDoorPlaceReceiveMessage)
                RaiseEvent PreviewReceiveCoinDoorPlace(Me, m)
                RaiseEvent ReceiveCoinDoorPlace(Me, m)

            Case GetType(SoundPlaceReceiveMessage)
                Dim m As SoundPlaceReceiveMessage = CType(e, SoundPlaceReceiveMessage)
                RaiseEvent PreviewReceiveSoundPlace(Me, m)
                RaiseEvent ReceiveSoundPlace(Me, m)

            Case GetType(PortalPlaceReceiveMessage)
                Dim m As PortalPlaceReceiveMessage = CType(e, PortalPlaceReceiveMessage)
                RaiseEvent PreviewReceivePortalPlace(Me, m)
                RaiseEvent ReceivePortalPlace(Me, m)

            Case GetType(LabelPlaceReceiveMessage)
                Dim m As LabelPlaceReceiveMessage = CType(e, LabelPlaceReceiveMessage)
                RaiseEvent PreviewReceiveLabelPlace(Me, m)
                RaiseEvent ReceiveLabelPlace(Me, m)

            Case GetType(GodModeReceiveMessage)
                Dim m As GodModeReceiveMessage = CType(e, GodModeReceiveMessage)
                RaiseEvent PreviewReceiveGodMode(Me, m)
                RaiseEvent ReceiveGodMode(Me, m)

            Case GetType(ModModeReceiveMessage)
                Dim m As ModModeReceiveMessage = CType(e, ModModeReceiveMessage)
                RaiseEvent PreviewReceiveModMode(Me, m)
                RaiseEvent ReceiveModMode(Me, m)

            Case GetType(AccessReceiveMessage)
                Dim m As AccessReceiveMessage = CType(e, AccessReceiveMessage)
                RaiseEvent PreviewReceiveAccess(Me, m)
                RaiseEvent ReceiveAccess(Me, m)

            Case GetType(LostAccessReceiveMessage)
                Dim m As LostAccessReceiveMessage = CType(e, LostAccessReceiveMessage)
                RaiseEvent PreviewReceiveLostAccess(Me, m)
                RaiseEvent ReceiveLostAccess(Me, m)

            Case GetType(TeleportReceiveMessage)
                Dim m As TeleportReceiveMessage = CType(e, TeleportReceiveMessage)
                RaiseEvent PreviewReceiveTeleport(Me, m)
                RaiseEvent ReceiveTeleport(Me, m)

            Case GetType(ResetReceiveMessage)
                Dim m As ResetReceiveMessage = CType(e, ResetReceiveMessage)
                RaiseEvent PreviewReceiveReset(Me, m)
                RaiseEvent ReceiveReset(Me, m)

            Case GetType(ClearReceiveMessage)
                Dim m As ClearReceiveMessage = CType(e, ClearReceiveMessage)
                RaiseEvent PreviewReceiveClear(Me, m)
                RaiseEvent ReceiveClear(Me, m)

            Case GetType(SaveDoneReceiveMessage)
                Dim m As SaveDoneReceiveMessage = CType(e, SaveDoneReceiveMessage)
                RaiseEvent PreviewReceiveSaveDone(Me, m)
                RaiseEvent ReceiveSaveDone(Me, m)

            Case GetType(RefreshShopReceiveMessage)
                Dim m As RefreshShopReceiveMessage = CType(e, RefreshShopReceiveMessage)
                RaiseEvent PreviewReceiveRefreshShop(Me, m)
                RaiseEvent ReceiveRefreshShop(Me, m)

            Case GetType(GiveWizardReceiveMessage)
                Dim m As GiveWizardReceiveMessage = CType(e, GiveWizardReceiveMessage)
                RaiseEvent PreviewReceiveGiveWizard(Me, m)
                RaiseEvent ReceiveGiveWizard(Me, m)

            Case GetType(GiveFireWizardReceiveMessage)
                Dim m As GiveFireWizardReceiveMessage = CType(e, GiveFireWizardReceiveMessage)
                RaiseEvent PreviewReceiveGiveFireWizard(Me, m)
                RaiseEvent ReceiveGiveFireWizard(Me, m)

            Case GetType(GiveWitchReceiveMessage)
                Dim m As GiveWitchReceiveMessage = CType(e, GiveWitchReceiveMessage)
                RaiseEvent PreviewReceiveGiveWitch(Me, m)
                RaiseEvent ReceiveGiveWitch(Me, m)

            Case GetType(GiveGrinchReceiveMessage)
                Dim m As GiveGrinchReceiveMessage = CType(e, GiveGrinchReceiveMessage)
                RaiseEvent PreviewReceiveGiveGrinch(Me, m)
                RaiseEvent ReceiveGiveGrinch(Me, m)

            Case GetType(AllowPotionsReceiveMessage)
                Dim m As AllowPotionsReceiveMessage = CType(e, AllowPotionsReceiveMessage)
                RaiseEvent PreviewReceiveAllowPotions(Me, m)
                RaiseEvent ReceiveAllowPotions(Me, m)
        End Select
    End Sub

    Private Sub myConnection_OnDisconnect(sender As Object, message As String) Handles myConnection.OnDisconnect
        UnRegisterAll()
        RaiseEvent Disconnect(Me, New DisconnectEventArgs(myExpectingDisconnect))
        myExpectingDisconnect = False
    End Sub

    Private Sub myConnection_OnMessage(sender As Object, m As Message) Handles myConnection.OnMessage
        Try
            If myMessageDictionary.ContainsKey(m.Type) Then
                Dim messageType As Type = myMessageDictionary(m.Type)
                Dim constructorInfo As ConstructorInfo = messageType.GetConstructor(BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, New Type() {GetType(Message)}, Nothing)
                Dim message As ReceiveMessage = CType(constructorInfo.Invoke(New Object() {m}), ReceiveMessage)
                RaiseEvent ReceiveMessage(Me, message)
            Else
                Dim messageArguments As New List(Of String)
                For n As UInteger = 0 To CType(m.Count - 1, UInteger)
                    messageArguments.Add("   [" & m.Item(n).GetType.Name & "] " & CType(m.Item(n), String))
                Next

                Cloud.Logger.Log(LogPriority.Warning, "Received unregistered message: " & """" & m.Type & """" & vbCrLf & _
                                 "(Arguments: {" & vbCrLf & _
                                 String.Join(vbCrLf, messageArguments) & vbCrLf & _
                                 "})")
            End If
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to parse message: """ & m.Type & """")
            Cloud.Logger.LogEx(ex)
        End Try
    End Sub

#Region "IConnection Support"

    Private myRunConnect As Boolean

    Friend Async Function ConnectAsync(type As AccountType, username As String, password As String, id As String) As Task Implements IConnection.ConnectAsync
        SyncLock myLockObj
            If Not myRunConnect Then
                myRunConnect = True
            Else
                Throw New Exception("A connection has been already established")
            End If
        End SyncLock

        Await Task.Run(
           Sub()
               Try
                   Dim ioClient As Client = Nothing
                   Select Case type
                       Case AccountType.Regular
                           ioClient = PlayerIO.QuickConnect.SimpleConnect(GameID, username, password)
                       Case AccountType.Facebook
                           ioClient = PlayerIO.QuickConnect.FacebookOAuthConnect(GameID, username, "")
                   End Select

                   Dim ioConnection As PlayerIOClient.Connection = GetIOConnection(ioClient, id)
                   SetupConnection(ioConnection, id)
               Catch ex As PlayerIOError
                   Throw New EECloudPlayerIOException(ex)
               End Try
           End Sub)
    End Function

    Friend Sub Send(message As SendMessage) Implements IConnection.Send
        If Connected Then
            If Not RaiseSendEvent(message) Then
                myConnection.Send(message.GetMessage(myClient.Game))
            End If
        End If
    End Sub

    Friend Sub Close() Implements IConnection.Close
        SyncLock myLockObj
            If Connected Then
                RaiseEvent Disconnecting(Me, EventArgs.Empty)
                myConnection.Disconnect()
            End If
        End SyncLock
    End Sub

#End Region

#Region "Message Register"
    Private myRegisteredStartMessages As Boolean
    Private myRegisteredMessages As Boolean

    Private Sub RegisterStartMessages()
        SyncLock myLockObj
            If myRegisteredStartMessages = False Then
                myRegisteredStartMessages = True
                RegisterMessage("groupdisallowedjoin", GetType(GroupDisallowedJoinReceiveMessage))
                RegisterMessage("info", GetType(InfoReceiveMessage))
                RegisterMessage("upgrade", GetType(UpgradeReceiveMessage))
                RegisterMessage("init", GetType(InitReceiveMessage))
                RegisterMessage("show", GetType(ShowKeyReceiveMessage))
                RegisterMessage("hide", GetType(HideKeyReceiveMessage))
                RegisterMessage("updatemeta", GetType(UpdateMetaReceiveMessage))
            End If
        End SyncLock
    End Sub

    Private Sub RegisterMessages()
        SyncLock myLockObj
            If myRegisteredMessages = False Then
                myRegisteredMessages = True
                UnRegisterMessage("init")
                UnRegisterMessage("groupdisallowedjoin")

                RegisterMessage("add", GetType(AddReceiveMessage))
                RegisterMessage("left", GetType(LeftReceiveMessage))
                RegisterMessage("m", GetType(MoveReceiveMessage))
                RegisterMessage("c", GetType(CoinReceiveMessage))
                RegisterMessage("k", GetType(CrownReceiveMessage))
                RegisterMessage("ks", GetType(SilverCrownReceiveMessage))
                RegisterMessage("face", GetType(FaceReceiveMessage))
                RegisterMessage("say", GetType(SayReceiveMessage))
                RegisterMessage("say_old", GetType(SayOldReceiveMessage))
                RegisterMessage("autotext", GetType(AutoTextReceiveMessage))
                RegisterMessage("write", GetType(WriteReceiveMessage))
                RegisterMessage("p", GetType(PotionReceiveMessage))
                RegisterMessage("b", GetType(BlockPlaceReceiveMessage))
                RegisterMessage("bc", GetType(CoinDoorPlaceReceiveMessage))
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
                RegisterMessage("allowpotions", GetType(AllowPotionsReceiveMessage))
            End If
        End SyncLock
    End Sub

    Private Sub RegisterMessage(str As String, type As Type)
        Try
            If Not type.IsSubclassOf(GetType(ReceiveMessage)) Then
                Throw New InvalidOperationException("Invalid Value class! Must inherit " & GetType(ReceiveMessage).ToString)
            Else
                myMessageDictionary.Add(str, type)
            End If
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to register Value: " & str)
        End Try
    End Sub

    Private Sub UnRegisterMessage(pString As String)
        Try
            myMessageDictionary.Remove(pString)
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to unregister Value: " & pString)
        End Try
    End Sub

    Private Sub UnRegisterAll()
        myRegisteredMessages = False
        myMessageDictionary.Clear()
    End Sub

#End Region
#End Region
End Class