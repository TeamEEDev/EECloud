Public Class Connection(Of P As {Player, New})
    Implements IConnection(Of P)

#Region "Fields"
    Private WithEvents myInternalConnection As InternalConnection
    Private myEvents As New EventHandlerList
    Private myInternalChatter As InternalChatter
#End Region

#Region "Properties"
    Friend ReadOnly Property InternalChatter As InternalChatter
        Get
            Return myInternalConnection.InternalChatter
        End Get
    End Property

    Friend ReadOnly Property DefaultChatter As IChatter
        Get
            Return myInternalConnection.DefaultChatter
        End Get
    End Property

    Public ReadOnly Property WorldID As String Implements IConnection(Of P).WorldID
        Get
            Return myInternalConnection.WorldID
        End Get
    End Property

    Public ReadOnly Property World As World Implements IConnection(Of P).World
        Get
            Return myInternalConnection.World
        End Get
    End Property

    Public ReadOnly Property IsMainConnection As Boolean Implements IConnection(Of P).IsMainConnection
        Get
            Return myInternalConnection.IsMainConnection
        End Get
    End Property

    Public ReadOnly Property Connected As Boolean Implements IConnection(Of P).Connected
        Get
            Return myInternalConnection.Connected
        End Get
    End Property

    Private myPlayersDictionary As New Dictionary(Of Integer, P)
    Public ReadOnly Property Players(number As Integer) As P Implements IConnection(Of P).Players
        Get
            If myPlayersDictionary.ContainsKey(number) Then
                Return myPlayersDictionary(number)
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public ReadOnly Property Players As IEnumerable(Of P) Implements IConnection(Of P).Players
        Get
            Try
                Return myPlayersDictionary.Values
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Private myCrown As P
    Public ReadOnly Property Crown As P Implements IConnection(Of P).Crown
        Get
            Return myCrown
        End Get
    End Property

    Friend ReadOnly Property DefaultConnection As Connection(Of Player)
        Get
            Return myInternalConnection.DefaultConnection
        End Get
    End Property

    Public ReadOnly Property Encryption As String Implements IConnection(Of P).Encryption
        Get
            Return myInternalConnection.Encryption
        End Get
    End Property
#End Region

