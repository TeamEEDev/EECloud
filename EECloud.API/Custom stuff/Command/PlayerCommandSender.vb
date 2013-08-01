Public Class PlayerCommandSender(Of TPlayer As {Player, New})
    Inherits CommandSender
#Region "Properties"
    Private myPlayer As TPlayer

    Public ReadOnly Property Player As TPlayer
        Get
            Return myPlayer
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub New(player As TPlayer)
        MyBase.New(CommandSenderType.Player)

        myPlayer = player
    End Sub

    Friend Overrides Sub Reply(msg As String)
        Player.Reply(msg)
    End Sub

#End Region

End Class
