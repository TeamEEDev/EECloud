Imports System.IO
Imports System.Net
Imports System.Reflection

Module ModuleMain

#Region "Methods"

#Region "Startup"

    Sub Main()
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf AppDomain_AssemblyResolve
        CheckForUpdates()
        Host.EECloud.RunDesktopMode()
    End Sub

#End Region

#Region "Assembly refrences"

    Private Function AppDomain_AssemblyResolve(sender As Object, e As ResolveEventArgs) As Assembly
        Dim assemblyName As String = e.Name.Split(","c)(0)
        Try
            Return Assembly.LoadFile(My.Application.Info.DirectoryPath & "\plugins\" & assemblyName & ".dll")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Updates"

    Private Async Sub CheckForUpdates()
        Try
            Using webClient As New WebClient()
                Dim version As String = Await webClient.DownloadStringTaskAsync(New Uri("http://dl.dropbox.com/u/13946635/EECloud/Version.txt"))
                If New Version(version) > My.Application.Info.Version AndAlso MsgBox("There is an update available, do you want to update?", vbYesNo, "Update") = MsgBoxResult.Yes Then
                    'Download
                    Await webClient.DownloadFileTaskAsync(New Uri("http://dl.dropbox.com/u/13946635/EECloud/EECloud.Setup.msi"), My.Application.Info.DirectoryPath & "\EECloud.msi")
                    'Notify user
                    MsgBox("Update ready. Press OK to start updating.", MsgBoxStyle.OkOnly, "Update")
                    'Write a batch file
                    Using writer As New StreamWriter(My.Application.Info.DirectoryPath & "\update.bat")
                        writer.WriteLine("start /w EECloud.msi")
                        writer.WriteLine("del EECloud.msi")
                        writer.WriteLine("start EECloud.exe")
                        writer.WriteLine("del %0")
                    End Using
                    'Start the batch file
                    Dim process As New Process()
                    process.StartInfo.CreateNoWindow = True
                    process.StartInfo.RedirectStandardOutput = True
                    process.StartInfo.UseShellExecute = False
                    process.StartInfo.FileName = My.Application.Info.DirectoryPath & "\update.bat"
                    process.Start()
                    'Exit
                    End
                End If
            End Using
        Catch ex As Exception
            MsgBox("Failed to check for updates: " + ex.ToString, vbOKOnly, "Error")
        End Try
    End Sub

#End Region

#End Region
End Module
