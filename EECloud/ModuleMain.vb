Module ModuleMain
    Dim myContext As CloudApplicationContext

    <STAThread>
    Sub Main()
        If System.Configuration.ConfigurationManager.AppSettings("Environment") = "Release" Then
            End
        End If
        myContext = New CloudApplicationContext
        Application.Run(myContext)
    End Sub

End Module
