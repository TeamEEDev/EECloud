Public Class Player
    Implements IPlayer

#Region "Fields"
    Private WithEvents myPlayer As IPlayer
    Private myChatter As IChatter
#End Region

#Region "Events"
    Public Event GroupChange(sender As Object, e As EventArgs) Implements IPlayer.GroupChange

    Public Event LoadUserData(sender As Object, e As UserData) Implements IPlayer.LoadUserData

    Public Event UserDataReady(sender As Object, e As EventArgs) Implements IPlayer.UserDataReady

    Public Event SaveUserData(sender As Object, e As EventArgs) Implements IPlayer.SaveUserData
#End Region

#Region "EventHandlers"

    Private Sub myPlayer_GroupChange(sender As Object, e As EventArgs) Handles myPlayer.GroupChange
        RaiseEvent GroupChange(Me, e)
    End Sub

    Private Sub myPlayer_LoadUserData(sender As Object, e As UserData) Handles myPlayer.LoadUserData
        RaiseEvent LoadUserData(Me, e)
    End Sub

    Private Sub myPlayer_SaveUserData(sender As Object, e As EventArgs) Handles myPlayer.SaveUserData
        RaiseEvent SaveUserData(Me, e)
    End Sub

    Private Sub myPlayer_UserDataReady(sender As Object, e As EventArgs) Handles myPlayer.UserDataReady
        RaiseEvent UserDataReady(Me, e)
    End Sub

#End Region

