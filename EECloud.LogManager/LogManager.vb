﻿Imports System.Threading

<Export(GetType(ILogManager))>
Public Class LogManager
    Implements ILogManager

    Private m_Input As String = String.Empty
    Public Property Input As String Implements ILogManager.Input
        Get
            Return m_Input
        End Get
        Set(value As String)
            Overwrite(Input.Length + 1, ">" & value)
            Console.CursorLeft = value.Length + 1
            m_Input = value
        End Set
    End Property

    Public Event OnInput As EventHandler Implements ILogManager.OnInput

    Sub New()
        Log("EECloud version: " & My.Application.Info.Version.ToString) 'Init
        Dim Worker As New Thread(
            Sub()
                Do
                    Dim InputKey As System.ConsoleKeyInfo = Console.ReadKey
                    Dim OldInputSize As Integer = Input.Length
                    If InputKey.Key = ConsoleKey.Backspace Then
                        If Input.Length >= 1 Then
                            Input = Input.Substring(0, Input.Length - 1)
                        Else
                            Console.CursorLeft = 1
                        End If
                    ElseIf InputKey.Key = ConsoleKey.Enter Then
                        Log(">" & Input)
                        RaiseEvent OnInput(Me, New EventArgs)
                        Input = String.Empty
                    Else
                        If Input.Length <= 76 Then
                            Input += InputKey.KeyChar
                        Else 'It gets buggy if it uses more than one line for input
                            Console.CursorLeft -= 1
                            Console.Write(" "c)
                            Console.CursorLeft -= 1
                        End If
                    End If
                Loop
            End Sub)
        Worker.Start()
    End Sub

    Public Sub Log(str As String) Implements ILogManager.Log
        Overwrite(Input.Length + 1, str)
        Console.WriteLine()
        Console.Write(">" & Input)
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
