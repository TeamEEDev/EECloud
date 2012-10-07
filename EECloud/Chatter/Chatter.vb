Friend NotInheritable Class Chatter
    Implements IChatter

#Region "Fields"
    ReadOnly myInternalChatter As InternalChatter
    ReadOnly myPrefix As String
#End Region

#Region "Properties"
    Private ReadOnly Property ChatPrefix As String
        Get
            Return String.Format("<{0}> ", myPrefix)
        End Get
    End Property

    Private ReadOnly Property ReplyPrefix(username As String) As String
        Get
            Return String.Format("<{0} (@{1})> ", myPrefix, StrConv(username, VbStrConv.ProperCase))
        End Get
    End Property
#End Region

#Region "Methods"

    Friend Sub New(internalChatter As InternalChatter, name As String)
        myInternalChatter = internalChatter
        myPrefix = name
    End Sub

    Friend Sub Chat(msg As String) Implements IChatter.Chat
        myInternalChatter.SendChat(ChatPrefix & msg)
    End Sub

    Public Sub Reply(username As String, msg As String) Implements IChatter.Reply
        myInternalChatter.SendChat(ReplyPrefix(username) & msg)
    End Sub

    Friend Sub Kick(user As Player, msg As String) Implements IChatter.Kick
        myInternalChatter.SendChat("/kick " & user.Username & " " & ChatPrefix & msg)
    End Sub

    Friend Sub Loadlevel() Implements IChatter.Loadlevel
        myInternalChatter.SendChat("/loadlevel")
    End Sub

    Friend Sub Reset() Implements IChatter.Reset
        myInternalChatter.SendChat("/reset")
    End Sub

#End Region
End Class
