Public Class CloudApplicationContext
    Inherits System.Windows.Forms.ApplicationContext

    Public Sub New()
        Console.Title = "EECloud"
        Dim myHost = New EECloud.HostAPI.CloudHost(System.Configuration.ConfigurationManager.AppSettings("Environment") = "Release", My.Application.Info.DirectoryPath)
    End Sub
End Class
