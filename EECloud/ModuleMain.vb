Module ModuleMain
    Dim myContext As EECloud.HostAPI.CloudApplicationContext

    <STAThread>
    Sub Main()
        myContext = New EECloud.HostAPI.CloudApplicationContext
        Application.Run(myContext)
    End Sub

End Module
