Friend Class CommandManager
    Private commandsDictionary As New Dictionary(Of String, CommandHandle)
    Private myBot As IHost
    Private myConnection As IConnection(Of Player)

    Sub New(connection As IConnection(Of Player), bot As IHost, target As Object)
        myConnection = connection
        Me.myBot = bot
        AddHandler myConnection.OnReceiveSay, AddressOf myConnection_OnReceiveSay
        AddHandler Cloud.Logger.OnInput, Sub(sender As Object, e As System.EventArgs) processMessage(Cloud.Logger.Input, Nothing)

        For Each method As Reflection.MethodInfo In target.GetType.GetMethods
            Dim myAttributes As Object() = method.GetCustomAttributes(GetType(CommandAttribute), True)
            If myAttributes IsNot Nothing AndAlso myAttributes.Length = 1 Then
                Dim myAttribute As CommandAttribute = CType(myAttributes(0), CommandAttribute)
                Try
                    Dim action As Action(Of ICommand) = CType([Delegate].CreateDelegate(GetType(Action(Of ICommand)), target, method), Action(Of ICommand))
                    Try
                        Dim syntax As New CommandSyntax(myAttribute.Syntax)
                        Dim handle As New CommandHandle(action, syntax)
                        Try
                            commandsDictionary.Add(myAttribute.Type, handle)
                            For Each item As String In myAttribute.Aliases
                                commandsDictionary.Add(item, handle)
                            Next
                        Catch ex As Exception
                            Cloud.Logger.Log(LogPriority.Error, "Duplicate command: " & myAttribute.Type)
                        End Try
                    Catch ex As Exception
                        Cloud.Logger.Log(LogPriority.Error, "Command has bad syntax: " & myAttribute.Type)
                        Cloud.Logger.Log(ex)
                    End Try
                Catch ex As Exception
                    Cloud.Logger.Log(LogPriority.Error, "Method has bad signature: " & myAttribute.Type)
                    Cloud.Logger.Log(ex)
                End Try
            End If
        Next
    End Sub

    Private Sub myConnection_OnReceiveSay(sender As Object, e As Say_ReceiveMessage)
        If e.Text.StartsWith("!") Then
            processMessage(e.Text.Substring(1), myConnection.Players(e.UserID))
        End If
    End Sub

    Private Sub processMessage(msg As String, sender As Player)
        Dim cmd As String() = msg.Split(" "c)
        Dim type As String = cmd(0).ToLower

        If Not commandsDictionary.ContainsKey(type) Then

            Exit Sub
        End If

        Dim handle As CommandHandle = commandsDictionary(type)

        If handle.Syntax.MinimumArgs > cmd.Length - 1 Then
            myBot.GetDefaultChatter(myConnection).Chat("Command usage: " & handle.Syntax.ToString)
            Exit Sub
        End If

        Dim myCommand As Command
        If cmd.Length > 1 Then
            Dim argnum = cmd.Length - 2
            If argnum < handle.Syntax.RecommendedArgs Then argnum = handle.Syntax.RecommendedArgs - 1
            Dim args(argnum) As String
            For i = 1 To cmd.Length - 1
                args(i - 1) = cmd(i)
            Next
            For i = cmd.Length - 1 To argnum
                args(i) = String.Empty
            Next
            myCommand = New Command(sender, type, args)
        Else
            myCommand = New Command(sender, type, {})
        End If

        Try
            handle.Action.Invoke(myCommand)
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to run command " & type)
            Cloud.Logger.Log(ex)
        End Try
    End Sub
End Class
