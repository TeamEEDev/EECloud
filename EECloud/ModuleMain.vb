Module ModuleMain
    Dim myContext As CloudApplicationContext

    <STAThread>
    Sub Main()
        myContext = New CloudApplicationContext
        Application.Run(myContext)
    End Sub

End Module
