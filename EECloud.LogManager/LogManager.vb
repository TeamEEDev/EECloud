Imports System.Threading

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
        Console.Write(">") 'Init
        Dim Worker As New Thread(
            Sub()
                Try
                    Do
                        Dim OldTop As Integer = Console.CursorTop
                        Dim OldLeft As Integer = Console.CursorLeft
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
                        ElseIf InputKey.Key = ConsoleKey.Tab Then 'Cancel
                            Console.CursorTop = OldTop
                            Console.CursorLeft = OldLeft
                        ElseIf InputKey.Modifiers = ConsoleModifiers.Control Then 'Cancel
                            Console.CursorTop = OldTop
                            Console.CursorLeft = OldLeft
                            Console.Write(" "c)
                            Console.CursorLeft -= 1
                        ElseIf InputKey.KeyChar <> Nothing Then
                            If Input.Length <= 76 Then
                                m_Input &= InputKey.KeyChar
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
                    Log(LogPriority.Serve, "Log Manager has crashed! Console is disabled.")
                End Try
            End Sub)
        Worker.Start()
    End Sub

    Public Sub Log(priority As LogPriority, str As String) Implements ILogManager.Log
        Dim Output As String = String.Format("{0} [{1}] {2}", Now.ToLongTimeString, priority.ToString.ToUpper, str)
        Overwrite(Input.Length + 1, Output)
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
