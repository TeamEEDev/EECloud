Imports System.Threading

Friend NotInheritable Class Logger
    Implements ILogger

#Region "Fields"
    Private myInput As String = String.Empty
    Dim myOldTop As Integer
    Dim myOldLeft As Integer
#End Region

#Region "Events"
    Friend Event OnInput As EventHandler Implements ILogger.OnInput
#End Region

#Region "Properties"

    Friend Property Input As String Implements ILogger.Input
        Get
            Return myInput
        End Get
        Set(value As String)
            If Not Cloud.IsNoConsole Then
                Overwrite(Input.Length + 1, ">" & value)
                Console.CursorLeft = value.Length + 1
                myInput = value
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    Friend Sub New()
        If Not Cloud.IsNoConsole Then
            Console.Write(">")
            Dim worker As New Thread(AddressOf HandleInput)
            worker.IsBackground = True
            worker.Start()
        End If
    End Sub

    Private Sub HandleInput()
        Do
            myOldTop = Console.CursorTop
            myOldLeft = Console.CursorLeft
            Dim inputKey As ConsoleKeyInfo = Console.ReadKey
            If inputKey.Key = ConsoleKey.Backspace Then
                If Input.Length >= 1 Then
                    Input = Input.Substring(0, Input.Length - 1)
                Else 'Cancel
                    Console.CursorTop = myOldTop
                    Console.CursorLeft = myOldLeft
                End If
            ElseIf inputKey.Key = ConsoleKey.Enter Then
                If Input IsNot String.Empty Then
                    Console.WriteLine()
                    RaiseEvent OnInput(Me, New EventArgs)
                End If
                Input = String.Empty
            ElseIf inputKey.Key = ConsoleKey.Tab Then
                Console.CursorTop = myOldTop
                Console.CursorLeft = myOldLeft
            ElseIf inputKey.Modifiers = ConsoleModifiers.Control Then
                Console.CursorTop = myOldTop
                Console.CursorLeft = myOldLeft
                Console.Write(" "c)
                Console.CursorLeft -= 1
            ElseIf inputKey.KeyChar <> Nothing Then
                If Input.Length <= 76 Then
                    myInput &= inputKey.KeyChar
                Else
                    Console.CursorLeft -= 1
                    Console.Write(" "c)
                    Console.CursorTop = myOldTop
                    Console.CursorLeft = myOldLeft
                End If
            Else
                Console.CursorTop = myOldTop
                Console.CursorLeft = myOldLeft
            End If
        Loop
        ' ReSharper disable FunctionNeverReturns
    End Sub
    ' ReSharper restore FunctionNeverReturns

    Friend Sub Log(priority As LogPriority, str As String) Implements ILogger.Log
        Dim output As String = String.Format("{0} [{1}] {2}", Now.ToLongTimeString, priority.ToString.ToUpper(InvariantCulture), str)
        If Not Cloud.IsNoConsole Then
            myOldTop = Console.CursorTop
            Overwrite(Input.Length + 1, output)
            Console.WriteLine()
            Console.Write(">" & Input)
        End If
    End Sub

    Friend Sub LogEx(ex As Exception) Implements ILogger.LogEx
        Cloud.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled: {1} {2}", ex.ToString, ex.Message, ex.StackTrace))
    End Sub

    Private Sub Overwrite(oldLength As Integer, newStr As String)
        Console.CursorLeft = 0
        Dim spaces As Integer = oldLength - newStr.Length
        If spaces > 0 Then
            Console.Write(newStr & Space(spaces))
        Else
            Console.Write(newStr)
        End If
    End Sub

    Private Sub Logger_OnInput(sender As Object, e As EventArgs) Handles Me.OnInput
        GlobalCommandManager.Value.InvokeConsoleCmd(Input, Me)
    End Sub

#End Region
End Class
