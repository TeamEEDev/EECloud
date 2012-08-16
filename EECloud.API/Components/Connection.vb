Public NotInheritable Class Connection(Of P As {Player, New})

#Region "Fields"
    Private myBot As IBot
    Private WithEvents myInternalConnection As IInternalConnection
    Private myEvents As New EventHandlerList
#End Region

#Region "Properties"
    Public ReadOnly Property WorldID As String
        Get
            Return myInternalConnection.WorldID
        End Get
    End Property

    Public ReadOnly Property World As World
        Get
            Return myInternalConnection.World
        End Get
    End Property

    Public ReadOnly Property IsMainConnection As Boolean
        Get
            Return myInternalConnection.IsMainConnection
        End Get
    End Property

    Public ReadOnly Property Connected As Boolean
        Get
            Return myInternalConnection.Connected
        End Get
    End Property

    Private myPlayersDictionary As New Dictionary(Of Integer, P)
    Public ReadOnly Property Players(number As Integer) As P
        Get
            Try
                Return myPlayersDictionary(number)
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property Players As IEnumerable(Of P)
        Get
            Try
                Return myPlayersDictionary.Values
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Private myCrown As P
    Public ReadOnly Property Crown As P
        Get
            Return myCrown
        End Get
    End Property

    Friend ReadOnly Property DefaultConnection As Connection(Of Player)
        Get
            Return myInternalConnection.DefaultConnection
        End Get
    End Property

    Public ReadOnly Property Encryption As String
        Get
            Return myInternalConnection.Encryption
        End Get
    End Property
#End Region

