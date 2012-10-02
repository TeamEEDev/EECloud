Friend MustInherit Class ConnectionBase(Of TPlayer As {Player, New})
    Implements IConnection(Of TPlayer)

#Region "Fields"
    Protected WithEvents InternalConnection As InternalConnection
    Private ReadOnly myEvents As New EventHandlerList
#End Region

#Region "Events"

    Friend Custom Event OnReceiveMessage As EventHandler(Of ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveMessage
        AddHandler(value As EventHandler(Of ReceiveMessage))
            myEvents.Add("OnReceiveMessage", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ReceiveMessage))
            myEvents.Remove("OnReceiveMessage", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ReceiveMessage) = CType(myEvents("OnReceiveMessage"), EventHandler(Of ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveMessage", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnDisconnect As EventHandler(Of EventArgs) Implements IConnection(Of TPlayer).OnDisconnect
        AddHandler(value As EventHandler(Of EventArgs))
            myEvents.Add("OnDisconnect", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of EventArgs))
            myEvents.Remove("OnDisconnect", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As EventArgs)
            Try
                Dim eevent As EventHandler(Of EventArgs) = CType(myEvents("OnDisconnect"), EventHandler(Of EventArgs))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnDisconnect", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveAccess As EventHandler(Of AccessReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveAccess
        AddHandler(value As EventHandler(Of AccessReceiveMessage))
            myEvents.Add("OnReceiveAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of AccessReceiveMessage))
            myEvents.Remove("OnReceiveAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As AccessReceiveMessage)
            Try
                Dim eevent As EventHandler(Of AccessReceiveMessage) = CType(myEvents("OnReceiveAccess"), EventHandler(Of AccessReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveAdd As EventHandler(Of AddReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveAdd
        AddHandler(value As EventHandler(Of AddReceiveMessage))
            myEvents.Add("OnReceiveAdd", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of AddReceiveMessage))
            myEvents.Remove("OnReceiveAdd", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As AddReceiveMessage)
            Try
                Dim eevent As EventHandler(Of AddReceiveMessage) = CType(myEvents("OnReceiveAdd"), EventHandler(Of AddReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveAdd", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveAutoText As EventHandler(Of AutoTextReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveAutoText
        AddHandler(value As EventHandler(Of AutoTextReceiveMessage))
            myEvents.Add("OnReceiveAutoText", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of AutoTextReceiveMessage))
            myEvents.Remove("OnReceiveAutoText", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As AutoTextReceiveMessage)
            Try
                Dim eevent As EventHandler(Of AutoTextReceiveMessage) = CType(myEvents("OnReceiveAutoText"), EventHandler(Of AutoTextReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveAutoText", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveBlockPlace As EventHandler(Of BlockPlaceReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveBlockPlace
        AddHandler(value As EventHandler(Of BlockPlaceReceiveMessage))
            myEvents.Add("OnReceiveBlockPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of BlockPlaceReceiveMessage))
            myEvents.Remove("OnReceiveBlockPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As BlockPlaceReceiveMessage)
            Try
                Dim eevent As EventHandler(Of BlockPlaceReceiveMessage) = CType(myEvents("OnReceiveBlockPlace"), EventHandler(Of BlockPlaceReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveBlockPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveClear As EventHandler(Of ClearReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveClear
        AddHandler(value As EventHandler(Of ClearReceiveMessage))
            myEvents.Add("OnReceiveClear", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ClearReceiveMessage))
            myEvents.Remove("OnReceiveClear", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ClearReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ClearReceiveMessage) = CType(myEvents("OnReceiveClear"), EventHandler(Of ClearReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveClear", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveCoin As EventHandler(Of CoinReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveCoin
        AddHandler(value As EventHandler(Of CoinReceiveMessage))
            myEvents.Add("OnReceiveCoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of CoinReceiveMessage))
            myEvents.Remove("OnReceiveCoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As CoinReceiveMessage)
            Try
                Dim eevent As EventHandler(Of CoinReceiveMessage) = CType(myEvents("OnReceiveCoin"), EventHandler(Of CoinReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveCoin", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveCoinDoorPlace As EventHandler(Of CoinDoorPlace_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveCoinDoorPlace
        AddHandler(value As EventHandler(Of CoinDoorPlace_ReceiveMessage))
            myEvents.Add("OnReceiveCoinDoorPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of CoinDoorPlace_ReceiveMessage))
            myEvents.Remove("OnReceiveCoinDoorPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As CoinDoorPlace_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of CoinDoorPlace_ReceiveMessage) = CType(myEvents("OnReceiveCoinDoorPlace"), EventHandler(Of CoinDoorPlace_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveCoinDoorPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveCrown As EventHandler(Of CrownReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveCrown
        AddHandler(value As EventHandler(Of CrownReceiveMessage))
            myEvents.Add("OnReceiveCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of CrownReceiveMessage))
            myEvents.Remove("OnReceiveCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As CrownReceiveMessage)
            Try
                Dim eevent As EventHandler(Of CrownReceiveMessage) = CType(myEvents("OnReceiveCrown"), EventHandler(Of CrownReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveFace As EventHandler(Of FaceReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveFace
        AddHandler(value As EventHandler(Of FaceReceiveMessage))
            myEvents.Add("OnReceiveFace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of FaceReceiveMessage))
            myEvents.Remove("OnReceiveFace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As FaceReceiveMessage)
            Try
                Dim eevent As EventHandler(Of FaceReceiveMessage) = CType(myEvents("OnReceiveFace"), EventHandler(Of FaceReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveFace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGiveFireWizard As EventHandler(Of GiveFireWizardReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGiveFireWizard
        AddHandler(value As EventHandler(Of GiveFireWizardReceiveMessage))
            myEvents.Add("OnReceiveGiveFireWizard", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveFireWizardReceiveMessage))
            myEvents.Remove("OnReceiveGiveFireWizard", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveFireWizardReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveFireWizardReceiveMessage) = CType(myEvents("OnReceiveGiveFireWizard"), EventHandler(Of GiveFireWizardReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveFireWizard", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGiveGrinch As EventHandler(Of GiveGrinchReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGiveGrinch
        AddHandler(value As EventHandler(Of GiveGrinchReceiveMessage))
            myEvents.Add("OnReceiveGiveGrinch", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveGrinchReceiveMessage))
            myEvents.Remove("OnReceiveGiveGrinch", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveGrinchReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveGrinchReceiveMessage) = CType(myEvents("OnReceiveGiveGrinch"), EventHandler(Of GiveGrinchReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveGrinch", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGiveWitch As EventHandler(Of GiveWitchReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGiveWitch
        AddHandler(value As EventHandler(Of GiveWitchReceiveMessage))
            myEvents.Add("OnReceiveGiveWitch", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveWitchReceiveMessage))
            myEvents.Remove("OnReceiveGiveWitch", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveWitchReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveWitchReceiveMessage) = CType(myEvents("OnReceiveGiveWitch"), EventHandler(Of GiveWitchReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveWitch", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGiveWizard As EventHandler(Of GiveWizardReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGiveWizard
        AddHandler(value As EventHandler(Of GiveWizardReceiveMessage))
            myEvents.Add("OnReceiveGiveWizard", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveWizardReceiveMessage))
            myEvents.Remove("OnReceiveGiveWizard", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveWizardReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveWizardReceiveMessage) = CType(myEvents("OnReceiveGiveWizard"), EventHandler(Of GiveWizardReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveWizard", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGodMode As EventHandler(Of GodModeReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGodMode
        AddHandler(value As EventHandler(Of GodModeReceiveMessage))
            myEvents.Add("OnReceiveGodMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GodModeReceiveMessage))
            myEvents.Remove("OnReceiveGodMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GodModeReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GodModeReceiveMessage) = CType(myEvents("OnReceiveGodMode"), EventHandler(Of GodModeReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGodMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGroupDisallowedJoin As EventHandler(Of GroupDisallowedJoinReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGroupDisallowedJoin
        AddHandler(value As EventHandler(Of GroupDisallowedJoinReceiveMessage))
            myEvents.Add("OnReceiveGroupDisallowedJoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GroupDisallowedJoinReceiveMessage))
            myEvents.Remove("OnReceiveGroupDisallowedJoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GroupDisallowedJoinReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GroupDisallowedJoinReceiveMessage) = CType(myEvents("OnReceiveGroupDisallowedJoin"), EventHandler(Of GroupDisallowedJoinReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGroupDisallowedJoin", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveHideKey As EventHandler(Of HideKeyReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveHideKey
        AddHandler(value As EventHandler(Of HideKeyReceiveMessage))
            myEvents.Add("OnReceiveHideKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of HideKeyReceiveMessage))
            myEvents.Remove("OnReceiveHideKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As HideKeyReceiveMessage)
            Try
                Dim eevent As EventHandler(Of HideKeyReceiveMessage) = CType(myEvents("OnReceiveHideKey"), EventHandler(Of HideKeyReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveHideKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveInfo As EventHandler(Of InfoReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveInfo
        AddHandler(value As EventHandler(Of InfoReceiveMessage))
            myEvents.Add("OnReceiveInfo", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of InfoReceiveMessage))
            myEvents.Remove("OnReceiveInfo", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As InfoReceiveMessage)
            Try
                Dim eevent As EventHandler(Of InfoReceiveMessage) = CType(myEvents("OnReceiveInfo"), EventHandler(Of InfoReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveInfo", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveInit As EventHandler(Of InitReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveInit
        AddHandler(value As EventHandler(Of InitReceiveMessage))
            myEvents.Add("OnReceiveInit", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of InitReceiveMessage))
            myEvents.Remove("OnReceiveInit", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As InitReceiveMessage)
            Try
                Dim eevent As EventHandler(Of InitReceiveMessage) = CType(myEvents("OnReceiveInit"), EventHandler(Of InitReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveInit", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveLabelPlace As EventHandler(Of LabelPlaceReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveLabelPlace
        AddHandler(value As EventHandler(Of LabelPlaceReceiveMessage))
            myEvents.Add("OnReceiveLabelPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LabelPlaceReceiveMessage))
            myEvents.Remove("OnReceiveLabelPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LabelPlaceReceiveMessage)
            Try
                Dim eevent As EventHandler(Of LabelPlaceReceiveMessage) = CType(myEvents("OnReceiveLabelPlace"), EventHandler(Of LabelPlaceReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveLabelPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveLeft As EventHandler(Of LeftReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveLeft
        AddHandler(value As EventHandler(Of LeftReceiveMessage))
            myEvents.Add("OnReceiveLeft", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LeftReceiveMessage))
            myEvents.Remove("OnReceiveLeft", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LeftReceiveMessage)
            Try
                Dim eevent As EventHandler(Of LeftReceiveMessage) = CType(myEvents("OnReceiveLeft"), EventHandler(Of LeftReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveLeft", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveLostAccess As EventHandler(Of LostAccessReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveLostAccess
        AddHandler(value As EventHandler(Of LostAccessReceiveMessage))
            myEvents.Add("OnReceiveLostAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LostAccessReceiveMessage))
            myEvents.Remove("OnReceiveLostAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LostAccessReceiveMessage)
            Try
                Dim eevent As EventHandler(Of LostAccessReceiveMessage) = CType(myEvents("OnReceiveLostAccess"), EventHandler(Of LostAccessReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveLostAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveModMode As EventHandler(Of ModModeReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveModMode
        AddHandler(value As EventHandler(Of ModModeReceiveMessage))
            myEvents.Add("OnReceiveModMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ModModeReceiveMessage))
            myEvents.Remove("OnReceiveModMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ModModeReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ModModeReceiveMessage) = CType(myEvents("OnReceiveModMode"), EventHandler(Of ModModeReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveModMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveMove As EventHandler(Of MoveReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveMove
        AddHandler(value As EventHandler(Of MoveReceiveMessage))
            myEvents.Add("OnReceiveMove", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of MoveReceiveMessage))
            myEvents.Remove("OnReceiveMove", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As MoveReceiveMessage)
            Try
                Dim eevent As EventHandler(Of MoveReceiveMessage) = CType(myEvents("OnReceiveMove"), EventHandler(Of MoveReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveMove", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceivePortalPlace As EventHandler(Of PortalPlaceReceiveMessage) Implements IConnection(Of TPlayer).OnReceivePortalPlace
        AddHandler(value As EventHandler(Of PortalPlaceReceiveMessage))
            myEvents.Add("OnReceivePortalPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of PortalPlaceReceiveMessage))
            myEvents.Remove("OnReceivePortalPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As PortalPlaceReceiveMessage)
            Try
                Dim eevent As EventHandler(Of PortalPlaceReceiveMessage) = CType(myEvents("OnReceivePortalPlace"), EventHandler(Of PortalPlaceReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceivePortalPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveRefreshShop As EventHandler(Of RefreshShopReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveRefreshShop
        AddHandler(value As EventHandler(Of RefreshShopReceiveMessage))
            myEvents.Add("OnReceiveRefreshShop", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of RefreshShopReceiveMessage))
            myEvents.Remove("OnReceiveRefreshShop", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As RefreshShopReceiveMessage)
            Try
                Dim eevent As EventHandler(Of RefreshShopReceiveMessage) = CType(myEvents("OnReceiveRefreshShop"), EventHandler(Of RefreshShopReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveRefreshShop", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveReset As EventHandler(Of ResetReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveReset
        AddHandler(value As EventHandler(Of ResetReceiveMessage))
            myEvents.Add("OnReceiveReset", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ResetReceiveMessage))
            myEvents.Remove("OnReceiveReset", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ResetReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ResetReceiveMessage) = CType(myEvents("OnReceiveReset"), EventHandler(Of ResetReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveReset", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveSaveDone As EventHandler(Of SaveDoneReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveSaveDone
        AddHandler(value As EventHandler(Of SaveDoneReceiveMessage))
            myEvents.Add("OnReceiveSaveDone", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SaveDoneReceiveMessage))
            myEvents.Remove("OnReceiveSaveDone", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SaveDoneReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SaveDoneReceiveMessage) = CType(myEvents("OnReceiveSaveDone"), EventHandler(Of SaveDoneReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSaveDone", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveSay As EventHandler(Of SayReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveSay
        AddHandler(value As EventHandler(Of SayReceiveMessage))
            myEvents.Add("OnReceiveSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SayReceiveMessage))
            myEvents.Remove("OnReceiveSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SayReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SayReceiveMessage) = CType(myEvents("OnReceiveSay"), EventHandler(Of SayReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSay", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveSayOld As EventHandler(Of SayOld_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveSayOld
        AddHandler(value As EventHandler(Of SayOld_ReceiveMessage))
            myEvents.Add("OnReceiveSayOld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SayOld_ReceiveMessage))
            myEvents.Remove("OnReceiveSayOld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SayOld_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SayOld_ReceiveMessage) = CType(myEvents("OnReceiveSayOld"), EventHandler(Of SayOld_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSayOld", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveShowKey As EventHandler(Of ShowKeyReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveShowKey
        AddHandler(value As EventHandler(Of ShowKeyReceiveMessage))
            myEvents.Add("OnReceiveShowKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ShowKeyReceiveMessage))
            myEvents.Remove("OnReceiveShowKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ShowKeyReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ShowKeyReceiveMessage) = CType(myEvents("OnReceiveShowKey"), EventHandler(Of ShowKeyReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveShowKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveSilverCrown As EventHandler(Of SilverCrownReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveSilverCrown
        AddHandler(value As EventHandler(Of SilverCrownReceiveMessage))
            myEvents.Add("OnReceiveSilverCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SilverCrownReceiveMessage))
            myEvents.Remove("OnReceiveSilverCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SilverCrownReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SilverCrownReceiveMessage) = CType(myEvents("OnReceiveSilverCrown"), EventHandler(Of SilverCrownReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSilverCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveSoundPlace As EventHandler(Of SoundPlaceReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveSoundPlace
        AddHandler(value As EventHandler(Of SoundPlaceReceiveMessage))
            myEvents.Add("OnReceiveSoundPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SoundPlaceReceiveMessage))
            myEvents.Remove("OnReceiveSoundPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SoundPlaceReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SoundPlaceReceiveMessage) = CType(myEvents("OnReceiveSoundPlace"), EventHandler(Of SoundPlaceReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSoundPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveTeleport As EventHandler(Of TeleportReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveTeleport
        AddHandler(value As EventHandler(Of TeleportReceiveMessage))
            myEvents.Add("OnReceiveTeleport", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of TeleportReceiveMessage))
            myEvents.Remove("OnReceiveTeleport", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As TeleportReceiveMessage)
            Try
                Dim eevent As EventHandler(Of TeleportReceiveMessage) = CType(myEvents("OnReceiveTeleport"), EventHandler(Of TeleportReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveTeleport", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveUpdateMeta As EventHandler(Of UpdateMetaReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveUpdateMeta
        AddHandler(value As EventHandler(Of UpdateMetaReceiveMessage))
            myEvents.Add("OnReceiveUpdateMeta", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of UpdateMetaReceiveMessage))
            myEvents.Remove("OnReceiveUpdateMeta", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As UpdateMetaReceiveMessage)
            Try
                Dim eevent As EventHandler(Of UpdateMetaReceiveMessage) = CType(myEvents("OnReceiveUpdateMeta"), EventHandler(Of UpdateMetaReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveUpdateMeta", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveUpgrade As EventHandler(Of UpgradeReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveUpgrade
        AddHandler(value As EventHandler(Of UpgradeReceiveMessage))
            myEvents.Add("OnReceiveUpgrade", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of UpgradeReceiveMessage))
            myEvents.Remove("OnReceiveUpgrade", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As UpgradeReceiveMessage)
            Try
                Dim eevent As EventHandler(Of UpgradeReceiveMessage) = CType(myEvents("OnReceiveUpgrade"), EventHandler(Of UpgradeReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveUpgrade", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveWrite As EventHandler(Of WriteReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveWrite
        AddHandler(value As EventHandler(Of WriteReceiveMessage))
            myEvents.Add("OnReceiveWrite", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of WriteReceiveMessage))
            myEvents.Remove("OnReceiveWrite", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As WriteReceiveMessage)
            Try
                Dim eevent As EventHandler(Of WriteReceiveMessage) = CType(myEvents("OnReceiveWrite"), EventHandler(Of WriteReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveWrite", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendMessage As EventHandler(Of SendMessage) Implements IConnection(Of TPlayer).OnSendMessage
        AddHandler(value As EventHandler(Of SendMessage))
            myEvents.Add("OnSendMessage", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendMessage))
            myEvents.Remove("OnSendMessage", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendMessage)
            Try
                Dim eevent As EventHandler(Of SendMessage) = CType(myEvents("OnSendMessage"), EventHandler(Of SendMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendMessage", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendInit As EventHandler(Of SendEventArgs(Of InitSendMessage)) Implements IConnection(Of TPlayer).OnSendInit
        AddHandler(value As EventHandler(Of SendEventArgs(Of InitSendMessage)))
            myEvents.Add("OnSendInit", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of InitSendMessage)))
            myEvents.Remove("OnSendInit", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of InitSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of InitSendMessage)) = CType(myEvents("OnSendInit"), EventHandler(Of SendEventArgs(Of InitSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendInit", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendInit2 As EventHandler(Of SendEventArgs(Of Init2SendMessage)) Implements IConnection(Of TPlayer).OnSendInit2
        AddHandler(value As EventHandler(Of SendEventArgs(Of Init2SendMessage)))
            myEvents.Add("OnSendInit2", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Init2SendMessage)))
            myEvents.Remove("OnSendInit2", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Init2SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of Init2SendMessage)) = CType(myEvents("OnSendInit2"), EventHandler(Of SendEventArgs(Of Init2SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendInit2", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendBlockPlace As EventHandler(Of SendEventArgs(Of BlockPlaceSendMessage)) Implements IConnection(Of TPlayer).OnSendBlockPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of BlockPlaceSendMessage)))
            myEvents.Add("OnSendBlockPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of BlockPlaceSendMessage)))
            myEvents.Remove("OnSendBlockPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of BlockPlaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of BlockPlaceSendMessage)) = CType(myEvents("OnSendBlockPlace"), EventHandler(Of SendEventArgs(Of BlockPlaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendBlockPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendCoindoorPlace As EventHandler(Of SendEventArgs(Of CoinDoorPlaceSendMessage)) Implements IConnection(Of TPlayer).OnSendCoindoorPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of CoinDoorPlaceSendMessage)))
            myEvents.Add("OnSendCoindoorPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of CoinDoorPlaceSendMessage)))
            myEvents.Remove("OnSendCoindoorPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of CoinDoorPlaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of CoinDoorPlaceSendMessage)) = CType(myEvents("OnSendCoindoorPlace"), EventHandler(Of SendEventArgs(Of CoinDoorPlaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCoindoorPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendSoundPlace As EventHandler(Of SendEventArgs(Of SoundPlaceSendMessage)) Implements IConnection(Of TPlayer).OnSendSoundPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of SoundPlaceSendMessage)))
            myEvents.Add("OnSendSoundPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of SoundPlaceSendMessage)))
            myEvents.Remove("OnSendSoundPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of SoundPlaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of SoundPlaceSendMessage)) = CType(myEvents("OnSendSoundPlace"), EventHandler(Of SendEventArgs(Of SoundPlaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSoundPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendPortalPlace As EventHandler(Of SendEventArgs(Of PortalPlaceSendMessage)) Implements IConnection(Of TPlayer).OnSendPortalPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of PortalPlaceSendMessage)))
            myEvents.Add("OnSendPortalPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PortalPlaceSendMessage)))
            myEvents.Remove("OnSendPortalPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PortalPlaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PortalPlaceSendMessage)) = CType(myEvents("OnSendPortalPlace"), EventHandler(Of SendEventArgs(Of PortalPlaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPortalPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendLabelPlace As EventHandler(Of SendEventArgs(Of LabelPlaceSendMessage)) Implements IConnection(Of TPlayer).OnSendLabelPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of LabelPlaceSendMessage)))
            myEvents.Add("OnSendLabelPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of LabelPlaceSendMessage)))
            myEvents.Remove("OnSendLabelPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of LabelPlaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of LabelPlaceSendMessage)) = CType(myEvents("OnSendLabelPlace"), EventHandler(Of SendEventArgs(Of LabelPlaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendLabelPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendCoin As EventHandler(Of SendEventArgs(Of CoinSendMessage)) Implements IConnection(Of TPlayer).OnSendCoin
        AddHandler(value As EventHandler(Of SendEventArgs(Of CoinSendMessage)))
            myEvents.Add("OnSendCoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of CoinSendMessage)))
            myEvents.Remove("OnSendCoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of CoinSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of CoinSendMessage)) = CType(myEvents("OnSendCoin"), EventHandler(Of SendEventArgs(Of CoinSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCoin", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendPressRedKey As EventHandler(Of SendEventArgs(Of PressRedKeySendMessage)) Implements IConnection(Of TPlayer).OnSendPressRedKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressRedKeySendMessage)))
            myEvents.Add("OnSendPressRedKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressRedKeySendMessage)))
            myEvents.Remove("OnSendPressRedKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressRedKeySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PressRedKeySendMessage)) = CType(myEvents("OnSendPressRedKey"), EventHandler(Of SendEventArgs(Of PressRedKeySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressRedKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendPressGreenKey As EventHandler(Of SendEventArgs(Of PressGreenKeySendMessage)) Implements IConnection(Of TPlayer).OnSendPressGreenKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressGreenKeySendMessage)))
            myEvents.Add("OnSendPressGreenKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressGreenKeySendMessage)))
            myEvents.Remove("OnSendPressGreenKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressGreenKeySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PressGreenKeySendMessage)) = CType(myEvents("OnSendPressGreenKey"), EventHandler(Of SendEventArgs(Of PressGreenKeySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressGreenKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendPressBlueKey As EventHandler(Of SendEventArgs(Of PressBlueKeySendMessage)) Implements IConnection(Of TPlayer).OnSendPressBlueKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressBlueKeySendMessage)))
            myEvents.Add("OnSendPressBlueKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressBlueKeySendMessage)))
            myEvents.Remove("OnSendPressBlueKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressBlueKeySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PressBlueKeySendMessage)) = CType(myEvents("OnSendPressBlueKey"), EventHandler(Of SendEventArgs(Of PressBlueKeySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressBlueKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendGetCrown As EventHandler(Of SendEventArgs(Of GetCrownSendMessage)) Implements IConnection(Of TPlayer).OnSendGetCrown
        AddHandler(value As EventHandler(Of SendEventArgs(Of GetCrownSendMessage)))
            myEvents.Add("OnSendGetCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of GetCrownSendMessage)))
            myEvents.Remove("OnSendGetCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of GetCrownSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of GetCrownSendMessage)) = CType(myEvents("OnSendGetCrown"), EventHandler(Of SendEventArgs(Of GetCrownSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendGetCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendTouchDiamond As EventHandler(Of SendEventArgs(Of TouchDiamondSendMessage)) Implements IConnection(Of TPlayer).OnSendTouchDiamond
        AddHandler(value As EventHandler(Of SendEventArgs(Of TouchDiamondSendMessage)))
            myEvents.Add("OnSendTouchDiamond", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of TouchDiamondSendMessage)))
            myEvents.Remove("OnSendTouchDiamond", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of TouchDiamondSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of TouchDiamondSendMessage)) = CType(myEvents("OnSendTouchDiamond"), EventHandler(Of SendEventArgs(Of TouchDiamondSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendTouchDiamond", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendCompleteLevel As EventHandler(Of SendEventArgs(Of CompleteLevelSendMessage)) Implements IConnection(Of TPlayer).OnSendCompleteLevel
        AddHandler(value As EventHandler(Of SendEventArgs(Of CompleteLevelSendMessage)))
            myEvents.Add("OnSendCompleteLevel", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of CompleteLevelSendMessage)))
            myEvents.Remove("OnSendCompleteLevel", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of CompleteLevelSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of CompleteLevelSendMessage)) = CType(myEvents("OnSendCompleteLevel"), EventHandler(Of SendEventArgs(Of CompleteLevelSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCompleteLevel", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendGodMode As EventHandler(Of SendEventArgs(Of GodModeSendMessage)) Implements IConnection(Of TPlayer).OnSendGodMode
        AddHandler(value As EventHandler(Of SendEventArgs(Of GodModeSendMessage)))
            myEvents.Add("OnSendGodMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of GodModeSendMessage)))
            myEvents.Remove("OnSendGodMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of GodModeSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of GodModeSendMessage)) = CType(myEvents("OnSendGodMode"), EventHandler(Of SendEventArgs(Of GodModeSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendGodMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendModMode As EventHandler(Of SendEventArgs(Of ModModeSendMessage)) Implements IConnection(Of TPlayer).OnSendModMode
        AddHandler(value As EventHandler(Of SendEventArgs(Of ModModeSendMessage)))
            myEvents.Add("OnSendModMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ModModeSendMessage)))
            myEvents.Remove("OnSendModMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ModModeSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ModModeSendMessage)) = CType(myEvents("OnSendModMode"), EventHandler(Of SendEventArgs(Of ModModeSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendModMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendMove As EventHandler(Of SendEventArgs(Of MoveSendMessage)) Implements IConnection(Of TPlayer).OnSendMove
        AddHandler(value As EventHandler(Of SendEventArgs(Of MoveSendMessage)))
            myEvents.Add("OnSendMove", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of MoveSendMessage)))
            myEvents.Remove("OnSendMove", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of MoveSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of MoveSendMessage)) = CType(myEvents("OnSendMove"), EventHandler(Of SendEventArgs(Of MoveSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendMove", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendSay As EventHandler(Of SendEventArgs(Of SaySendMessage)) Implements IConnection(Of TPlayer).OnSendSay
        AddHandler(value As EventHandler(Of SendEventArgs(Of SaySendMessage)))
            myEvents.Add("OnSendSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of SaySendMessage)))
            myEvents.Remove("OnSendSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of SaySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of SaySendMessage)) = CType(myEvents("OnSendSay"), EventHandler(Of SendEventArgs(Of SaySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSay", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendAutoSay As EventHandler(Of SendEventArgs(Of AutoSaySendMessage)) Implements IConnection(Of TPlayer).OnSendAutoSay
        AddHandler(value As EventHandler(Of SendEventArgs(Of AutoSaySendMessage)))
            myEvents.Add("OnSendAutoSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of AutoSaySendMessage)))
            myEvents.Remove("OnSendAutoSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of AutoSaySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of AutoSaySendMessage)) = CType(myEvents("OnSendAutoSay"), EventHandler(Of SendEventArgs(Of AutoSaySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendAutoSay", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendAccess As EventHandler(Of SendEventArgs(Of AccessSendMessage)) Implements IConnection(Of TPlayer).OnSendAccess
        AddHandler(value As EventHandler(Of SendEventArgs(Of AccessSendMessage)))
            myEvents.Add("OnSendAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of AccessSendMessage)))
            myEvents.Remove("OnSendAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of AccessSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of AccessSendMessage)) = CType(myEvents("OnSendAccess"), EventHandler(Of SendEventArgs(Of AccessSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendChangeFace As EventHandler(Of SendEventArgs(Of ChangeFaceSendMessage)) Implements IConnection(Of TPlayer).OnSendChangeFace
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeFaceSendMessage)))
            myEvents.Add("OnSendChangeFace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeFaceSendMessage)))
            myEvents.Remove("OnSendChangeFace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeFaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ChangeFaceSendMessage)) = CType(myEvents("OnSendChangeFace"), EventHandler(Of SendEventArgs(Of ChangeFaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeFace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendSaveWorld As EventHandler(Of SendEventArgs(Of SaveWorldSendMessage)) Implements IConnection(Of TPlayer).OnSendSaveWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of SaveWorldSendMessage)))
            myEvents.Add("OnSendSaveWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of SaveWorldSendMessage)))
            myEvents.Remove("OnSendSaveWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of SaveWorldSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of SaveWorldSendMessage)) = CType(myEvents("OnSendSaveWorld"), EventHandler(Of SendEventArgs(Of SaveWorldSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSaveWorld", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendChangeWorldName As EventHandler(Of SendEventArgs(Of ChangeWorldNameSendMessage)) Implements IConnection(Of TPlayer).OnSendChangeWorldName
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldNameSendMessage)))
            myEvents.Add("OnSendChangeWorldName", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldNameSendMessage)))
            myEvents.Remove("OnSendChangeWorldName", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeWorldNameSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ChangeWorldNameSendMessage)) = CType(myEvents("OnSendChangeWorldName"), EventHandler(Of SendEventArgs(Of ChangeWorldNameSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeWorldName", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendChangeWorldEditKey As EventHandler(Of SendEventArgs(Of ChangeWorldEditKeySendMessage)) Implements IConnection(Of TPlayer).OnSendChangeWorldEditKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldEditKeySendMessage)))
            myEvents.Add("OnSendChangeWorldEditKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldEditKeySendMessage)))
            myEvents.Remove("OnSendChangeWorldEditKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeWorldEditKeySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ChangeWorldEditKeySendMessage)) = CType(myEvents("OnSendChangeWorldEditKey"), EventHandler(Of SendEventArgs(Of ChangeWorldEditKeySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeWorldEditKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendClearWorld As EventHandler(Of SendEventArgs(Of ClearWorldSendMessage)) Implements IConnection(Of TPlayer).OnSendClearWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of ClearWorldSendMessage)))
            myEvents.Add("OnSendClearWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ClearWorldSendMessage)))
            myEvents.Remove("OnSendClearWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ClearWorldSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ClearWorldSendMessage)) = CType(myEvents("OnSendClearWorld"), EventHandler(Of SendEventArgs(Of ClearWorldSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendClearWorld", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendKillWorld As EventHandler(Of SendEventArgs(Of KillWorldSendMessage)) Implements IConnection(Of TPlayer).OnSendKillWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of KillWorldSendMessage)))
            myEvents.Add("OnSendKillWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of KillWorldSendMessage)))
            myEvents.Remove("OnSendKillWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of KillWorldSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of KillWorldSendMessage)) = CType(myEvents("OnSendKillWorld"), EventHandler(Of SendEventArgs(Of KillWorldSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendKillWorld", ex)
            End Try
        End RaiseEvent
    End Event

#End Region

#Region "Properties"
    Friend MustOverride ReadOnly Property Chatter As IChatter Implements IConnection(Of TPlayer).Chatter

    Friend MustOverride ReadOnly Property Connected As Boolean Implements IConnection(Of TPlayer).Connected

    Friend MustOverride ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer) Implements IConnection(Of TPlayer).PlayerManager

    Friend MustOverride ReadOnly Property PluginManager As IPluginManager Implements IConnection(Of TPlayer).PluginManager

    Friend MustOverride ReadOnly Property World As World Implements IConnection(Of TPlayer).World

    Friend MustOverride ReadOnly Property WorldID As String Implements IConnection(Of TPlayer).WorldID
#End Region

#Region "Methods"

    Private Sub OnEventError(eventName As String, ex As Exception)
        Cloud.Logger.Log(LogPriority.Error, String.Format("Unable to pass event {0} to {1}.", eventName, ex.Source))
        Cloud.Logger.Log(ex)
    End Sub

    Private Sub myInternalConnection_OnDisconnect(sender As Object, e As String) Handles InternalConnection.OnInternalDisconnect
        RaiseEvent OnDisconnect(Me, EventArgs.Empty)
    End Sub

    Private Sub myInternalConnection_OnMessage(sender As Object, e As ReceiveMessage) Handles InternalConnection.OnInternalMessage
        RaiseEvent OnReceiveMessage(Me, e)
        Select Case e.GetType
            Case GetType(InitReceiveMessage)
                Dim m As InitReceiveMessage = CType(e, InitReceiveMessage)
                RaiseEvent OnReceiveInit(Me, m)

            Case GetType(GroupDisallowedJoinReceiveMessage)
                Dim m As GroupDisallowedJoinReceiveMessage = CType(e, GroupDisallowedJoinReceiveMessage)
                RaiseEvent OnReceiveGroupDisallowedJoin(Me, m)

            Case GetType(InfoReceiveMessage)
                Dim m As InfoReceiveMessage = CType(e, InfoReceiveMessage)
                RaiseEvent OnReceiveInfo(Me, m)

            Case GetType(UpgradeReceiveMessage)
                Dim m As UpgradeReceiveMessage = CType(e, UpgradeReceiveMessage)
                RaiseEvent OnReceiveUpgrade(Me, m)

            Case GetType(UpdateMetaReceiveMessage)
                Dim m As UpdateMetaReceiveMessage = CType(e, UpdateMetaReceiveMessage)
                RaiseEvent OnReceiveUpdateMeta(Me, m)

            Case GetType(AddReceiveMessage)
                Dim m As AddReceiveMessage = CType(e, AddReceiveMessage)
                RaiseEvent OnReceiveAdd(Me, m)

            Case GetType(LeftReceiveMessage)
                Dim m As LeftReceiveMessage = CType(e, LeftReceiveMessage)
                RaiseEvent OnReceiveLeft(Me, m)

            Case GetType(MoveReceiveMessage)
                Dim m As MoveReceiveMessage = CType(e, MoveReceiveMessage)
                RaiseEvent OnReceiveMove(Me, m)

            Case GetType(CoinReceiveMessage)
                Dim m As CoinReceiveMessage = CType(e, CoinReceiveMessage)
                RaiseEvent OnReceiveCoin(Me, m)

            Case GetType(CrownReceiveMessage)
                Dim m As CrownReceiveMessage = CType(e, CrownReceiveMessage)
                RaiseEvent OnReceiveCrown(Me, m)

            Case GetType(SilverCrownReceiveMessage)
                Dim m As SilverCrownReceiveMessage = CType(e, SilverCrownReceiveMessage)
                RaiseEvent OnReceiveSilverCrown(Me, m)
            Case GetType(FaceReceiveMessage)
                Dim m As FaceReceiveMessage = CType(e, FaceReceiveMessage)
                RaiseEvent OnReceiveFace(Me, m)

            Case GetType(ShowKeyReceiveMessage)
                Dim m As ShowKeyReceiveMessage = CType(e, ShowKeyReceiveMessage)
                RaiseEvent OnReceiveShowKey(Me, m)

            Case GetType(HideKeyReceiveMessage)
                Dim m As HideKeyReceiveMessage = CType(e, HideKeyReceiveMessage)
                RaiseEvent OnReceiveHideKey(Me, m)

            Case GetType(SayReceiveMessage)
                Dim m As SayReceiveMessage = CType(e, SayReceiveMessage)
                RaiseEvent OnReceiveSay(Me, m)

            Case GetType(SayOld_ReceiveMessage)
                Dim m As SayOld_ReceiveMessage = CType(e, SayOld_ReceiveMessage)
                RaiseEvent OnReceiveSayOld(Me, m)

            Case GetType(AutoTextReceiveMessage)
                Dim m As AutoTextReceiveMessage = CType(e, AutoTextReceiveMessage)
                RaiseEvent OnReceiveAutoText(Me, m)

            Case GetType(WriteReceiveMessage)
                Dim m As WriteReceiveMessage = CType(e, WriteReceiveMessage)
                RaiseEvent OnReceiveWrite(Me, m)

            Case GetType(BlockPlaceReceiveMessage)
                Dim m As BlockPlaceReceiveMessage = CType(e, BlockPlaceReceiveMessage)
                RaiseEvent OnReceiveBlockPlace(Me, m)

            Case GetType(CoinDoorPlace_ReceiveMessage)
                Dim m As CoinDoorPlace_ReceiveMessage = CType(e, CoinDoorPlace_ReceiveMessage)
                RaiseEvent OnReceiveCoinDoorPlace(Me, m)
                RaiseEvent OnReceiveBlockPlace(Me, m)

            Case GetType(SoundPlaceReceiveMessage)
                Dim m As SoundPlaceReceiveMessage = CType(e, SoundPlaceReceiveMessage)
                RaiseEvent OnReceiveSoundPlace(Me, m)
                RaiseEvent OnReceiveBlockPlace(Me, m)

            Case GetType(PortalPlaceReceiveMessage)
                Dim m As PortalPlaceReceiveMessage = CType(e, PortalPlaceReceiveMessage)
                RaiseEvent OnReceivePortalPlace(Me, m)
                RaiseEvent OnReceiveBlockPlace(Me, m)

            Case GetType(LabelPlaceReceiveMessage)
                Dim m As LabelPlaceReceiveMessage = CType(e, LabelPlaceReceiveMessage)
                RaiseEvent OnReceiveLabelPlace(Me, m)
                RaiseEvent OnReceiveBlockPlace(Me, m)

            Case GetType(GodModeReceiveMessage)
                Dim m As GodModeReceiveMessage = CType(e, GodModeReceiveMessage)
                RaiseEvent OnReceiveGodMode(Me, m)

            Case GetType(ModModeReceiveMessage)
                Dim m As ModModeReceiveMessage = CType(e, ModModeReceiveMessage)
                RaiseEvent OnReceiveModMode(Me, m)

            Case GetType(AccessReceiveMessage)
                Dim m As AccessReceiveMessage = CType(e, AccessReceiveMessage)
                RaiseEvent OnReceiveAccess(Me, m)

            Case GetType(LostAccessReceiveMessage)
                Dim m As LostAccessReceiveMessage = CType(e, LostAccessReceiveMessage)
                RaiseEvent OnReceiveLostAccess(Me, m)

            Case GetType(TeleportReceiveMessage)
                Dim m As TeleportReceiveMessage = CType(e, TeleportReceiveMessage)
                RaiseEvent OnReceiveTeleport(Me, m)

            Case GetType(ResetReceiveMessage)
                Dim m As ResetReceiveMessage = CType(e, ResetReceiveMessage)
                RaiseEvent OnReceiveReset(Me, m)

            Case GetType(ClearReceiveMessage)
                Dim m As ClearReceiveMessage = CType(e, ClearReceiveMessage)
                RaiseEvent OnReceiveClear(Me, m)

            Case GetType(SaveDoneReceiveMessage)
                Dim m As SaveDoneReceiveMessage = CType(e, SaveDoneReceiveMessage)
                RaiseEvent OnReceiveSaveDone(Me, m)

            Case GetType(RefreshShopReceiveMessage)
                Dim m As RefreshShopReceiveMessage = CType(e, RefreshShopReceiveMessage)
                RaiseEvent OnReceiveRefreshShop(Me, m)

            Case GetType(GiveWizardReceiveMessage)
                Dim m As GiveWizardReceiveMessage = CType(e, GiveWizardReceiveMessage)
                RaiseEvent OnReceiveGiveWizard(Me, m)

            Case GetType(GiveFireWizardReceiveMessage)
                Dim m As GiveFireWizardReceiveMessage = CType(e, GiveFireWizardReceiveMessage)
                RaiseEvent OnReceiveGiveFireWizard(Me, m)

            Case GetType(GiveWitchReceiveMessage)
                Dim m As GiveWitchReceiveMessage = CType(e, GiveWitchReceiveMessage)
                RaiseEvent OnReceiveGiveWitch(Me, m)

            Case GetType(GiveGrinchReceiveMessage)
                Dim m As GiveGrinchReceiveMessage = CType(e, GiveGrinchReceiveMessage)
                RaiseEvent OnReceiveGiveGrinch(Me, m)
        End Select
    End Sub

    Protected Function RaiseSendEvent(message As SendMessage) As Boolean
        RaiseEvent OnSendMessage(Me, message)
        Select Case message.GetType
            Case GetType(InitSendMessage)
                Dim eventArgs As New SendEventArgs(Of InitSendMessage)(CType(message, InitSendMessage))
                RaiseEvent OnSendInit(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(Init2SendMessage)
                Dim eventArgs As New SendEventArgs(Of Init2SendMessage)(CType(message, Init2SendMessage))
                RaiseEvent OnSendInit2(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(BlockPlaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of BlockPlaceSendMessage)(CType(message, BlockPlaceSendMessage))
                RaiseEvent OnSendBlockPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(CoinDoorPlaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of CoinDoorPlaceSendMessage)(CType(message, CoinDoorPlaceSendMessage))
                RaiseEvent OnSendCoindoorPlace(Me, eventArgs)
                Dim blockEventArgs As New SendEventArgs(Of BlockPlaceSendMessage)(CType(message, BlockPlaceSendMessage))
                RaiseEvent OnSendBlockPlace(Me, blockEventArgs)
                Return eventArgs.Handled And blockEventArgs.Handled

            Case GetType(SoundPlaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of SoundPlaceSendMessage)(CType(message, SoundPlaceSendMessage))
                RaiseEvent OnSendSoundPlace(Me, eventArgs)
                Dim blockEventArgs As New SendEventArgs(Of BlockPlaceSendMessage)(CType(message, BlockPlaceSendMessage))
                RaiseEvent OnSendBlockPlace(Me, blockEventArgs)
                Return eventArgs.Handled And blockEventArgs.Handled

            Case GetType(PortalPlaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of PortalPlaceSendMessage)(CType(message, PortalPlaceSendMessage))
                RaiseEvent OnSendPortalPlace(Me, eventArgs)
                Dim blockEventArgs As New SendEventArgs(Of BlockPlaceSendMessage)(CType(message, BlockPlaceSendMessage))
                RaiseEvent OnSendBlockPlace(Me, blockEventArgs)
                Return eventArgs.Handled And blockEventArgs.Handled

            Case GetType(LabelPlaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of LabelPlaceSendMessage)(CType(message, LabelPlaceSendMessage))
                RaiseEvent OnSendLabelPlace(Me, eventArgs)
                Dim blockEventArgs As New SendEventArgs(Of BlockPlaceSendMessage)(CType(message, BlockPlaceSendMessage))
                RaiseEvent OnSendBlockPlace(Me, blockEventArgs)
                Return eventArgs.Handled And blockEventArgs.Handled

            Case GetType(CoinSendMessage)
                Dim eventArgs As New SendEventArgs(Of CoinSendMessage)(CType(message, CoinSendMessage))
                RaiseEvent OnSendCoin(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressRedKeySendMessage)
                Dim eventArgs As New SendEventArgs(Of PressRedKeySendMessage)(CType(message, PressRedKeySendMessage))
                RaiseEvent OnSendPressRedKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressGreenKeySendMessage)
                Dim eventArgs As New SendEventArgs(Of PressGreenKeySendMessage)(CType(message, PressGreenKeySendMessage))
                RaiseEvent OnSendPressGreenKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressBlueKeySendMessage)
                Dim eventArgs As New SendEventArgs(Of PressBlueKeySendMessage)(CType(message, PressBlueKeySendMessage))
                RaiseEvent OnSendPressBlueKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(GetCrownSendMessage)
                Dim eventArgs As New SendEventArgs(Of GetCrownSendMessage)(CType(message, GetCrownSendMessage))
                RaiseEvent OnSendGetCrown(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(TouchDiamondSendMessage)
                Dim eventArgs As New SendEventArgs(Of TouchDiamondSendMessage)(CType(message, TouchDiamondSendMessage))
                RaiseEvent OnSendTouchDiamond(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(CompleteLevelSendMessage)
                Dim eventArgs As New SendEventArgs(Of CompleteLevelSendMessage)(CType(message, CompleteLevelSendMessage))
                RaiseEvent OnSendCompleteLevel(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(GodModeSendMessage)
                Dim eventArgs As New SendEventArgs(Of GodModeSendMessage)(CType(message, GodModeSendMessage))
                RaiseEvent OnSendGodMode(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ModModeSendMessage)
                Dim eventArgs As New SendEventArgs(Of ModModeSendMessage)(CType(message, ModModeSendMessage))
                RaiseEvent OnSendModMode(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(MoveSendMessage)
                Dim eventArgs As New SendEventArgs(Of MoveSendMessage)(CType(message, MoveSendMessage))
                RaiseEvent OnSendMove(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(SaySendMessage)
                Dim eventArgs As New SendEventArgs(Of SaySendMessage)(CType(message, SaySendMessage))
                RaiseEvent OnSendSay(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(AutoSaySendMessage)
                Dim eventArgs As New SendEventArgs(Of AutoSaySendMessage)(CType(message, AutoSaySendMessage))
                RaiseEvent OnSendAutoSay(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(AccessSendMessage)
                Dim eventArgs As New SendEventArgs(Of AccessSendMessage)(CType(message, AccessSendMessage))
                RaiseEvent OnSendAccess(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeFaceSendMessage)
                Dim eventArgs As New SendEventArgs(Of ChangeFaceSendMessage)(CType(message, ChangeFaceSendMessage))
                RaiseEvent OnSendChangeFace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(SaveWorldSendMessage)
                Dim eventArgs As New SendEventArgs(Of SaveWorldSendMessage)(CType(message, SaveWorldSendMessage))
                RaiseEvent OnSendSaveWorld(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeWorldNameSendMessage)
                Dim eventArgs As New SendEventArgs(Of ChangeWorldNameSendMessage)(CType(message, ChangeWorldNameSendMessage))
                RaiseEvent OnSendChangeWorldName(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeWorldEditKeySendMessage)
                Dim eventArgs As New SendEventArgs(Of ChangeWorldEditKeySendMessage)(CType(message, ChangeWorldEditKeySendMessage))
                RaiseEvent OnSendChangeWorldEditKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ClearWorldSendMessage)
                Dim eventArgs As New SendEventArgs(Of ClearWorldSendMessage)(CType(message, ClearWorldSendMessage))
                RaiseEvent OnSendClearWorld(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(KillWorldSendMessage)
                Dim eventArgs As New SendEventArgs(Of KillWorldSendMessage)(CType(message, KillWorldSendMessage))
                RaiseEvent OnSendKillWorld(Me, eventArgs)
                Return eventArgs.Handled
            Case Else
                Return False
        End Select
    End Function

    Friend MustOverride Sub Send(message As SendMessage) Implements IConnection(Of TPlayer).Send

#End Region
End Class
