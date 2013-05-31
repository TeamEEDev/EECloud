Friend NotInheritable Class Chatter
    Implements IChatter

#Region "Fields"
    ReadOnly myInternalChatter As InternalChatter
    ReadOnly myChatName As String
#End Region

#Region "Properties"

    Public Property SyntaxProvider As IChatSyntaxProvider Implements IChatter.SyntaxProvider
        Get
            Return myInternalChatter.ChatSyntaxProvider
        End Get
        Set(value As IChatSyntaxProvider)
            If value Is Nothing Then
                Throw New ArgumentNullException("value")
            End If
            myInternalChatter.ChatSyntaxProvider = value
        End Set
    End Property

#End Region

#Region "Methods"

    Friend Sub New(internalChatter As InternalChatter, name As String)
        myInternalChatter = internalChatter
        myChatName = name
    End Sub


    Public Sub Chat(msg As String) Implements IChatter.Chat
        myInternalChatter.SendChat(myInternalChatter.ChatSyntaxProvider.ApplyChatSyntax(msg, myChatName))
    End Sub

    Public Sub Send(msg As String) Implements IChatter.Send
        myInternalChatter.SendChat(msg)
    End Sub

    Public Sub Reply(username As String, msg As String) Implements IChatter.Reply
        myInternalChatter.SendChat(myInternalChatter.ChatSyntaxProvider.ApplyReplySyntax(msg, myChatName, username))
    End Sub


    Public Sub GiveEdit(username As String) Implements IChatter.GiveEdit
        myInternalChatter.SendChat("/giveedit " & username)
    End Sub

    Public Sub RemoveEdit(username As String) Implements IChatter.RemoveEdit
        myInternalChatter.SendChat("/removeedit " & username)
    End Sub

    Public Sub Teleport(username As String) Implements IChatter.Teleport
        myInternalChatter.SendChat("/teleport " & username)
    End Sub

    Public Sub Teleport(username As String, x As Integer, y As Integer) Implements IChatter.Teleport
        myInternalChatter.SendChat("/teleport " & username & " " & x & " " & y)
    End Sub


    Public Sub Kick(username As String) Implements IChatter.Kick
        myInternalChatter.SendChat(myInternalChatter.ChatSyntaxProvider.ApplyKickSyntax(myChatName, username, String.Empty))
    End Sub

    Public Sub Kick(username As String, reason As String) Implements IChatter.Kick
        myInternalChatter.SendChat(myInternalChatter.ChatSyntaxProvider.ApplyKickSyntax(myChatName, username, reason))
    End Sub

    Public Sub KickGuests() Implements IChatter.KickGuests
        myInternalChatter.SendChat("/kickguests")
    End Sub

    Public Sub Kill(username As String) Implements IChatter.Kill
        myInternalChatter.SendChat("/kill " & username)
    End Sub

    Public Sub KillAll() Implements IChatter.KillAll
        myInternalChatter.SendChat("/killemall")
    End Sub

    Public Sub Reset() Implements IChatter.Reset
        myInternalChatter.SendChat("/reset")
    End Sub

    Public Sub Respawn() Implements IChatter.Respawn
        myInternalChatter.SendChat("/respawn")
    End Sub

    Public Sub RespawnAll() Implements IChatter.RespawnAll
        myInternalChatter.SendChat("/respawnall")
    End Sub


    Public Sub PotionsOn(ParamArray potions As String()) Implements IChatter.PotionsOn
        myInternalChatter.SendChat("/potionson  " & String.Join(" ", potions))
    End Sub

    Public Sub PotionsOn(ParamArray potions As Integer()) Implements IChatter.PotionsOn
        myInternalChatter.SendChat("/potionson  " & String.Join(" ", potions))
    End Sub

    Public Sub PotionsOn(ParamArray potions As Potion()) Implements IChatter.PotionsOn
        Dim p(potions.Length - 1) As Integer
        For n = 0 To potions.Length - 1
            p(n) = CInt(potions(n))
        Next

        myInternalChatter.SendChat("/potionson  " & String.Join(" ", p))
    End Sub

    Public Sub PotionsOff(ParamArray potions As String()) Implements IChatter.PotionsOff
        myInternalChatter.SendChat("/potionsoff  " & String.Join(" ", potions))
    End Sub

    Public Sub PotionsOff(ParamArray potions As Integer()) Implements IChatter.PotionsOff
        myInternalChatter.SendChat("/potionsoff  " & String.Join(" ", potions))
    End Sub

    Public Sub PotionsOff(ParamArray potions As Potion()) Implements IChatter.PotionsOff
        Dim p(potions.Length - 1) As Integer
        For n = 0 To potions.Length - 1
            p(n) = CInt(potions(n))
        Next

        myInternalChatter.SendChat("/potionsoff  " & String.Join(" ", p))
    End Sub


    Public Sub ChangeVisibility(visible As Boolean) Implements IChatter.ChangeVisibility
        myInternalChatter.SendChat("/visible " & visible.ToString())
    End Sub


    Public Sub LoadLevel() Implements IChatter.LoadLevel
        myInternalChatter.SendChat("/loadlevel")
    End Sub

#End Region

End Class
