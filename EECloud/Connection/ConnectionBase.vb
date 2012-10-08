Friend MustInherit Class ConnectionBase(Of TPlayer As {Player, New})
    Implements IConnection(Of TPlayer)

#Region "Fields"
    Friend WithEvents InternalConnection As InternalConnection
    Private ReadOnly myEvents As New EventHandlerList
#End Region

#Region "Events"

    Friend Custom Event ReceiveMessage As EventHandler(Of ReceiveMessage) Implements IConnection(Of TPlayer).ReceiveMessage
        AddHandler(value As EventHandler(Of ReceiveMessage))
            myEvents.Add("ReceiveMessage", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ReceiveMessage))
            myEvents.Remove("ReceiveMessage", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ReceiveMessage) = CType(myEvents("ReceiveMessage"), EventHandler(Of ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveMessage", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event Disconnect As EventHandler(Of DisconnectEventArgs) Implements IConnection(Of TPlayer).Disconnect
        AddHandler(value As EventHandler(Of DisconnectEventArgs))
            myEvents.Add("Disconnect", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of DisconnectEventArgs))
            myEvents.Remove("Disconnect", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As DisconnectEventArgs)
            Try
                Dim eevent As EventHandler(Of DisconnectEventArgs) = CType(myEvents("Disconnect"), EventHandler(Of DisconnectEventArgs))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("Disconnect", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event Disconnecting As EventHandler(Of EventArgs) Implements IConnection(Of TPlayer).Disconnecting
        AddHandler(value As EventHandler(Of EventArgs))
            myEvents.Add("Disconnecting", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of EventArgs))
            myEvents.Remove("Disconnecting", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As EventArgs)
            Try
                Dim eevent As EventHandler(Of EventArgs) = CType(myEvents("Disconnecting"), EventHandler(Of EventArgs))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("Disconnecting", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveAccess As EventHandler(Of AccessReceiveMessage) Implements IConnection(Of TPlayer).ReceiveAccess
        AddHandler(value As EventHandler(Of AccessReceiveMessage))
            myEvents.Add("ReceiveAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of AccessReceiveMessage))
            myEvents.Remove("ReceiveAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As AccessReceiveMessage)
            Try
                Dim eevent As EventHandler(Of AccessReceiveMessage) = CType(myEvents("ReceiveAccess"), EventHandler(Of AccessReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveAdd As EventHandler(Of AddReceiveMessage) Implements IConnection(Of TPlayer).ReceiveAdd
        AddHandler(value As EventHandler(Of AddReceiveMessage))
            myEvents.Add("ReceiveAdd", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of AddReceiveMessage))
            myEvents.Remove("ReceiveAdd", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As AddReceiveMessage)
            Try
                Dim eevent As EventHandler(Of AddReceiveMessage) = CType(myEvents("ReceiveAdd"), EventHandler(Of AddReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveAdd", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveAutoText As EventHandler(Of AutoTextReceiveMessage) Implements IConnection(Of TPlayer).ReceiveAutoText
        AddHandler(value As EventHandler(Of AutoTextReceiveMessage))
            myEvents.Add("ReceiveAutoText", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of AutoTextReceiveMessage))
            myEvents.Remove("ReceiveAutoText", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As AutoTextReceiveMessage)
            Try
                Dim eevent As EventHandler(Of AutoTextReceiveMessage) = CType(myEvents("ReceiveAutoText"), EventHandler(Of AutoTextReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveAutoText", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveBlockPlace As EventHandler(Of BlockPlaceReceiveMessage) Implements IConnection(Of TPlayer).ReceiveBlockPlace
        AddHandler(value As EventHandler(Of BlockPlaceReceiveMessage))
            myEvents.Add("ReceiveBlockPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of BlockPlaceReceiveMessage))
            myEvents.Remove("ReceiveBlockPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As BlockPlaceReceiveMessage)
            Try
                Dim eevent As EventHandler(Of BlockPlaceReceiveMessage) = CType(myEvents("ReceiveBlockPlace"), EventHandler(Of BlockPlaceReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveBlockPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveClear As EventHandler(Of ClearReceiveMessage) Implements IConnection(Of TPlayer).ReceiveClear
        AddHandler(value As EventHandler(Of ClearReceiveMessage))
            myEvents.Add("ReceiveClear", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ClearReceiveMessage))
            myEvents.Remove("ReceiveClear", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ClearReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ClearReceiveMessage) = CType(myEvents("ReceiveClear"), EventHandler(Of ClearReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveClear", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveCoin As EventHandler(Of CoinReceiveMessage) Implements IConnection(Of TPlayer).ReceiveCoin
        AddHandler(value As EventHandler(Of CoinReceiveMessage))
            myEvents.Add("ReceiveCoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of CoinReceiveMessage))
            myEvents.Remove("ReceiveCoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As CoinReceiveMessage)
            Try
                Dim eevent As EventHandler(Of CoinReceiveMessage) = CType(myEvents("ReceiveCoin"), EventHandler(Of CoinReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveCoin", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveCoinDoorPlace As EventHandler(Of CoinDoorPlace_ReceiveMessage) Implements IConnection(Of TPlayer).ReceiveCoinDoorPlace
        AddHandler(value As EventHandler(Of CoinDoorPlace_ReceiveMessage))
            myEvents.Add("ReceiveCoinDoorPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of CoinDoorPlace_ReceiveMessage))
            myEvents.Remove("ReceiveCoinDoorPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As CoinDoorPlace_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of CoinDoorPlace_ReceiveMessage) = CType(myEvents("ReceiveCoinDoorPlace"), EventHandler(Of CoinDoorPlace_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveCoinDoorPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveCrown As EventHandler(Of CrownReceiveMessage) Implements IConnection(Of TPlayer).ReceiveCrown
        AddHandler(value As EventHandler(Of CrownReceiveMessage))
            myEvents.Add("ReceiveCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of CrownReceiveMessage))
            myEvents.Remove("ReceiveCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As CrownReceiveMessage)
            Try
                Dim eevent As EventHandler(Of CrownReceiveMessage) = CType(myEvents("ReceiveCrown"), EventHandler(Of CrownReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveFace As EventHandler(Of FaceReceiveMessage) Implements IConnection(Of TPlayer).ReceiveFace
        AddHandler(value As EventHandler(Of FaceReceiveMessage))
            myEvents.Add("ReceiveFace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of FaceReceiveMessage))
            myEvents.Remove("ReceiveFace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As FaceReceiveMessage)
            Try
                Dim eevent As EventHandler(Of FaceReceiveMessage) = CType(myEvents("ReceiveFace"), EventHandler(Of FaceReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveFace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveGiveFireWizard As EventHandler(Of GiveFireWizardReceiveMessage) Implements IConnection(Of TPlayer).ReceiveGiveFireWizard
        AddHandler(value As EventHandler(Of GiveFireWizardReceiveMessage))
            myEvents.Add("ReceiveGiveFireWizard", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveFireWizardReceiveMessage))
            myEvents.Remove("ReceiveGiveFireWizard", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveFireWizardReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveFireWizardReceiveMessage) = CType(myEvents("ReceiveGiveFireWizard"), EventHandler(Of GiveFireWizardReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveGiveFireWizard", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveGiveGrinch As EventHandler(Of GiveGrinchReceiveMessage) Implements IConnection(Of TPlayer).ReceiveGiveGrinch
        AddHandler(value As EventHandler(Of GiveGrinchReceiveMessage))
            myEvents.Add("ReceiveGiveGrinch", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveGrinchReceiveMessage))
            myEvents.Remove("ReceiveGiveGrinch", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveGrinchReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveGrinchReceiveMessage) = CType(myEvents("ReceiveGiveGrinch"), EventHandler(Of GiveGrinchReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveGiveGrinch", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveGiveWitch As EventHandler(Of GiveWitchReceiveMessage) Implements IConnection(Of TPlayer).ReceiveGiveWitch
        AddHandler(value As EventHandler(Of GiveWitchReceiveMessage))
            myEvents.Add("ReceiveGiveWitch", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveWitchReceiveMessage))
            myEvents.Remove("ReceiveGiveWitch", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveWitchReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveWitchReceiveMessage) = CType(myEvents("ReceiveGiveWitch"), EventHandler(Of GiveWitchReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveGiveWitch", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveGiveWizard As EventHandler(Of GiveWizardReceiveMessage) Implements IConnection(Of TPlayer).ReceiveGiveWizard
        AddHandler(value As EventHandler(Of GiveWizardReceiveMessage))
            myEvents.Add("ReceiveGiveWizard", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveWizardReceiveMessage))
            myEvents.Remove("ReceiveGiveWizard", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveWizardReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveWizardReceiveMessage) = CType(myEvents("ReceiveGiveWizard"), EventHandler(Of GiveWizardReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveGiveWizard", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveGodMode As EventHandler(Of GodModeReceiveMessage) Implements IConnection(Of TPlayer).ReceiveGodMode
        AddHandler(value As EventHandler(Of GodModeReceiveMessage))
            myEvents.Add("ReceiveGodMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GodModeReceiveMessage))
            myEvents.Remove("ReceiveGodMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GodModeReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GodModeReceiveMessage) = CType(myEvents("ReceiveGodMode"), EventHandler(Of GodModeReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveGodMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveGroupDisallowedJoin As EventHandler(Of GroupDisallowedJoinReceiveMessage) Implements IConnection(Of TPlayer).ReceiveGroupDisallowedJoin
        AddHandler(value As EventHandler(Of GroupDisallowedJoinReceiveMessage))
            myEvents.Add("ReceiveGroupDisallowedJoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GroupDisallowedJoinReceiveMessage))
            myEvents.Remove("ReceiveGroupDisallowedJoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GroupDisallowedJoinReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GroupDisallowedJoinReceiveMessage) = CType(myEvents("ReceiveGroupDisallowedJoin"), EventHandler(Of GroupDisallowedJoinReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveGroupDisallowedJoin", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveHideKey As EventHandler(Of HideKeyReceiveMessage) Implements IConnection(Of TPlayer).ReceiveHideKey
        AddHandler(value As EventHandler(Of HideKeyReceiveMessage))
            myEvents.Add("ReceiveHideKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of HideKeyReceiveMessage))
            myEvents.Remove("ReceiveHideKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As HideKeyReceiveMessage)
            Try
                Dim eevent As EventHandler(Of HideKeyReceiveMessage) = CType(myEvents("ReceiveHideKey"), EventHandler(Of HideKeyReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveHideKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveInfo As EventHandler(Of InfoReceiveMessage) Implements IConnection(Of TPlayer).ReceiveInfo
        AddHandler(value As EventHandler(Of InfoReceiveMessage))
            myEvents.Add("ReceiveInfo", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of InfoReceiveMessage))
            myEvents.Remove("ReceiveInfo", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As InfoReceiveMessage)
            Try
                Dim eevent As EventHandler(Of InfoReceiveMessage) = CType(myEvents("ReceiveInfo"), EventHandler(Of InfoReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveInfo", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveInit As EventHandler(Of InitReceiveMessage) Implements IConnection(Of TPlayer).ReceiveInit
        AddHandler(value As EventHandler(Of InitReceiveMessage))
            myEvents.Add("ReceiveInit", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of InitReceiveMessage))
            myEvents.Remove("ReceiveInit", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As InitReceiveMessage)
            Try
                Dim eevent As EventHandler(Of InitReceiveMessage) = CType(myEvents("ReceiveInit"), EventHandler(Of InitReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveInit", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveLabelPlace As EventHandler(Of LabelPlaceReceiveMessage) Implements IConnection(Of TPlayer).ReceiveLabelPlace
        AddHandler(value As EventHandler(Of LabelPlaceReceiveMessage))
            myEvents.Add("ReceiveLabelPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LabelPlaceReceiveMessage))
            myEvents.Remove("ReceiveLabelPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LabelPlaceReceiveMessage)
            Try
                Dim eevent As EventHandler(Of LabelPlaceReceiveMessage) = CType(myEvents("ReceiveLabelPlace"), EventHandler(Of LabelPlaceReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveLabelPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveLeft As EventHandler(Of LeftReceiveMessage) Implements IConnection(Of TPlayer).ReceiveLeft
        AddHandler(value As EventHandler(Of LeftReceiveMessage))
            myEvents.Add("ReceiveLeft", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LeftReceiveMessage))
            myEvents.Remove("ReceiveLeft", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LeftReceiveMessage)
            Try
                Dim eevent As EventHandler(Of LeftReceiveMessage) = CType(myEvents("ReceiveLeft"), EventHandler(Of LeftReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveLeft", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveLostAccess As EventHandler(Of LostAccessReceiveMessage) Implements IConnection(Of TPlayer).ReceiveLostAccess
        AddHandler(value As EventHandler(Of LostAccessReceiveMessage))
            myEvents.Add("ReceiveLostAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LostAccessReceiveMessage))
            myEvents.Remove("ReceiveLostAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LostAccessReceiveMessage)
            Try
                Dim eevent As EventHandler(Of LostAccessReceiveMessage) = CType(myEvents("ReceiveLostAccess"), EventHandler(Of LostAccessReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveLostAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveModMode As EventHandler(Of ModModeReceiveMessage) Implements IConnection(Of TPlayer).ReceiveModMode
        AddHandler(value As EventHandler(Of ModModeReceiveMessage))
            myEvents.Add("ReceiveModMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ModModeReceiveMessage))
            myEvents.Remove("ReceiveModMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ModModeReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ModModeReceiveMessage) = CType(myEvents("ReceiveModMode"), EventHandler(Of ModModeReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveModMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveMove As EventHandler(Of MoveReceiveMessage) Implements IConnection(Of TPlayer).ReceiveMove
        AddHandler(value As EventHandler(Of MoveReceiveMessage))
            myEvents.Add("ReceiveMove", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of MoveReceiveMessage))
            myEvents.Remove("ReceiveMove", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As MoveReceiveMessage)
            Try
                Dim eevent As EventHandler(Of MoveReceiveMessage) = CType(myEvents("ReceiveMove"), EventHandler(Of MoveReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveMove", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceivePortalPlace As EventHandler(Of PortalPlaceReceiveMessage) Implements IConnection(Of TPlayer).ReceivePortalPlace
        AddHandler(value As EventHandler(Of PortalPlaceReceiveMessage))
            myEvents.Add("ReceivePortalPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of PortalPlaceReceiveMessage))
            myEvents.Remove("ReceivePortalPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As PortalPlaceReceiveMessage)
            Try
                Dim eevent As EventHandler(Of PortalPlaceReceiveMessage) = CType(myEvents("ReceivePortalPlace"), EventHandler(Of PortalPlaceReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceivePortalPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveRefreshShop As EventHandler(Of RefreshShopReceiveMessage) Implements IConnection(Of TPlayer).ReceiveRefreshShop
        AddHandler(value As EventHandler(Of RefreshShopReceiveMessage))
            myEvents.Add("ReceiveRefreshShop", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of RefreshShopReceiveMessage))
            myEvents.Remove("ReceiveRefreshShop", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As RefreshShopReceiveMessage)
            Try
                Dim eevent As EventHandler(Of RefreshShopReceiveMessage) = CType(myEvents("ReceiveRefreshShop"), EventHandler(Of RefreshShopReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveRefreshShop", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveReset As EventHandler(Of ResetReceiveMessage) Implements IConnection(Of TPlayer).ReceiveReset
        AddHandler(value As EventHandler(Of ResetReceiveMessage))
            myEvents.Add("ReceiveReset", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ResetReceiveMessage))
            myEvents.Remove("ReceiveReset", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ResetReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ResetReceiveMessage) = CType(myEvents("ReceiveReset"), EventHandler(Of ResetReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveReset", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveSaveDone As EventHandler(Of SaveDoneReceiveMessage) Implements IConnection(Of TPlayer).ReceiveSaveDone
        AddHandler(value As EventHandler(Of SaveDoneReceiveMessage))
            myEvents.Add("ReceiveSaveDone", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SaveDoneReceiveMessage))
            myEvents.Remove("ReceiveSaveDone", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SaveDoneReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SaveDoneReceiveMessage) = CType(myEvents("ReceiveSaveDone"), EventHandler(Of SaveDoneReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveSaveDone", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveSay As EventHandler(Of SayReceiveMessage) Implements IConnection(Of TPlayer).ReceiveSay
        AddHandler(value As EventHandler(Of SayReceiveMessage))
            myEvents.Add("ReceiveSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SayReceiveMessage))
            myEvents.Remove("ReceiveSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SayReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SayReceiveMessage) = CType(myEvents("ReceiveSay"), EventHandler(Of SayReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveSay", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveSayOld As EventHandler(Of SayOld_ReceiveMessage) Implements IConnection(Of TPlayer).ReceiveSayOld
        AddHandler(value As EventHandler(Of SayOld_ReceiveMessage))
            myEvents.Add("ReceiveSayOld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SayOld_ReceiveMessage))
            myEvents.Remove("ReceiveSayOld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SayOld_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SayOld_ReceiveMessage) = CType(myEvents("ReceiveSayOld"), EventHandler(Of SayOld_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveSayOld", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveShowKey As EventHandler(Of ShowKeyReceiveMessage) Implements IConnection(Of TPlayer).ReceiveShowKey
        AddHandler(value As EventHandler(Of ShowKeyReceiveMessage))
            myEvents.Add("ReceiveShowKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ShowKeyReceiveMessage))
            myEvents.Remove("ReceiveShowKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ShowKeyReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ShowKeyReceiveMessage) = CType(myEvents("ReceiveShowKey"), EventHandler(Of ShowKeyReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveShowKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveSilverCrown As EventHandler(Of SilverCrownReceiveMessage) Implements IConnection(Of TPlayer).ReceiveSilverCrown
        AddHandler(value As EventHandler(Of SilverCrownReceiveMessage))
            myEvents.Add("ReceiveSilverCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SilverCrownReceiveMessage))
            myEvents.Remove("ReceiveSilverCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SilverCrownReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SilverCrownReceiveMessage) = CType(myEvents("ReceiveSilverCrown"), EventHandler(Of SilverCrownReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveSilverCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveSoundPlace As EventHandler(Of SoundPlaceReceiveMessage) Implements IConnection(Of TPlayer).ReceiveSoundPlace
        AddHandler(value As EventHandler(Of SoundPlaceReceiveMessage))
            myEvents.Add("ReceiveSoundPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SoundPlaceReceiveMessage))
            myEvents.Remove("ReceiveSoundPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SoundPlaceReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SoundPlaceReceiveMessage) = CType(myEvents("ReceiveSoundPlace"), EventHandler(Of SoundPlaceReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveSoundPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveTeleport As EventHandler(Of TeleportReceiveMessage) Implements IConnection(Of TPlayer).ReceiveTeleport
        AddHandler(value As EventHandler(Of TeleportReceiveMessage))
            myEvents.Add("ReceiveTeleport", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of TeleportReceiveMessage))
            myEvents.Remove("ReceiveTeleport", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As TeleportReceiveMessage)
            Try
                Dim eevent As EventHandler(Of TeleportReceiveMessage) = CType(myEvents("ReceiveTeleport"), EventHandler(Of TeleportReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveTeleport", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveUpdateMeta As EventHandler(Of UpdateMetaReceiveMessage) Implements IConnection(Of TPlayer).ReceiveUpdateMeta
        AddHandler(value As EventHandler(Of UpdateMetaReceiveMessage))
            myEvents.Add("ReceiveUpdateMeta", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of UpdateMetaReceiveMessage))
            myEvents.Remove("ReceiveUpdateMeta", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As UpdateMetaReceiveMessage)
            Try
                Dim eevent As EventHandler(Of UpdateMetaReceiveMessage) = CType(myEvents("ReceiveUpdateMeta"), EventHandler(Of UpdateMetaReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveUpdateMeta", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveUpgrade As EventHandler(Of UpgradeReceiveMessage) Implements IConnection(Of TPlayer).ReceiveUpgrade
        AddHandler(value As EventHandler(Of UpgradeReceiveMessage))
            myEvents.Add("ReceiveUpgrade", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of UpgradeReceiveMessage))
            myEvents.Remove("ReceiveUpgrade", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As UpgradeReceiveMessage)
            Try
                Dim eevent As EventHandler(Of UpgradeReceiveMessage) = CType(myEvents("ReceiveUpgrade"), EventHandler(Of UpgradeReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveUpgrade", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event ReceiveWrite As EventHandler(Of WriteReceiveMessage) Implements IConnection(Of TPlayer).ReceiveWrite
        AddHandler(value As EventHandler(Of WriteReceiveMessage))
            myEvents.Add("ReceiveWrite", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of WriteReceiveMessage))
            myEvents.Remove("ReceiveWrite", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As WriteReceiveMessage)
            Try
                Dim eevent As EventHandler(Of WriteReceiveMessage) = CType(myEvents("ReceiveWrite"), EventHandler(Of WriteReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("ReceiveWrite", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendMessage As EventHandler(Of SendMessage) Implements IConnection(Of TPlayer).SendMessage
        AddHandler(value As EventHandler(Of SendMessage))
            myEvents.Add("SendMessage", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendMessage))
            myEvents.Remove("SendMessage", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendMessage)
            Try
                Dim eevent As EventHandler(Of SendMessage) = CType(myEvents("SendMessage"), EventHandler(Of SendMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendMessage", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendInit As EventHandler(Of SendEventArgs(Of InitSendMessage)) Implements IConnection(Of TPlayer).SendInit
        AddHandler(value As EventHandler(Of SendEventArgs(Of InitSendMessage)))
            myEvents.Add("SendInit", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of InitSendMessage)))
            myEvents.Remove("SendInit", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of InitSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of InitSendMessage)) = CType(myEvents("SendInit"), EventHandler(Of SendEventArgs(Of InitSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendInit", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendInit2 As EventHandler(Of SendEventArgs(Of Init2SendMessage)) Implements IConnection(Of TPlayer).SendInit2
        AddHandler(value As EventHandler(Of SendEventArgs(Of Init2SendMessage)))
            myEvents.Add("SendInit2", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Init2SendMessage)))
            myEvents.Remove("SendInit2", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Init2SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of Init2SendMessage)) = CType(myEvents("SendInit2"), EventHandler(Of SendEventArgs(Of Init2SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendInit2", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendBlockPlace As EventHandler(Of SendEventArgs(Of BlockPlaceSendMessage)) Implements IConnection(Of TPlayer).SendBlockPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of BlockPlaceSendMessage)))
            myEvents.Add("SendBlockPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of BlockPlaceSendMessage)))
            myEvents.Remove("SendBlockPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of BlockPlaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of BlockPlaceSendMessage)) = CType(myEvents("SendBlockPlace"), EventHandler(Of SendEventArgs(Of BlockPlaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendBlockPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendCoindoorPlace As EventHandler(Of SendEventArgs(Of CoinDoorPlaceSendMessage)) Implements IConnection(Of TPlayer).SendCoindoorPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of CoinDoorPlaceSendMessage)))
            myEvents.Add("SendCoindoorPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of CoinDoorPlaceSendMessage)))
            myEvents.Remove("SendCoindoorPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of CoinDoorPlaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of CoinDoorPlaceSendMessage)) = CType(myEvents("SendCoindoorPlace"), EventHandler(Of SendEventArgs(Of CoinDoorPlaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendCoindoorPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendSoundPlace As EventHandler(Of SendEventArgs(Of SoundPlaceSendMessage)) Implements IConnection(Of TPlayer).SendSoundPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of SoundPlaceSendMessage)))
            myEvents.Add("SendSoundPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of SoundPlaceSendMessage)))
            myEvents.Remove("SendSoundPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of SoundPlaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of SoundPlaceSendMessage)) = CType(myEvents("SendSoundPlace"), EventHandler(Of SendEventArgs(Of SoundPlaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendSoundPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendPortalPlace As EventHandler(Of SendEventArgs(Of PortalPlaceSendMessage)) Implements IConnection(Of TPlayer).SendPortalPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of PortalPlaceSendMessage)))
            myEvents.Add("SendPortalPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PortalPlaceSendMessage)))
            myEvents.Remove("SendPortalPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PortalPlaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PortalPlaceSendMessage)) = CType(myEvents("SendPortalPlace"), EventHandler(Of SendEventArgs(Of PortalPlaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendPortalPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendLabelPlace As EventHandler(Of SendEventArgs(Of LabelPlaceSendMessage)) Implements IConnection(Of TPlayer).SendLabelPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of LabelPlaceSendMessage)))
            myEvents.Add("SendLabelPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of LabelPlaceSendMessage)))
            myEvents.Remove("SendLabelPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of LabelPlaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of LabelPlaceSendMessage)) = CType(myEvents("SendLabelPlace"), EventHandler(Of SendEventArgs(Of LabelPlaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendLabelPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendCoin As EventHandler(Of SendEventArgs(Of CoinSendMessage)) Implements IConnection(Of TPlayer).SendCoin
        AddHandler(value As EventHandler(Of SendEventArgs(Of CoinSendMessage)))
            myEvents.Add("SendCoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of CoinSendMessage)))
            myEvents.Remove("SendCoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of CoinSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of CoinSendMessage)) = CType(myEvents("SendCoin"), EventHandler(Of SendEventArgs(Of CoinSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendCoin", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendPressRedKey As EventHandler(Of SendEventArgs(Of PressRedKeySendMessage)) Implements IConnection(Of TPlayer).SendPressRedKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressRedKeySendMessage)))
            myEvents.Add("SendPressRedKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressRedKeySendMessage)))
            myEvents.Remove("SendPressRedKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressRedKeySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PressRedKeySendMessage)) = CType(myEvents("SendPressRedKey"), EventHandler(Of SendEventArgs(Of PressRedKeySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendPressRedKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendPressGreenKey As EventHandler(Of SendEventArgs(Of PressGreenKeySendMessage)) Implements IConnection(Of TPlayer).SendPressGreenKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressGreenKeySendMessage)))
            myEvents.Add("SendPressGreenKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressGreenKeySendMessage)))
            myEvents.Remove("SendPressGreenKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressGreenKeySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PressGreenKeySendMessage)) = CType(myEvents("SendPressGreenKey"), EventHandler(Of SendEventArgs(Of PressGreenKeySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendPressGreenKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendPressBlueKey As EventHandler(Of SendEventArgs(Of PressBlueKeySendMessage)) Implements IConnection(Of TPlayer).SendPressBlueKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressBlueKeySendMessage)))
            myEvents.Add("SendPressBlueKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressBlueKeySendMessage)))
            myEvents.Remove("SendPressBlueKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressBlueKeySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PressBlueKeySendMessage)) = CType(myEvents("SendPressBlueKey"), EventHandler(Of SendEventArgs(Of PressBlueKeySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendPressBlueKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendGetCrown As EventHandler(Of SendEventArgs(Of GetCrownSendMessage)) Implements IConnection(Of TPlayer).SendGetCrown
        AddHandler(value As EventHandler(Of SendEventArgs(Of GetCrownSendMessage)))
            myEvents.Add("SendGetCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of GetCrownSendMessage)))
            myEvents.Remove("SendGetCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of GetCrownSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of GetCrownSendMessage)) = CType(myEvents("SendGetCrown"), EventHandler(Of SendEventArgs(Of GetCrownSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendGetCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendTouchDiamond As EventHandler(Of SendEventArgs(Of TouchDiamondSendMessage)) Implements IConnection(Of TPlayer).SendTouchDiamond
        AddHandler(value As EventHandler(Of SendEventArgs(Of TouchDiamondSendMessage)))
            myEvents.Add("SendTouchDiamond", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of TouchDiamondSendMessage)))
            myEvents.Remove("SendTouchDiamond", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of TouchDiamondSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of TouchDiamondSendMessage)) = CType(myEvents("SendTouchDiamond"), EventHandler(Of SendEventArgs(Of TouchDiamondSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendTouchDiamond", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendCompleteLevel As EventHandler(Of SendEventArgs(Of CompleteLevelSendMessage)) Implements IConnection(Of TPlayer).SendCompleteLevel
        AddHandler(value As EventHandler(Of SendEventArgs(Of CompleteLevelSendMessage)))
            myEvents.Add("SendCompleteLevel", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of CompleteLevelSendMessage)))
            myEvents.Remove("SendCompleteLevel", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of CompleteLevelSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of CompleteLevelSendMessage)) = CType(myEvents("SendCompleteLevel"), EventHandler(Of SendEventArgs(Of CompleteLevelSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendCompleteLevel", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendGodMode As EventHandler(Of SendEventArgs(Of GodModeSendMessage)) Implements IConnection(Of TPlayer).SendGodMode
        AddHandler(value As EventHandler(Of SendEventArgs(Of GodModeSendMessage)))
            myEvents.Add("SendGodMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of GodModeSendMessage)))
            myEvents.Remove("SendGodMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of GodModeSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of GodModeSendMessage)) = CType(myEvents("SendGodMode"), EventHandler(Of SendEventArgs(Of GodModeSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendGodMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendModMode As EventHandler(Of SendEventArgs(Of ModModeSendMessage)) Implements IConnection(Of TPlayer).SendModMode
        AddHandler(value As EventHandler(Of SendEventArgs(Of ModModeSendMessage)))
            myEvents.Add("SendModMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ModModeSendMessage)))
            myEvents.Remove("SendModMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ModModeSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ModModeSendMessage)) = CType(myEvents("SendModMode"), EventHandler(Of SendEventArgs(Of ModModeSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendModMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendMove As EventHandler(Of SendEventArgs(Of MoveSendMessage)) Implements IConnection(Of TPlayer).SendMove
        AddHandler(value As EventHandler(Of SendEventArgs(Of MoveSendMessage)))
            myEvents.Add("SendMove", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of MoveSendMessage)))
            myEvents.Remove("SendMove", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of MoveSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of MoveSendMessage)) = CType(myEvents("SendMove"), EventHandler(Of SendEventArgs(Of MoveSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendMove", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendSay As EventHandler(Of SendEventArgs(Of SaySendMessage)) Implements IConnection(Of TPlayer).SendSay
        AddHandler(value As EventHandler(Of SendEventArgs(Of SaySendMessage)))
            myEvents.Add("SendSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of SaySendMessage)))
            myEvents.Remove("SendSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of SaySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of SaySendMessage)) = CType(myEvents("SendSay"), EventHandler(Of SendEventArgs(Of SaySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendSay", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendAutoSay As EventHandler(Of SendEventArgs(Of AutoSaySendMessage)) Implements IConnection(Of TPlayer).SendAutoSay
        AddHandler(value As EventHandler(Of SendEventArgs(Of AutoSaySendMessage)))
            myEvents.Add("SendAutoSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of AutoSaySendMessage)))
            myEvents.Remove("SendAutoSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of AutoSaySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of AutoSaySendMessage)) = CType(myEvents("SendAutoSay"), EventHandler(Of SendEventArgs(Of AutoSaySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendAutoSay", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendAccess As EventHandler(Of SendEventArgs(Of AccessSendMessage)) Implements IConnection(Of TPlayer).SendAccess
        AddHandler(value As EventHandler(Of SendEventArgs(Of AccessSendMessage)))
            myEvents.Add("SendAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of AccessSendMessage)))
            myEvents.Remove("SendAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of AccessSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of AccessSendMessage)) = CType(myEvents("SendAccess"), EventHandler(Of SendEventArgs(Of AccessSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendChangeFace As EventHandler(Of SendEventArgs(Of ChangeFaceSendMessage)) Implements IConnection(Of TPlayer).SendChangeFace
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeFaceSendMessage)))
            myEvents.Add("SendChangeFace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeFaceSendMessage)))
            myEvents.Remove("SendChangeFace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeFaceSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ChangeFaceSendMessage)) = CType(myEvents("SendChangeFace"), EventHandler(Of SendEventArgs(Of ChangeFaceSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendChangeFace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendSaveWorld As EventHandler(Of SendEventArgs(Of SaveWorldSendMessage)) Implements IConnection(Of TPlayer).SendSaveWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of SaveWorldSendMessage)))
            myEvents.Add("SendSaveWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of SaveWorldSendMessage)))
            myEvents.Remove("SendSaveWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of SaveWorldSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of SaveWorldSendMessage)) = CType(myEvents("SendSaveWorld"), EventHandler(Of SendEventArgs(Of SaveWorldSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendSaveWorld", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendChangeWorldName As EventHandler(Of SendEventArgs(Of ChangeWorldNameSendMessage)) Implements IConnection(Of TPlayer).SendChangeWorldName
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldNameSendMessage)))
            myEvents.Add("SendChangeWorldName", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldNameSendMessage)))
            myEvents.Remove("SendChangeWorldName", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeWorldNameSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ChangeWorldNameSendMessage)) = CType(myEvents("SendChangeWorldName"), EventHandler(Of SendEventArgs(Of ChangeWorldNameSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendChangeWorldName", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendChangeWorldEditKey As EventHandler(Of SendEventArgs(Of ChangeWorldEditKeySendMessage)) Implements IConnection(Of TPlayer).SendChangeWorldEditKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldEditKeySendMessage)))
            myEvents.Add("SendChangeWorldEditKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldEditKeySendMessage)))
            myEvents.Remove("SendChangeWorldEditKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeWorldEditKeySendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ChangeWorldEditKeySendMessage)) = CType(myEvents("SendChangeWorldEditKey"), EventHandler(Of SendEventArgs(Of ChangeWorldEditKeySendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendChangeWorldEditKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendClearWorld As EventHandler(Of SendEventArgs(Of ClearWorldSendMessage)) Implements IConnection(Of TPlayer).SendClearWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of ClearWorldSendMessage)))
            myEvents.Add("SendClearWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ClearWorldSendMessage)))
            myEvents.Remove("SendClearWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ClearWorldSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ClearWorldSendMessage)) = CType(myEvents("SendClearWorld"), EventHandler(Of SendEventArgs(Of ClearWorldSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendClearWorld", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event SendKillWorld As EventHandler(Of SendEventArgs(Of KillWorldSendMessage)) Implements IConnection(Of TPlayer).SendKillWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of KillWorldSendMessage)))
            myEvents.Add("SendKillWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of KillWorldSendMessage)))
            myEvents.Remove("SendKillWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of KillWorldSendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of KillWorldSendMessage)) = CType(myEvents("SendKillWorld"), EventHandler(Of SendEventArgs(Of KillWorldSendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("SendKillWorld", ex)
            End Try
        End RaiseEvent
    End Event

#End Region

#Region "Properties"
    Friend MustOverride ReadOnly Property Chatter As IChatter Implements IConnection(Of TPlayer).Chatter

    Friend MustOverride ReadOnly Property Connected As Boolean Implements IConnection(Of TPlayer).Connected

    Friend MustOverride ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer) Implements IConnection(Of TPlayer).PlayerManager

    Friend MustOverride ReadOnly Property PluginManager As IPluginManager Implements IConnection(Of TPlayer).PluginManager

    Friend MustOverride ReadOnly Property World As IWorld Implements IConnection(Of TPlayer).World

    Friend MustOverride ReadOnly Property WorldID As String Implements IConnection(Of TPlayer).WorldID

    Public MustOverride ReadOnly Property CommandManager As ICommandManager Implements IConnection(Of TPlayer).CommandManager
#End Region

#Region "Methods"

    Private Sub OnEventError(eventName As String, ex As Exception)
        Cloud.Logger.Log(LogPriority.Error, String.Format("Unable to pass event {0} to {1}.", eventName, ex.Source))
        Cloud.Logger.LogEx(ex)
    End Sub

    Private Sub myInternalConnection_OnDisconnect(sender As Object, e As DisconnectEventArgs) Handles InternalConnection.OnInternalDisconnect
        RaiseEvent Disconnect(Me, e)
    End Sub

    Private Sub InternalConnection_OnInternalDisconnecting(sender As Object, e As EventArgs) Handles InternalConnection.OnInternalDisconnecting
        RaiseEvent Disconnecting(Me, e)
    End Sub

    Private Sub myInternalConnection_OnInternalMessage(sender As Object, e As ReceiveMessage) Handles InternalConnection.OnInternalMessage
        RaiseEvent ReceiveMessage(Me, e)
        Select Case e.GetType
            Case GetType(InitReceiveMessage)
                Dim m As InitReceiveMessage = CType(e, InitReceiveMessage)
                RaiseEvent ReceiveInit(Me, m)

            Case GetType(GroupDisallowedJoinReceiveMessage)
                Dim m As GroupDisallowedJoinReceiveMessage = CType(e, GroupDisallowedJoinReceiveMessage)
                RaiseEvent ReceiveGroupDisallowedJoin(Me, m)

            Case GetType(InfoReceiveMessage)
                Dim m As InfoReceiveMessage = CType(e, InfoReceiveMessage)
                RaiseEvent ReceiveInfo(Me, m)

            Case GetType(UpgradeReceiveMessage)
                Dim m As UpgradeReceiveMessage = CType(e, UpgradeReceiveMessage)
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

    Protected Function RaiseSendEvent(message As SendMessage) As Boolean
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

    Friend MustOverride Sub Send(message As SendMessage) Implements IConnection(Of TPlayer).Send

#End Region
End Class
