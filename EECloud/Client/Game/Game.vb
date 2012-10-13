Public Class Game(Of TPlayer As {New, Player})
    Implements IGame(Of TPlayer)

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)
    Private WithEvents myConnection As IConnection
#End Region

#Region "Event"
    Public Event NameChange(sender As Object, e As String) Implements IGame(Of TPlayer).NameChange

    Public Event OnClear(sender As Object, e As EventArgs) Implements IGame(Of TPlayer).OnClear

    Public Event OnLoadLevel(sender As Object, e As EventArgs) Implements IGame(Of TPlayer).OnLoadLevel

    Public Event OnReset(sender As Object, e As EventArgs) Implements IGame(Of TPlayer).OnReset

    Public Event OnSave(sender As Object, e As EventArgs) Implements IGame(Of TPlayer).OnSave

    Public Event AccessRigthtChange(sender As Object, e As ItemChangedEventArgs(Of AccessRight)) Implements IGame(Of TPlayer).AccessRigthtChange

    Public Event BlueKeyStateChange(sender As Object, e As Boolean) Implements IGame(Of TPlayer).BlueKeyStateChange

    Public Event GreenKeyStateChange(sender As Object, e As Boolean) Implements IGame(Of TPlayer).GreenKeyStateChange

    Public Event KeyPress(sender As Object, e As Key) Implements IGame(Of TPlayer).KeyPress

    Public Event KeyRelease(sender As Object, e As Key) Implements IGame(Of TPlayer).KeyRelease

    Public Event RedKeyStateChange(sender As Object, e As Boolean) Implements IGame(Of TPlayer).RedKeyStateChange
#End Region

#Region "Properties"

    Public ReadOnly Property BlueAuraPotionCount As Integer Implements IGame(Of TPlayer).BlueAuraPotionCount
        Get

        End Get
    End Property

    Public ReadOnly Property BlueKey As KeyState Implements IGame(Of TPlayer).BlueKey
        Get

        End Get
    End Property

    Public ReadOnly Property Encryption As String Implements IGame(Of TPlayer).Encryption
        Get

        End Get
    End Property

    Public ReadOnly Property GreenKey As KeyState Implements IGame(Of TPlayer).GreenKey
        Get

        End Get
    End Property

    Public ReadOnly Property ModMode As Boolean Implements IGame(Of TPlayer).ModMode
        Get

        End Get
    End Property

    Private myMyPlayer As TPlayer

    Public ReadOnly Property MyPlayer As TPlayer Implements IGame(Of TPlayer).MyPlayer
        Get
            Return myMyPlayer
        End Get
    End Property

    Public ReadOnly Property Owner As String Implements IGame(Of TPlayer).Owner
        Get

        End Get
    End Property

    Public ReadOnly Property Plays As String Implements IGame(Of TPlayer).Plays
        Get

        End Get
    End Property

    Public ReadOnly Property RedAuraPotionCount As Integer Implements IGame(Of TPlayer).RedAuraPotionCount
        Get

        End Get
    End Property

    Public ReadOnly Property RedKey As KeyState Implements IGame(Of TPlayer).RedKey
        Get

        End Get
    End Property

    Public ReadOnly Property TimedKey As KeyState Implements IGame(Of TPlayer).TimedKey
        Get

        End Get
    End Property

    Public ReadOnly Property YellowAuraPotionCount As Integer Implements IGame(Of TPlayer).YellowAuraPotionCount
        Get

        End Get
    End Property

    Public ReadOnly Property AccessRight As AccessRight Implements IGame(Of TPlayer).AccessRight
        Get

        End Get
    End Property

    Public WriteOnly Property GodMode As Boolean Implements IGame(Of TPlayer).GodMode
        Set(value As Boolean)
            myConnection.Send(New GodModeSendMessage(value))
        End Set
    End Property

    Public WriteOnly Property Location As Location Implements IGame(Of TPlayer).Location
        Set(value As Location)
            myConnection.Send(New MoveSendMessage(value.X, value.Y, 0, 0, 0, 0, 0, 0))
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

    Private Sub myConnection_ReceiveInit(sender As Object, e As InitReceiveMessage) Handles myConnection.ReceiveInit
        myMyPlayer = New TPlayer
        myMyPlayer.SetupPlayer(New InternalPlayer(myClient, e), myClient.Chatter)
    End Sub

#End Region
End Class
