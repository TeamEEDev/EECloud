﻿Public Class Game(Of TPlayer As {New, Player})
    Implements IGame(Of TPlayer)

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)
    Private WithEvents myConnection As IConnection
#End Region

#Region "Event"
    Public Event WorldNameChange(sender As Object, e As ItemChangedEventArgs(Of String)) Implements IGame(Of TPlayer).WorldNameChange

    Public Event OnClear(sender As Object, e As EventArgs) Implements IGame(Of TPlayer).OnClear

    Public Event OnLoadLevel(sender As Object, e As EventArgs) Implements IGame(Of TPlayer).OnLoadLevel

    Public Event OnReset(sender As Object, e As EventArgs) Implements IGame(Of TPlayer).OnReset

    Public Event OnSave(sender As Object, e As EventArgs) Implements IGame(Of TPlayer).OnSave

    Public Event AccessRightChange(sender As Object, e As ItemChangedEventArgs(Of AccessRight)) Implements IGame(Of TPlayer).AccessRightChange

    Public Event KeyPress(sender As Object, e As Key) Implements IGame(Of TPlayer).KeyPress

    Public Event KeyRelease(sender As Object, e As Key) Implements IGame(Of TPlayer).KeyRelease

    Public Event PlaysChange(sender As Object, e As ItemChangedEventArgs(Of Integer)) Implements IGame(Of TPlayer).PlaysChange

    Public Event OwnerChange(sender As Object, e As ItemChangedEventArgs(Of String)) Implements IGame(Of TPlayer).OwnerChange

    Public Event Init(sender As Object, e As EventArgs) Implements IGame(Of TPlayer).Init
#End Region

