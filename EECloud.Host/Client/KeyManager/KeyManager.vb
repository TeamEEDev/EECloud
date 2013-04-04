Friend Class KeyManager
    Implements IKeyManager

#Region "Fields"
    Private WithEvents myConnection As IConnection
#End Region

#Region "Events"
    Friend Event OnBlueKey(sender As Object, e As Boolean) Implements IKeyManager.OnBlueKey

    Friend Event OnGreenKey(sender As Object, e As Boolean) Implements IKeyManager.OnGreenKey

    Friend Event OnPress(sender As Object, e As Key) Implements IKeyManager.OnPress

    Friend Event OnRedKey(sender As Object, e As Boolean) Implements IKeyManager.OnRedKey

    Friend Event OnRelease(sender As Object, e As Key) Implements IKeyManager.OnRelease

    Friend Event OnTimedDoor(sender As Object, e As Boolean) Implements IKeyManager.OnTimedDoor
#End Region

#Region "Properties"

    Private myBlueKey As Boolean

    Friend ReadOnly Property BlueKey As Boolean Implements IKeyManager.BlueKey
        Get
            Return myBlueKey
        End Get
    End Property

    Private myGreenKey As Boolean

    Friend ReadOnly Property GreenKey As Boolean Implements IKeyManager.GreenKey
        Get
            Return myGreenKey
        End Get
    End Property

    Private myRedKey As Boolean

    Friend ReadOnly Property RedKey As Boolean Implements IKeyManager.RedKey
        Get
            Return myRedKey
        End Get
    End Property

    Private myTimeDoor As Boolean

    Friend ReadOnly Property TimeDoor As Boolean Implements IKeyManager.TimeDoor
        Get
            Return myTimeDoor
        End Get
    End Property

#End Region

#Region "Methods"

    Friend Sub New(client As IClient(Of Player))
        myConnection = client.Connection
    End Sub

    Friend Sub PressBlueKey() Implements IKeyManager.PressBlueKey
        myConnection.Send(New PressRedKeySendMessage)
    End Sub

    Friend Sub PressGreenKey() Implements IKeyManager.PressGreenKey
        myConnection.Send(New PressRedKeySendMessage)
    End Sub

    Friend Sub PressRedKey() Implements IKeyManager.PressRedKey
        myConnection.Send(New PressRedKeySendMessage)
    End Sub

    Private Sub myConnection_ReceiveHideKey(sender As Object, e As HideKeyReceiveMessage) Handles myConnection.ReceiveHideKey
        For Each key1 In e.Keys
            RaiseEvent OnPress(Me, key1)
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
            End Select
        Next
    End Sub

    Private Sub myConnection_ReceiveShowKey(sender As Object, e As ShowKeyReceiveMessage) Handles myConnection.ReceiveShowKey
        For Each key1 In e.Keys
            RaiseEvent OnRelease(Me, key1)
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
            End Select
        Next
    End Sub

#End Region

End Class
