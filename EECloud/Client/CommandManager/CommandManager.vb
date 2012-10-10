﻿Imports System.Reflection

Friend NotInheritable Class CommandManager(Of TPlayer As {New, Player})
    Implements ICommandManager

#Region "Fields"
    Private ReadOnly myCommandsDictionary As New Dictionary(Of String, List(Of CommandHandle(Of TPlayer)))
    Private ReadOnly myClient As IClient(Of TPlayer)
    Private WithEvents myInternalCommandManager As InternalCommandManager
    Private ReadOnly myAddedTargets As New List(Of Object)
#End Region

#Region "Methods"

    Sub New(client As IClient(Of TPlayer), internalCommandManager As InternalCommandManager)
        myClient = client
        myInternalCommandManager = internalCommandManager
    End Sub

    Friend Sub Add(target As Object) Implements ICommandManager.Add
        If myAddedTargets.Contains(target) Then
            Throw New EECloudException(ErrorCode.CommandTargetAlreadyAdded)
        End If
        For Each method As MethodInfo In target.GetType.GetMethods
            Dim attributes As Object() = method.GetCustomAttributes(GetType(CommandAttribute), True)
            If attributes IsNot Nothing AndAlso attributes.Length = 1 Then
                Dim attribute As CommandAttribute = CType(attributes(0), CommandAttribute)
                Try
                    Dim handle As New CommandHandle(Of TPlayer)(attribute, method, target)
                    Try
                        AddCommand(attribute.Type, handle)

                        For Each item As String In attribute.Aliases
                            AddCommand(item, handle)
                        Next
                    Catch ex As Exception
                        Cloud.Logger.Log(LogPriority.Error, "Failed to add command: " & attribute.Type)
                        Cloud.Logger.LogEx(ex)
                    End Try
                Catch ex As Exception
                    Cloud.Logger.Log(LogPriority.Error, "Method has bad signature: " & attribute.Type)
                    Cloud.Logger.LogEx(ex)
                End Try
            End If
        Next
    End Sub

    Private Sub ProcessMessage(msg As String, user As Integer, e As CommandEventArgs) Handles myInternalCommandManager.OnCommand
        Dim sender As TPlayer = myClient.PlayerManager.Players(user)
        Dim cmd As String() = msg.Split(" "c)
        Dim type As String = cmd(0).ToLower

        If myCommandsDictionary.ContainsKey(type) Then
            e.Handled = True
            For Each handle In myCommandsDictionary(type)
                'Check for syntax
                If handle.Count = cmd.Length - 1 OrElse (handle.Count < cmd.Length - 1 AndAlso handle.HasParamArray) Then
                    TryRunCmd(sender, cmd, type, handle)
                    Exit Sub
                End If
            Next
            'No signature matched
            Dim usages As String = String.Empty
            usages = myCommandsDictionary(type).Aggregate(usages, Function(current, handle) current & handle.ToString & " / ") 'Some LINQ magic here...
            sender.Reply("Command usage(s): " & Left(usages, usages.Length - 3))
        End If
    End Sub

    Private Sub TryRunCmd(sender As TPlayer, cmd As String(), type As String, handle As CommandHandle(Of TPlayer))
        'Check for rights
        If Not sender Is Nothing AndAlso Not handle.Attribute.MinPermission <= sender.Group Then
            If sender.Group >= Group.Trusted Then
                sender.Reply("You are not allowed to use this command!")
            End If
            Exit Sub
        End If

        'Check for access rights
        If myClient.World.AccessRight < handle.Attribute.AccessRight Then
            If handle.Attribute.AccessRight = AccessRight.Edit Then
                sender.Reply("Bot needs edit rights to run this command!")
            Else
                sender.Reply("Bot needs owner rights to run this command!")
            End If
            Exit Sub
        End If

        'Build args
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

        'Excecute
        Try
            handle.Run(args)
        Catch ex As Exception
            Cloud.Logger.Log(LogPriority.Error, "Failed to run command " & type)
            Cloud.Logger.LogEx(ex)
            sender.Reply("Failed to run command!")
            Exit Sub
        End Try
    End Sub

    Public Sub InvokeCommand(player As Player, msg As String) Implements ICommandManager.InvokeCommand
        myInternalCommandManager.HandleMessage(msg, player.UserID)
    End Sub

    Private Sub AddCommand(name As String, handle As CommandHandle(Of TPlayer))
        If myCommandsDictionary.ContainsKey(name) Then
            Dim list As List(Of CommandHandle(Of TPlayer)) = myCommandsDictionary(name)
            Dim usedNums As New List(Of Integer)
            Dim maxNum As Integer = -1
            For Each item In list
                usedNums.Add(item.Count)
                If item.HasParamArray Then
                    maxNum = item.Count
                End If
            Next
            If maxNum = -1 OrElse (handle.Count < maxNum AndAlso Not handle.HasParamArray) Then
                If Not usedNums.Contains(handle.Count) Then
                    myCommandsDictionary(name).Add(handle)
                Else
                    Cloud.Logger.Log(LogPriority.Error, "Can not overload command because of conflicting parameter count: " & name)
                End If
            Else
                Cloud.Logger.Log(LogPriority.Error, "Can not overload command because of conflicting ParamArray variable: " & name)
            End If
        Else
            Dim list As New List(Of CommandHandle(Of TPlayer))
            list.Add(handle)
            myCommandsDictionary.Add(name, list)
        End If
    End Sub

#End Region
End Class