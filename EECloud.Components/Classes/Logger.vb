﻿Imports System.Threading

Friend NotInheritable Class Logger
    Inherits BaseGlobalComponent
    Implements ILogger

    Dim OldTop As Integer
    Dim OldLeft As Integer

    Private myInput As String = String.Empty
    Public Property Input As String Implements ILogger.Input
        Get
            Return myInput
        End Get
        Set(value As String)
            If Not myBot.AppEnvironment = AppEnvironment.Release Then
                Overwrite(Input.Length + 1, ">" & value)
                Console.CursorLeft = value.Length + 1
                myInput = value
            End If
        End Set
    End Property

    Public Event OnInput As EventHandler Implements ILogger.OnInput
    Public Sub New(PBot As Bot)
        MyBase.New(PBot)
        If Not myBot.AppEnvironment = AppEnvironment.Release Then
            Console.Write(">")
            Dim Worker As New Thread(AddressOf HandleInput)
            Worker.Start()
        End If
    End Sub

    Public Sub HandleInput()
        Try
            Do
                OldTop = Console.CursorTop
                OldLeft = Console.CursorLeft
                Dim InputKey As System.ConsoleKeyInfo = Console.ReadKey
                If InputKey.Key = ConsoleKey.Backspace Then
                    If Input.Length >= 1 Then
                        Input = Input.Substring(0, Input.Length - 1)
                    Else 'Cancel
                        Console.CursorTop = OldTop
                        Console.CursorLeft = OldLeft
                    End If
                ElseIf InputKey.Key = ConsoleKey.Enter Then
                    If Input IsNot String.Empty Then
                        Console.CursorTop += 1
                        RaiseEvent OnInput(Me, New EventArgs)
                    End If
                    Input = String.Empty
                ElseIf InputKey.Key = ConsoleKey.Tab Then
                    Console.CursorTop = OldTop
                    Console.CursorLeft = OldLeft
                ElseIf InputKey.Modifiers = ConsoleModifiers.Control Then
                    Console.CursorTop = OldTop
                    Console.CursorLeft = OldLeft
                    Console.Write(" "c)
                    Console.CursorLeft -= 1
                ElseIf InputKey.KeyChar <> Nothing Then
                    If Input.Length <= 76 Then
                        myInput &= InputKey.KeyChar
                    Else
                        Console.CursorLeft -= 1
                        Console.Write(" "c)
                        Console.CursorTop = OldTop
                        Console.CursorLeft = OldLeft
                    End If
                Else
                    Console.CursorTop = OldTop
                    Console.CursorLeft = OldLeft
                End If
            Loop
        Catch ex As Exception
            Log(LogPriority.Serve, "Log Manager has crashed! Console input is disabled.")
        End Try
    End Sub

    Public Sub Log(priority As LogPriority, str As String) Implements ILogger.Log
        If Not myBot.AppEnvironment = AppEnvironment.Release Then
            OldTop += 1
            Dim Output As String = String.Format("{0} [{1}] {2}", Now.ToLongTimeString, priority.ToString.ToUpper, str)
            Overwrite(Input.Length + 1, Output)
            Console.WriteLine()
            Console.Write(">" & Input)
        End If
    End Sub

    Private Sub Overwrite(oldLength As Integer, newStr As String)
        Console.CursorLeft = 0
        Dim Spaces As Integer = oldLength - newStr.Length
        If Spaces > 0 Then
            Console.Write(newStr & Space(Spaces))
        Else
            Console.Write(newStr)
        End If
    End Sub
End Class
