Public Class Player
    Implements IPlayer

#Region "Fields"
    Private myPlayer As IPlayer
    Private myChatter As IChatter
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

    Public ReadOnly Property Face As Smiley Implements IPlayer.Face
        Get
            Try
                Return myPlayer.Face
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

    Public ReadOnly Property UserData As EEService.UserData Implements IPlayer.UserData
        Get
            Return myPlayer.UserData
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
#End Region
End Class
