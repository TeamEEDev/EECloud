Imports System.Reflection

Friend Class CommandManager
    Private commandsDictionary As New Dictionary(Of String, CommandHandle)
    Private myConnection As IConnection(Of Player)

    Sub New(connection As IConnection(Of Player), target As Object)
        myConnection = connection
        AddHandler myConnection.OnReceiveSay, AddressOf myConnection_OnReceiveSay
        AddHandler Cloud.Logger.OnInput, Sub(sender As Object, e As System.EventArgs) processMessage(Cloud.Logger.Input, Nothing)

        For Each method As Reflection.MethodInfo In target.GetType.GetMethods
            Dim myAttributes As Object() = method.GetCustomAttributes(GetType(CommandAttribute), True)
            If myAttributes IsNot Nothing AndAlso myAttributes.Length = 1 Then
                Dim myAttribute As CommandAttribute = CType(myAttributes(0), CommandAttribute)
                Try
                    Dim handle As New CommandHandle(myAttribute.Type, method, target)
                    Try
                        commandsDictionary.Add(myAttribute.Type, handle)
                        For Each item As String In myAttribute.Aliases
                            commandsDictionary.Add(item, handle)
                        Next
                    Catch ex As Exception
                        Cloud.Logger.Log(LogPriority.Error, "Duplicate command: " & myAttribute.Type)
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
            processMessage(e.Text.Substring(1), myConnection.PlayerManager.Players(e.UserID))
        End If
    End Sub

    Private Sub processMessage(msg As String, sender As Player)
        Dim cmd As String() = msg.Split(" "c)
        Dim type As String = cmd(0).ToLower

        If Not commandsDictionary.ContainsKey(type) Then
            Exit Sub
        End If

        Dim handle As CommandHandle = commandsDictionary(type)

        If handle.MinimumArgs > cmd.Length - 1 Then
            myConnection.Chatter.Chat("Command usage: " & handle.ToString)
            Exit Sub
        End If

        Dim myCommand As New Command(sender, type)
        Try
            handle.Run(myCommand)
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to run command " & type)
            Cloud.Logger.Log(ex)
        End Try
    End Sub
End Class
