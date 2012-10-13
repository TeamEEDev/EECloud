Public Class Game
    Implements IGame

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)
    Private WithEvents myConnection As IConnection
#End Region

#Region "Event"
    Public Event GodModeChange(sender As Object, e As String) Implements IGame.GodModeChange

    Public Event LocationChange(sender As Object, e As ItemChangedEventArgs(Of Location)) Implements IGame.LocationChange

    Public Event NameChange(sender As Object, e As String) Implements IGame.NameChange

    Public Event OnClear(sender As Object, e As EventArgs) Implements IGame.OnClear

    Public Event OnLoadLevel(sender As Object, e As EventArgs) Implements IGame.OnLoadLevel

    Public Event OnReset(sender As Object, e As EventArgs) Implements IGame.OnReset

    Public Event OnSave(sender As Object, e As EventArgs) Implements IGame.OnSave

    Public Event SmileyChange(sender As Object, e As Smiley) Implements IGame.SmileyChange
#End Region

#Region "Properties"

    Public ReadOnly Property BlueAuraPotionCount As Integer Implements IGame.BlueAuraPotionCount
        Get

        End Get
    End Property

    Public ReadOnly Property BlueKey As KeyState Implements IGame.BlueKey
        Get

        End Get
    End Property

    Public Property EditKey As String Implements IGame.EditKey

    Public ReadOnly Property Encryption As String Implements IGame.Encryption
        Get

        End Get
    End Property

    Public ReadOnly Property GreenKey As KeyState Implements IGame.GreenKey
        Get

        End Get
    End Property

    Public ReadOnly Property ModMode As Boolean Implements IGame.ModMode
        Get

        End Get
    End Property

    Public ReadOnly Property MyPlayer As Player Implements IGame.MyPlayer
        Get

        End Get
    End Property

    Public ReadOnly Property Owner As String Implements IGame.Owner
        Get

        End Get
    End Property

    Public ReadOnly Property Plays As String Implements IGame.Plays
        Get

        End Get
    End Property

    Public ReadOnly Property RedAuraPotionCount As Integer Implements IGame.RedAuraPotionCount
        Get

        End Get
    End Property

    Public ReadOnly Property RedKey As KeyState Implements IGame.RedKey
        Get

        End Get
    End Property

    Public ReadOnly Property TimedKey As KeyState Implements IGame.TimedKey
        Get

        End Get
    End Property

    Public ReadOnly Property YellowAuraPotionCount As Integer Implements IGame.YellowAuraPotionCount
        Get

        End Get
    End Property

    Public ReadOnly Property AccessRight As AccessRight Implements IGame.AccessRight
        Get

        End Get
    End Property

    Public Property GodMode As Boolean Implements IGame.GodMode
        Get

        End Get
        Set(value As Boolean)

        End Set
    End Property

    Public Property Location As Location Implements IGame.Location
        Get

        End Get
        Set(value As Location)

        End Set
    End Property

    Public Property WorldName As String Implements IGame.WorldName
        Get

        End Get
        Set(value As String)

        End Set
    End Property

    Public Property Smiley As Smiley Implements IGame.Smiley
        Get

        End Get
        Set(value As Smiley)

        End Set
    End Property

#End Region

#Region "Methods"

    Sub New(client As IClient(Of Player))
        myClient = client
        myConnection = myClient.Connection
    End Sub

    Public Sub Clear() Implements IGame.Clear
        myConnection.Send(New ClearWorldSendMessage)
    End Sub

    Public Sub EnterModMode() Implements IGame.EnterModMode
        myConnection.Send(New ModModeSendMessage)
    End Sub

    Public Sub LoadLevel() Implements IGame.LoadLevel
        myClient.Chatter.Loadlevel()
    End Sub

    Public Sub PressBlueKey() Implements IGame.PressBlueKey
        myConnection.Send(New PressBlueKeySendMessage)
    End Sub

    Public Sub PressRedKey() Implements IGame.PressRedKey
        myConnection.Send(New PressRedKeySendMessage)
    End Sub

    Public Sub PressGreenKey() Implements IGame.PressGreenKey
        myConnection.Send(New PressGreenKeySendMessage)
    End Sub

    Public Sub Reset() Implements IGame.Reset
        myClient.Chatter.Reset()
    End Sub

    Public Sub Save() Implements IGame.Save
        myConnection.Send(New SaveWorldSendMessage)
    End Sub

    Public Sub TryAccess(key As String) Implements IGame.TryAccess
        myConnection.Send(New AccessSendMessage(key))
    End Sub

    Public Sub UsePotion(potion As Potion) Implements IGame.UsePotion
        myConnection.Send(New PotionSendMessage(potion))
    End Sub

#End Region
End Class
