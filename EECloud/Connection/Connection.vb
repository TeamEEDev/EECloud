Friend Class Connection(Of TPlayer As {Player, New})
    Implements IConnection(Of TPlayer)

#Region "Fields"
    Protected WithEvents InternalConnection As InternalConnection
    Private ReadOnly myEvents As New EventHandlerList
#End Region

#Region "Properties"
    Friend ReadOnly Property WorldID As String Implements IConnection(Of TPlayer).WorldID
        Get
            Return InternalConnection.WorldID
        End Get
    End Property

    Friend ReadOnly Property Connected As Boolean Implements IConnection(Of TPlayer).Connected
        Get
            Return InternalConnection.Connected
        End Get
    End Property

    Friend ReadOnly Property World As World Implements IConnection(Of TPlayer).World
        Get
            Return InternalConnection.World
        End Get
    End Property

    Friend Overridable ReadOnly Property PluginManager As IPluginManager Implements IConnection(Of TPlayer).PluginManager
        Get
            Return InternalConnection.PluginManager
        End Get
    End Property

    Private ReadOnly myChatter As IChatter
    Friend ReadOnly Property Chatter As IChatter Implements IConnection(Of TPlayer).Chatter
        Get
            Return myChatter
        End Get
    End Property

    Private ReadOnly myPlayerManager As PlayerManager(Of TPlayer)
    Friend ReadOnly Property PlayerManager As IPlayerManager(Of TPlayer) Implements IConnection(Of TPlayer).PlayerManager
        Get
            Return myPlayerManager
        End Get
    End Property

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

    Friend Custom Event OnReceiveAccess As EventHandler(Of Access_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveAccess
        AddHandler(value As EventHandler(Of Access_ReceiveMessage))
            myEvents.Add("OnReceiveAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Access_ReceiveMessage))
            myEvents.Remove("OnReceiveAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Access_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Access_ReceiveMessage) = CType(myEvents("OnReceiveAccess"), EventHandler(Of Access_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveAdd As EventHandler(Of Add_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveAdd
        AddHandler(value As EventHandler(Of Add_ReceiveMessage))
            myEvents.Add("OnReceiveAdd", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Add_ReceiveMessage))
            myEvents.Remove("OnReceiveAdd", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Add_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Add_ReceiveMessage) = CType(myEvents("OnReceiveAdd"), EventHandler(Of Add_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveAdd", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveAutoText As EventHandler(Of AutoText_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveAutoText
        AddHandler(value As EventHandler(Of AutoText_ReceiveMessage))
            myEvents.Add("OnReceiveAutoText", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of AutoText_ReceiveMessage))
            myEvents.Remove("OnReceiveAutoText", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As AutoText_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of AutoText_ReceiveMessage) = CType(myEvents("OnReceiveAutoText"), EventHandler(Of AutoText_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveAutoText", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveBlockPlace As EventHandler(Of BlockPlace_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveBlockPlace
        AddHandler(value As EventHandler(Of BlockPlace_ReceiveMessage))
            myEvents.Add("OnReceiveBlockPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of BlockPlace_ReceiveMessage))
            myEvents.Remove("OnReceiveBlockPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As BlockPlace_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of BlockPlace_ReceiveMessage) = CType(myEvents("OnReceiveBlockPlace"), EventHandler(Of BlockPlace_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveBlockPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveClear As EventHandler(Of Clear_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveClear
        AddHandler(value As EventHandler(Of Clear_ReceiveMessage))
            myEvents.Add("OnReceiveClear", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Clear_ReceiveMessage))
            myEvents.Remove("OnReceiveClear", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Clear_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Clear_ReceiveMessage) = CType(myEvents("OnReceiveClear"), EventHandler(Of Clear_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveClear", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveCoin As EventHandler(Of Coin_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveCoin
        AddHandler(value As EventHandler(Of Coin_ReceiveMessage))
            myEvents.Add("OnReceiveCoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Coin_ReceiveMessage))
            myEvents.Remove("OnReceiveCoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Coin_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Coin_ReceiveMessage) = CType(myEvents("OnReceiveCoin"), EventHandler(Of Coin_ReceiveMessage))
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

    Friend Custom Event OnReceiveCrown As EventHandler(Of Crown_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveCrown
        AddHandler(value As EventHandler(Of Crown_ReceiveMessage))
            myEvents.Add("OnReceiveCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Crown_ReceiveMessage))
            myEvents.Remove("OnReceiveCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Crown_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Crown_ReceiveMessage) = CType(myEvents("OnReceiveCrown"), EventHandler(Of Crown_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveFace As EventHandler(Of Face_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveFace
        AddHandler(value As EventHandler(Of Face_ReceiveMessage))
            myEvents.Add("OnReceiveFace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Face_ReceiveMessage))
            myEvents.Remove("OnReceiveFace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Face_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Face_ReceiveMessage) = CType(myEvents("OnReceiveFace"), EventHandler(Of Face_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveFace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGiveFireWizard As EventHandler(Of GiveFireWizard_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGiveFireWizard
        AddHandler(value As EventHandler(Of GiveFireWizard_ReceiveMessage))
            myEvents.Add("OnReceiveGiveFireWizard", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveFireWizard_ReceiveMessage))
            myEvents.Remove("OnReceiveGiveFireWizard", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveFireWizard_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveFireWizard_ReceiveMessage) = CType(myEvents("OnReceiveGiveFireWizard"), EventHandler(Of GiveFireWizard_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveFireWizard", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGiveGrinch As EventHandler(Of GiveGrinch_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGiveGrinch
        AddHandler(value As EventHandler(Of GiveGrinch_ReceiveMessage))
            myEvents.Add("OnReceiveGiveGrinch", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveGrinch_ReceiveMessage))
            myEvents.Remove("OnReceiveGiveGrinch", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveGrinch_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveGrinch_ReceiveMessage) = CType(myEvents("OnReceiveGiveGrinch"), EventHandler(Of GiveGrinch_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveGrinch", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGiveWitch As EventHandler(Of GiveWitch_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGiveWitch
        AddHandler(value As EventHandler(Of GiveWitch_ReceiveMessage))
            myEvents.Add("OnReceiveGiveWitch", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveWitch_ReceiveMessage))
            myEvents.Remove("OnReceiveGiveWitch", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveWitch_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveWitch_ReceiveMessage) = CType(myEvents("OnReceiveGiveWitch"), EventHandler(Of GiveWitch_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveWitch", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGiveWizard As EventHandler(Of GiveWizard_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGiveWizard
        AddHandler(value As EventHandler(Of GiveWizard_ReceiveMessage))
            myEvents.Add("OnReceiveGiveWizard", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveWizard_ReceiveMessage))
            myEvents.Remove("OnReceiveGiveWizard", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveWizard_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GiveWizard_ReceiveMessage) = CType(myEvents("OnReceiveGiveWizard"), EventHandler(Of GiveWizard_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveWizard", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGodMode As EventHandler(Of GodMode_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGodMode
        AddHandler(value As EventHandler(Of GodMode_ReceiveMessage))
            myEvents.Add("OnReceiveGodMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GodMode_ReceiveMessage))
            myEvents.Remove("OnReceiveGodMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GodMode_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GodMode_ReceiveMessage) = CType(myEvents("OnReceiveGodMode"), EventHandler(Of GodMode_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGodMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveGroupDisallowedJoin As EventHandler(Of GroupDisallowedJoin_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveGroupDisallowedJoin
        AddHandler(value As EventHandler(Of GroupDisallowedJoin_ReceiveMessage))
            myEvents.Add("OnReceiveGroupDisallowedJoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GroupDisallowedJoin_ReceiveMessage))
            myEvents.Remove("OnReceiveGroupDisallowedJoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GroupDisallowedJoin_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of GroupDisallowedJoin_ReceiveMessage) = CType(myEvents("OnReceiveGroupDisallowedJoin"), EventHandler(Of GroupDisallowedJoin_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGroupDisallowedJoin", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveHideKey As EventHandler(Of HideKey_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveHideKey
        AddHandler(value As EventHandler(Of HideKey_ReceiveMessage))
            myEvents.Add("OnReceiveHideKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of HideKey_ReceiveMessage))
            myEvents.Remove("OnReceiveHideKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As HideKey_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of HideKey_ReceiveMessage) = CType(myEvents("OnReceiveHideKey"), EventHandler(Of HideKey_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveHideKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveInfo As EventHandler(Of Info_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveInfo
        AddHandler(value As EventHandler(Of Info_ReceiveMessage))
            myEvents.Add("OnReceiveInfo", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Info_ReceiveMessage))
            myEvents.Remove("OnReceiveInfo", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Info_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Info_ReceiveMessage) = CType(myEvents("OnReceiveInfo"), EventHandler(Of Info_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveInfo", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveInit As EventHandler(Of Init_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveInit
        AddHandler(value As EventHandler(Of Init_ReceiveMessage))
            myEvents.Add("OnReceiveInit", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Init_ReceiveMessage))
            myEvents.Remove("OnReceiveInit", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Init_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Init_ReceiveMessage) = CType(myEvents("OnReceiveInit"), EventHandler(Of Init_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveInit", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveLabelPlace As EventHandler(Of LabelPlace_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveLabelPlace
        AddHandler(value As EventHandler(Of LabelPlace_ReceiveMessage))
            myEvents.Add("OnReceiveLabelPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LabelPlace_ReceiveMessage))
            myEvents.Remove("OnReceiveLabelPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LabelPlace_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of LabelPlace_ReceiveMessage) = CType(myEvents("OnReceiveLabelPlace"), EventHandler(Of LabelPlace_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveLabelPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveLeft As EventHandler(Of Left_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveLeft
        AddHandler(value As EventHandler(Of Left_ReceiveMessage))
            myEvents.Add("OnReceiveLeft", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Left_ReceiveMessage))
            myEvents.Remove("OnReceiveLeft", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Left_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Left_ReceiveMessage) = CType(myEvents("OnReceiveLeft"), EventHandler(Of Left_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveLeft", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveLostAccess As EventHandler(Of LostAccess_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveLostAccess
        AddHandler(value As EventHandler(Of LostAccess_ReceiveMessage))
            myEvents.Add("OnReceiveLostAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LostAccess_ReceiveMessage))
            myEvents.Remove("OnReceiveLostAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LostAccess_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of LostAccess_ReceiveMessage) = CType(myEvents("OnReceiveLostAccess"), EventHandler(Of LostAccess_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveLostAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveModMode As EventHandler(Of ModMode_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveModMode
        AddHandler(value As EventHandler(Of ModMode_ReceiveMessage))
            myEvents.Add("OnReceiveModMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ModMode_ReceiveMessage))
            myEvents.Remove("OnReceiveModMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ModMode_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ModMode_ReceiveMessage) = CType(myEvents("OnReceiveModMode"), EventHandler(Of ModMode_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveModMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveMove As EventHandler(Of Move_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveMove
        AddHandler(value As EventHandler(Of Move_ReceiveMessage))
            myEvents.Add("OnReceiveMove", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Move_ReceiveMessage))
            myEvents.Remove("OnReceiveMove", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Move_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Move_ReceiveMessage) = CType(myEvents("OnReceiveMove"), EventHandler(Of Move_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveMove", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceivePortalPlace As EventHandler(Of PortalPlace_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceivePortalPlace
        AddHandler(value As EventHandler(Of PortalPlace_ReceiveMessage))
            myEvents.Add("OnReceivePortalPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of PortalPlace_ReceiveMessage))
            myEvents.Remove("OnReceivePortalPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As PortalPlace_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of PortalPlace_ReceiveMessage) = CType(myEvents("OnReceivePortalPlace"), EventHandler(Of PortalPlace_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceivePortalPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveRefreshShop As EventHandler(Of RefreshShop_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveRefreshShop
        AddHandler(value As EventHandler(Of RefreshShop_ReceiveMessage))
            myEvents.Add("OnReceiveRefreshShop", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of RefreshShop_ReceiveMessage))
            myEvents.Remove("OnReceiveRefreshShop", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As RefreshShop_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of RefreshShop_ReceiveMessage) = CType(myEvents("OnReceiveRefreshShop"), EventHandler(Of RefreshShop_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveRefreshShop", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveReset As EventHandler(Of Reset_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveReset
        AddHandler(value As EventHandler(Of Reset_ReceiveMessage))
            myEvents.Add("OnReceiveReset", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Reset_ReceiveMessage))
            myEvents.Remove("OnReceiveReset", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Reset_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Reset_ReceiveMessage) = CType(myEvents("OnReceiveReset"), EventHandler(Of Reset_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveReset", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveSaveDone As EventHandler(Of SaveDone_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveSaveDone
        AddHandler(value As EventHandler(Of SaveDone_ReceiveMessage))
            myEvents.Add("OnReceiveSaveDone", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SaveDone_ReceiveMessage))
            myEvents.Remove("OnReceiveSaveDone", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SaveDone_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SaveDone_ReceiveMessage) = CType(myEvents("OnReceiveSaveDone"), EventHandler(Of SaveDone_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSaveDone", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveSay As EventHandler(Of Say_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveSay
        AddHandler(value As EventHandler(Of Say_ReceiveMessage))
            myEvents.Add("OnReceiveSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Say_ReceiveMessage))
            myEvents.Remove("OnReceiveSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Say_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Say_ReceiveMessage) = CType(myEvents("OnReceiveSay"), EventHandler(Of Say_ReceiveMessage))
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

    Friend Custom Event OnReceiveShowKey As EventHandler(Of ShowKey_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveShowKey
        AddHandler(value As EventHandler(Of ShowKey_ReceiveMessage))
            myEvents.Add("OnReceiveShowKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ShowKey_ReceiveMessage))
            myEvents.Remove("OnReceiveShowKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ShowKey_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of ShowKey_ReceiveMessage) = CType(myEvents("OnReceiveShowKey"), EventHandler(Of ShowKey_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveShowKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveSilverCrown As EventHandler(Of SilverCrown_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveSilverCrown
        AddHandler(value As EventHandler(Of SilverCrown_ReceiveMessage))
            myEvents.Add("OnReceiveSilverCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SilverCrown_ReceiveMessage))
            myEvents.Remove("OnReceiveSilverCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SilverCrown_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SilverCrown_ReceiveMessage) = CType(myEvents("OnReceiveSilverCrown"), EventHandler(Of SilverCrown_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSilverCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveSoundPlace As EventHandler(Of SoundPlace_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveSoundPlace
        AddHandler(value As EventHandler(Of SoundPlace_ReceiveMessage))
            myEvents.Add("OnReceiveSoundPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SoundPlace_ReceiveMessage))
            myEvents.Remove("OnReceiveSoundPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SoundPlace_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of SoundPlace_ReceiveMessage) = CType(myEvents("OnReceiveSoundPlace"), EventHandler(Of SoundPlace_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSoundPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveTeleport As EventHandler(Of Teleport_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveTeleport
        AddHandler(value As EventHandler(Of Teleport_ReceiveMessage))
            myEvents.Add("OnReceiveTeleport", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Teleport_ReceiveMessage))
            myEvents.Remove("OnReceiveTeleport", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Teleport_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Teleport_ReceiveMessage) = CType(myEvents("OnReceiveTeleport"), EventHandler(Of Teleport_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveTeleport", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveUpdateMeta As EventHandler(Of UpdateMeta_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveUpdateMeta
        AddHandler(value As EventHandler(Of UpdateMeta_ReceiveMessage))
            myEvents.Add("OnReceiveUpdateMeta", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of UpdateMeta_ReceiveMessage))
            myEvents.Remove("OnReceiveUpdateMeta", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As UpdateMeta_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of UpdateMeta_ReceiveMessage) = CType(myEvents("OnReceiveUpdateMeta"), EventHandler(Of UpdateMeta_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveUpdateMeta", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveUpgrade As EventHandler(Of Upgrade_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveUpgrade
        AddHandler(value As EventHandler(Of Upgrade_ReceiveMessage))
            myEvents.Add("OnReceiveUpgrade", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Upgrade_ReceiveMessage))
            myEvents.Remove("OnReceiveUpgrade", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Upgrade_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Upgrade_ReceiveMessage) = CType(myEvents("OnReceiveUpgrade"), EventHandler(Of Upgrade_ReceiveMessage))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveUpgrade", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnReceiveWrite As EventHandler(Of Write_ReceiveMessage) Implements IConnection(Of TPlayer).OnReceiveWrite
        AddHandler(value As EventHandler(Of Write_ReceiveMessage))
            myEvents.Add("OnReceiveWrite", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Write_ReceiveMessage))
            myEvents.Remove("OnReceiveWrite", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Write_ReceiveMessage)
            Try
                Dim eevent As EventHandler(Of Write_ReceiveMessage) = CType(myEvents("OnReceiveWrite"), EventHandler(Of Write_ReceiveMessage))
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

    Friend Custom Event OnSendInit As EventHandler(Of SendEventArgs(Of Init_SendMessage)) Implements IConnection(Of TPlayer).OnSendInit
        AddHandler(value As EventHandler(Of SendEventArgs(Of Init_SendMessage)))
            myEvents.Add("OnSendInit", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Init_SendMessage)))
            myEvents.Remove("OnSendInit", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Init_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of Init_SendMessage)) = CType(myEvents("OnSendInit"), EventHandler(Of SendEventArgs(Of Init_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendInit", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendInit2 As EventHandler(Of SendEventArgs(Of Init2_SendMessage)) Implements IConnection(Of TPlayer).OnSendInit2
        AddHandler(value As EventHandler(Of SendEventArgs(Of Init2_SendMessage)))
            myEvents.Add("OnSendInit2", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Init2_SendMessage)))
            myEvents.Remove("OnSendInit2", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Init2_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of Init2_SendMessage)) = CType(myEvents("OnSendInit2"), EventHandler(Of SendEventArgs(Of Init2_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendInit2", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendBlockPlace As EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage)) Implements IConnection(Of TPlayer).OnSendBlockPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage)))
            myEvents.Add("OnSendBlockPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage)))
            myEvents.Remove("OnSendBlockPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of BlockPlace_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage)) = CType(myEvents("OnSendBlockPlace"), EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendBlockPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendCoindoorPlace As EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage)) Implements IConnection(Of TPlayer).OnSendCoindoorPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage)))
            myEvents.Add("OnSendCoindoorPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage)))
            myEvents.Remove("OnSendCoindoorPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of CoinDoorPlace_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage)) = CType(myEvents("OnSendCoindoorPlace"), EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCoindoorPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendSoundPlace As EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage)) Implements IConnection(Of TPlayer).OnSendSoundPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage)))
            myEvents.Add("OnSendSoundPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage)))
            myEvents.Remove("OnSendSoundPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of SoundPlace_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage)) = CType(myEvents("OnSendSoundPlace"), EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSoundPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendPortalPlace As EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage)) Implements IConnection(Of TPlayer).OnSendPortalPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage)))
            myEvents.Add("OnSendPortalPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage)))
            myEvents.Remove("OnSendPortalPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PortalPlace_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage)) = CType(myEvents("OnSendPortalPlace"), EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPortalPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendLabelPlace As EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage)) Implements IConnection(Of TPlayer).OnSendLabelPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage)))
            myEvents.Add("OnSendLabelPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage)))
            myEvents.Remove("OnSendLabelPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of LabelPlace_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage)) = CType(myEvents("OnSendLabelPlace"), EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendLabelPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendCoin As EventHandler(Of SendEventArgs(Of Coin_SendMessage)) Implements IConnection(Of TPlayer).OnSendCoin
        AddHandler(value As EventHandler(Of SendEventArgs(Of Coin_SendMessage)))
            myEvents.Add("OnSendCoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Coin_SendMessage)))
            myEvents.Remove("OnSendCoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Coin_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of Coin_SendMessage)) = CType(myEvents("OnSendCoin"), EventHandler(Of SendEventArgs(Of Coin_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCoin", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendPressRedKey As EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage)) Implements IConnection(Of TPlayer).OnSendPressRedKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage)))
            myEvents.Add("OnSendPressRedKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage)))
            myEvents.Remove("OnSendPressRedKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressRedKey_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage)) = CType(myEvents("OnSendPressRedKey"), EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressRedKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendPressGreenKey As EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage)) Implements IConnection(Of TPlayer).OnSendPressGreenKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage)))
            myEvents.Add("OnSendPressGreenKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage)))
            myEvents.Remove("OnSendPressGreenKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressGreenKey_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage)) = CType(myEvents("OnSendPressGreenKey"), EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressGreenKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendPressBlueKey As EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage)) Implements IConnection(Of TPlayer).OnSendPressBlueKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage)))
            myEvents.Add("OnSendPressBlueKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage)))
            myEvents.Remove("OnSendPressBlueKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressBlueKey_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage)) = CType(myEvents("OnSendPressBlueKey"), EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressBlueKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendGetCrown As EventHandler(Of SendEventArgs(Of GetCrown_SendMessage)) Implements IConnection(Of TPlayer).OnSendGetCrown
        AddHandler(value As EventHandler(Of SendEventArgs(Of GetCrown_SendMessage)))
            myEvents.Add("OnSendGetCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of GetCrown_SendMessage)))
            myEvents.Remove("OnSendGetCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of GetCrown_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of GetCrown_SendMessage)) = CType(myEvents("OnSendGetCrown"), EventHandler(Of SendEventArgs(Of GetCrown_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendGetCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendTouchDiamond As EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage)) Implements IConnection(Of TPlayer).OnSendTouchDiamond
        AddHandler(value As EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage)))
            myEvents.Add("OnSendTouchDiamond", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage)))
            myEvents.Remove("OnSendTouchDiamond", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of TouchDiamond_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage)) = CType(myEvents("OnSendTouchDiamond"), EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendTouchDiamond", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendCompleteLevel As EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage)) Implements IConnection(Of TPlayer).OnSendCompleteLevel
        AddHandler(value As EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage)))
            myEvents.Add("OnSendCompleteLevel", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage)))
            myEvents.Remove("OnSendCompleteLevel", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of CompleteLevel_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage)) = CType(myEvents("OnSendCompleteLevel"), EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCompleteLevel", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendGodMode As EventHandler(Of SendEventArgs(Of GodMode_SendMessage)) Implements IConnection(Of TPlayer).OnSendGodMode
        AddHandler(value As EventHandler(Of SendEventArgs(Of GodMode_SendMessage)))
            myEvents.Add("OnSendGodMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of GodMode_SendMessage)))
            myEvents.Remove("OnSendGodMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of GodMode_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of GodMode_SendMessage)) = CType(myEvents("OnSendGodMode"), EventHandler(Of SendEventArgs(Of GodMode_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendGodMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendModMode As EventHandler(Of SendEventArgs(Of ModMode_SendMessage)) Implements IConnection(Of TPlayer).OnSendModMode
        AddHandler(value As EventHandler(Of SendEventArgs(Of ModMode_SendMessage)))
            myEvents.Add("OnSendModMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ModMode_SendMessage)))
            myEvents.Remove("OnSendModMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ModMode_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ModMode_SendMessage)) = CType(myEvents("OnSendModMode"), EventHandler(Of SendEventArgs(Of ModMode_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendModMode", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendMove As EventHandler(Of SendEventArgs(Of Move_SendMessage)) Implements IConnection(Of TPlayer).OnSendMove
        AddHandler(value As EventHandler(Of SendEventArgs(Of Move_SendMessage)))
            myEvents.Add("OnSendMove", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Move_SendMessage)))
            myEvents.Remove("OnSendMove", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Move_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of Move_SendMessage)) = CType(myEvents("OnSendMove"), EventHandler(Of SendEventArgs(Of Move_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendMove", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendSay As EventHandler(Of SendEventArgs(Of Say_SendMessage)) Implements IConnection(Of TPlayer).OnSendSay
        AddHandler(value As EventHandler(Of SendEventArgs(Of Say_SendMessage)))
            myEvents.Add("OnSendSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Say_SendMessage)))
            myEvents.Remove("OnSendSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Say_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of Say_SendMessage)) = CType(myEvents("OnSendSay"), EventHandler(Of SendEventArgs(Of Say_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSay", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendAutoSay As EventHandler(Of SendEventArgs(Of AutoSay_SendMessage)) Implements IConnection(Of TPlayer).OnSendAutoSay
        AddHandler(value As EventHandler(Of SendEventArgs(Of AutoSay_SendMessage)))
            myEvents.Add("OnSendAutoSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of AutoSay_SendMessage)))
            myEvents.Remove("OnSendAutoSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of AutoSay_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of AutoSay_SendMessage)) = CType(myEvents("OnSendAutoSay"), EventHandler(Of SendEventArgs(Of AutoSay_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendAutoSay", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendAccess As EventHandler(Of SendEventArgs(Of Access_SendMessage)) Implements IConnection(Of TPlayer).OnSendAccess
        AddHandler(value As EventHandler(Of SendEventArgs(Of Access_SendMessage)))
            myEvents.Add("OnSendAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Access_SendMessage)))
            myEvents.Remove("OnSendAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Access_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of Access_SendMessage)) = CType(myEvents("OnSendAccess"), EventHandler(Of SendEventArgs(Of Access_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendChangeFace As EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage)) Implements IConnection(Of TPlayer).OnSendChangeFace
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage)))
            myEvents.Add("OnSendChangeFace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage)))
            myEvents.Remove("OnSendChangeFace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeFace_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage)) = CType(myEvents("OnSendChangeFace"), EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeFace", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendSaveWorld As EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage)) Implements IConnection(Of TPlayer).OnSendSaveWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage)))
            myEvents.Add("OnSendSaveWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage)))
            myEvents.Remove("OnSendSaveWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of SaveWorld_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage)) = CType(myEvents("OnSendSaveWorld"), EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSaveWorld", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendChangeWorldName As EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage)) Implements IConnection(Of TPlayer).OnSendChangeWorldName
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage)))
            myEvents.Add("OnSendChangeWorldName", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage)))
            myEvents.Remove("OnSendChangeWorldName", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeWorldName_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage)) = CType(myEvents("OnSendChangeWorldName"), EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeWorldName", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendChangeWorldEditKey As EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage)) Implements IConnection(Of TPlayer).OnSendChangeWorldEditKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage)))
            myEvents.Add("OnSendChangeWorldEditKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage)))
            myEvents.Remove("OnSendChangeWorldEditKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeWorldEditKey_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage)) = CType(myEvents("OnSendChangeWorldEditKey"), EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeWorldEditKey", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendClearWorld As EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage)) Implements IConnection(Of TPlayer).OnSendClearWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage)))
            myEvents.Add("OnSendClearWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage)))
            myEvents.Remove("OnSendClearWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ClearWorld_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage)) = CType(myEvents("OnSendClearWorld"), EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendClearWorld", ex)
            End Try
        End RaiseEvent
    End Event

    Friend Custom Event OnSendKillWorld As EventHandler(Of SendEventArgs(Of KillWorld_SendMessage)) Implements IConnection(Of TPlayer).OnSendKillWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of KillWorld_SendMessage)))
            myEvents.Add("OnSendKillWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of KillWorld_SendMessage)))
            myEvents.Remove("OnSendKillWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of KillWorld_SendMessage))
            Try
                Dim eevent As EventHandler(Of SendEventArgs(Of KillWorld_SendMessage)) = CType(myEvents("OnSendKillWorld"), EventHandler(Of SendEventArgs(Of KillWorld_SendMessage)))
                If eevent IsNot Nothing Then
                    Call eevent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendKillWorld", ex)
            End Try
        End RaiseEvent
    End Event
#End Region

#Region "Methods"
    Friend Sub New(internalConnection As InternalConnection, chatter As IChatter)
        Me.InternalConnection = internalConnection
        myChatter = chatter
        myPlayerManager = New PlayerManager(Of TPlayer)(internalConnection.InternalPlayerManager, internalConnection.DefaultConnection)
    End Sub

    Protected Sub New()
    End Sub

    Private Sub OnEventError(eventName As String, ex As Exception)
        Cloud.Logger.Log(LogPriority.Error, String.Format("Unable to pass event {0} to {1}.", eventName, ex.Source))
        Cloud.Logger.Log(ex)
    End Sub

    Private Sub myInternalConnection_OnDisconnect(sender As Object, e As String) Handles InternalConnection.OnDisconnect
        RaiseEvent OnDisconnect(Me, EventArgs.Empty)
    End Sub

    Private Sub myInternalConnection_OnMessage(sender As Object, e As ReceiveMessage) Handles InternalConnection.OnMessage
        RaiseEvent OnReceiveMessage(Me, e)
        Select Case e.GetType
            Case GetType(Init_ReceiveMessage)
                Dim m As Init_ReceiveMessage = CType(e, Init_ReceiveMessage)
                RaiseEvent OnReceiveInit(Me, m)

            Case GetType(GroupDisallowedJoin_ReceiveMessage)
                Dim m As GroupDisallowedJoin_ReceiveMessage = CType(e, GroupDisallowedJoin_ReceiveMessage)
                RaiseEvent OnReceiveGroupDisallowedJoin(Me, m)

            Case GetType(Info_ReceiveMessage)
                Dim m As Info_ReceiveMessage = CType(e, Info_ReceiveMessage)
                RaiseEvent OnReceiveInfo(Me, m)

            Case GetType(Upgrade_ReceiveMessage)
                Dim m As Upgrade_ReceiveMessage = CType(e, Upgrade_ReceiveMessage)
                RaiseEvent OnReceiveUpgrade(Me, m)

            Case GetType(UpdateMeta_ReceiveMessage)
                Dim m As UpdateMeta_ReceiveMessage = CType(e, UpdateMeta_ReceiveMessage)
                RaiseEvent OnReceiveUpdateMeta(Me, m)

            Case GetType(Add_ReceiveMessage)
                Dim m As Add_ReceiveMessage = CType(e, Add_ReceiveMessage)
                RaiseEvent OnReceiveAdd(Me, m)

            Case GetType(Left_ReceiveMessage)
                Dim m As Left_ReceiveMessage = CType(e, Left_ReceiveMessage)
                RaiseEvent OnReceiveLeft(Me, m)

            Case GetType(Move_ReceiveMessage)
                Dim m As Move_ReceiveMessage = CType(e, Move_ReceiveMessage)
                RaiseEvent OnReceiveMove(Me, m)

            Case GetType(Coin_ReceiveMessage)
                Dim m As Coin_ReceiveMessage = CType(e, Coin_ReceiveMessage)
                RaiseEvent OnReceiveCoin(Me, m)

            Case GetType(Crown_ReceiveMessage)
                Dim m As Crown_ReceiveMessage = CType(e, Crown_ReceiveMessage)
                RaiseEvent OnReceiveCrown(Me, m)

            Case GetType(SilverCrown_ReceiveMessage)
                Dim m As SilverCrown_ReceiveMessage = CType(e, SilverCrown_ReceiveMessage)
                RaiseEvent OnReceiveSilverCrown(Me, m)
            Case GetType(Face_ReceiveMessage)
                Dim m As Face_ReceiveMessage = CType(e, Face_ReceiveMessage)
                RaiseEvent OnReceiveFace(Me, m)

            Case GetType(ShowKey_ReceiveMessage)
                Dim m As ShowKey_ReceiveMessage = CType(e, ShowKey_ReceiveMessage)
                RaiseEvent OnReceiveShowKey(Me, m)

            Case GetType(HideKey_ReceiveMessage)
                Dim m As HideKey_ReceiveMessage = CType(e, HideKey_ReceiveMessage)
                RaiseEvent OnReceiveHideKey(Me, m)

            Case GetType(Say_ReceiveMessage)
                Dim m As Say_ReceiveMessage = CType(e, Say_ReceiveMessage)
                RaiseEvent OnReceiveSay(Me, m)

            Case GetType(SayOld_ReceiveMessage)
                Dim m As SayOld_ReceiveMessage = CType(e, SayOld_ReceiveMessage)
                RaiseEvent OnReceiveSayOld(Me, m)

            Case GetType(AutoText_ReceiveMessage)
                Dim m As AutoText_ReceiveMessage = CType(e, AutoText_ReceiveMessage)
                RaiseEvent OnReceiveAutoText(Me, m)

            Case GetType(Write_ReceiveMessage)
                Dim m As Write_ReceiveMessage = CType(e, Write_ReceiveMessage)
                RaiseEvent OnReceiveWrite(Me, m)

            Case GetType(BlockPlace_ReceiveMessage)
                Dim m As BlockPlace_ReceiveMessage = CType(e, BlockPlace_ReceiveMessage)
                RaiseEvent OnReceiveBlockPlace(Me, m)

            Case GetType(CoinDoorPlace_ReceiveMessage)
                Dim m As CoinDoorPlace_ReceiveMessage = CType(e, CoinDoorPlace_ReceiveMessage)
                RaiseEvent OnReceiveCoinDoorPlace(Me, m)
                RaiseEvent OnReceiveBlockPlace(Me, m)

            Case GetType(SoundPlace_ReceiveMessage)
                Dim m As SoundPlace_ReceiveMessage = CType(e, SoundPlace_ReceiveMessage)
                RaiseEvent OnReceiveSoundPlace(Me, m)
                RaiseEvent OnReceiveBlockPlace(Me, m)

            Case GetType(PortalPlace_ReceiveMessage)
                Dim m As PortalPlace_ReceiveMessage = CType(e, PortalPlace_ReceiveMessage)
                RaiseEvent OnReceivePortalPlace(Me, m)
                RaiseEvent OnReceiveBlockPlace(Me, m)

            Case GetType(LabelPlace_ReceiveMessage)
                Dim m As LabelPlace_ReceiveMessage = CType(e, LabelPlace_ReceiveMessage)
                RaiseEvent OnReceiveLabelPlace(Me, m)
                RaiseEvent OnReceiveBlockPlace(Me, m)

            Case GetType(GodMode_ReceiveMessage)
                Dim m As GodMode_ReceiveMessage = CType(e, GodMode_ReceiveMessage)
                RaiseEvent OnReceiveGodMode(Me, m)

            Case GetType(ModMode_ReceiveMessage)
                Dim m As ModMode_ReceiveMessage = CType(e, ModMode_ReceiveMessage)
                RaiseEvent OnReceiveModMode(Me, m)

            Case GetType(Access_ReceiveMessage)
                Dim m As Access_ReceiveMessage = CType(e, Access_ReceiveMessage)
                RaiseEvent OnReceiveAccess(Me, m)

            Case GetType(LostAccess_ReceiveMessage)
                Dim m As LostAccess_ReceiveMessage = CType(e, LostAccess_ReceiveMessage)
                RaiseEvent OnReceiveLostAccess(Me, m)

            Case GetType(Teleport_ReceiveMessage)
                Dim m As Teleport_ReceiveMessage = CType(e, Teleport_ReceiveMessage)
                RaiseEvent OnReceiveTeleport(Me, m)

            Case GetType(Reset_ReceiveMessage)
                Dim m As Reset_ReceiveMessage = CType(e, Reset_ReceiveMessage)
                RaiseEvent OnReceiveReset(Me, m)

            Case GetType(Clear_ReceiveMessage)
                Dim m As Clear_ReceiveMessage = CType(e, Clear_ReceiveMessage)
                RaiseEvent OnReceiveClear(Me, m)

            Case GetType(SaveDone_ReceiveMessage)
                Dim m As SaveDone_ReceiveMessage = CType(e, SaveDone_ReceiveMessage)
                RaiseEvent OnReceiveSaveDone(Me, m)

            Case GetType(RefreshShop_ReceiveMessage)
                Dim m As RefreshShop_ReceiveMessage = CType(e, RefreshShop_ReceiveMessage)
                RaiseEvent OnReceiveRefreshShop(Me, m)

            Case GetType(GiveWizard_ReceiveMessage)
                Dim m As GiveWizard_ReceiveMessage = CType(e, GiveWizard_ReceiveMessage)
                RaiseEvent OnReceiveGiveWizard(Me, m)

            Case GetType(GiveFireWizard_ReceiveMessage)
                Dim m As GiveFireWizard_ReceiveMessage = CType(e, GiveFireWizard_ReceiveMessage)
                RaiseEvent OnReceiveGiveFireWizard(Me, m)

            Case GetType(GiveWitch_ReceiveMessage)
                Dim m As GiveWitch_ReceiveMessage = CType(e, GiveWitch_ReceiveMessage)
                RaiseEvent OnReceiveGiveWitch(Me, m)

            Case GetType(GiveGrinch_ReceiveMessage)
                Dim m As GiveGrinch_ReceiveMessage = CType(e, GiveGrinch_ReceiveMessage)
                RaiseEvent OnReceiveGiveGrinch(Me, m)
        End Select
    End Sub

    Private Function RaiseSendEvent(message As SendMessage) As Boolean
        RaiseEvent OnSendMessage(Me, message)
        Select Case message.GetType
            Case GetType(Init_SendMessage)
                Dim eventArgs As New SendEventArgs(Of Init_SendMessage)(CType(message, Init_SendMessage))
                RaiseEvent OnSendInit(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(Init2_SendMessage)
                Dim eventArgs As New SendEventArgs(Of Init2_SendMessage)(CType(message, Init2_SendMessage))
                RaiseEvent OnSendInit2(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(BlockPlace_SendMessage)
                Dim eventArgs As New SendEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage))
                RaiseEvent OnSendBlockPlace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(CoinDoorPlace_SendMessage)
                Dim eventArgs As New SendEventArgs(Of CoinDoorPlace_SendMessage)(CType(message, CoinDoorPlace_SendMessage))
                RaiseEvent OnSendCoindoorPlace(Me, eventArgs)
                Dim blockEventArgs As New SendEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage))
                RaiseEvent OnSendBlockPlace(Me, blockEventArgs)
                Return eventArgs.Handled And blockEventArgs.Handled

            Case GetType(SoundPlace_SendMessage)
                Dim eventArgs As New SendEventArgs(Of SoundPlace_SendMessage)(CType(message, SoundPlace_SendMessage))
                RaiseEvent OnSendSoundPlace(Me, eventArgs)
                Dim blockEventArgs As New SendEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage))
                RaiseEvent OnSendBlockPlace(Me, blockEventArgs)
                Return eventArgs.Handled And blockEventArgs.Handled

            Case GetType(PortalPlace_SendMessage)
                Dim eventArgs As New SendEventArgs(Of PortalPlace_SendMessage)(CType(message, PortalPlace_SendMessage))
                RaiseEvent OnSendPortalPlace(Me, eventArgs)
                Dim blockEventArgs As New SendEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage))
                RaiseEvent OnSendBlockPlace(Me, blockEventArgs)
                Return eventArgs.Handled And blockEventArgs.Handled

            Case GetType(LabelPlace_SendMessage)
                Dim eventArgs As New SendEventArgs(Of LabelPlace_SendMessage)(CType(message, LabelPlace_SendMessage))
                RaiseEvent OnSendLabelPlace(Me, eventArgs)
                Dim blockEventArgs As New SendEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage))
                RaiseEvent OnSendBlockPlace(Me, blockEventArgs)
                Return eventArgs.Handled And blockEventArgs.Handled

            Case GetType(Coin_SendMessage)
                Dim eventArgs As New SendEventArgs(Of Coin_SendMessage)(CType(message, Coin_SendMessage))
                RaiseEvent OnSendCoin(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressRedKey_SendMessage)
                Dim eventArgs As New SendEventArgs(Of PressRedKey_SendMessage)(CType(message, PressRedKey_SendMessage))
                RaiseEvent OnSendPressRedKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressGreenKey_SendMessage)
                Dim eventArgs As New SendEventArgs(Of PressGreenKey_SendMessage)(CType(message, PressGreenKey_SendMessage))
                RaiseEvent OnSendPressGreenKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(PressBlueKey_SendMessage)
                Dim eventArgs As New SendEventArgs(Of PressBlueKey_SendMessage)(CType(message, PressBlueKey_SendMessage))
                RaiseEvent OnSendPressBlueKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(GetCrown_SendMessage)
                Dim eventArgs As New SendEventArgs(Of GetCrown_SendMessage)(CType(message, GetCrown_SendMessage))
                RaiseEvent OnSendGetCrown(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(TouchDiamond_SendMessage)
                Dim eventArgs As New SendEventArgs(Of TouchDiamond_SendMessage)(CType(message, TouchDiamond_SendMessage))
                RaiseEvent OnSendTouchDiamond(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(CompleteLevel_SendMessage)
                Dim eventArgs As New SendEventArgs(Of CompleteLevel_SendMessage)(CType(message, CompleteLevel_SendMessage))
                RaiseEvent OnSendCompleteLevel(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(GodMode_SendMessage)
                Dim eventArgs As New SendEventArgs(Of GodMode_SendMessage)(CType(message, GodMode_SendMessage))
                RaiseEvent OnSendGodMode(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ModMode_SendMessage)
                Dim eventArgs As New SendEventArgs(Of ModMode_SendMessage)(CType(message, ModMode_SendMessage))
                RaiseEvent OnSendModMode(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(Move_SendMessage)
                Dim eventArgs As New SendEventArgs(Of Move_SendMessage)(CType(message, Move_SendMessage))
                RaiseEvent OnSendMove(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(Say_SendMessage)
                Dim eventArgs As New SendEventArgs(Of Say_SendMessage)(CType(message, Say_SendMessage))
                RaiseEvent OnSendSay(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(AutoSay_SendMessage)
                Dim eventArgs As New SendEventArgs(Of AutoSay_SendMessage)(CType(message, AutoSay_SendMessage))
                RaiseEvent OnSendAutoSay(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(Access_SendMessage)
                Dim eventArgs As New SendEventArgs(Of Access_SendMessage)(CType(message, Access_SendMessage))
                RaiseEvent OnSendAccess(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeFace_SendMessage)
                Dim eventArgs As New SendEventArgs(Of ChangeFace_SendMessage)(CType(message, ChangeFace_SendMessage))
                RaiseEvent OnSendChangeFace(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(SaveWorld_SendMessage)
                Dim eventArgs As New SendEventArgs(Of SaveWorld_SendMessage)(CType(message, SaveWorld_SendMessage))
                RaiseEvent OnSendSaveWorld(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeWorldName_SendMessage)
                Dim eventArgs As New SendEventArgs(Of ChangeWorldName_SendMessage)(CType(message, ChangeWorldName_SendMessage))
                RaiseEvent OnSendChangeWorldName(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ChangeWorldEditKey_SendMessage)
                Dim eventArgs As New SendEventArgs(Of ChangeWorldEditKey_SendMessage)(CType(message, ChangeWorldEditKey_SendMessage))
                RaiseEvent OnSendChangeWorldEditKey(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(ClearWorld_SendMessage)
                Dim eventArgs As New SendEventArgs(Of ClearWorld_SendMessage)(CType(message, ClearWorld_SendMessage))
                RaiseEvent OnSendClearWorld(Me, eventArgs)
                Return eventArgs.Handled

            Case GetType(KillWorld_SendMessage)
                Dim eventArgs As New SendEventArgs(Of KillWorld_SendMessage)(CType(message, KillWorld_SendMessage))
                RaiseEvent OnSendKillWorld(Me, eventArgs)
                Return eventArgs.Handled
            Case Else
                Return False
        End Select
    End Function

    Friend Sub Send(message As SendMessage) Implements IConnection(Of TPlayer).Send
        If Not RaiseSendEvent(message) Then
            InternalConnection.Send(message)
        End If
    End Sub
#End Region
End Class
