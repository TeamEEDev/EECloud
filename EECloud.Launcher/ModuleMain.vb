Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Threading

Module ModuleMain
#Region "Unmanaged calls"

    Private Delegate Function HandlerRoutine(ctrlType As Integer) As Boolean

    Const SW_HIDE As Integer = 0
    Const SW_RESTORE As Integer = 9

    <DllImport("user32.dll")>
    Private Sub SetForegroundWindow(ByVal handle As IntPtr)
    End Sub

    <DllImport("kernel32.dll")>
    Private Function GetConsoleWindow() As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Sub ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer)
    End Sub

    <DllImport("kernel32.dll")>
    Private Sub SetConsoleCtrlHandler(ByVal handler As HandlerRoutine, ByVal add As Boolean)
    End Sub

#End Region

#Region "Fields"
    Private ReadOnly myBgAppProcess As New Process() With {.StartInfo = New ProcessStartInfo(My.Application.Info.DirectoryPath & "\EECloud.exe") With {.UseShellExecute = False}}
    Private ReadOnly myHandle As IntPtr = GetConsoleWindow()

    Private ReadOnly mySeparatorText As String = Environment.NewLine & New String("_"c, Console.BufferWidth - 1) & Environment.NewLine

    Private WithEvents myTrayIcon As NotifyIcon

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

#End Region

#Region "Methods"

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

    Sub Main()
        Initialize()

        Do
            myLastRestart = Now
            Console.WriteLine(mySeparatorText)

            'Start process
            myBgAppProcess.Start()

            Do Until myBgAppProcess.HasExited
                Thread.Sleep(1000)
            Loop

            'Exit if it exists with a 0 exit code
            If myBgAppProcess.ExitCode = 0 Then
                Close()
            End If

            Console.WriteLine(mySeparatorText)

            'Wait if failing too often
            If Now.Subtract(myLastRestart).TotalMinutes >= 1 Then
                myRestartTry = 0
            Else
                Dim waitSecs As Integer = CInt(2 ^ myRestartTry)
                Console.WriteLine(String.Format("Restarting in {0} second(s)...", waitSecs))
                Thread.Sleep(waitSecs * 1000)

                myRestartTry += 1
            End If

            'Restart
            Console.Write("Restarting EECloud...")
        Loop

        ' ReSharper disable FunctionNeverReturns
    End Sub
    ' ReSharper restore FunctionNeverReturns

    Sub Close()
        BeforeClose()
        End
    End Sub

    Private Sub BeforeClose()
        myBgAppProcess.Dispose()

        If myTrayIcon IsNot Nothing Then
            myTrayIcon.Dispose()
        End If
    End Sub

    Private Function ConsoleCtrlCheck(ctrlType As Integer) As Boolean
        BeforeClose()

        Return False
    End Function

#End Region
End Module
