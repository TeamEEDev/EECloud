Imports System.Reflection

Friend Class CommandManager
    Private ReadOnly myCommandsDictionary As New Dictionary(Of String, CommandHandle)
    Private ReadOnly myConnection As IConnection(Of Player)

    Sub New(connection As IConnection(Of Player), target As Object)
        myConnection = connection
        AddHandler myConnection.OnReceiveSay, AddressOf myConnection_OnReceiveSay
        AddHandler Cloud.Logger.OnInput,
            Sub(sender As Object, e As EventArgs) ProcessMessage(Cloud.Logger.Input, Nothing)

        For Each method As MethodInfo In target.GetType.GetMethods
            Dim attributes As Object() = method.GetCustomAttributes(GetType(CommandAttribute), True)
            If attributes IsNot Nothing AndAlso attributes.Length = 1 Then
                Dim attribute As CommandAttribute = CType(attributes(0), CommandAttribute)
                Try
                    Dim handle As New CommandHandle(attribute.Type, method, target)
                    Try
                        myCommandsDictionary.Add(attribute.Type, handle)
                        For Each item As String In attribute.Aliases
                            myCommandsDictionary.Add(item, handle)
                        Next
                    Catch ex As Exception
                        Cloud.Logger.Log(LogPriority.Error, "Duplicate command: " & attribute.Type)
                    End Try
                Catch ex As Exception
                    Cloud.Logger.Log(LogPriority.Error, "Method has bad signature: " & attribute.Type)
                    Cloud.Logger.Log(ex)
                End Try
            End If
        Next
    End Sub

    Private Sub myConnection_OnReceiveSay(sender As Object, e As Say_ReceiveMessage)
        If e.Text.StartsWith("!", StringComparison.Ordinal) Then
            ProcessMessage(e.Text.Substring(1), myConnection.PlayerManager.Players(e.UserID))
        End If
    End Sub

    Private Sub ProcessMessage(msg As String, sender As Player)
        Dim cmd As String() = msg.Split(" "c)
        Dim type As String = cmd(0).ToLower

        If Not myCommandsDictionary.ContainsKey(type) Then
            Exit Sub
        End If

        Dim handle As CommandHandle = myCommandsDictionary(type)

        If handle.MinimumArgs > cmd.Length - 1 Then
            myConnection.Chatter.Chat("Command usage: " & handle.ToString)
            Exit Sub
        End If

        Dim command As New Command(sender, type)
        Try
            handle.Run(command)
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to run command " & type)
            Cloud.Logger.Log(ex)
        End Try
    End Sub
End Class
