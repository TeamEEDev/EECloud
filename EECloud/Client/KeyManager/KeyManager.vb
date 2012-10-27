Public Class KeyManager
    Implements IKeyManager

#Region "Fields"
    Private WithEvents myConnection As IConnection
#End Region

#Region "Events"
    Public Event OnBlueKey(sender As Object, e As Boolean) Implements IKeyManager.OnBlueKey

    Public Event OnGreenKey(sender As Object, e As Boolean) Implements IKeyManager.OnGreenKey

    Public Event OnPress(sender As Object, e As Key) Implements IKeyManager.OnPress

    Public Event OnPurpleSwitch(sender As Object, e As Boolean) Implements IKeyManager.OnPurpleSwitch

    Public Event OnRedKey(sender As Object, e As Boolean) Implements IKeyManager.OnRedKey

    Public Event OnRelease(sender As Object, e As Key) Implements IKeyManager.OnRelease

    Public Event OnTimedDoor(sender As Object, e As Boolean) Implements IKeyManager.OnTimedDoor
#End Region

#Region "Properties"

    Private myBlueKey As Boolean

    Public ReadOnly Property BlueKey As Boolean Implements IKeyManager.BlueKey
        Get
            Return myBlueKey
        End Get
    End Property

    Private myGreenKey As Boolean

    Public ReadOnly Property GreenKey As Boolean Implements IKeyManager.GreenKey
        Get
            Return myGreenKey
        End Get
    End Property

    Private myRedKey As Boolean

    Public ReadOnly Property RedKey As Boolean Implements IKeyManager.RedKey
        Get
            Return myRedKey
        End Get
    End Property

    Private myTimeDoor As Boolean

    Public ReadOnly Property TimeDoor As Boolean Implements IKeyManager.TimeDoor
        Get
            Return myTimeDoor
        End Get
    End Property

    Private myPurpleSwitch As Boolean

    Public ReadOnly Property PurpleSwitch As Boolean Implements IKeyManager.PurpleSwitch
        Get
            Return myPurpleSwitch
        End Get
    End Property

#End Region

#Region "Methods"

    Public Sub New(client As IClient(Of Player))
        myConnection = client.Connection
    End Sub

    Public Sub PressBlueKey() Implements IKeyManager.PressBlueKey
        myConnection.Send(New PressRedKeySendMessage)
    End Sub

    Public Sub PressGreenKey() Implements IKeyManager.PressGreenKey
        myConnection.Send(New PressRedKeySendMessage)
    End Sub

    Public Sub PressPurpleSwitch() Implements IKeyManager.PressPurpleSwitch
        myConnection.Send(New PressPurpleSwitchSendMessage)
    End Sub

    Public Sub PressRedKey() Implements IKeyManager.PressRedKey
        myConnection.Send(New PressRedKeySendMessage)
    End Sub

    Private Sub myConnection_ReceiveHideKey(sender As Object, e As HideKeyReceiveMessage) Handles myConnection.ReceiveHideKey
        For Each key1 In e.Keys
            Select Case key1
                Case Key.Blue
                    RaiseEvent OnBlueKey(Me, False)
                    myBlueKey = False
                Case Key.Green
                    RaiseEvent OnGreenKey(Me, False)
                    myGreenKey = False
                Case Key.Red
                    RaiseEvent OnRedKey(Me, False)
                    myRedKey = False
                Case Key.TimeDoor
                    RaiseEvent OnTimedDoor(Me, False)
                    myTimeDoor = False
                Case Key.Purple
                    RaiseEvent OnPurpleSwitch(Me, False)
                    myPurpleSwitch = False
            End Select
        Next
    End Sub

    Private Sub myConnection_ReceiveShowKey(sender As Object, e As ShowKeyReceiveMessage) Handles myConnection.ReceiveShowKey
        For Each key1 In e.Keys
            Select Case key1
                Case Key.Blue
                    RaiseEvent OnBlueKey(Me, True)
                    myBlueKey = True
                Case Key.Green
                    RaiseEvent OnGreenKey(Me, True)
                    myGreenKey = True
                Case Key.Red
                    RaiseEvent OnRedKey(Me, True)
                    myRedKey = True
                Case Key.TimeDoor
                    RaiseEvent OnTimedDoor(Me, True)
                    myTimeDoor = True
                Case Key.Purple
                    RaiseEvent OnPurpleSwitch(Me, True)
                    myPurpleSwitch = True
            End Select
        Next
    End Sub

#End Region
End Class