#Region "Properties"

    Public ReadOnly Property Username As String Implements IPlayer.Username
        Get
            Try
                Return myPlayer.Username
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property UserID As Integer Implements IPlayer.UserID
        Get
            Try
                Return myPlayer.UserID
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property IsUserDataReady As Boolean Implements IPlayer.IsUserDataReady
        Get
            Try
                Return myPlayer.IsUserDataReady
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property DatabaseName As String Implements IPlayer.DatabaseName
        Get
            Try
                Return myPlayer.DatabaseName
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public Property Group As Group Implements IPlayer.Group
        Get
            Try
                Return myPlayer.Group
            Catch
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

    Public ReadOnly Property IsGuest As Boolean Implements IPlayer.IsGuest
        Get
            Try
                Return myPlayer.IsGuest
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property IsGod As Boolean Implements IPlayer.IsGod
        Get
            Try
                Return myPlayer.IsGod
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property IsMod As Boolean Implements IPlayer.IsMod
        Get
            Try
                Return myPlayer.IsMod
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property IsMyFriend As Boolean Implements IPlayer.IsMyFriend
        Get
            Try
                Return myPlayer.IsMyFriend
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property IsClubMember As Boolean Implements IPlayer.IsClubMember
        Get
            Try
                Return myPlayer.IsClubMember
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property IsDisconnected As Boolean Implements IPlayer.IsDisconnected
        Get
            Try
                Return myPlayer.IsDisconnected
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property HasChat As Boolean Implements IPlayer.HasChat
        Get
            Try
                Return myPlayer.HasChat
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property MagicClass As MagicClass Implements IPlayer.MagicClass
        Get
            Try
                Return myPlayer.MagicClass
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property Smiley As Smiley Implements IPlayer.Smiley
        Get
            Try
                Return myPlayer.Smiley
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property Coins As Integer Implements IPlayer.Coins
        Get
            Try
                Return myPlayer.Coins
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property SpawnX As Integer Implements IPlayer.SpawnX
        Get
            Try
                Return myPlayer.SpawnX
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property SpawnY As Integer Implements IPlayer.SpawnY
        Get
            Try
                Return myPlayer.SpawnY
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property PlayerPosX As Integer Implements IPlayer.PlayerPosX
        Get
            Try
                Return myPlayer.PlayerPosX
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property PlayerPosY As Integer Implements IPlayer.PlayerPosY
        Get
            Try
                Return myPlayer.PlayerPosY
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property BlockX As Integer Implements IPlayer.BlockX
        Get
            Try
                Return myPlayer.BlockX
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property BlockY As Integer Implements IPlayer.BlockY
        Get
            Try
                Return myPlayer.BlockY
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property SpeedX As Double Implements IPlayer.SpeedX
        Get
            Try
                Return myPlayer.SpeedX
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property SpeedY As Double Implements IPlayer.SpeedY
        Get
            Try
                Return myPlayer.SpeedY
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property ModifierX As Double Implements IPlayer.ModifierX
        Get
            Try
                Return myPlayer.ModifierX
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property ModifierY As Double Implements IPlayer.ModifierY
        Get
            Try
                Return myPlayer.ModifierY
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property Vertical As Double Implements IPlayer.Vertical
        Get
            Try
                Return myPlayer.Vertical
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property Horizontal As Double Implements IPlayer.Horizontal
        Get
            Try
                Return myPlayer.Horizontal
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property Say As String Implements IPlayer.Say
        Get
            Try
                Return myPlayer.Say
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property AutoText As String Implements IPlayer.AutoText
        Get
            Try
                Return myPlayer.AutoText
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Friend ReadOnly Property HasCrown As Boolean Implements IPlayer.HasCrown
        Get
            Try
                Return myPlayer.HasCrown
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Friend ReadOnly Property HasSilverCrown As Boolean Implements IPlayer.HasSilverCrown
        Get
            Try
                Return myPlayer.HasSilverCrown
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property RedAuraPotion As Boolean Implements IPlayer.RedAuraPotion
        Get
            Try
                Return myPlayer.RedAuraPotion
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property BlueAuraPotion As Boolean Implements IPlayer.BlueAuraPotion
        Get
            Try
                Return myPlayer.BlueAuraPotion
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property YellowAuraPotion As Boolean Implements IPlayer.YellowAuraPotion
        Get
            Try
                Return myPlayer.YellowAuraPotion
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property GreenAuraPotion As Boolean Implements IPlayer.GreenAuraPotion
        Get
            Try
                Return myPlayer.GreenAuraPotion
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property JumpPotion As Boolean Implements IPlayer.JumpPotion
        Get
            Try
                Return myPlayer.JumpPotion
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property FirePotion As Boolean Implements IPlayer.FirePotion
        Get
            Try
                Return myPlayer.FirePotion
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property CursePotion As Boolean Implements IPlayer.CursePotion
        Get
            Try
                Return myPlayer.CursePotion
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property ProtectionPotion As Boolean Implements IPlayer.ProtectionPotion
        Get
            Try
                Return myPlayer.ProtectionPotion
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property LastPotion As Potion? Implements IPlayer.LastPotion
        Get
            Try
                Return myPlayer.LastPotion
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property LastPotionEnabled As Boolean Implements IPlayer.LastPotionEnabled
        Get
            Try
                Return myPlayer.LastPotionEnabled
            Catch
                Return Nothing
            End Try
        End Get
    End Property

    Public ReadOnly Property LastPotionTimeout As Integer Implements IPlayer.LastPotionTimeout
        Get
            Try
                Return myPlayer.LastPotionTimeout
            Catch
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

    Public Sub ReloadUserData() Implements IPlayer.ReloadUserData
        myPlayer.ReloadUserData()
    End Sub

    Public Function ReloadUserDataAsync() As Task Implements IPlayer.ReloadUserDataAsync
        Return myPlayer.ReloadUserDataAsync()
    End Function

    Public Sub Reply(msg As String) Implements IPlayer.Reply
        myChatter.Reply(Username, msg)
    End Sub

    Public Sub Kick(msg As String) Implements IPlayer.Kick
        myChatter.Kick(Username, msg)
    End Sub

    Public Sub GiveEdit() Implements IPlayer.GiveEdit
        myChatter.GiveEdit(myPlayer.Username)
    End Sub

    Public Sub RemoveEdit() Implements IPlayer.RemoveEdit
        myChatter.RemoveEdit(myPlayer.Username)
    End Sub

    Public Sub Save() Implements IPlayer.Save
        myPlayer.Save()
    End Sub

    Public Sub Kill() Implements IPlayer.Kill
        myChatter.Kill(Username)
    End Sub

    Public Sub Teleport() Implements IPlayer.Teleport
        myChatter.Teleport(Username)
    End Sub

    Public Sub Teleport(x As Integer, y As Integer) Implements IPlayer.Teleport
        myChatter.Teleport(Username, x, y)
    End Sub

    Public Sub Kick() Implements IPlayer.Kick
        myChatter.Kick(Username)
    End Sub

#End Region

End Class
