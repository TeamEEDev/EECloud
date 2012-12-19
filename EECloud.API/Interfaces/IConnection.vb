﻿Public Interface IConnection
    Event InitComplete As EventHandler
    Event ReceiveMessage As EventHandler(Of ReceiveMessage)
    Event Disconnecting As EventHandler(Of EventArgs)
    Event Disconnect As EventHandler(Of DisconnectEventArgs)
    Event ReceiveAccess As EventHandler(Of AccessReceiveMessage)
    Event ReceiveAdd As EventHandler(Of AddReceiveMessage)
    Event ReceiveAutoText As EventHandler(Of AutoTextReceiveMessage)
    Event ReceiveBlockPlace As EventHandler(Of BlockPlaceReceiveMessage)
    Event ReceiveClear As EventHandler(Of ClearReceiveMessage)
    Event ReceiveCoin As EventHandler(Of CoinReceiveMessage)
    Event ReceiveCoinDoorPlace As EventHandler(Of CoinDoorPlaceReceiveMessage)
    Event ReceiveCrown As EventHandler(Of CrownReceiveMessage)
    Event ReceiveFace As EventHandler(Of FaceReceiveMessage)
    Event ReceiveGiveFireWizard As EventHandler(Of GiveFireWizardReceiveMessage)
    Event ReceiveGiveGrinch As EventHandler(Of GiveGrinchReceiveMessage)
    Event ReceiveGiveWitch As EventHandler(Of GiveWitchReceiveMessage)
    Event ReceiveGiveWizard As EventHandler(Of GiveWizardReceiveMessage)
    Event ReceiveGodMode As EventHandler(Of GodModeReceiveMessage)
    Event ReceiveGroupDisallowedJoin As EventHandler(Of GroupDisallowedJoinReceiveMessage)
    Event ReceiveHideKey As EventHandler(Of HideKeyReceiveMessage)
    Event ReceiveInfo As EventHandler(Of InfoReceiveMessage)
    Event ReceiveInit As EventHandler(Of InitReceiveMessage)
    Event ReceivePotion As EventHandler(Of PotionReceiveMessage)
    Event ReceiveLabelPlace As EventHandler(Of LabelPlaceReceiveMessage)
    Event ReceiveLeft As EventHandler(Of LeftReceiveMessage)
    Event ReceiveLostAccess As EventHandler(Of LostAccessReceiveMessage)
    Event ReceiveModMode As EventHandler(Of ModModeReceiveMessage)
    Event ReceiveMove As EventHandler(Of MoveReceiveMessage)
    Event ReceivePortalPlace As EventHandler(Of PortalPlaceReceiveMessage)
    Event ReceiveRefreshShop As EventHandler(Of RefreshShopReceiveMessage)
    Event ReceiveReset As EventHandler(Of ResetReceiveMessage)
    Event ReceiveSaveDone As EventHandler(Of SaveDoneReceiveMessage)
    Event ReceiveSay As EventHandler(Of SayReceiveMessage)
    Event ReceiveSayOld As EventHandler(Of SayOldReceiveMessage)
    Event ReceiveShowKey As EventHandler(Of ShowKeyReceiveMessage)
    Event ReceiveSilverCrown As EventHandler(Of SilverCrownReceiveMessage)
    Event ReceiveSoundPlace As EventHandler(Of SoundPlaceReceiveMessage)
    Event ReceiveTeleport As EventHandler(Of TeleportReceiveMessage)
    Event ReceiveUpdateMeta As EventHandler(Of UpdateMetaReceiveMessage)
    Event ReceiveUpgrade As EventHandler(Of UpgradeReceiveMessage)
    Event ReceiveWrite As EventHandler(Of WriteReceiveMessage)
    Event ReceiveAllowPotions As EventHandler(Of AllowPotionsReceiveMessage)
    Event ReceiveMagic As EventHandler(Of MagicRecieveMessage)
    Event ReceiveLevelup As EventHandler(Of LevelupRecieveMessage)
    Event ReceiveWootUp As EventHandler(Of WootUpReceiveMessage)
    Event PreviewReceiveMessage As EventHandler(Of ReceiveMessage)
    Event PreviewDisconnecting As EventHandler(Of EventArgs)
    Event PreviewDisconnect As EventHandler(Of DisconnectEventArgs)
    Event PreviewReceiveAccess As EventHandler(Of AccessReceiveMessage)
    Event PreviewReceiveAdd As EventHandler(Of AddReceiveMessage)
    Event PreviewReceiveAutoText As EventHandler(Of AutoTextReceiveMessage)
    Event PreviewReceiveBlockPlace As EventHandler(Of BlockPlaceReceiveMessage)
    Event PreviewReceiveClear As EventHandler(Of ClearReceiveMessage)
    Event PreviewReceiveCoin As EventHandler(Of CoinReceiveMessage)
    Event PreviewReceiveCoinDoorPlace As EventHandler(Of CoinDoorPlaceReceiveMessage)
    Event PreviewReceiveCrown As EventHandler(Of CrownReceiveMessage)
    Event PreviewReceiveFace As EventHandler(Of FaceReceiveMessage)
    Event PreviewReceiveGiveFireWizard As EventHandler(Of GiveFireWizardReceiveMessage)
    Event PreviewReceiveGiveGrinch As EventHandler(Of GiveGrinchReceiveMessage)
    Event PreviewReceiveGiveWitch As EventHandler(Of GiveWitchReceiveMessage)
    Event PreviewReceiveGiveWizard As EventHandler(Of GiveWizardReceiveMessage)
    Event PreviewReceiveGodMode As EventHandler(Of GodModeReceiveMessage)
    Event PreviewReceiveGroupDisallowedJoin As EventHandler(Of GroupDisallowedJoinReceiveMessage)
    Event PreviewReceiveHideKey As EventHandler(Of HideKeyReceiveMessage)
    Event PreviewReceiveInfo As EventHandler(Of InfoReceiveMessage)
    Event PreviewReceiveInit As EventHandler(Of InitReceiveMessage)
    Event PreviewReceivePotion As EventHandler(Of PotionReceiveMessage)
    Event PreviewReceiveLabelPlace As EventHandler(Of LabelPlaceReceiveMessage)
    Event PreviewReceiveLeft As EventHandler(Of LeftReceiveMessage)
    Event PreviewReceiveLostAccess As EventHandler(Of LostAccessReceiveMessage)
    Event PreviewReceiveModMode As EventHandler(Of ModModeReceiveMessage)
    Event PreviewReceiveMove As EventHandler(Of MoveReceiveMessage)
    Event PreviewReceivePortalPlace As EventHandler(Of PortalPlaceReceiveMessage)
    Event PreviewReceiveRefreshShop As EventHandler(Of RefreshShopReceiveMessage)
    Event PreviewReceiveReset As EventHandler(Of ResetReceiveMessage)
    Event PreviewReceiveSaveDone As EventHandler(Of SaveDoneReceiveMessage)
    Event PreviewReceiveSay As EventHandler(Of SayReceiveMessage)
    Event PreviewReceiveSayOld As EventHandler(Of SayOldReceiveMessage)
    Event PreviewReceiveShowKey As EventHandler(Of ShowKeyReceiveMessage)
    Event PreviewReceiveSilverCrown As EventHandler(Of SilverCrownReceiveMessage)
    Event PreviewReceiveSoundPlace As EventHandler(Of SoundPlaceReceiveMessage)
    Event PreviewReceiveTeleport As EventHandler(Of TeleportReceiveMessage)
    Event PreviewReceiveUpdateMeta As EventHandler(Of UpdateMetaReceiveMessage)
    Event PreviewReceiveUpgrade As EventHandler(Of UpgradeReceiveMessage)
    Event PreviewReceiveWrite As EventHandler(Of WriteReceiveMessage)
    Event PreviewReceiveAllowPotions As EventHandler(Of AllowPotionsReceiveMessage)
    Event PreviewReceiveMagic As EventHandler(Of MagicRecieveMessage)
    Event PreviewReceiveLevelup As EventHandler(Of LevelupRecieveMessage)
    Event PreviewReceiveWootUp As EventHandler(Of WootUpReceiveMessage)
    Event SendMessage As EventHandler(Of SendMessage)
    Event SendInit As EventHandler(Of Cancelable(Of InitSendMessage))
    Event SendInit2 As EventHandler(Of Cancelable(Of Init2SendMessage))
    Event SendBlockPlace As EventHandler(Of Cancelable(Of BlockPlaceSendMessage))
    Event SendCoindoorPlace As EventHandler(Of Cancelable(Of CoinDoorPlaceSendMessage))
    Event SendSoundPlace As EventHandler(Of Cancelable(Of SoundPlaceSendMessage))
    Event SendPortalPlace As EventHandler(Of Cancelable(Of PortalPlaceSendMessage))
    Event SendLabelPlace As EventHandler(Of Cancelable(Of LabelPlaceSendMessage))
    Event SendCoin As EventHandler(Of Cancelable(Of CoinSendMessage))
    Event SendPressRedKey As EventHandler(Of Cancelable(Of PressRedKeySendMessage))
    Event SendPressGreenKey As EventHandler(Of Cancelable(Of PressGreenKeySendMessage))
    Event SendPressBlueKey As EventHandler(Of Cancelable(Of PressBlueKeySendMessage))
    Event SendGetCrown As EventHandler(Of Cancelable(Of GetCrownSendMessage))
    Event SendTouchDiamond As EventHandler(Of Cancelable(Of TouchDiamondSendMessage))
    Event SendTouchCake As EventHandler(Of Cancelable(Of TouchCakeSendMessage))
    Event SendCompleteLevel As EventHandler(Of Cancelable(Of CompleteLevelSendMessage))
    Event SendGodMode As EventHandler(Of Cancelable(Of GodModeSendMessage))
    Event SendModMode As EventHandler(Of Cancelable(Of ModModeSendMessage))
    Event SendMove As EventHandler(Of Cancelable(Of MoveSendMessage))
    Event SendSay As EventHandler(Of Cancelable(Of SaySendMessage))
    Event SendAutoSay As EventHandler(Of Cancelable(Of AutoSaySendMessage))
    Event SendAccess As EventHandler(Of Cancelable(Of AccessSendMessage))
    Event SendChangeFace As EventHandler(Of Cancelable(Of ChangeFaceSendMessage))
    Event SendSaveWorld As EventHandler(Of Cancelable(Of SaveWorldSendMessage))
    Event SendChangeWorldName As EventHandler(Of Cancelable(Of ChangeWorldNameSendMessage))
    Event SendChangeWorldEditKey As EventHandler(Of Cancelable(Of ChangeWorldEditKeySendMessage))
    Event SendClearWorld As EventHandler(Of Cancelable(Of ClearWorldSendMessage))
    Event SendKillWorld As EventHandler(Of Cancelable(Of KillWorldSendMessage))
    Event SendPotion As EventHandler(Of Cancelable(Of PotionSendMessage))
    Event SendAllowPotions As EventHandler(Of Cancelable(Of AllowPotionsSendMessage))
    Event SendWootUp As EventHandler(Of Cancelable(Of WootUpSendMessage))
    Event UploadBlockPlace As EventHandler(Of Cancelable(Of BlockPlaceUploadMessage))
    Event UploadCoindoorPlace As EventHandler(Of Cancelable(Of CoinDoorPlaceUploadMessage))
    Event UploadSoundPlace As EventHandler(Of Cancelable(Of SoundPlaceUploadMessage))
    Event UploadPortalPlace As EventHandler(Of Cancelable(Of PortalPlaceUploadMessage))
    Event UploadLabelPlace As EventHandler(Of Cancelable(Of LabelPlaceUploadMessage))

    ''' <summary>
    '''     The world id
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property WorldID As String
    
    ''' <summary>
    '''     Returns true if the connection is still active
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Connected As Boolean
    
    ''' <summary>
    '''     Connects using the given data
    ''' </summary>
    ''' <param name="type">AccountType we are using to login</param>
    ''' <param name="username">Username, Email or Token</param>
    ''' <param name="password">Password</param>
    ''' <param name="id">WorldID we are entering</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ConnectAsync(type As AccountType, username As String, password As String, id As String) As Task
    
    ''' <summary>
    '''     Sends the given message
    ''' </summary>
    ''' <param name="message">The message being sent</param>
    ''' <remarks></remarks>
    Sub Send(message As SendMessage)
    
    ''' <summary>
    '''     Terminates the connection
    ''' </summary>
    ''' <remarks></remarks>
    Sub Close()
End Interface
