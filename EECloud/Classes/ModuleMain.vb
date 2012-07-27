Module ModuleMain
    Dim myContext As CloudApplicationContext

    <STAThread>
    Sub Main()
        Application.Run(New CloudApplicationContext)
    End Sub

End Module
