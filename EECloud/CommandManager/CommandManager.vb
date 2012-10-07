Imports System.Reflection

Friend NotInheritable Class CommandManager(Of TPlayer As {New, Player})
    Private ReadOnly myCommandsDictionary As New Dictionary(Of String, CommandHandle(Of TPlayer))
    Private ReadOnly myConnection As IConnection(Of TPlayer)
    Private WithEvents myInternalCommandManager As InternalCommandManager

    Sub New(connection As IConnection(Of TPlayer), internalCommandManager As InternalCommandManager)
        myConnection = connection
        myInternalCommandManager = internalCommandManager
    End Sub

    Friend Sub Add(target As Object)
        For Each method As MethodInfo In target.GetType.GetMethods
            Dim attributes As Object() = method.GetCustomAttributes(GetType(CommandAttribute), True)
            If attributes IsNot Nothing AndAlso attributes.Length = 1 Then
                Dim attribute As CommandAttribute = CType(attributes(0), CommandAttribute)
                Try
                    Dim handle As New CommandHandle(Of TPlayer)(attribute, method, target)
                    Try
                        myCommandsDictionary.Add(attribute.Type, handle)
                        For Each item As String In attribute.Aliases
                            myCommandsDictionary.Add(item, handle)
                        Next
                    Catch ex As Exception
                        Cloud.Logger.Log(LogPriority.Error, "Duplicate command: " & attribute.Type)
                        Cloud.Logger.Log(ex)
                    End Try
                Catch ex As Exception
                    Cloud.Logger.Log(LogPriority.Error, "Method has bad signature: " & attribute.Type)
                    Cloud.Logger.Log(ex)
                End Try
            End If
        Next
    End Sub

    Private Sub ProcessMessage(msg As String, user As Integer, e As CommandEventArgs) Handles myInternalCommandManager.OnCommand
        Dim sender As TPlayer = myConnection.PlayerManager.Players(user)
        If sender IsNot Nothing Then
            Dim cmd As String() = msg.Split(" "c)
            Dim type As String = cmd(0).ToLower

            If Not myCommandsDictionary.ContainsKey(type) Then
                Exit Sub
            End If

            e.Handled = True
            Dim handle As CommandHandle(Of TPlayer) = myCommandsDictionary(type)

            If Not sender Is Nothing AndAlso Not handle.Attribute.MinPermission = sender.UserData.GroupID.Value Then
                If sender.UserData.GroupID >= Group.Trusted Then
                    sender.Reply("You are not allowed to use this command!")
                End If
                Exit Sub
            End If

            If handle.Count > cmd.Length - 1 Then
                sender.Reply("Command usage: " & handle.ToString)
                Exit Sub
            End If

            Dim toCount As Integer = cmd.Length - 1
            If toCount > handle.Count Then toCount = handle.Count

            Dim args(toCount + CInt(IIf(handle.HasParamArray, 1, 0))) As Object
            args(0) = New Command(Of TPlayer)(sender, type)

            For i = 1 To toCount
                args(i) = cmd(i)
            Next

            If handle.HasParamArray Then
                Dim pramArgs(cmd.Length - toCount - 2) As String
                For i = 0 To cmd.Length - toCount - 2
                    pramArgs(i) = cmd(i + toCount + 1)
                Next

                args(args.Length - 1) = pramArgs
            End If

            Try
                handle.Run(args)
            Catch ex As Exception
                Cloud.Logger.Log(LogPriority.Error, "Failed to run command " & type)
                Cloud.Logger.Log(ex)
                sender.Reply("Failed to run command!")
                Exit Sub
            End Try
        End If
    End Sub
End Class
