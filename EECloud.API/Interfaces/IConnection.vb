﻿Public Interface IConnection(Of P As {Player, New})
    Inherits IConnectionBase

    Event OnReceiveMessage As EventHandler(Of ReceiveMessage)
    Event OnDisconnect As EventHandler(Of EventArgs)
    Event OnReceiveAccess As EventHandler(Of Access_ReceiveMessage)
    Event OnReceiveAdd As EventHandler(Of Add_ReceiveMessage)
    Event OnReceiveAutoText As EventHandler(Of AutoText_ReceiveMessage)
    Event OnReceiveBlockPlace As EventHandler(Of BlockPlace_ReceiveMessage)
    Event OnReceiveClear As EventHandler(Of Clear_ReceiveMessage)
    Event OnReceiveCoin As EventHandler(Of Coin_ReceiveMessage)
    Event OnReceiveCoinDoorPlace As EventHandler(Of CoinDoorPlace_ReceiveMessage)
    Event OnReceiveCrown As EventHandler(Of Crown_ReceiveMessage)
    Event OnReceiveFace As EventHandler(Of Face_ReceiveMessage)
    Event OnReceiveGiveFireWizard As EventHandler(Of GiveFireWizard_ReceiveMessage)
    Event OnReceiveGiveGrinch As EventHandler(Of GiveGrinch_ReceiveMessage)
    Event OnReceiveGiveWitch As EventHandler(Of GiveWitch_ReceiveMessage)
    Event OnReceiveGiveWizard As EventHandler(Of GiveWizard_ReceiveMessage)
    Event OnReceiveGodMode As EventHandler(Of GodMode_ReceiveMessage)
    Event OnReceiveGroupDisallowedJoin As EventHandler(Of GroupDisallowedJoin_ReceiveMessage)
    Event OnReceiveHideKey As EventHandler(Of HideKey_ReceiveMessage)
    Event OnReceiveInfo As EventHandler(Of Info_ReceiveMessage)
    Event OnReceiveInit As EventHandler(Of Init_ReceiveMessage)
    Event OnReceiveLabelPlace As EventHandler(Of LabelPlace_ReceiveMessage)
    Event OnReceiveLeft As EventHandler(Of Left_ReceiveMessage)
    Event OnReceiveLostAccess As EventHandler(Of LostAccess_ReceiveMessage)
    Event OnReceiveModMode As EventHandler(Of ModMode_ReceiveMessage)
    Event OnReceiveMove As EventHandler(Of Move_ReceiveMessage)
    Event OnReceivePortalPlace As EventHandler(Of PortalPlace_ReceiveMessage)
    Event OnReceiveRefreshShop As EventHandler(Of RefreshShop_ReceiveMessage)
    Event OnReceiveReset As EventHandler(Of Reset_ReceiveMessage)
    Event OnReceiveSaveDone As EventHandler(Of SaveDone_ReceiveMessage)
    Event OnReceiveSay As EventHandler(Of Say_ReceiveMessage)
    Event OnReceiveSayOld As EventHandler(Of SayOld_ReceiveMessage)
    Event OnReceiveShowKey As EventHandler(Of ShowKey_ReceiveMessage)
    Event OnReceiveSilverCrown As EventHandler(Of SilverCrown_ReceiveMessage)
    Event OnReceiveSoundPlace As EventHandler(Of SoundPlace_ReceiveMessage)
    Event OnReceiveTeleport As EventHandler(Of Teleport_ReceiveMessage)
    Event OnReceiveUpdateMeta As EventHandler(Of UpdateMeta_ReceiveMessage)
    Event OnReceiveUpgrade As EventHandler(Of Upgrade_ReceiveMessage)
    Event OnReceiveWrite As EventHandler(Of Write_ReceiveMessage)
    Event OnSendMessage As EventHandler(Of SendMessage)
    Event OnSendInit As EventHandler(Of SendEventArgs(Of Init_SendMessage))
    Event OnSendInit2 As EventHandler(Of SendEventArgs(Of Init2_SendMessage))
    Event OnSendBlockPlace As EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage))
    Event OnSendCoindoorPlace As EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage))
    Event OnSendSoundPlace As EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage))
    Event OnSendPortalPlace As EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage))
    Event OnSendLabelPlace As EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage))
    Event OnSendCoin As EventHandler(Of SendEventArgs(Of Coin_SendMessage))
    Event OnSendPressRedKey As EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage))
    Event OnSendPressGreenKey As EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage))
    Event OnSendPressBlueKey As EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage))
    Event OnSendGetCrown As EventHandler(Of SendEventArgs(Of GetCrown_SendMessage))
    Event OnSendTouchDiamond As EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage))
    Event OnSendCompleteLevel As EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage))
    Event OnSendGodMode As EventHandler(Of SendEventArgs(Of GodMode_SendMessage))
    Event OnSendModMode As EventHandler(Of SendEventArgs(Of ModMode_SendMessage))
    Event OnSendMove As EventHandler(Of SendEventArgs(Of Move_SendMessage))
    Event OnSendSay As EventHandler(Of SendEventArgs(Of Say_SendMessage))
    Event OnSendAutoSay As EventHandler(Of SendEventArgs(Of AutoSay_SendMessage))
    Event OnSendAccess As EventHandler(Of SendEventArgs(Of Access_SendMessage))
    Event OnSendChangeFace As EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage))
    Event OnSendSaveWorld As EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage))
    Event OnSendChangeWorldName As EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage))
    Event OnSendChangeWorldEditKey As EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage))
    Event OnSendClearWorld As EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage))
    Event OnSendKillWorld As EventHandler(Of SendEventArgs(Of KillWorld_SendMessage))

    ReadOnly Property WorldID As String
    ReadOnly Property World As World
    ReadOnly Property IsMainConnection As Boolean
    ReadOnly Property Connected As Boolean
    ReadOnly Property Encryption As String
    ReadOnly Property GetChatter(name As String) As IChatter

    Sub Send(message As SendMessage)
    ReadOnly Property Players(number As Integer) As P
    ReadOnly Property Players As IEnumerable(Of P)
    ReadOnly Property Crown As P

    Sub Disconnect()
End Interface
