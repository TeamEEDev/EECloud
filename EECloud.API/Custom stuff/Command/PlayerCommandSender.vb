Public NotInheritable Class PlayerCommandSender
    Inherits CommandSender

#Region "Properties"
    Private ReadOnly myPlayer As Player

    Public ReadOnly Property UserID As Integer
        Get
            Return myPlayer.UserID
        End Get
    End Property

    Public ReadOnly Property Username As String
        Get
            Return myPlayer.Username
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub New(player As Player)
        MyBase.New(CommandSenderType.Player)

        myPlayer = player
    End Sub

    Public Overrides Sub Reply(msg As String)
        Chatter.Reply(Username, msg)
    End Sub
#End Region
End Class
