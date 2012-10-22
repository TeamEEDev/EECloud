﻿Friend NotInheritable Class Chatter
    Implements IChatter

#Region "Fields"
    ReadOnly myInternalChatter As InternalChatter
    ReadOnly myChatName As String
#End Region

#Region "Methods"

    Friend Sub New(internalChatter As InternalChatter, name As String)
        myInternalChatter = internalChatter
        myChatName = name
    End Sub

    Friend Sub Chat(msg As String) Implements IChatter.Chat
        myInternalChatter.SendChat(myInternalChatter.ChatSyntaxProvider.ApplyChatSyntax(msg, myChatName))
    End Sub

    Public Sub Reply(username As String, msg As String) Implements IChatter.Reply
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

    Public Sub InjectSyntaxProvider(provider As IChatSyntaxProvider) Implements IChatter.InjectSyntaxProvider
        If provider Is Nothing Then
            Throw New ArgumentException("Provider can not be null.")
        End If
        myInternalChatter.ChatSyntaxProvider = provider
    End Sub

#End Region
End Class
