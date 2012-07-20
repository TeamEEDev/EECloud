Public Class CloudApplicationContext
    Inherits System.Windows.Forms.ApplicationContext

    Public Sub New()
        Dim myHost = New EECloud.HostAPI.CloudHost(My.Application.Info.DirectoryPath)
        myHost.Connections.MainConnection.LogManager.Log("dfajklsdfjk")
    End Sub
End Class