#Region "Events"
    Public Custom Event OnReceiveMessage As EventHandler(Of ReceiveMessage) Implements IConnection(Of P).OnReceiveMessage
        AddHandler(value As EventHandler(Of ReceiveMessage))
            myEvents.Add("OnReceiveMessage", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ReceiveMessage))
            myEvents.Remove("OnReceiveMessage", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of ReceiveMessage) = CType(myEvents("OnReceiveMessage"), EventHandler(Of ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveMessage", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnDisconnect As EventHandler(Of EventArgs) Implements IConnection(Of P).OnDisconnect
        AddHandler(value As EventHandler(Of EventArgs))
            myEvents.Add("OnDisconnect", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of EventArgs))
            myEvents.Remove("OnDisconnect", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As EventArgs)
            Try
                Dim myEvent As EventHandler(Of EventArgs) = CType(myEvents("OnDisconnect"), EventHandler(Of EventArgs))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnDisconnect", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveAccess As EventHandler(Of Access_ReceiveMessage) Implements IConnection(Of P).OnReceiveAccess
        AddHandler(value As EventHandler(Of Access_ReceiveMessage))
            myEvents.Add("OnReceiveAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Access_ReceiveMessage))
            myEvents.Remove("OnReceiveAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Access_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Access_ReceiveMessage) = CType(myEvents("OnReceiveAccess"), EventHandler(Of Access_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveAdd As EventHandler(Of Add_ReceiveMessage) Implements IConnection(Of P).OnReceiveAdd
        AddHandler(value As EventHandler(Of Add_ReceiveMessage))
            myEvents.Add("OnReceiveAdd", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Add_ReceiveMessage))
            myEvents.Remove("OnReceiveAdd", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Add_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Add_ReceiveMessage) = CType(myEvents("OnReceiveAdd"), EventHandler(Of Add_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveAdd", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveAutoText As EventHandler(Of AutoText_ReceiveMessage) Implements IConnection(Of P).OnReceiveAutoText
        AddHandler(value As EventHandler(Of AutoText_ReceiveMessage))
            myEvents.Add("OnReceiveAutoText", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of AutoText_ReceiveMessage))
            myEvents.Remove("OnReceiveAutoText", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As AutoText_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of AutoText_ReceiveMessage) = CType(myEvents("OnReceiveAutoText"), EventHandler(Of AutoText_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveAutoText", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveBlockPlace As EventHandler(Of BlockPlace_ReceiveMessage) Implements IConnection(Of P).OnReceiveBlockPlace
        AddHandler(value As EventHandler(Of BlockPlace_ReceiveMessage))
            myEvents.Add("OnReceiveBlockPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of BlockPlace_ReceiveMessage))
            myEvents.Remove("OnReceiveBlockPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As BlockPlace_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of BlockPlace_ReceiveMessage) = CType(myEvents("OnReceiveBlockPlace"), EventHandler(Of BlockPlace_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveBlockPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveClear As EventHandler(Of Clear_ReceiveMessage) Implements IConnection(Of P).OnReceiveClear
        AddHandler(value As EventHandler(Of Clear_ReceiveMessage))
            myEvents.Add("OnReceiveClear", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Clear_ReceiveMessage))
            myEvents.Remove("OnReceiveClear", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Clear_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Clear_ReceiveMessage) = CType(myEvents("OnReceiveClear"), EventHandler(Of Clear_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveClear", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveCoin As EventHandler(Of Coin_ReceiveMessage) Implements IConnection(Of P).OnReceiveCoin
        AddHandler(value As EventHandler(Of Coin_ReceiveMessage))
            myEvents.Add("OnReceiveCoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Coin_ReceiveMessage))
            myEvents.Remove("OnReceiveCoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Coin_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Coin_ReceiveMessage) = CType(myEvents("OnReceiveCoin"), EventHandler(Of Coin_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveCoin", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveCoinDoorPlace As EventHandler(Of CoinDoorPlace_ReceiveMessage) Implements IConnection(Of P).OnReceiveCoinDoorPlace
        AddHandler(value As EventHandler(Of CoinDoorPlace_ReceiveMessage))
            myEvents.Add("OnReceiveCoinDoorPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of CoinDoorPlace_ReceiveMessage))
            myEvents.Remove("OnReceiveCoinDoorPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As CoinDoorPlace_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of CoinDoorPlace_ReceiveMessage) = CType(myEvents("OnReceiveCoinDoorPlace"), EventHandler(Of CoinDoorPlace_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveCoinDoorPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveCrown As EventHandler(Of Crown_ReceiveMessage) Implements IConnection(Of P).OnReceiveCrown
        AddHandler(value As EventHandler(Of Crown_ReceiveMessage))
            myEvents.Add("OnReceiveCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Crown_ReceiveMessage))
            myEvents.Remove("OnReceiveCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Crown_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Crown_ReceiveMessage) = CType(myEvents("OnReceiveCrown"), EventHandler(Of Crown_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveFace As EventHandler(Of Face_ReceiveMessage) Implements IConnection(Of P).OnReceiveFace
        AddHandler(value As EventHandler(Of Face_ReceiveMessage))
            myEvents.Add("OnReceiveFace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Face_ReceiveMessage))
            myEvents.Remove("OnReceiveFace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Face_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Face_ReceiveMessage) = CType(myEvents("OnReceiveFace"), EventHandler(Of Face_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveFace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveGiveFireWizard As EventHandler(Of GiveFireWizard_ReceiveMessage) Implements IConnection(Of P).OnReceiveGiveFireWizard
        AddHandler(value As EventHandler(Of GiveFireWizard_ReceiveMessage))
            myEvents.Add("OnReceiveGiveFireWizard", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveFireWizard_ReceiveMessage))
            myEvents.Remove("OnReceiveGiveFireWizard", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveFireWizard_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of GiveFireWizard_ReceiveMessage) = CType(myEvents("OnReceiveGiveFireWizard"), EventHandler(Of GiveFireWizard_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveFireWizard", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveGiveGrinch As EventHandler(Of GiveGrinch_ReceiveMessage) Implements IConnection(Of P).OnReceiveGiveGrinch
        AddHandler(value As EventHandler(Of GiveGrinch_ReceiveMessage))
            myEvents.Add("OnReceiveGiveGrinch", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveGrinch_ReceiveMessage))
            myEvents.Remove("OnReceiveGiveGrinch", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveGrinch_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of GiveGrinch_ReceiveMessage) = CType(myEvents("OnReceiveGiveGrinch"), EventHandler(Of GiveGrinch_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveGrinch", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveGiveWitch As EventHandler(Of GiveWitch_ReceiveMessage) Implements IConnection(Of P).OnReceiveGiveWitch
        AddHandler(value As EventHandler(Of GiveWitch_ReceiveMessage))
            myEvents.Add("OnReceiveGiveWitch", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveWitch_ReceiveMessage))
            myEvents.Remove("OnReceiveGiveWitch", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveWitch_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of GiveWitch_ReceiveMessage) = CType(myEvents("OnReceiveGiveWitch"), EventHandler(Of GiveWitch_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveWitch", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveGiveWizard As EventHandler(Of GiveWizard_ReceiveMessage) Implements IConnection(Of P).OnReceiveGiveWizard
        AddHandler(value As EventHandler(Of GiveWizard_ReceiveMessage))
            myEvents.Add("OnReceiveGiveWizard", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveWizard_ReceiveMessage))
            myEvents.Remove("OnReceiveGiveWizard", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveWizard_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of GiveWizard_ReceiveMessage) = CType(myEvents("OnReceiveGiveWizard"), EventHandler(Of GiveWizard_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGiveWizard", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveGodMode As EventHandler(Of GodMode_ReceiveMessage) Implements IConnection(Of P).OnReceiveGodMode
        AddHandler(value As EventHandler(Of GodMode_ReceiveMessage))
            myEvents.Add("OnReceiveGodMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GodMode_ReceiveMessage))
            myEvents.Remove("OnReceiveGodMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GodMode_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of GodMode_ReceiveMessage) = CType(myEvents("OnReceiveGodMode"), EventHandler(Of GodMode_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGodMode", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveGroupDisallowedJoin As EventHandler(Of GroupDisallowedJoin_ReceiveMessage) Implements IConnection(Of P).OnReceiveGroupDisallowedJoin
        AddHandler(value As EventHandler(Of GroupDisallowedJoin_ReceiveMessage))
            myEvents.Add("OnReceiveGroupDisallowedJoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GroupDisallowedJoin_ReceiveMessage))
            myEvents.Remove("OnReceiveGroupDisallowedJoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GroupDisallowedJoin_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of GroupDisallowedJoin_ReceiveMessage) = CType(myEvents("OnReceiveGroupDisallowedJoin"), EventHandler(Of GroupDisallowedJoin_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveGroupDisallowedJoin", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveHideKey As EventHandler(Of HideKey_ReceiveMessage) Implements IConnection(Of P).OnReceiveHideKey
        AddHandler(value As EventHandler(Of HideKey_ReceiveMessage))
            myEvents.Add("OnReceiveHideKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of HideKey_ReceiveMessage))
            myEvents.Remove("OnReceiveHideKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As HideKey_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of HideKey_ReceiveMessage) = CType(myEvents("OnReceiveHideKey"), EventHandler(Of HideKey_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveHideKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveInfo As EventHandler(Of Info_ReceiveMessage) Implements IConnection(Of P).OnReceiveInfo
        AddHandler(value As EventHandler(Of Info_ReceiveMessage))
            myEvents.Add("OnReceiveInfo", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Info_ReceiveMessage))
            myEvents.Remove("OnReceiveInfo", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Info_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Info_ReceiveMessage) = CType(myEvents("OnReceiveInfo"), EventHandler(Of Info_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveInfo", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveInit As EventHandler(Of Init_ReceiveMessage) Implements IConnection(Of P).OnReceiveInit
        AddHandler(value As EventHandler(Of Init_ReceiveMessage))
            myEvents.Add("OnReceiveInit", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Init_ReceiveMessage))
            myEvents.Remove("OnReceiveInit", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Init_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Init_ReceiveMessage) = CType(myEvents("OnReceiveInit"), EventHandler(Of Init_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveInit", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveLabelPlace As EventHandler(Of LabelPlace_ReceiveMessage) Implements IConnection(Of P).OnReceiveLabelPlace
        AddHandler(value As EventHandler(Of LabelPlace_ReceiveMessage))
            myEvents.Add("OnReceiveLabelPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LabelPlace_ReceiveMessage))
            myEvents.Remove("OnReceiveLabelPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LabelPlace_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of LabelPlace_ReceiveMessage) = CType(myEvents("OnReceiveLabelPlace"), EventHandler(Of LabelPlace_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveLabelPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveLeft As EventHandler(Of Left_ReceiveMessage) Implements IConnection(Of P).OnReceiveLeft
        AddHandler(value As EventHandler(Of Left_ReceiveMessage))
            myEvents.Add("OnReceiveLeft", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Left_ReceiveMessage))
            myEvents.Remove("OnReceiveLeft", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Left_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Left_ReceiveMessage) = CType(myEvents("OnReceiveLeft"), EventHandler(Of Left_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveLeft", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveLostAccess As EventHandler(Of LostAccess_ReceiveMessage) Implements IConnection(Of P).OnReceiveLostAccess
        AddHandler(value As EventHandler(Of LostAccess_ReceiveMessage))
            myEvents.Add("OnReceiveLostAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LostAccess_ReceiveMessage))
            myEvents.Remove("OnReceiveLostAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LostAccess_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of LostAccess_ReceiveMessage) = CType(myEvents("OnReceiveLostAccess"), EventHandler(Of LostAccess_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveLostAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveModMode As EventHandler(Of ModMode_ReceiveMessage) Implements IConnection(Of P).OnReceiveModMode
        AddHandler(value As EventHandler(Of ModMode_ReceiveMessage))
            myEvents.Add("OnReceiveModMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ModMode_ReceiveMessage))
            myEvents.Remove("OnReceiveModMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ModMode_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of ModMode_ReceiveMessage) = CType(myEvents("OnReceiveModMode"), EventHandler(Of ModMode_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveModMode", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveMove As EventHandler(Of Move_ReceiveMessage) Implements IConnection(Of P).OnReceiveMove
        AddHandler(value As EventHandler(Of Move_ReceiveMessage))
            myEvents.Add("OnReceiveMove", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Move_ReceiveMessage))
            myEvents.Remove("OnReceiveMove", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Move_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Move_ReceiveMessage) = CType(myEvents("OnReceiveMove"), EventHandler(Of Move_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveMove", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceivePortalPlace As EventHandler(Of PortalPlace_ReceiveMessage) Implements IConnection(Of P).OnReceivePortalPlace
        AddHandler(value As EventHandler(Of PortalPlace_ReceiveMessage))
            myEvents.Add("OnReceivePortalPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of PortalPlace_ReceiveMessage))
            myEvents.Remove("OnReceivePortalPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As PortalPlace_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of PortalPlace_ReceiveMessage) = CType(myEvents("OnReceivePortalPlace"), EventHandler(Of PortalPlace_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceivePortalPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveRefreshShop As EventHandler(Of RefreshShop_ReceiveMessage) Implements IConnection(Of P).OnReceiveRefreshShop
        AddHandler(value As EventHandler(Of RefreshShop_ReceiveMessage))
            myEvents.Add("OnReceiveRefreshShop", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of RefreshShop_ReceiveMessage))
            myEvents.Remove("OnReceiveRefreshShop", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As RefreshShop_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of RefreshShop_ReceiveMessage) = CType(myEvents("OnReceiveRefreshShop"), EventHandler(Of RefreshShop_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveRefreshShop", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveReset As EventHandler(Of Reset_ReceiveMessage) Implements IConnection(Of P).OnReceiveReset
        AddHandler(value As EventHandler(Of Reset_ReceiveMessage))
            myEvents.Add("OnReceiveReset", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Reset_ReceiveMessage))
            myEvents.Remove("OnReceiveReset", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Reset_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Reset_ReceiveMessage) = CType(myEvents("OnReceiveReset"), EventHandler(Of Reset_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveReset", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveSaveDone As EventHandler(Of SaveDone_ReceiveMessage) Implements IConnection(Of P).OnReceiveSaveDone
        AddHandler(value As EventHandler(Of SaveDone_ReceiveMessage))
            myEvents.Add("OnReceiveSaveDone", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SaveDone_ReceiveMessage))
            myEvents.Remove("OnReceiveSaveDone", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SaveDone_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of SaveDone_ReceiveMessage) = CType(myEvents("OnReceiveSaveDone"), EventHandler(Of SaveDone_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSaveDone", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveSay As EventHandler(Of Say_ReceiveMessage) Implements IConnection(Of P).OnReceiveSay
        AddHandler(value As EventHandler(Of Say_ReceiveMessage))
            myEvents.Add("OnReceiveSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Say_ReceiveMessage))
            myEvents.Remove("OnReceiveSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Say_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Say_ReceiveMessage) = CType(myEvents("OnReceiveSay"), EventHandler(Of Say_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSay", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveSayOld As EventHandler(Of SayOld_ReceiveMessage) Implements IConnection(Of P).OnReceiveSayOld
        AddHandler(value As EventHandler(Of SayOld_ReceiveMessage))
            myEvents.Add("OnReceiveSayOld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SayOld_ReceiveMessage))
            myEvents.Remove("OnReceiveSayOld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SayOld_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of SayOld_ReceiveMessage) = CType(myEvents("OnReceiveSayOld"), EventHandler(Of SayOld_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSayOld", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveShowKey As EventHandler(Of ShowKey_ReceiveMessage) Implements IConnection(Of P).OnReceiveShowKey
        AddHandler(value As EventHandler(Of ShowKey_ReceiveMessage))
            myEvents.Add("OnReceiveShowKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ShowKey_ReceiveMessage))
            myEvents.Remove("OnReceiveShowKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ShowKey_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of ShowKey_ReceiveMessage) = CType(myEvents("OnReceiveShowKey"), EventHandler(Of ShowKey_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveShowKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveSilverCrown As EventHandler(Of SilverCrown_ReceiveMessage) Implements IConnection(Of P).OnReceiveSilverCrown
        AddHandler(value As EventHandler(Of SilverCrown_ReceiveMessage))
            myEvents.Add("OnReceiveSilverCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SilverCrown_ReceiveMessage))
            myEvents.Remove("OnReceiveSilverCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SilverCrown_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of SilverCrown_ReceiveMessage) = CType(myEvents("OnReceiveSilverCrown"), EventHandler(Of SilverCrown_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSilverCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveSoundPlace As EventHandler(Of SoundPlace_ReceiveMessage) Implements IConnection(Of P).OnReceiveSoundPlace
        AddHandler(value As EventHandler(Of SoundPlace_ReceiveMessage))
            myEvents.Add("OnReceiveSoundPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SoundPlace_ReceiveMessage))
            myEvents.Remove("OnReceiveSoundPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SoundPlace_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of SoundPlace_ReceiveMessage) = CType(myEvents("OnReceiveSoundPlace"), EventHandler(Of SoundPlace_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveSoundPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveTeleport As EventHandler(Of Teleport_ReceiveMessage) Implements IConnection(Of P).OnReceiveTeleport
        AddHandler(value As EventHandler(Of Teleport_ReceiveMessage))
            myEvents.Add("OnReceiveTeleport", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Teleport_ReceiveMessage))
            myEvents.Remove("OnReceiveTeleport", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Teleport_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Teleport_ReceiveMessage) = CType(myEvents("OnReceiveTeleport"), EventHandler(Of Teleport_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveTeleport", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveUpdateMeta As EventHandler(Of UpdateMeta_ReceiveMessage) Implements IConnection(Of P).OnReceiveUpdateMeta
        AddHandler(value As EventHandler(Of UpdateMeta_ReceiveMessage))
            myEvents.Add("OnReceiveUpdateMeta", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of UpdateMeta_ReceiveMessage))
            myEvents.Remove("OnReceiveUpdateMeta", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As UpdateMeta_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of UpdateMeta_ReceiveMessage) = CType(myEvents("OnReceiveUpdateMeta"), EventHandler(Of UpdateMeta_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveUpdateMeta", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveUpgrade As EventHandler(Of Upgrade_ReceiveMessage) Implements IConnection(Of P).OnReceiveUpgrade
        AddHandler(value As EventHandler(Of Upgrade_ReceiveMessage))
            myEvents.Add("OnReceiveUpgrade", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Upgrade_ReceiveMessage))
            myEvents.Remove("OnReceiveUpgrade", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Upgrade_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Upgrade_ReceiveMessage) = CType(myEvents("OnReceiveUpgrade"), EventHandler(Of Upgrade_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveUpgrade", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReceiveWrite As EventHandler(Of Write_ReceiveMessage) Implements IConnection(Of P).OnReceiveWrite
        AddHandler(value As EventHandler(Of Write_ReceiveMessage))
            myEvents.Add("OnReceiveWrite", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Write_ReceiveMessage))
            myEvents.Remove("OnReceiveWrite", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Write_ReceiveMessage)
            Try
                Dim myEvent As EventHandler(Of Write_ReceiveMessage) = CType(myEvents("OnReceiveWrite"), EventHandler(Of Write_ReceiveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReceiveWrite", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendMessage As EventHandler(Of SendMessage) Implements IConnection(Of P).OnSendMessage
        AddHandler(value As EventHandler(Of SendMessage))
            myEvents.Add("OnSendMessage", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendMessage))
            myEvents.Remove("OnSendMessage", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendMessage)
            Try
                Dim myEvent As EventHandler(Of SendMessage) = CType(myEvents("OnSendMessage"), EventHandler(Of SendMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendMessage", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendInit As EventHandler(Of SendEventArgs(Of Init_SendMessage)) Implements IConnection(Of P).OnSendInit
        AddHandler(value As EventHandler(Of SendEventArgs(Of Init_SendMessage)))
            myEvents.Add("OnSendInit", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Init_SendMessage)))
            myEvents.Remove("OnSendInit", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Init_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of Init_SendMessage)) = CType(myEvents("OnSendInit"), EventHandler(Of SendEventArgs(Of Init_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendInit", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendInit2 As EventHandler(Of SendEventArgs(Of Init2_SendMessage)) Implements IConnection(Of P).OnSendInit2
        AddHandler(value As EventHandler(Of SendEventArgs(Of Init2_SendMessage)))
            myEvents.Add("OnSendInit2", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Init2_SendMessage)))
            myEvents.Remove("OnSendInit2", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Init2_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of Init2_SendMessage)) = CType(myEvents("OnSendInit2"), EventHandler(Of SendEventArgs(Of Init2_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendInit2", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendBlockPlace As EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage)) Implements IConnection(Of P).OnSendBlockPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage)))
            myEvents.Add("OnSendBlockPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage)))
            myEvents.Remove("OnSendBlockPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of BlockPlace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage)) = CType(myEvents("OnSendBlockPlace"), EventHandler(Of SendEventArgs(Of BlockPlace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendBlockPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendCoindoorPlace As EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage)) Implements IConnection(Of P).OnSendCoindoorPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage)))
            myEvents.Add("OnSendCoindoorPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage)))
            myEvents.Remove("OnSendCoindoorPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of CoinDoorPlace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage)) = CType(myEvents("OnSendCoindoorPlace"), EventHandler(Of SendEventArgs(Of CoinDoorPlace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCoindoorPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendSoundPlace As EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage)) Implements IConnection(Of P).OnSendSoundPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage)))
            myEvents.Add("OnSendSoundPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage)))
            myEvents.Remove("OnSendSoundPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of SoundPlace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage)) = CType(myEvents("OnSendSoundPlace"), EventHandler(Of SendEventArgs(Of SoundPlace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSoundPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendPortalPlace As EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage)) Implements IConnection(Of P).OnSendPortalPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage)))
            myEvents.Add("OnSendPortalPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage)))
            myEvents.Remove("OnSendPortalPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PortalPlace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage)) = CType(myEvents("OnSendPortalPlace"), EventHandler(Of SendEventArgs(Of PortalPlace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPortalPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendLabelPlace As EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage)) Implements IConnection(Of P).OnSendLabelPlace
        AddHandler(value As EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage)))
            myEvents.Add("OnSendLabelPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage)))
            myEvents.Remove("OnSendLabelPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of LabelPlace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage)) = CType(myEvents("OnSendLabelPlace"), EventHandler(Of SendEventArgs(Of LabelPlace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendLabelPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendCoin As EventHandler(Of SendEventArgs(Of Coin_SendMessage)) Implements IConnection(Of P).OnSendCoin
        AddHandler(value As EventHandler(Of SendEventArgs(Of Coin_SendMessage)))
            myEvents.Add("OnSendCoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Coin_SendMessage)))
            myEvents.Remove("OnSendCoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Coin_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of Coin_SendMessage)) = CType(myEvents("OnSendCoin"), EventHandler(Of SendEventArgs(Of Coin_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCoin", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendPressRedKey As EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage)) Implements IConnection(Of P).OnSendPressRedKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage)))
            myEvents.Add("OnSendPressRedKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage)))
            myEvents.Remove("OnSendPressRedKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressRedKey_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage)) = CType(myEvents("OnSendPressRedKey"), EventHandler(Of SendEventArgs(Of PressRedKey_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressRedKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendPressGreenKey As EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage)) Implements IConnection(Of P).OnSendPressGreenKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage)))
            myEvents.Add("OnSendPressGreenKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage)))
            myEvents.Remove("OnSendPressGreenKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressGreenKey_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage)) = CType(myEvents("OnSendPressGreenKey"), EventHandler(Of SendEventArgs(Of PressGreenKey_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressGreenKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendPressBlueKey As EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage)) Implements IConnection(Of P).OnSendPressBlueKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage)))
            myEvents.Add("OnSendPressBlueKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage)))
            myEvents.Remove("OnSendPressBlueKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of PressBlueKey_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage)) = CType(myEvents("OnSendPressBlueKey"), EventHandler(Of SendEventArgs(Of PressBlueKey_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressBlueKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendGetCrown As EventHandler(Of SendEventArgs(Of GetCrown_SendMessage)) Implements IConnection(Of P).OnSendGetCrown
        AddHandler(value As EventHandler(Of SendEventArgs(Of GetCrown_SendMessage)))
            myEvents.Add("OnSendGetCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of GetCrown_SendMessage)))
            myEvents.Remove("OnSendGetCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of GetCrown_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of GetCrown_SendMessage)) = CType(myEvents("OnSendGetCrown"), EventHandler(Of SendEventArgs(Of GetCrown_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendGetCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendTouchDiamond As EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage)) Implements IConnection(Of P).OnSendTouchDiamond
        AddHandler(value As EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage)))
            myEvents.Add("OnSendTouchDiamond", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage)))
            myEvents.Remove("OnSendTouchDiamond", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of TouchDiamond_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage)) = CType(myEvents("OnSendTouchDiamond"), EventHandler(Of SendEventArgs(Of TouchDiamond_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendTouchDiamond", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendCompleteLevel As EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage)) Implements IConnection(Of P).OnSendCompleteLevel
        AddHandler(value As EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage)))
            myEvents.Add("OnSendCompleteLevel", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage)))
            myEvents.Remove("OnSendCompleteLevel", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of CompleteLevel_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage)) = CType(myEvents("OnSendCompleteLevel"), EventHandler(Of SendEventArgs(Of CompleteLevel_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCompleteLevel", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendGodMode As EventHandler(Of SendEventArgs(Of GodMode_SendMessage)) Implements IConnection(Of P).OnSendGodMode
        AddHandler(value As EventHandler(Of SendEventArgs(Of GodMode_SendMessage)))
            myEvents.Add("OnSendGodMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of GodMode_SendMessage)))
            myEvents.Remove("OnSendGodMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of GodMode_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of GodMode_SendMessage)) = CType(myEvents("OnSendGodMode"), EventHandler(Of SendEventArgs(Of GodMode_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendGodMode", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendModMode As EventHandler(Of SendEventArgs(Of ModMode_SendMessage)) Implements IConnection(Of P).OnSendModMode
        AddHandler(value As EventHandler(Of SendEventArgs(Of ModMode_SendMessage)))
            myEvents.Add("OnSendModMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ModMode_SendMessage)))
            myEvents.Remove("OnSendModMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ModMode_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of ModMode_SendMessage)) = CType(myEvents("OnSendModMode"), EventHandler(Of SendEventArgs(Of ModMode_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendModMode", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendMove As EventHandler(Of SendEventArgs(Of Move_SendMessage)) Implements IConnection(Of P).OnSendMove
        AddHandler(value As EventHandler(Of SendEventArgs(Of Move_SendMessage)))
            myEvents.Add("OnSendMove", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Move_SendMessage)))
            myEvents.Remove("OnSendMove", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Move_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of Move_SendMessage)) = CType(myEvents("OnSendMove"), EventHandler(Of SendEventArgs(Of Move_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendMove", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendSay As EventHandler(Of SendEventArgs(Of Say_SendMessage)) Implements IConnection(Of P).OnSendSay
        AddHandler(value As EventHandler(Of SendEventArgs(Of Say_SendMessage)))
            myEvents.Add("OnSendSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Say_SendMessage)))
            myEvents.Remove("OnSendSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Say_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of Say_SendMessage)) = CType(myEvents("OnSendSay"), EventHandler(Of SendEventArgs(Of Say_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSay", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendAutoSay As EventHandler(Of SendEventArgs(Of AutoSay_SendMessage)) Implements IConnection(Of P).OnSendAutoSay
        AddHandler(value As EventHandler(Of SendEventArgs(Of AutoSay_SendMessage)))
            myEvents.Add("OnSendAutoSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of AutoSay_SendMessage)))
            myEvents.Remove("OnSendAutoSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of AutoSay_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of AutoSay_SendMessage)) = CType(myEvents("OnSendAutoSay"), EventHandler(Of SendEventArgs(Of AutoSay_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendAutoSay", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendAccess As EventHandler(Of SendEventArgs(Of Access_SendMessage)) Implements IConnection(Of P).OnSendAccess
        AddHandler(value As EventHandler(Of SendEventArgs(Of Access_SendMessage)))
            myEvents.Add("OnSendAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of Access_SendMessage)))
            myEvents.Remove("OnSendAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of Access_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of Access_SendMessage)) = CType(myEvents("OnSendAccess"), EventHandler(Of SendEventArgs(Of Access_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendChangeFace As EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage)) Implements IConnection(Of P).OnSendChangeFace
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage)))
            myEvents.Add("OnSendChangeFace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage)))
            myEvents.Remove("OnSendChangeFace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeFace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage)) = CType(myEvents("OnSendChangeFace"), EventHandler(Of SendEventArgs(Of ChangeFace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeFace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendSaveWorld As EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage)) Implements IConnection(Of P).OnSendSaveWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage)))
            myEvents.Add("OnSendSaveWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage)))
            myEvents.Remove("OnSendSaveWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of SaveWorld_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage)) = CType(myEvents("OnSendSaveWorld"), EventHandler(Of SendEventArgs(Of SaveWorld_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSaveWorld", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendChangeWorldName As EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage)) Implements IConnection(Of P).OnSendChangeWorldName
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage)))
            myEvents.Add("OnSendChangeWorldName", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage)))
            myEvents.Remove("OnSendChangeWorldName", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeWorldName_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage)) = CType(myEvents("OnSendChangeWorldName"), EventHandler(Of SendEventArgs(Of ChangeWorldName_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeWorldName", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendChangeWorldEditKey As EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage)) Implements IConnection(Of P).OnSendChangeWorldEditKey
        AddHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage)))
            myEvents.Add("OnSendChangeWorldEditKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage)))
            myEvents.Remove("OnSendChangeWorldEditKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ChangeWorldEditKey_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage)) = CType(myEvents("OnSendChangeWorldEditKey"), EventHandler(Of SendEventArgs(Of ChangeWorldEditKey_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeWorldEditKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendClearWorld As EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage)) Implements IConnection(Of P).OnSendClearWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage)))
            myEvents.Add("OnSendClearWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage)))
            myEvents.Remove("OnSendClearWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of ClearWorld_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage)) = CType(myEvents("OnSendClearWorld"), EventHandler(Of SendEventArgs(Of ClearWorld_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendClearWorld", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendKillWorld As EventHandler(Of SendEventArgs(Of KillWorld_SendMessage)) Implements IConnection(Of P).OnSendKillWorld
        AddHandler(value As EventHandler(Of SendEventArgs(Of KillWorld_SendMessage)))
            myEvents.Add("OnSendKillWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SendEventArgs(Of KillWorld_SendMessage)))
            myEvents.Remove("OnSendKillWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SendEventArgs(Of KillWorld_SendMessage))
            Try
                Dim myEvent As EventHandler(Of SendEventArgs(Of KillWorld_SendMessage)) = CType(myEvents("OnSendKillWorld"), EventHandler(Of SendEventArgs(Of KillWorld_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendKillWorld", ex)
            End Try
        End RaiseEvent
    End Event
#End Region

#Region "Methods"
    Friend Sub New(internalConnection As InternalConnection)
        myInternalConnection = internalConnection
    End Sub

    Private Sub OnEventError(eventName As String, ex As Exception)
        Cloud.Logger.Log(LogPriority.Error, String.Format("Unable to pass event {0} to {1}.", eventName, ex.Source))
        Cloud.Logger.Log(ex)
    End Sub

    Private Sub myInternalConnection_OnAddUser(sender As Object, e As IPlayer) Handles myInternalConnection.OnAddUser
        If Not myPlayersDictionary.ContainsKey(e.UserID) Then
            Dim myPlayer As New P
            myPlayer.SetupPlayer(e)
            myPlayersDictionary.Add(e.UserID, myPlayer)
        End If
    End Sub

    Private Sub myInternalConnection_OnDisconnect(sender As Object, e As String) Handles myInternalConnection.OnDisconnect
        RaiseEvent OnDisconnect(Me, EventArgs.Empty)
    End Sub

    Private Sub myInternalConnection_OnMessage(sender As Object, e As ReceiveMessage) Handles myInternalConnection.OnMessage
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

    Private Sub myInternalConnection_OnRemoveUser(sender As Object, e As Left_ReceiveMessage) Handles myInternalConnection.OnRemoveUser
        Try
            myPlayersDictionary.Remove(e.UserID)
        Catch
        End Try
    End Sub

    Private Function RaiseSendEvent(message As SendMessage) As Boolean
        RaiseEvent OnSendMessage(Me, message)
        Select Case message.GetType
            Case GetType(Init_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of Init_SendMessage)(CType(message, Init_SendMessage), myInternalConnection)
                RaiseEvent OnSendInit(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(Init2_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of Init2_SendMessage)(CType(message, Init2_SendMessage), myInternalConnection)
                RaiseEvent OnSendInit2(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(BlockPlace_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendBlockPlace(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(CoinDoorPlace_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of CoinDoorPlace_SendMessage)(CType(message, CoinDoorPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendCoindoorPlace(Me, myEventArgs)
                Dim myBlockEventArgs As New EESendEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendBlockPlace(Me, myBlockEventArgs)
                Return myEventArgs.Handled And myBlockEventArgs.Handled

            Case GetType(SoundPlace_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of SoundPlace_SendMessage)(CType(message, SoundPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendSoundPlace(Me, myEventArgs)
                Dim myBlockEventArgs As New EESendEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendBlockPlace(Me, myBlockEventArgs)
                Return myEventArgs.Handled And myBlockEventArgs.Handled

            Case GetType(PortalPlace_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of PortalPlace_SendMessage)(CType(message, PortalPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendPortalPlace(Me, myEventArgs)
                Dim myBlockEventArgs As New EESendEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendBlockPlace(Me, myBlockEventArgs)
                Return myEventArgs.Handled And myBlockEventArgs.Handled

            Case GetType(LabelPlace_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of LabelPlace_SendMessage)(CType(message, LabelPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendLabelPlace(Me, myEventArgs)
                Dim myBlockEventArgs As New EESendEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendBlockPlace(Me, myBlockEventArgs)
                Return myEventArgs.Handled And myBlockEventArgs.Handled

            Case GetType(Coin_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of Coin_SendMessage)(CType(message, Coin_SendMessage), myInternalConnection)
                RaiseEvent OnSendCoin(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(PressRedKey_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of PressRedKey_SendMessage)(CType(message, PressRedKey_SendMessage), myInternalConnection)
                RaiseEvent OnSendPressRedKey(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(PressGreenKey_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of PressGreenKey_SendMessage)(CType(message, PressGreenKey_SendMessage), myInternalConnection)
                RaiseEvent OnSendPressGreenKey(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(PressBlueKey_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of PressBlueKey_SendMessage)(CType(message, PressBlueKey_SendMessage), myInternalConnection)
                RaiseEvent OnSendPressBlueKey(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(GetCrown_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of GetCrown_SendMessage)(CType(message, GetCrown_SendMessage), myInternalConnection)
                RaiseEvent OnSendGetCrown(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(TouchDiamond_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of TouchDiamond_SendMessage)(CType(message, TouchDiamond_SendMessage), myInternalConnection)
                RaiseEvent OnSendTouchDiamond(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(CompleteLevel_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of CompleteLevel_SendMessage)(CType(message, CompleteLevel_SendMessage), myInternalConnection)
                RaiseEvent OnSendCompleteLevel(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(GodMode_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of GodMode_SendMessage)(CType(message, GodMode_SendMessage), myInternalConnection)
                RaiseEvent OnSendGodMode(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(ModMode_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of ModMode_SendMessage)(CType(message, ModMode_SendMessage), myInternalConnection)
                RaiseEvent OnSendModMode(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(Move_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of Move_SendMessage)(CType(message, Move_SendMessage), myInternalConnection)
                RaiseEvent OnSendMove(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(Say_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of Say_SendMessage)(CType(message, Say_SendMessage), myInternalConnection)
                RaiseEvent OnSendSay(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(AutoSay_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of AutoSay_SendMessage)(CType(message, AutoSay_SendMessage), myInternalConnection)
                RaiseEvent OnSendAutoSay(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(Access_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of Access_SendMessage)(CType(message, Access_SendMessage), myInternalConnection)
                RaiseEvent OnSendAccess(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(ChangeFace_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of ChangeFace_SendMessage)(CType(message, ChangeFace_SendMessage), myInternalConnection)
                RaiseEvent OnSendChangeFace(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(SaveWorld_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of SaveWorld_SendMessage)(CType(message, SaveWorld_SendMessage), myInternalConnection)
                RaiseEvent OnSendSaveWorld(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(ChangeWorldName_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of ChangeWorldName_SendMessage)(CType(message, ChangeWorldName_SendMessage), myInternalConnection)
                RaiseEvent OnSendChangeWorldName(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(ChangeWorldEditKey_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of ChangeWorldEditKey_SendMessage)(CType(message, ChangeWorldEditKey_SendMessage), myInternalConnection)
                RaiseEvent OnSendChangeWorldEditKey(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(ClearWorld_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of ClearWorld_SendMessage)(CType(message, ClearWorld_SendMessage), myInternalConnection)
                RaiseEvent OnSendClearWorld(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(KillWorld_SendMessage)
                Dim myEventArgs As New EESendEventArgs(Of KillWorld_SendMessage)(CType(message, KillWorld_SendMessage), myInternalConnection)
                RaiseEvent OnSendKillWorld(Me, myEventArgs)
                Return myEventArgs.Handled
            Case Else
                Return False
        End Select
    End Function

    Public Sub Send(message As SendMessage) Implements IConnection(Of P).Send
        If Not RaiseSendEvent(message) Then
            myInternalConnection.Send(message)
        End If
    End Sub

    Public Sub Disconnect() Implements IConnection(Of P).Disconnect
        myInternalConnection.Disconnect()
    End Sub
#End Region

    Public ReadOnly Property GetChatter(name As String) As IChatter Implements IConnection(Of P).GetChatter
        Get

        End Get
    End Property
End Class