#Region "Properties"
    Private myEncryption As String

    Public ReadOnly Property Encryption As String Implements IGame(Of TPlayer).Encryption
        Get
            Return myEncryption
        End Get
    End Property

    Private myMyPlayer As TPlayer

    Public ReadOnly Property MyPlayer As TPlayer Implements IGame(Of TPlayer).MyPlayer
        Get
            Return myMyPlayer
        End Get
    End Property

    Private myOwner As String

    Public ReadOnly Property Owner As String Implements IGame(Of TPlayer).Owner
        Get
            Return myOwner
        End Get
    End Property

    Private myPlays As Integer

    Public ReadOnly Property Plays As Integer Implements IGame(Of TPlayer).Plays
        Get
            Return myPlays
        End Get
    End Property

    Private myBlueKey As Boolean

    Public ReadOnly Property BlueKey As Boolean Implements IGame(Of TPlayer).BlueKey
        Get
            Return myBlueKey
        End Get
    End Property

    Private myGreenKey As Boolean

    Public ReadOnly Property GreenKey As Boolean Implements IGame(Of TPlayer).GreenKey
        Get
            Return myGreenKey
        End Get
    End Property

    Private myRedKey As Boolean

    Public ReadOnly Property RedKey As Boolean Implements IGame(Of TPlayer).RedKey
        Get
            Return myRedKey
        End Get
    End Property

    Private myTimedKey As Boolean

    Public ReadOnly Property TimedKey As Boolean Implements IGame(Of TPlayer).TimedKey
        Get
            Return myTimedKey
        End Get
    End Property

    Private myBlueAuraPotionCount As Integer

    Public ReadOnly Property BlueAuraPotionCount As Integer Implements IGame(Of TPlayer).BlueAuraPotionCount
        Get
            Return myBlueAuraPotionCount
        End Get
    End Property

    Private myRedAuraPotionCount As Integer

    Public ReadOnly Property RedAuraPotionCount As Integer Implements IGame(Of TPlayer).RedAuraPotionCount
        Get
            Return myRedAuraPotionCount
        End Get
    End Property

    Private myYellowAuraPotionCount As Integer

    Public ReadOnly Property YellowAuraPotionCount As Integer Implements IGame(Of TPlayer).YellowAuraPotionCount
        Get
            Return myYellowAuraPotionCount
        End Get
    End Property

    Private myAccessRight As AccessRight

    Public ReadOnly Property AccessRight As AccessRight Implements IGame(Of TPlayer).AccessRight
        Get
            Return myAccessRight
        End Get
    End Property

    Public WriteOnly Property GodMode As Boolean Implements IGame(Of TPlayer).GodMode
        Set(value As Boolean)
            myConnection.Send(New GodModeSendMessage(value))
        End Set
    End Property

    Public WriteOnly Property Location As Location Implements IGame(Of TPlayer).Location
        Set(value As Location)
            myConnection.Send(New MoveSendMessage(value.X, value.Y, 0, 0, 0, 0, 0, 0, myGravityMultiplayer))
        End Set
    End Property

    Private myWorldName As String

    Public Property WorldName As String Implements IGame(Of TPlayer).WorldName
        Get
            Return myWorldName
        End Get
        Set(value As String)
            myConnection.Send(New ChangeWorldNameSendMessage(value))
        End Set
    End Property

    Public WriteOnly Property Smiley As Smiley Implements IGame(Of TPlayer).Smiley
        Set(value As Smiley)
            myConnection.Send(New ChangeFaceSendMessage(value))
        End Set
    End Property

    Private myAllowPotions As Boolean

    Public ReadOnly Property AllowPotions As Boolean Implements IGame(Of TPlayer).AllowPotions
        Get
            Return myAllowPotions
        End Get
    End Property

    Private myGravityMultiplayer As Double

    Public ReadOnly Property GravityMultiplayer As Double Implements IGame(Of TPlayer).GravityMultiplayer
        Get
            Return myGravityMultiplayer
        End Get
    End Property

    Private myIsTutorialRoom As Boolean

    Public ReadOnly Property IsTutorialRoom As Boolean Implements IGame(Of TPlayer).IsTutorialRoom
        Get
            Return myIsTutorialRoom
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(client As IClient(Of Player))
        myClient = client
        myConnection = myClient.Connection
    End Sub

    Public Sub Clear() Implements IGame(Of TPlayer).Clear
        myConnection.Send(New ClearWorldSendMessage)
    End Sub

    Public Sub EnterModMode() Implements IGame(Of TPlayer).EnterModMode
        myConnection.Send(New ModModeSendMessage)
    End Sub

    Public Sub LoadLevel() Implements IGame(Of TPlayer).LoadLevel
        myClient.Chatter.Loadlevel()
    End Sub

    Public Sub PressBlueKey() Implements IGame(Of TPlayer).PressBlueKey
        myConnection.Send(New PressBlueKeySendMessage)
    End Sub

    Public Sub PressRedKey() Implements IGame(Of TPlayer).PressRedKey
        myConnection.Send(New PressRedKeySendMessage)
    End Sub

    Public Sub PressGreenKey() Implements IGame(Of TPlayer).PressGreenKey
        myConnection.Send(New PressGreenKeySendMessage)
    End Sub

    Public Sub Reset() Implements IGame(Of TPlayer).Reset
        myClient.Chatter.Reset()
    End Sub

    Public Sub Save() Implements IGame(Of TPlayer).Save
        myConnection.Send(New SaveWorldSendMessage)
    End Sub

    Public Sub TryAccess(key As String) Implements IGame(Of TPlayer).TryAccess
        myConnection.Send(New AccessSendMessage(key))
    End Sub

    Public Sub UsePotion(potion As Potion) Implements IGame(Of TPlayer).UsePotion
        myConnection.Send(New PotionSendMessage(potion))
    End Sub

    Private Sub myConnection_ReceiveClear(sender As Object, e As ClearReceiveMessage) Handles myConnection.ReceiveClear
        RaiseEvent OnClear(Me, EventArgs.Empty)
    End Sub

    Private Sub myConnection_ReceiveHideKey(sender As Object, e As HideKeyReceiveMessage) Handles myConnection.ReceiveHideKey
        RaiseEvent KeyRelease(Me, e.Key)
        Select Case e.Key
            Case Key.Blue
                myBlueKey = False
            Case Key.Green
                myGreenKey = False
            Case Key.Red
                myRedKey = False
            Case Key.TimeDoor
                myTimedKey = False
        End Select
    End Sub

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit
        myMyPlayer = New TPlayer
        myMyPlayer.SetupPlayer(New InternalPlayer(myClient, e), myClient.Chatter)
        myOwner = e.UsernameOwner
        myWorldName = e.WorldName
        myPlays = e.Plays
        myEncryption = Derot(e.Encryption)
        myIsTutorialRoom = e.IsTutorialRoom
        myGravityMultiplayer = e.Gravity
        myAllowPotions = e.AllowPotions


        If e.IsOwner Then
            myAccessRight = AccessRight.Owner
        ElseIf e.CanEdit Then
            myAccessRight = AccessRight.Edit
        End If

        ParsePotion(e)

        RaiseEvent Init(Me, EventArgs.Empty)
    End Sub

    Private Sub ParsePotion(e As InitReceiveMessage)
        Dim startNum As UInteger
        For i = CInt(e.PlayerIOMessage.Count - 1) To 0 Step -1
            If TryCast(e.PlayerIOMessage.Item(CUInt(i)), String) IsNot Nothing AndAlso e.PlayerIOMessage.GetString(CUInt(i)) = "pe" Then
                startNum = CUInt(i - 1)
            End If
        Next
        Dim pointer As UInteger = startNum
        Do
            If TryCast(e.PlayerIOMessage.Item(pointer), String) IsNot Nothing AndAlso e.PlayerIOMessage.GetString(pointer) = "we" Then
                Exit Do
            End If
            Select Case CType(e.PlayerIOMessage.GetInteger(CUInt(pointer - 1)), Potion)
                Case Potion.BlueAura
                    myBlueAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.RedAura
                    myRedAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
                Case Potion.YellowAura
                    myYellowAuraPotionCount = e.PlayerIOMessage.GetInteger(pointer)
            End Select
            pointer = CUInt(pointer - 2)
        Loop
    End Sub

    Private Sub myConnection_OnReceiveLostAccess(sender As Object, e As LostAccessReceiveMessage) Handles myConnection.ReceiveLostAccess
        RaiseEvent AccessRightChange(Me, New ItemChangedEventArgs(Of AccessRight)(myAccessRight, AccessRight.None))
        myAccessRight = AccessRight.None
    End Sub

    Private Sub myConnection_OnReceiveAccess(sender As Object, e As AccessReceiveMessage) Handles myConnection.ReceiveAccess
        RaiseEvent AccessRightChange(Me, New ItemChangedEventArgs(Of AccessRight)(myAccessRight, AccessRight.Edit))
        myAccessRight = AccessRight.Edit
    End Sub

    Private Sub myConnection_ReceiveShowKey(sender As Object, e As ShowKeyReceiveMessage) Handles myConnection.ReceiveShowKey
        RaiseEvent KeyPress(Me, e.Key)
        Select Case e.Key
            Case Key.Blue
                myBlueKey = True
            Case Key.Green
                myGreenKey = True
            Case Key.Red
                myRedKey = True
            Case Key.TimeDoor
                myTimedKey = True
        End Select
    End Sub

    Private Sub myConnection_ReceiveUpdateMeta(sender As Object, e As UpdateMetaReceiveMessage) Handles myConnection.ReceiveUpdateMeta
        If myWorldName <> e.WorldName Then
            RaiseEvent WorldNameChange(Me, New ItemChangedEventArgs(Of String)(myWorldName, e.WorldName))
            myWorldName = e.WorldName
        End If

        If myPlays <> e.Plays Then
            RaiseEvent PlaysChange(Me, New ItemChangedEventArgs(Of Integer)(myPlays, e.Plays))
            myPlays = e.Plays
        End If

        If myOwner <> e.Owner Then
            RaiseEvent OwnerChange(Me, New ItemChangedEventArgs(Of String)(myOwner, e.Owner))
            myOwner = e.Owner
        End If
    End Sub

    Private Sub myConnection_ReceiveReset(sender As Object, e As ResetReceiveMessage) Handles myConnection.ReceiveReset
        RaiseEvent OnLoadLevel(Me, EventArgs.Empty)
    End Sub

    Private Sub myConnection_ReceiveTeleport(sender As Object, e As TeleportReceiveMessage) Handles myConnection.ReceiveTeleport
        RaiseEvent OnReset(Me, EventArgs.Empty)
    End Sub

    Private Sub myConnection_ReceiveSaveDone(sender As Object, e As SaveDoneReceiveMessage) Handles myConnection.ReceiveSaveDone
        RaiseEvent OnSave(Me, EventArgs.Empty)
    End Sub

#End Region
End Class