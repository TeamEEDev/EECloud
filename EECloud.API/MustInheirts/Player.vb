Public Class Player
    Implements IPlayer

#Region "Fields"
    Private WithEvents myPlayer As IPlayer
    Private myChatter As IChatter
#End Region

#Region "Events"
    Public Event AutoText(sender As Object, e As AutoText) Implements IPlayer.AutoText

    Public Event Chat(sender As Object, e As String) Implements IPlayer.Chat

    Public Event Coin(sender As Object, e As ItemChangedEventArgs(Of Integer)) Implements IPlayer.Coin

    Public Event GodMode(sender As Object, e As ItemChangedEventArgs(Of Boolean)) Implements IPlayer.GodMode

    Public Event Leave(sender As Object, e As EventArgs) Implements IPlayer.Leave

    Public Event ModMode(sender As Object, e As ItemChangedEventArgs(Of Boolean)) Implements IPlayer.ModMode

    Public Event Move(sender As Object, e As MoveReceiveMessage) Implements IPlayer.Move

    Public Event SilverCrown(sender As Object, e As EventArgs) Implements IPlayer.SilverCrown

    Public Event SmileyChange(sender As Object, e As ItemChangedEventArgs(Of Smiley)) Implements IPlayer.SmileyChange

    Public Event UsePotion(sender As Object, e As Potion) Implements IPlayer.UsePotion

    Public Event DeactivatePotion(sender As Object, e As Potion) Implements IPlayer.DeactivatePotion

    Public Event GroupChange(sender As Object, e As ItemChangedEventArgs(Of Group)) Implements IPlayer.GroupChange

    Public Event LoadUserData(sender As Object, e As EEService.UserData) Implements IPlayer.LoadUserData
#End Region

#Region "EventHandlers"
    Private Sub myPlayer_AutoText(sender As Object, e As AutoText) Handles myPlayer.AutoText
        RaiseEvent AutoText(Me, e)
    End Sub

    Private Sub myPlayer_Chat(sender As Object, e As String) Handles myPlayer.Chat
        RaiseEvent Chat(Me, e)
    End Sub

    Private Sub myPlayer_Coin(sender As Object, e As ItemChangedEventArgs(Of Integer)) Handles myPlayer.Coin
        RaiseEvent Coin(Me, e)
    End Sub

    Private Sub myPlayer_DeactivatePotion(sender As Object, e As Potion) Handles myPlayer.DeactivatePotion
        RaiseEvent DeactivatePotion(Me, e)
    End Sub

    Private Sub myPlayer_GodMode(sender As Object, e As ItemChangedEventArgs(Of Boolean)) Handles myPlayer.GodMode
        RaiseEvent GodMode(Me, e)
    End Sub

    Private Sub myPlayer_GroupChange(sender As Object, e As ItemChangedEventArgs(Of Group)) Handles myPlayer.GroupChange
        RaiseEvent GroupChange(Me, e)
    End Sub

    Private Sub myPlayer_Leave(sender As Object, e As EventArgs) Handles myPlayer.Leave
        RaiseEvent Leave(Me, e)
    End Sub

    Private Sub myPlayer_LoadUserData(sender As Object, e As EEService.UserData) Handles myPlayer.LoadUserData
        RaiseEvent LoadUserData(Me, e)
    End Sub

    Private Sub myPlayer_ModMode(sender As Object, e As ItemChangedEventArgs(Of Boolean)) Handles myPlayer.ModMode
        RaiseEvent ModMode(Me, e)
    End Sub

    Private Sub myPlayer_Move(sender As Object, e As MoveReceiveMessage) Handles myPlayer.Move
        RaiseEvent Move(Me, e)
    End Sub

    Private Sub myPlayer_SilverCrown(sender As Object, e As EventArgs) Handles myPlayer.SilverCrown
        RaiseEvent SilverCrown(Me, e)
    End Sub

    Private Sub myPlayer_SmileyChange(sender As Object, e As ItemChangedEventArgs(Of Smiley)) Handles myPlayer.SmileyChange
        RaiseEvent SmileyChange(Me, e)
    End Sub

    Private Sub myPlayer_UsePotion(sender As Object, e As Potion) Handles myPlayer.UsePotion
        RaiseEvent UsePotion(Me, e)
    End Sub
