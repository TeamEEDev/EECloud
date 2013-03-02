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
            Return Assembly.LoadFile(My.Application.Info.DirectoryPath & "\Plugins\" & assemblyName & ".dll")
        Catch
            Return Nothing
        End Try
    End Function

#End Region

#Region "Updates"

    Private Async Sub CheckForUpdates()
        Try
            Using webClient As New WebClient()
                Dim version As String = Await webClient.DownloadStringTaskAsync(New Uri("http://dl.dropbox.com/u/13946635/EECloud/Version.txt"))
                If New Version(version).CompareTo(New Version(0, 0, 0, 0)) > 0 AndAlso MsgBox(String.Format("An update is available (Version {0}). Do you want to update now?", version), DirectCast(vbYesNo + vbInformation, MsgBoxStyle), "Update available") = MsgBoxResult.Yes Then
                    'Download
                    Await webClient.DownloadFileTaskAsync(New Uri("http://dl.dropbox.com/u/13946635/EECloud/EECloud.Setup.msi"), My.Application.Info.DirectoryPath & "\EECloud.msi")

                    'Notify user
                    MsgBox("The update has been downloaded and it's ready to be installed. Press OK to start updating!",
                           MsgBoxStyle.Information,
                           "Update ready")

                    'Write a batch file
                    Using writer As New StreamWriter(My.Application.Info.DirectoryPath & "\Update.bat")
                        writer.WriteLine("start /w EECloud.msi")
                        writer.WriteLine("del EECloud.msi")
                        writer.WriteLine("start EECloud.Launcher.exe")
                        writer.WriteLine("del %0")
                    End Using

                    'Start the batch file
                    Dim process As New Process()
                    process.StartInfo.CreateNoWindow = True
                    process.StartInfo.RedirectStandardOutput = True
                    process.StartInfo.UseShellExecute = False
                    process.StartInfo.FileName = My.Application.Info.DirectoryPath & "\Update.bat"
                    process.Start()
                    'Exit
                    End
                End If
            End Using
        Catch ex As Exception
            MsgBox("Failed to check for updates: " & Environment.NewLine &
                   ex.ToString(),
                   MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

#End Region

#End Region
End Module