#Region "Events"
    Public Custom Event OnReciveMessage As EventHandler(Of ReciveMessage)
        AddHandler(value As EventHandler(Of ReciveMessage))
            myEvents.Add("OnReciveMessage", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ReciveMessage))
            myEvents.Remove("OnReciveMessage", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of ReciveMessage) = CType(myEvents("OnReciveMessage"), EventHandler(Of ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveMessage", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnDisconnect As EventHandler(Of EventArgs)
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

    Public Custom Event OnReciveAccess As EventHandler(Of Access_ReciveMessage)
        AddHandler(value As EventHandler(Of Access_ReciveMessage))
            myEvents.Add("OnReciveAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Access_ReciveMessage))
            myEvents.Remove("OnReciveAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Access_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Access_ReciveMessage) = CType(myEvents("OnReciveAccess"), EventHandler(Of Access_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveAdd As EventHandler(Of Add_ReciveMessage)
        AddHandler(value As EventHandler(Of Add_ReciveMessage))
            myEvents.Add("OnReciveAdd", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Add_ReciveMessage))
            myEvents.Remove("OnReciveAdd", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Add_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Add_ReciveMessage) = CType(myEvents("OnReciveAdd"), EventHandler(Of Add_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveAdd", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveAutoText As EventHandler(Of AutoText_ReciveMessage)
        AddHandler(value As EventHandler(Of AutoText_ReciveMessage))
            myEvents.Add("OnReciveAutoText", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of AutoText_ReciveMessage))
            myEvents.Remove("OnReciveAutoText", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As AutoText_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of AutoText_ReciveMessage) = CType(myEvents("OnReciveAutoText"), EventHandler(Of AutoText_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveAutoText", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveBlockPlace As EventHandler(Of BlockPlace_ReciveMessage)
        AddHandler(value As EventHandler(Of BlockPlace_ReciveMessage))
            myEvents.Add("OnReciveBlockPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of BlockPlace_ReciveMessage))
            myEvents.Remove("OnReciveBlockPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As BlockPlace_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of BlockPlace_ReciveMessage) = CType(myEvents("OnReciveBlockPlace"), EventHandler(Of BlockPlace_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveBlockPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveClear As EventHandler(Of Clear_ReciveMessage)
        AddHandler(value As EventHandler(Of Clear_ReciveMessage))
            myEvents.Add("OnReciveClear", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Clear_ReciveMessage))
            myEvents.Remove("OnReciveClear", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Clear_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Clear_ReciveMessage) = CType(myEvents("OnReciveClear"), EventHandler(Of Clear_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveClear", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveCoin As EventHandler(Of Coin_ReciveMessage)
        AddHandler(value As EventHandler(Of Coin_ReciveMessage))
            myEvents.Add("OnReciveCoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Coin_ReciveMessage))
            myEvents.Remove("OnReciveCoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Coin_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Coin_ReciveMessage) = CType(myEvents("OnReciveCoin"), EventHandler(Of Coin_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveCoin", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveCoinDoorPlace As EventHandler(Of CoinDoorPlace_ReciveMessage)
        AddHandler(value As EventHandler(Of CoinDoorPlace_ReciveMessage))
            myEvents.Add("OnReciveCoinDoorPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of CoinDoorPlace_ReciveMessage))
            myEvents.Remove("OnReciveCoinDoorPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As CoinDoorPlace_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of CoinDoorPlace_ReciveMessage) = CType(myEvents("OnReciveCoinDoorPlace"), EventHandler(Of CoinDoorPlace_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveCoinDoorPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveCrown As EventHandler(Of Crown_ReciveMessage)
        AddHandler(value As EventHandler(Of Crown_ReciveMessage))
            myEvents.Add("OnReciveCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Crown_ReciveMessage))
            myEvents.Remove("OnReciveCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Crown_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Crown_ReciveMessage) = CType(myEvents("OnReciveCrown"), EventHandler(Of Crown_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveFace As EventHandler(Of Face_ReciveMessage)
        AddHandler(value As EventHandler(Of Face_ReciveMessage))
            myEvents.Add("OnReciveFace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Face_ReciveMessage))
            myEvents.Remove("OnReciveFace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Face_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Face_ReciveMessage) = CType(myEvents("OnReciveFace"), EventHandler(Of Face_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveFace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveGiveFireWizard As EventHandler(Of GiveFireWizard_ReciveMessage)
        AddHandler(value As EventHandler(Of GiveFireWizard_ReciveMessage))
            myEvents.Add("OnReciveGiveFireWizard", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveFireWizard_ReciveMessage))
            myEvents.Remove("OnReciveGiveFireWizard", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveFireWizard_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of GiveFireWizard_ReciveMessage) = CType(myEvents("OnReciveGiveFireWizard"), EventHandler(Of GiveFireWizard_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveGiveFireWizard", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveGiveGrinch As EventHandler(Of GiveGrinch_ReciveMessage)
        AddHandler(value As EventHandler(Of GiveGrinch_ReciveMessage))
            myEvents.Add("OnReciveGiveGrinch", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveGrinch_ReciveMessage))
            myEvents.Remove("OnReciveGiveGrinch", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveGrinch_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of GiveGrinch_ReciveMessage) = CType(myEvents("OnReciveGiveGrinch"), EventHandler(Of GiveGrinch_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveGiveGrinch", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveGiveWitch As EventHandler(Of GiveWitch_ReciveMessage)
        AddHandler(value As EventHandler(Of GiveWitch_ReciveMessage))
            myEvents.Add("OnReciveGiveWitch", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveWitch_ReciveMessage))
            myEvents.Remove("OnReciveGiveWitch", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveWitch_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of GiveWitch_ReciveMessage) = CType(myEvents("OnReciveGiveWitch"), EventHandler(Of GiveWitch_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveGiveWitch", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveGiveWizard As EventHandler(Of GiveWizard_ReciveMessage)
        AddHandler(value As EventHandler(Of GiveWizard_ReciveMessage))
            myEvents.Add("OnReciveGiveWizard", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GiveWizard_ReciveMessage))
            myEvents.Remove("OnReciveGiveWizard", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GiveWizard_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of GiveWizard_ReciveMessage) = CType(myEvents("OnReciveGiveWizard"), EventHandler(Of GiveWizard_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveGiveWizard", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveGodmode As EventHandler(Of Godmode_ReciveMessage)
        AddHandler(value As EventHandler(Of Godmode_ReciveMessage))
            myEvents.Add("OnReciveGodmode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Godmode_ReciveMessage))
            myEvents.Remove("OnReciveGodmode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Godmode_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Godmode_ReciveMessage) = CType(myEvents("OnReciveGodmode"), EventHandler(Of Godmode_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveGodmode", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveGroupDisallowedJoin As EventHandler(Of GroupDisallowedJoin_ReciveMessage)
        AddHandler(value As EventHandler(Of GroupDisallowedJoin_ReciveMessage))
            myEvents.Add("OnReciveGroupDisallowedJoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of GroupDisallowedJoin_ReciveMessage))
            myEvents.Remove("OnReciveGroupDisallowedJoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As GroupDisallowedJoin_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of GroupDisallowedJoin_ReciveMessage) = CType(myEvents("OnReciveGroupDisallowedJoin"), EventHandler(Of GroupDisallowedJoin_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveGroupDisallowedJoin", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveHideKey As EventHandler(Of HideKey_ReciveMessage)
        AddHandler(value As EventHandler(Of HideKey_ReciveMessage))
            myEvents.Add("OnReciveHideKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of HideKey_ReciveMessage))
            myEvents.Remove("OnReciveHideKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As HideKey_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of HideKey_ReciveMessage) = CType(myEvents("OnReciveHideKey"), EventHandler(Of HideKey_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveHideKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveInfo As EventHandler(Of Info_ReciveMessage)
        AddHandler(value As EventHandler(Of Info_ReciveMessage))
            myEvents.Add("OnReciveInfo", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Info_ReciveMessage))
            myEvents.Remove("OnReciveInfo", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Info_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Info_ReciveMessage) = CType(myEvents("OnReciveInfo"), EventHandler(Of Info_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveInfo", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveInit As EventHandler(Of Init_ReciveMessage)
        AddHandler(value As EventHandler(Of Init_ReciveMessage))
            myEvents.Add("OnReciveInit", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Init_ReciveMessage))
            myEvents.Remove("OnReciveInit", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Init_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Init_ReciveMessage) = CType(myEvents("OnReciveInit"), EventHandler(Of Init_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveInit", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveLabelPlace As EventHandler(Of LabelPlace_ReciveMessage)
        AddHandler(value As EventHandler(Of LabelPlace_ReciveMessage))
            myEvents.Add("OnReciveLabelPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LabelPlace_ReciveMessage))
            myEvents.Remove("OnReciveLabelPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LabelPlace_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of LabelPlace_ReciveMessage) = CType(myEvents("OnReciveLabelPlace"), EventHandler(Of LabelPlace_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveLabelPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveLeft As EventHandler(Of Left_ReciveMessage)
        AddHandler(value As EventHandler(Of Left_ReciveMessage))
            myEvents.Add("OnReciveLeft", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Left_ReciveMessage))
            myEvents.Remove("OnReciveLeft", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Left_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Left_ReciveMessage) = CType(myEvents("OnReciveLeft"), EventHandler(Of Left_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveLeft", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveLostAccess As EventHandler(Of LostAccess_ReciveMessage)
        AddHandler(value As EventHandler(Of LostAccess_ReciveMessage))
            myEvents.Add("OnReciveLostAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of LostAccess_ReciveMessage))
            myEvents.Remove("OnReciveLostAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As LostAccess_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of LostAccess_ReciveMessage) = CType(myEvents("OnReciveLostAccess"), EventHandler(Of LostAccess_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveLostAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveModmode As EventHandler(Of Modmode_ReciveMessage)
        AddHandler(value As EventHandler(Of Modmode_ReciveMessage))
            myEvents.Add("OnReciveModmode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Modmode_ReciveMessage))
            myEvents.Remove("OnReciveModmode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Modmode_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Modmode_ReciveMessage) = CType(myEvents("OnReciveModmode"), EventHandler(Of Modmode_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveModmode", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveMove As EventHandler(Of Move_ReciveMessage)
        AddHandler(value As EventHandler(Of Move_ReciveMessage))
            myEvents.Add("OnReciveMove", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Move_ReciveMessage))
            myEvents.Remove("OnReciveMove", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Move_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Move_ReciveMessage) = CType(myEvents("OnReciveMove"), EventHandler(Of Move_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveMove", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnRecivePortalPlace As EventHandler(Of PortalPlace_ReciveMessage)
        AddHandler(value As EventHandler(Of PortalPlace_ReciveMessage))
            myEvents.Add("OnRecivePortalPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of PortalPlace_ReciveMessage))
            myEvents.Remove("OnRecivePortalPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As PortalPlace_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of PortalPlace_ReciveMessage) = CType(myEvents("OnRecivePortalPlace"), EventHandler(Of PortalPlace_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnRecivePortalPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveRefreshShop As EventHandler(Of RefreshShop_ReciveMessage)
        AddHandler(value As EventHandler(Of RefreshShop_ReciveMessage))
            myEvents.Add("OnReciveRefreshShop", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of RefreshShop_ReciveMessage))
            myEvents.Remove("OnReciveRefreshShop", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As RefreshShop_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of RefreshShop_ReciveMessage) = CType(myEvents("OnReciveRefreshShop"), EventHandler(Of RefreshShop_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveRefreshShop", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveReset As EventHandler(Of Reset_ReciveMessage)
        AddHandler(value As EventHandler(Of Reset_ReciveMessage))
            myEvents.Add("OnReciveReset", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Reset_ReciveMessage))
            myEvents.Remove("OnReciveReset", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Reset_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Reset_ReciveMessage) = CType(myEvents("OnReciveReset"), EventHandler(Of Reset_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveReset", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveSaveDone As EventHandler(Of SaveDone_ReciveMessage)
        AddHandler(value As EventHandler(Of SaveDone_ReciveMessage))
            myEvents.Add("OnReciveSaveDone", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SaveDone_ReciveMessage))
            myEvents.Remove("OnReciveSaveDone", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SaveDone_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of SaveDone_ReciveMessage) = CType(myEvents("OnReciveSaveDone"), EventHandler(Of SaveDone_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveSaveDone", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveSay As EventHandler(Of Say_ReciveMessage)
        AddHandler(value As EventHandler(Of Say_ReciveMessage))
            myEvents.Add("OnReciveSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Say_ReciveMessage))
            myEvents.Remove("OnReciveSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Say_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Say_ReciveMessage) = CType(myEvents("OnReciveSay"), EventHandler(Of Say_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveSay", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveSayOld As EventHandler(Of SayOld_ReciveMessage)
        AddHandler(value As EventHandler(Of SayOld_ReciveMessage))
            myEvents.Add("OnReciveSayOld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SayOld_ReciveMessage))
            myEvents.Remove("OnReciveSayOld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SayOld_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of SayOld_ReciveMessage) = CType(myEvents("OnReciveSayOld"), EventHandler(Of SayOld_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveSayOld", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveShowKey As EventHandler(Of ShowKey_ReciveMessage)
        AddHandler(value As EventHandler(Of ShowKey_ReciveMessage))
            myEvents.Add("OnReciveShowKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of ShowKey_ReciveMessage))
            myEvents.Remove("OnReciveShowKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As ShowKey_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of ShowKey_ReciveMessage) = CType(myEvents("OnReciveShowKey"), EventHandler(Of ShowKey_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveShowKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveSilverCrown As EventHandler(Of SilverCrown_ReciveMessage)
        AddHandler(value As EventHandler(Of SilverCrown_ReciveMessage))
            myEvents.Add("OnReciveSilverCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SilverCrown_ReciveMessage))
            myEvents.Remove("OnReciveSilverCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SilverCrown_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of SilverCrown_ReciveMessage) = CType(myEvents("OnReciveSilverCrown"), EventHandler(Of SilverCrown_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveSilverCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveSoundPlace As EventHandler(Of SoundPlace_ReciveMessage)
        AddHandler(value As EventHandler(Of SoundPlace_ReciveMessage))
            myEvents.Add("OnReciveSoundPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of SoundPlace_ReciveMessage))
            myEvents.Remove("OnReciveSoundPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As SoundPlace_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of SoundPlace_ReciveMessage) = CType(myEvents("OnReciveSoundPlace"), EventHandler(Of SoundPlace_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveSoundPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveTeleport As EventHandler(Of Teleport_ReciveMessage)
        AddHandler(value As EventHandler(Of Teleport_ReciveMessage))
            myEvents.Add("OnReciveTeleport", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Teleport_ReciveMessage))
            myEvents.Remove("OnReciveTeleport", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Teleport_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Teleport_ReciveMessage) = CType(myEvents("OnReciveTeleport"), EventHandler(Of Teleport_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveTeleport", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveUpdateMeta As EventHandler(Of UpdateMeta_ReciveMessage)
        AddHandler(value As EventHandler(Of UpdateMeta_ReciveMessage))
            myEvents.Add("OnReciveUpdateMeta", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of UpdateMeta_ReciveMessage))
            myEvents.Remove("OnReciveUpdateMeta", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As UpdateMeta_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of UpdateMeta_ReciveMessage) = CType(myEvents("OnReciveUpdateMeta"), EventHandler(Of UpdateMeta_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveUpdateMeta", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveUpgrade As EventHandler(Of Upgrade_ReciveMessage)
        AddHandler(value As EventHandler(Of Upgrade_ReciveMessage))
            myEvents.Add("OnReciveUpgrade", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Upgrade_ReciveMessage))
            myEvents.Remove("OnReciveUpgrade", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Upgrade_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Upgrade_ReciveMessage) = CType(myEvents("OnReciveUpgrade"), EventHandler(Of Upgrade_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveUpgrade", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnReciveWrite As EventHandler(Of Write_ReciveMessage)
        AddHandler(value As EventHandler(Of Write_ReciveMessage))
            myEvents.Add("OnReciveWrite", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of Write_ReciveMessage))
            myEvents.Remove("OnReciveWrite", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As Write_ReciveMessage)
            Try
                Dim myEvent As EventHandler(Of Write_ReciveMessage) = CType(myEvents("OnReciveWrite"), EventHandler(Of Write_ReciveMessage))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnReciveWrite", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendMessage As EventHandler(Of SendMessage)
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

    Public Custom Event OnSendInit As EventHandler(Of OnSendMessageEventArgs(Of Init_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Init_SendMessage)))
            myEvents.Add("OnSendInit", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Init_SendMessage)))
            myEvents.Remove("OnSendInit", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of Init_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of Init_SendMessage)) = CType(myEvents("OnSendInit"), EventHandler(Of OnSendMessageEventArgs(Of Init_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendInit", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendInit2 As EventHandler(Of OnSendMessageEventArgs(Of Init2_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Init2_SendMessage)))
            myEvents.Add("OnSendInit2", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Init2_SendMessage)))
            myEvents.Remove("OnSendInit2", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of Init2_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of Init2_SendMessage)) = CType(myEvents("OnSendInit2"), EventHandler(Of OnSendMessageEventArgs(Of Init2_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendInit2", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendBlockPlace As EventHandler(Of OnSendMessageEventArgs(Of BlockPlace_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of BlockPlace_SendMessage)))
            myEvents.Add("OnSendBlockPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of BlockPlace_SendMessage)))
            myEvents.Remove("OnSendBlockPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of BlockPlace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of BlockPlace_SendMessage)) = CType(myEvents("OnSendBlockPlace"), EventHandler(Of OnSendMessageEventArgs(Of BlockPlace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendBlockPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendCoindoorPlace As EventHandler(Of OnSendMessageEventArgs(Of CoinDoorPlace_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of CoinDoorPlace_SendMessage)))
            myEvents.Add("OnSendCoindoorPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of CoinDoorPlace_SendMessage)))
            myEvents.Remove("OnSendCoindoorPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of CoinDoorPlace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of CoindoorPlace_SendMessage)) = CType(myEvents("OnSendCoindoorPlace"), EventHandler(Of OnSendMessageEventArgs(Of CoindoorPlace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCoindoorPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendSoundPlace As EventHandler(Of OnSendMessageEventArgs(Of SoundPlace_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of SoundPlace_SendMessage)))
            myEvents.Add("OnSendSoundPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of SoundPlace_SendMessage)))
            myEvents.Remove("OnSendSoundPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of SoundPlace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of SoundPlace_SendMessage)) = CType(myEvents("OnSendSoundPlace"), EventHandler(Of OnSendMessageEventArgs(Of SoundPlace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSoundPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendPortalPlace As EventHandler(Of OnSendMessageEventArgs(Of PortalPlace_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of PortalPlace_SendMessage)))
            myEvents.Add("OnSendPortalPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of PortalPlace_SendMessage)))
            myEvents.Remove("OnSendPortalPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of PortalPlace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of PortalPlace_SendMessage)) = CType(myEvents("OnSendPortalPlace"), EventHandler(Of OnSendMessageEventArgs(Of PortalPlace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPortalPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendLabelPlace As EventHandler(Of OnSendMessageEventArgs(Of LabelPlace_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of LabelPlace_SendMessage)))
            myEvents.Add("OnSendLabelPlace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of LabelPlace_SendMessage)))
            myEvents.Remove("OnSendLabelPlace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of LabelPlace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of LabelPlace_SendMessage)) = CType(myEvents("OnSendLabelPlace"), EventHandler(Of OnSendMessageEventArgs(Of LabelPlace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendLabelPlace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendCoin As EventHandler(Of OnSendMessageEventArgs(Of Coin_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Coin_SendMessage)))
            myEvents.Add("OnSendCoin", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Coin_SendMessage)))
            myEvents.Remove("OnSendCoin", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of Coin_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of Coin_SendMessage)) = CType(myEvents("OnSendCoin"), EventHandler(Of OnSendMessageEventArgs(Of Coin_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCoin", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendPressRedKey As EventHandler(Of OnSendMessageEventArgs(Of PressRedKey_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of PressRedKey_SendMessage)))
            myEvents.Add("OnSendPressRedKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of PressRedKey_SendMessage)))
            myEvents.Remove("OnSendPressRedKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of PressRedKey_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of PressRedKey_SendMessage)) = CType(myEvents("OnSendPressRedKey"), EventHandler(Of OnSendMessageEventArgs(Of PressRedKey_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressRedKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendPressGreenKey As EventHandler(Of OnSendMessageEventArgs(Of PressGreenKey_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of PressGreenKey_SendMessage)))
            myEvents.Add("OnSendPressGreenKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of PressGreenKey_SendMessage)))
            myEvents.Remove("OnSendPressGreenKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of PressGreenKey_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of PressGreenKey_SendMessage)) = CType(myEvents("OnSendPressGreenKey"), EventHandler(Of OnSendMessageEventArgs(Of PressGreenKey_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressGreenKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendPressBlueKey As EventHandler(Of OnSendMessageEventArgs(Of PressBlueKey_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of PressBlueKey_SendMessage)))
            myEvents.Add("OnSendPressBlueKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of PressBlueKey_SendMessage)))
            myEvents.Remove("OnSendPressBlueKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of PressBlueKey_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of PressBlueKey_SendMessage)) = CType(myEvents("OnSendPressBlueKey"), EventHandler(Of OnSendMessageEventArgs(Of PressBlueKey_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendPressBlueKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendGetCrown As EventHandler(Of OnSendMessageEventArgs(Of GetCrown_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of GetCrown_SendMessage)))
            myEvents.Add("OnSendGetCrown", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of GetCrown_SendMessage)))
            myEvents.Remove("OnSendGetCrown", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of GetCrown_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of GetCrown_SendMessage)) = CType(myEvents("OnSendGetCrown"), EventHandler(Of OnSendMessageEventArgs(Of GetCrown_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendGetCrown", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendTouchDiamond As EventHandler(Of OnSendMessageEventArgs(Of TouchDiamond_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of TouchDiamond_SendMessage)))
            myEvents.Add("OnSendTouchDiamond", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of TouchDiamond_SendMessage)))
            myEvents.Remove("OnSendTouchDiamond", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of TouchDiamond_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of TouchDiamond_SendMessage)) = CType(myEvents("OnSendTouchDiamond"), EventHandler(Of OnSendMessageEventArgs(Of TouchDiamond_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendTouchDiamond", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendCompleteLevel As EventHandler(Of OnSendMessageEventArgs(Of CompleteLevel_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of CompleteLevel_SendMessage)))
            myEvents.Add("OnSendCompleteLevel", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of CompleteLevel_SendMessage)))
            myEvents.Remove("OnSendCompleteLevel", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of CompleteLevel_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of CompleteLevel_SendMessage)) = CType(myEvents("OnSendCompleteLevel"), EventHandler(Of OnSendMessageEventArgs(Of CompleteLevel_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendCompleteLevel", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendGodMode As EventHandler(Of OnSendMessageEventArgs(Of GodMode_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of GodMode_SendMessage)))
            myEvents.Add("OnSendGodMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of GodMode_SendMessage)))
            myEvents.Remove("OnSendGodMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of GodMode_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of GodMode_SendMessage)) = CType(myEvents("OnSendGodMode"), EventHandler(Of OnSendMessageEventArgs(Of GodMode_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendGodMode", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendModMode As EventHandler(Of OnSendMessageEventArgs(Of ModMode_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of ModMode_SendMessage)))
            myEvents.Add("OnSendModMode", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of ModMode_SendMessage)))
            myEvents.Remove("OnSendModMode", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of ModMode_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of ModMode_SendMessage)) = CType(myEvents("OnSendModMode"), EventHandler(Of OnSendMessageEventArgs(Of ModMode_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendModMode", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendMove As EventHandler(Of OnSendMessageEventArgs(Of Move_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Move_SendMessage)))
            myEvents.Add("OnSendMove", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Move_SendMessage)))
            myEvents.Remove("OnSendMove", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of Move_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of Move_SendMessage)) = CType(myEvents("OnSendMove"), EventHandler(Of OnSendMessageEventArgs(Of Move_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendMove", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendSay As EventHandler(Of OnSendMessageEventArgs(Of Say_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Say_SendMessage)))
            myEvents.Add("OnSendSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Say_SendMessage)))
            myEvents.Remove("OnSendSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of Say_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of Say_SendMessage)) = CType(myEvents("OnSendSay"), EventHandler(Of OnSendMessageEventArgs(Of Say_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSay", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendAutoSay As EventHandler(Of OnSendMessageEventArgs(Of AutoSay_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of AutoSay_SendMessage)))
            myEvents.Add("OnSendAutoSay", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of AutoSay_SendMessage)))
            myEvents.Remove("OnSendAutoSay", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of AutoSay_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of AutoSay_SendMessage)) = CType(myEvents("OnSendAutoSay"), EventHandler(Of OnSendMessageEventArgs(Of AutoSay_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendAutoSay", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendAccess As EventHandler(Of OnSendMessageEventArgs(Of Access_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Access_SendMessage)))
            myEvents.Add("OnSendAccess", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of Access_SendMessage)))
            myEvents.Remove("OnSendAccess", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of Access_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of Access_SendMessage)) = CType(myEvents("OnSendAccess"), EventHandler(Of OnSendMessageEventArgs(Of Access_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendAccess", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendChangeFace As EventHandler(Of OnSendMessageEventArgs(Of ChangeFace_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of ChangeFace_SendMessage)))
            myEvents.Add("OnSendChangeFace", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of ChangeFace_SendMessage)))
            myEvents.Remove("OnSendChangeFace", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of ChangeFace_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of ChangeFace_SendMessage)) = CType(myEvents("OnSendChangeFace"), EventHandler(Of OnSendMessageEventArgs(Of ChangeFace_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeFace", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendSaveWorld As EventHandler(Of OnSendMessageEventArgs(Of SaveWorld_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of SaveWorld_SendMessage)))
            myEvents.Add("OnSendSaveWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of SaveWorld_SendMessage)))
            myEvents.Remove("OnSendSaveWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of SaveWorld_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of SaveWorld_SendMessage)) = CType(myEvents("OnSendSaveWorld"), EventHandler(Of OnSendMessageEventArgs(Of SaveWorld_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendSaveWorld", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendChangeWorldName As EventHandler(Of OnSendMessageEventArgs(Of ChangeWorldName_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of ChangeWorldName_SendMessage)))
            myEvents.Add("OnSendChangeWorldName", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of ChangeWorldName_SendMessage)))
            myEvents.Remove("OnSendChangeWorldName", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of ChangeWorldName_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of ChangeWorldName_SendMessage)) = CType(myEvents("OnSendChangeWorldName"), EventHandler(Of OnSendMessageEventArgs(Of ChangeWorldName_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeWorldName", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendChangeWorldEditKey As EventHandler(Of OnSendMessageEventArgs(Of ChangeWorldEditKey_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of ChangeWorldEditKey_SendMessage)))
            myEvents.Add("OnSendChangeWorldEditKey", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of ChangeWorldEditKey_SendMessage)))
            myEvents.Remove("OnSendChangeWorldEditKey", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of ChangeWorldEditKey_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of ChangeWorldEditKey_SendMessage)) = CType(myEvents("OnSendChangeWorldEditKey"), EventHandler(Of OnSendMessageEventArgs(Of ChangeWorldEditKey_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendChangeWorldEditKey", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendClearWorld As EventHandler(Of OnSendMessageEventArgs(Of ClearWorld_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of ClearWorld_SendMessage)))
            myEvents.Add("OnSendClearWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of ClearWorld_SendMessage)))
            myEvents.Remove("OnSendClearWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of ClearWorld_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of ClearWorld_SendMessage)) = CType(myEvents("OnSendClearWorld"), EventHandler(Of OnSendMessageEventArgs(Of ClearWorld_SendMessage)))
                If myEvent IsNot Nothing Then
                    Call myEvent(sender, e)
                End If
            Catch ex As Exception
                OnEventError("OnSendClearWorld", ex)
            End Try
        End RaiseEvent
    End Event

    Public Custom Event OnSendKillWorld As EventHandler(Of OnSendMessageEventArgs(Of KillWorld_SendMessage))
        AddHandler(value As EventHandler(Of OnSendMessageEventArgs(Of KillWorld_SendMessage)))
            myEvents.Add("OnSendKillWorld", value)
        End AddHandler

        RemoveHandler(value As EventHandler(Of OnSendMessageEventArgs(Of KillWorld_SendMessage)))
            myEvents.Remove("OnSendKillWorld", value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As OnSendMessageEventArgs(Of KillWorld_SendMessage))
            Try
                Dim myEvent As EventHandler(Of OnSendMessageEventArgs(Of KillWorld_SendMessage)) = CType(myEvents("OnSendKillWorld"), EventHandler(Of OnSendMessageEventArgs(Of KillWorld_SendMessage)))
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
    Friend Sub New(bot As IBot, internalConnection As IInternalConnection)
        myBot = bot
        myInternalConnection = internalConnection
    End Sub

    Private Sub OnEventError(eventName As String, ex As Exception)
        myBot.Logger.Log(LogPriority.Error, String.Format("Unable to pass event {0} to {1}.", eventName, ex.Source))
        myBot.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled: {1} {2}", ex.ToString, ex.Message, ex.StackTrace))
    End Sub

    Private Sub myInternalConnection_OnAddUser(sender As Object, e As IPlayer) Handles myInternalConnection.OnAddUser
        Try
            Dim myPlayer As New P
            myPlayer.SetupPlayer(e)
            myPlayersDictionary.Add(e.UserID, myPlayer)
        Catch
        End Try
    End Sub

    Private Sub myInternalConnection_OnDisconnect(sender As Object, e As String) Handles myInternalConnection.OnDisconnect
        RaiseEvent OnDisconnect(Me, EventArgs.Empty)
    End Sub

    Private Sub myInternalConnection_OnMessage(sender As Object, e As ReciveMessage) Handles myInternalConnection.OnMessage
        RaiseEvent OnReciveMessage(Me, e)
        Select Case e.GetType
            Case GetType(Init_ReciveMessage)
                Dim m As Init_ReciveMessage = CType(e, Init_ReciveMessage)
                RaiseEvent OnReciveInit(Me, m)

            Case GetType(GroupDisallowedJoin_ReciveMessage)
                Dim m As GroupDisallowedJoin_ReciveMessage = CType(e, GroupDisallowedJoin_ReciveMessage)
                RaiseEvent OnReciveGroupDisallowedJoin(Me, m)

            Case GetType(Info_ReciveMessage)
                Dim m As Info_ReciveMessage = CType(e, Info_ReciveMessage)
                RaiseEvent OnReciveInfo(Me, m)

            Case GetType(Upgrade_ReciveMessage)
                Dim m As Upgrade_ReciveMessage = CType(e, Upgrade_ReciveMessage)
                RaiseEvent OnReciveUpgrade(Me, m)

            Case GetType(UpdateMeta_ReciveMessage)
                Dim m As UpdateMeta_ReciveMessage = CType(e, UpdateMeta_ReciveMessage)
                RaiseEvent OnReciveUpdateMeta(Me, m)

            Case GetType(Add_ReciveMessage)
                Dim m As Add_ReciveMessage = CType(e, Add_ReciveMessage)
                RaiseEvent OnReciveAdd(Me, m)

            Case GetType(Left_ReciveMessage)
                Dim m As Left_ReciveMessage = CType(e, Left_ReciveMessage)
                RaiseEvent OnReciveLeft(Me, m)

            Case GetType(Move_ReciveMessage)
                Dim m As Move_ReciveMessage = CType(e, Move_ReciveMessage)
                RaiseEvent OnReciveMove(Me, m)

            Case GetType(Coin_ReciveMessage)
                Dim m As Coin_ReciveMessage = CType(e, Coin_ReciveMessage)
                RaiseEvent OnReciveCoin(Me, m)

            Case GetType(Crown_ReciveMessage)
                Dim m As Crown_ReciveMessage = CType(e, Crown_ReciveMessage)
                RaiseEvent OnReciveCrown(Me, m)

            Case GetType(SilverCrown_ReciveMessage)
                Dim m As SilverCrown_ReciveMessage = CType(e, SilverCrown_ReciveMessage)
                RaiseEvent OnReciveSilverCrown(Me, m)
            Case GetType(Face_ReciveMessage)
                Dim m As Face_ReciveMessage = CType(e, Face_ReciveMessage)
                RaiseEvent OnReciveFace(Me, m)

            Case GetType(ShowKey_ReciveMessage)
                Dim m As ShowKey_ReciveMessage = CType(e, ShowKey_ReciveMessage)
                RaiseEvent OnReciveShowKey(Me, m)

            Case GetType(HideKey_ReciveMessage)
                Dim m As HideKey_ReciveMessage = CType(e, HideKey_ReciveMessage)
                RaiseEvent OnReciveHideKey(Me, m)

            Case GetType(Say_ReciveMessage)
                Dim m As Say_ReciveMessage = CType(e, Say_ReciveMessage)
                RaiseEvent OnReciveSay(Me, m)

            Case GetType(SayOld_ReciveMessage)
                Dim m As SayOld_ReciveMessage = CType(e, SayOld_ReciveMessage)
                RaiseEvent OnReciveSayOld(Me, m)

            Case GetType(AutoText_ReciveMessage)
                Dim m As AutoText_ReciveMessage = CType(e, AutoText_ReciveMessage)
                RaiseEvent OnReciveAutoText(Me, m)

            Case GetType(Write_ReciveMessage)
                Dim m As Write_ReciveMessage = CType(e, Write_ReciveMessage)
                RaiseEvent OnReciveWrite(Me, m)

            Case GetType(BlockPlace_ReciveMessage)
                Dim m As BlockPlace_ReciveMessage = CType(e, BlockPlace_ReciveMessage)
                RaiseEvent OnReciveBlockPlace(Me, m)

            Case GetType(CoinDoorPlace_ReciveMessage)
                Dim m As CoinDoorPlace_ReciveMessage = CType(e, CoinDoorPlace_ReciveMessage)
                RaiseEvent OnReciveCoinDoorPlace(Me, m)
                RaiseEvent OnReciveBlockPlace(Me, m)

            Case GetType(SoundPlace_ReciveMessage)
                Dim m As SoundPlace_ReciveMessage = CType(e, SoundPlace_ReciveMessage)
                RaiseEvent OnReciveSoundPlace(Me, m)
                RaiseEvent OnReciveBlockPlace(Me, m)

            Case GetType(PortalPlace_ReciveMessage)
                Dim m As PortalPlace_ReciveMessage = CType(e, PortalPlace_ReciveMessage)
                RaiseEvent OnRecivePortalPlace(Me, m)
                RaiseEvent OnReciveBlockPlace(Me, m)

            Case GetType(LabelPlace_ReciveMessage)
                Dim m As LabelPlace_ReciveMessage = CType(e, LabelPlace_ReciveMessage)
                RaiseEvent OnReciveLabelPlace(Me, m)
                RaiseEvent OnReciveBlockPlace(Me, m)

            Case GetType(Godmode_ReciveMessage)
                Dim m As Godmode_ReciveMessage = CType(e, Godmode_ReciveMessage)
                RaiseEvent OnReciveGodmode(Me, m)

            Case GetType(Modmode_ReciveMessage)
                Dim m As Modmode_ReciveMessage = CType(e, Modmode_ReciveMessage)
                RaiseEvent OnReciveModmode(Me, m)

            Case GetType(Access_ReciveMessage)
                Dim m As Access_ReciveMessage = CType(e, Access_ReciveMessage)
                RaiseEvent OnReciveAccess(Me, m)

            Case GetType(LostAccess_ReciveMessage)
                Dim m As LostAccess_ReciveMessage = CType(e, LostAccess_ReciveMessage)
                RaiseEvent OnReciveLostAccess(Me, m)

            Case GetType(Teleport_ReciveMessage)
                Dim m As Teleport_ReciveMessage = CType(e, Teleport_ReciveMessage)
                RaiseEvent OnReciveTeleport(Me, m)

            Case GetType(Reset_ReciveMessage)
                Dim m As Reset_ReciveMessage = CType(e, Reset_ReciveMessage)
                RaiseEvent OnReciveReset(Me, m)

            Case GetType(Clear_ReciveMessage)
                Dim m As Clear_ReciveMessage = CType(e, Clear_ReciveMessage)
                RaiseEvent OnReciveClear(Me, m)

            Case GetType(SaveDone_ReciveMessage)
                Dim m As SaveDone_ReciveMessage = CType(e, SaveDone_ReciveMessage)
                RaiseEvent OnReciveSaveDone(Me, m)

            Case GetType(RefreshShop_ReciveMessage)
                Dim m As RefreshShop_ReciveMessage = CType(e, RefreshShop_ReciveMessage)
                RaiseEvent OnReciveRefreshShop(Me, m)

            Case GetType(GiveWizard_ReciveMessage)
                Dim m As GiveWizard_ReciveMessage = CType(e, GiveWizard_ReciveMessage)
                RaiseEvent OnReciveGiveWizard(Me, m)

            Case GetType(GiveFireWizard_ReciveMessage)
                Dim m As GiveFireWizard_ReciveMessage = CType(e, GiveFireWizard_ReciveMessage)
                RaiseEvent OnReciveGiveFireWizard(Me, m)

            Case GetType(GiveWitch_ReciveMessage)
                Dim m As GiveWitch_ReciveMessage = CType(e, GiveWitch_ReciveMessage)
                RaiseEvent OnReciveGiveWitch(Me, m)

            Case GetType(GiveGrinch_ReciveMessage)
                Dim m As GiveGrinch_ReciveMessage = CType(e, GiveGrinch_ReciveMessage)
                RaiseEvent OnReciveGiveGrinch(Me, m)
        End Select
    End Sub

    Private Sub myInternalConnection_OnRemoveUser(sender As Object, e As Left_ReciveMessage) Handles myInternalConnection.OnRemoveUser
        Try
            myPlayersDictionary.Remove(e.UserID)
        Catch
        End Try
    End Sub

    Private Function RaiseSendEvent(message As SendMessage) As Boolean
        RaiseEvent OnSendMessage(Me, message)
        Select Case message.GetType
            Case GetType(Init_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of Init_SendMessage)(CType(message, Init_SendMessage), myInternalConnection)
                RaiseEvent OnSendInit(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(Init2_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of Init2_SendMessage)(CType(message, Init2_SendMessage), myInternalConnection)
                RaiseEvent OnSendInit2(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(BlockPlace_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendBlockPlace(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(CoinDoorPlace_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of CoinDoorPlace_SendMessage)(CType(message, CoinDoorPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendCoindoorPlace(Me, myEventArgs)
                Dim myBlockEventArgs As New OnSendMessageEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendBlockPlace(Me, myBlockEventArgs)
                Return myEventArgs.Handled And myBlockEventArgs.Handled

            Case GetType(SoundPlace_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of SoundPlace_SendMessage)(CType(message, SoundPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendSoundPlace(Me, myEventArgs)
                Dim myBlockEventArgs As New OnSendMessageEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendBlockPlace(Me, myBlockEventArgs)
                Return myEventArgs.Handled And myBlockEventArgs.Handled

            Case GetType(PortalPlace_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of PortalPlace_SendMessage)(CType(message, PortalPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendPortalPlace(Me, myEventArgs)
                Dim myBlockEventArgs As New OnSendMessageEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendBlockPlace(Me, myBlockEventArgs)
                Return myEventArgs.Handled And myBlockEventArgs.Handled

            Case GetType(LabelPlace_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of LabelPlace_SendMessage)(CType(message, LabelPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendLabelPlace(Me, myEventArgs)
                Dim myBlockEventArgs As New OnSendMessageEventArgs(Of BlockPlace_SendMessage)(CType(message, BlockPlace_SendMessage), myInternalConnection)
                RaiseEvent OnSendBlockPlace(Me, myBlockEventArgs)
                Return myEventArgs.Handled And myBlockEventArgs.Handled

            Case GetType(Coin_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of Coin_SendMessage)(CType(message, Coin_SendMessage), myInternalConnection)
                RaiseEvent OnSendCoin(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(PressRedKey_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of PressRedKey_SendMessage)(CType(message, PressRedKey_SendMessage), myInternalConnection)
                RaiseEvent OnSendPressRedKey(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(PressGreenKey_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of PressGreenKey_SendMessage)(CType(message, PressGreenKey_SendMessage), myInternalConnection)
                RaiseEvent OnSendPressGreenKey(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(PressBlueKey_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of PressBlueKey_SendMessage)(CType(message, PressBlueKey_SendMessage), myInternalConnection)
                RaiseEvent OnSendPressBlueKey(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(GetCrown_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of GetCrown_SendMessage)(CType(message, GetCrown_SendMessage), myInternalConnection)
                RaiseEvent OnSendGetCrown(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(TouchDiamond_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of TouchDiamond_SendMessage)(CType(message, TouchDiamond_SendMessage), myInternalConnection)
                RaiseEvent OnSendTouchDiamond(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(CompleteLevel_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of CompleteLevel_SendMessage)(CType(message, CompleteLevel_SendMessage), myInternalConnection)
                RaiseEvent OnSendCompleteLevel(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(GodMode_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of GodMode_SendMessage)(CType(message, GodMode_SendMessage), myInternalConnection)
                RaiseEvent OnSendGodMode(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(ModMode_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of ModMode_SendMessage)(CType(message, ModMode_SendMessage), myInternalConnection)
                RaiseEvent OnSendModMode(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(Move_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of Move_SendMessage)(CType(message, Move_SendMessage), myInternalConnection)
                RaiseEvent OnSendMove(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(Say_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of Say_SendMessage)(CType(message, Say_SendMessage), myInternalConnection)
                RaiseEvent OnSendSay(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(AutoSay_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of AutoSay_SendMessage)(CType(message, AutoSay_SendMessage), myInternalConnection)
                RaiseEvent OnSendAutoSay(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(Access_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of Access_SendMessage)(CType(message, Access_SendMessage), myInternalConnection)
                RaiseEvent OnSendAccess(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(ChangeFace_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of ChangeFace_SendMessage)(CType(message, ChangeFace_SendMessage), myInternalConnection)
                RaiseEvent OnSendChangeFace(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(SaveWorld_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of SaveWorld_SendMessage)(CType(message, SaveWorld_SendMessage), myInternalConnection)
                RaiseEvent OnSendSaveWorld(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(ChangeWorldName_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of ChangeWorldName_SendMessage)(CType(message, ChangeWorldName_SendMessage), myInternalConnection)
                RaiseEvent OnSendChangeWorldName(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(ChangeWorldEditKey_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of ChangeWorldEditKey_SendMessage)(CType(message, ChangeWorldEditKey_SendMessage), myInternalConnection)
                RaiseEvent OnSendChangeWorldEditKey(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(ClearWorld_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of ClearWorld_SendMessage)(CType(message, ClearWorld_SendMessage), myInternalConnection)
                RaiseEvent OnSendClearWorld(Me, myEventArgs)
                Return myEventArgs.Handled

            Case GetType(KillWorld_SendMessage)
                Dim myEventArgs As New OnSendMessageEventArgs(Of KillWorld_SendMessage)(CType(message, KillWorld_SendMessage), myInternalConnection)
                RaiseEvent OnSendKillWorld(Me, myEventArgs)
                Return myEventArgs.Handled
            Case Else
                Return False
        End Select
    End Function

    Public Sub Send(message As SendMessage)
        If RaiseSendEvent(message) Then
            myInternalConnection.Send(message)
        End If
    End Sub

    Public Sub Disconnect()
        myInternalConnection.Disconnect()
    End Sub
#End Region
End Class
