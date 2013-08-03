Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Threading

Module ModuleMain

#Region "Unmanaged calls"

    Private Delegate Function HandlerRoutine(ctrlType As Integer) As Boolean

    Private Const SW_HIDE As Integer = 0
    Private Const SW_RESTORE As Integer = 9

    <DllImport("user32.dll")>
    Private Sub SetForegroundWindow(handle As IntPtr)
    End Sub

    <DllImport("kernel32.dll")>
    Private Function GetConsoleWindow() As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Sub ShowWindow(hWnd As IntPtr, nCmdShow As Integer)
    End Sub

    <DllImport("kernel32.dll")>
    Private Sub SetConsoleCtrlHandler(handler As HandlerRoutine, add As Boolean)
    End Sub

#End Region

#Region "Fields"
    Private ReadOnly myHandle As IntPtr = GetConsoleWindow()

    Private WithEvents myAppProcess As New Process() With {.StartInfo = New ProcessStartInfo(My.Application.Info.DirectoryPath & "\EECloud.exe") With {.UseShellExecute = False},
                                                           .EnableRaisingEvents = True}
    Private WithEvents myTrayIcon As NotifyIcon

    Private ReadOnly mySeparatorText As String = Environment.NewLine &
                                                 New String("_"c, Console.BufferWidth)

    Private myLastRestart As Date
    Private myRestartTry As Integer
#End Region

#Region "Properties"

    Private myConsoleVisible As Boolean = True

    Public Property ConsoleVisible As Boolean
        Get
            Return myConsoleVisible
        End Get

        Set(value As Boolean)
            If value Then
                ShowWindow(myHandle, SW_RESTORE)
                SetForegroundWindow(GetConsoleWindow())
            Else
                ShowWindow(myHandle, SW_HIDE)
            End If

            myConsoleVisible = value
        End Set
    End Property

    Private Property Closing As Boolean

#End Region

#Region "Methods"

#Region "Initializers"

    Private Sub Initialize()
        SetConsoleCtrlHandler(AddressOf ConsoleCtrlCheck, True)

        Dim trayIconThread As New Thread(AddressOf InitializeTrayIcon)
        trayIconThread.SetApartmentState(ApartmentState.STA)
        trayIconThread.Start()

        Console.Title = "EECloud"
        Console.Write("Welcome to EECloud.Launcher!" & Environment.NewLine &
                      "Starting EECloud...")
    End Sub

    Private Sub InitializeTrayIcon()
        myTrayIcon = New NotifyIcon() With {.Icon = My.Resources.Icon,
                                            .Visible = True,
                                            .Text = "EECloud"}

        AddHandler myTrayIcon.DoubleClick,
            Sub()
                ConsoleVisible = Not ConsoleVisible
            End Sub

        Application.Run()
    End Sub

#End Region

#Region "Main methods"

    Sub Main()
        Initialize()

        RestartAppProcess(False)
    End Sub

    Private Sub RestartAppProcess(restart As Boolean)
        myLastRestart = DateTime.UtcNow
        Console.WriteLine(mySeparatorText)

        If restart Then
            myAppProcess.StartInfo.Arguments = "-restart"
        End If

        'Start the process
        myAppProcess.Start()
    End Sub

    Private Sub myAppProcess_Exited(sender As Object, e As EventArgs) Handles myAppProcess.Exited
        If Not Closing Then
            'Exit if the process exits with a 0 exit code
            If myAppProcess.ExitCode = 0 Then
                Close()
                Exit Sub
            End If

            Console.WriteLine(mySeparatorText)

            'Wait if failing too often
            If DateTime.UtcNow.Subtract(myLastRestart).TotalMinutes >= 1 Then
                myRestartTry = 0
            Else
                Dim waitSecs As Integer
                If myRestartTry < 22 Then
                    waitSecs = CInt(2 ^ myRestartTry)
                Else
                    waitSecs = CInt(Integer.MaxValue / 1000)
                End If

                Console.WriteLine("Restarting in " & waitSecs & " second(s)...")
                Thread.Sleep(waitSecs * 1000)

                myRestartTry += 1
            End If

            'Restart the process
            Console.Write("Restarting EECloud...")
            RestartAppProcess(True)
        End If
    End Sub

#End Region

#Region "Closing-related methods"

    Sub Close()
        BeforeClose()
        End
    End Sub

    Private Sub BeforeClose()
        Closing = True

        If myTrayIcon IsNot Nothing Then
            myTrayIcon.Dispose()
        End If
    End Sub

    Private Function ConsoleCtrlCheck(ctrlType As Integer) As Boolean
        BeforeClose()

        Return False
    End Function

#End Region

#End Region

End Module
