﻿Friend NotInheritable Class Chatter
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
                Throw New ArgumentException("value can not be null.", "value")
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

    Friend Sub Chat(msg As String) Implements IChatter.Chat
        myInternalChatter.SendChat(myInternalChatter.ChatSyntaxProvider.ApplyChatSyntax(msg, myChatName))
    End Sub

    Public Sub Send(msg As String) Implements IChatter.Send
        myInternalChatter.SendChat(msg)
    End Sub

    Friend Sub Reply(username As String, msg As String) Implements IChatter.Reply
        myInternalChatter.SendChat(myInternalChatter.ChatSyntaxProvider.ApplyReplySyntax(msg, myChatName, username))
    End Sub

    Friend Sub Kick(username As String, msg As String) Implements IChatter.Kick
        myInternalChatter.SendChat(myInternalChatter.ChatSyntaxProvider.ApplyKickSyntax(myChatName, username, msg))
    End Sub

    Friend Sub Loadlevel() Implements IChatter.Loadlevel
        myInternalChatter.SendChat("/loadlevel")
    End Sub

    Friend Sub Reset() Implements IChatter.Reset
        myInternalChatter.SendChat("/reset")
    End Sub

    Public Sub GiveEdit(username As String) Implements IChatter.GiveEdit
        myInternalChatter.SendChat("/giveedit " & username)
    End Sub

    Public Sub RemoveEdit(username As String) Implements IChatter.RemoveEdit
        myInternalChatter.SendChat("/removeedit " & username)
    End Sub

#End Region
End Class