#End Region

#Region "Properties"

    Public ReadOnly Property Coins As Integer Implements IPlayer.Coins
        Get
            Try
                Return myPlayer.Coins
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property UserID As Integer Implements IPlayer.UserID
        Get
            Try
                Return myPlayer.UserID
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property Username As String Implements IPlayer.Username
        Get
            Try
                Return myPlayer.Username
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property Smiley As Smiley Implements IPlayer.Smiley
        Get
            Try
                Return myPlayer.Smiley
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property HasChat As Boolean Implements IPlayer.HasChat
        Get
            Try
                Return myPlayer.HasChat
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property Horizontal As Double Implements IPlayer.Horizontal
        Get
            Try
                Return myPlayer.Horizontal
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property IsGod As Boolean Implements IPlayer.IsGod
        Get
            Try
                Return myPlayer.IsGod
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property IsMod As Boolean Implements IPlayer.IsMod
        Get
            Try
                Return myPlayer.IsMod
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property IsMyFriend As Boolean Implements IPlayer.IsMyFriend
        Get
            Try
                Return myPlayer.IsMyFriend
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property ModifierX As Double Implements IPlayer.ModifierX
        Get
            Try
                Return myPlayer.ModifierX
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property ModifierY As Double Implements IPlayer.ModifierY
        Get
            Try
                Return myPlayer.ModifierY
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property PlayerPosX As Integer Implements IPlayer.PlayerPosX
        Get
            Try
                Return myPlayer.PlayerPosX
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property PlayerPosY As Integer Implements IPlayer.PlayerPosY
        Get
            Try
                Return myPlayer.PlayerPosY
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property SpeedX As Double Implements IPlayer.SpeedX
        Get
            Try
                Return myPlayer.SpeedX
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property SpeedY As Double Implements IPlayer.SpeedY
        Get
            Try
                Return myPlayer.SpeedY
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property Vertical As Double Implements IPlayer.Vertical
        Get
            Try
                Return myPlayer.Vertical
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Friend ReadOnly Property HasSilverCrown As Boolean Implements IPlayer.HasSilverCrown
        Get
            Try
                Return myPlayer.HasSilverCrown
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Friend ReadOnly Property HasCrown As Boolean Implements IPlayer.HasCrown
        Get
            Try
                Return myPlayer.HasCrown
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public Property Group As Group Implements IPlayer.Group
        Get
            Try
                Return myPlayer.Group
            Catch ex As Exception
                Return Nothing
            End Try
        End Get

        Set(value As Group)
            Try
                myPlayer.Group = value
            Catch
            End Try
        End Set
    End Property

    Public ReadOnly Property BlueAuraPotion As Boolean Implements IPlayer.BlueAuraPotion
        Get
            Try
                Return myPlayer.BlueAuraPotion
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property RedAuraPotion As Boolean Implements IPlayer.RedAuraPotion
        Get
            Try
                Return myPlayer.RedAuraPotion
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property YellowAuraPotion As Boolean Implements IPlayer.YellowAuraPotion
        Get
            Try
                Return myPlayer.YellowAuraPotion
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property SpawnX As Integer Implements IPlayer.SpawnX
        Get
            Try
                Return myPlayer.SpawnX
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property SpawnY As Integer Implements IPlayer.SpawnY
        Get
            Try
                Return myPlayer.SpawnY
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
#End Region

#Region "Methods"

    Friend Sub SetupPlayer(player As IPlayer, chatter As IChatter)
        myPlayer = player
        myChatter = chatter
    End Sub

    Public Async Function ReloadUserDataAsync() As Task Implements IPlayer.ReloadUserDataAsync
        Await myPlayer.ReloadUserDataAsync()
    End Function

    Public Sub Reply(msg As String) Implements IPlayer.Reply
        myChatter.Reply(Username, msg)
    End Sub

    Public Sub Kick(msg As String) Implements IPlayer.Kick
        myChatter.Kick(myPlayer.Username, msg)
    End Sub

#End Region
End Class
