Imports System.Threading

Friend NotInheritable Class Logger
    Implements ILogger

#Region "Fields"
    Private ReadOnly myClient As IClient(Of Player)

    Private myInput As String = String.Empty
    Private Shared ReadOnly maxInputLength As Integer = Console.BufferWidth - 4

    Private tabbingWord As String = String.Empty
    Private ReadOnly currentlyTabbableUsers As New List(Of String)
    Private myIsTabbingMultipleUsers As Boolean
    Private myTabbingMultipleUsersAt As Integer
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

    Private Property IsTabbingMultipleUsers As Boolean
        Get
            Return myIsTabbingMultipleUsers
        End Get
        Set(value As Boolean)
            If value <> myIsTabbingMultipleUsers Then
                If value Then
                    myTabbingMultipleUsersAt = -1
                Else
                    currentlyTabbableUsers.Clear()
                End If

                myIsTabbingMultipleUsers = value
            End If
        End Set
    End Property

#End Region

#Region "Methods"

    Sub New(client As IClient(Of Player))
        myClient = client

        If Not Cloud.IsNoConsole Then
            Console.Write(">")
            Call New Thread(AddressOf HandleInput) With {.IsBackground = True}.Start()
        End If
    End Sub

    Private Sub HandleInput()
        Dim inputKey As ConsoleKeyInfo

        Do
            inputKey = Console.ReadKey(True)

            Select Case inputKey.Key
                Case ConsoleKey.Enter
                    If Input.Length > 0 Then
                        Console.WriteLine()
                        RaiseEvent OnInput(Me, New EventArgs())
                        Input = String.Empty

                        IsTabbingMultipleUsers = False
                    End If
                Case ConsoleKey.Backspace
                    If Input.Length > 0 Then
                        Input = Left(Input, Input.Length - 1)

                        IsTabbingMultipleUsers = False
                    End If
                Case ConsoleKey.Tab
                    HandleUsernameTabbing()

                Case Else
                    If inputKey.Modifiers <> ConsoleModifiers.Control AndAlso inputKey.KeyChar <> Nothing Then
                        If Input.Length <= maxInputLength Then
                            myInput &= inputKey.KeyChar
                            Console.Write(inputKey.KeyChar)

                            IsTabbingMultipleUsers = False
                        End If
                    End If
            End Select
        Loop
        ' ReSharper disable FunctionNeverReturns
    End Sub
    ' ReSharper restore FunctionNeverReturns

    Private Sub HandleUsernameTabbing()
        If myClient.PlayerManager IsNot Nothing AndAlso myClient.PlayerManager.Count > 0 Then
            If Not IsTabbingMultipleUsers Then
                Dim splitInput() As String = Input.Split(" "c)
                tabbingWord = splitInput.Last().ToLower(InvariantCulture)

                If tabbingWord <> String.Empty Then
                    Dim users() As String = (From player In myClient.PlayerManager
                                             Where player.Username.StartsWith(tabbingWord, StringComparison.Ordinal)
                                             Select player.Username.ToUpper(InvariantCulture) &
                                             DirectCast(IIf(splitInput.Count = 1, ": ", " "), String)).ToArray()

                    If users.Count = 1 Then
                        Console.CursorLeft -= tabbingWord.Length
                        Console.Write(users(0))
                        myInput = Left(myInput, myInput.Length - tabbingWord.Length) & users(0)

                    ElseIf users.Count > 1 Then
                        IsTabbingMultipleUsers = True
                        currentlyTabbableUsers.AddRange(users)
                        currentlyTabbableUsers.Sort()

                        GoTo IsTabbingMultipleUsers
                    End If
                End If

                Exit Sub
            End If

IsTabbingMultipleUsers:
            Dim minusPos As Integer
            If myTabbingMultipleUsersAt = -1 Then
                minusPos = tabbingWord.Length
            Else
                minusPos = currentlyTabbableUsers(myTabbingMultipleUsersAt).Length
            End If

            If currentlyTabbableUsers.Count - 1 = myTabbingMultipleUsersAt Then
                myTabbingMultipleUsersAt = 0
            Else
                myTabbingMultipleUsersAt += 1
            End If

            Input = Left(myInput, myInput.Length - minusPos) & currentlyTabbableUsers(myTabbingMultipleUsersAt)
        End If
    End Sub

    Friend Sub Log(priority As LogPriority, str As String) Implements ILogger.Log
        If Not Cloud.IsNoConsole Then
            Dim output As String = String.Format("{0} [{1}] {2}",
                                                 Now.ToLongTimeString(),
                                                 priority.ToString().ToUpper(InvariantCulture),
                                                 str)
            Overwrite(Input.Length + 1, output)
            Console.Write(Environment.NewLine &
                          ">" & Input)
        End If
    End Sub

    Friend Sub LogEx(ex As Exception) Implements ILogger.LogEx
        Cloud.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled:" & Environment.NewLine &
                                                          "{1}" & Environment.NewLine &
                                                          "{2}",
                                                          ex.ToString(), ex.Message, ex.StackTrace))
    End Sub

    Private Shared Sub Overwrite(oldLength As Integer, newStr As String)
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
