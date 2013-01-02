Module ModuleMain

#Region "Methods"

#Region "Startup"

    Sub Main()
        'CheckForUpdates()
        Host.EECloud.RunDesktopMode()
    End Sub

#End Region

#Region "Updates"

    '    Private Async Sub CheckForUpdates()
    '        Try
    '            Using webClient As New WebClient()
    '                Dim version As String = Await webClient.DownloadStringTaskAsync(New Uri("https://dl.dropbox.com/u/13946635/EECloud/Version.txt"))
    '                If New Version(version) > My.Application.Info.Version Then
    '                    'Download
    '                    Await webClient.DownloadFileTaskAsync(New Uri("https://dl.dropbox.com/u/13946635/EECloud/EECloud.msi"), My.Application.Info.DirectoryPath & "\EECloud.msi")
    '                    'Notify user
    '                    MsgBox("Update ready. Press OK to start updating:", MsgBoxStyle.OkOnly)
    '                    'Write a batch file
    '                    Using writer As New StreamWriter(My.Application.Info.DirectoryPath & "\update.bat")
    '                        writer.WriteLine("start /w EECloud.msi")
    '                        writer.WriteLine("del EECloud.msi")
    '                        writer.WriteLine("start EECloud.exe")
    '                        writer.WriteLine("del %0")
    '                    End Using
    '                    'Start the batch file
    '                    Dim process As New Process()
    '                    process.StartInfo.CreateNoWindow = True
    '                    process.StartInfo.RedirectStandardOutput = True
    '                    process.StartInfo.UseShellExecute = False
    '                    process.StartInfo.FileName = My.Application.Info.DirectoryPath & "\update.bat"
    '                    process.Start()
    '                    'Exit
    '                    End
    '                End If
    '            End Using
    '        Catch ex As Exception
    '            MsgBox("Failed to check for updates: " + ex.ToString)
    '        End Try
    '    End Sub

#End Region

#End Region
End Module
