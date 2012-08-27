Friend Class CommandManager
    Private commandsDictionary As New Dictionary(Of String, CommandHandle)
    Private myBot As IBot
    Private myConnection As Connection(Of Player)

    Sub New(connection As Connection(Of Player), bot As IBot, target As Object)
        myConnection = connection
        Me.myBot = bot
        AddHandler myConnection.OnReciveSay, AddressOf myConnection_OnReciveSay

        For Each method As Reflection.MethodInfo In target.GetType.GetMethods
            Dim myAttributes As Object() = method.GetCustomAttributes(GetType(CommandAttribute), True)
            If myAttributes IsNot Nothing AndAlso myAttributes.Length = 1 Then
                Dim myAttribute As CommandAttribute = CType(myAttributes(0), CommandAttribute)
                Try
                    Dim action As Action(Of Command) = CType([Delegate].CreateDelegate(GetType(Action(Of Command)), target, method), Action(Of Command))
                    Try
                        Dim syntax As New CommandSyntax(myAttribute.Syntax)
                        Dim handle As New CommandHandle(action, syntax)
                        Try
                            commandsDictionary.Add(myAttribute.Type, handle)
                            For Each item As String In myAttribute.Aliases
                                commandsDictionary.Add(item, handle)
                            Next
                        Catch ex As Exception
                            myBot.Logger.Log(LogPriority.Error, "Duplicate command: " & myAttribute.Type)
                        End Try
                    Catch ex As Exception
                        myBot.Logger.Log(LogPriority.Error, "Command has bad syntax: " & myAttribute.Type)
                        myBot.Logger.Log(ex)
                    End Try
                Catch ex As Exception
                    myBot.Logger.Log(LogPriority.Error, "Method has bad signature: " & myAttribute.Type)
                    myBot.Logger.Log(ex)
                End Try
            End If
        Next
    End Sub

    Private Sub myConnection_OnReciveSay(sender As Object, e As Say_ReciveMessage)
        If e.Text.StartsWith("!") Then
            Dim cmd As String() = e.Text.Substring(1).Split(" "c)
            Dim type As String = cmd(0).ToLower
            If commandsDictionary.ContainsKey(type) Then
                Dim handle As CommandHandle = commandsDictionary(type)
                If handle.Syntax.MinimumArgs <= cmd.Length - 1 Then
                    Dim args() As String = {}
                    If cmd.Length > 1 Then
                        ReDim args(cmd.Length - 2)
                        For i = 1 To cmd.Length - 1
                            args(i - 1) = cmd(i)
                        Next
                    End If
                    Dim myCommand As New Command(myConnection.Players(e.UserID), type, args)
                    handle.Action.Invoke(myCommand)
                Else
                    myConnection.DefaultChatter.Chat("Command usage: !" & e.Text.Substring(1).Split(" "c)(0).ToLower & " " & handle.Syntax.ToString.Substring(9))
                End If
            End If
        End If
    End Sub
End Class
