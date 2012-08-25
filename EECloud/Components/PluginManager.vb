Imports System.IO
Imports System.Reflection

Friend NotInheritable Class PluginManager
    Inherits BaseGlobalComponent
    Implements IPluginManager

#Region "Properties"
    Private myPluginsList As New List(Of IPluginObject)
    Friend ReadOnly Property Plugins As IEnumerable(Of IPluginObject) Implements IPluginManager.Plugins
        Get
            Return myPluginsList
        End Get
    End Property
#End Region

#Region "Methods"
    Friend Sub New(PBot As Bot)
        MyBase.New(PBot)
        Dim allAssemblies As New List(Of Assembly)
        Dim path As String = My.Application.Info.DirectoryPath

        For Each dll As String In Directory.GetFiles(path, "*.dll")
            Try
                allAssemblies.Add(Assembly.LoadFile(dll))
            Catch ex As FileLoadException
                myBot.Logger.Log(LogPriority.Error, "Failed to load Assembly: " & dll)
            Catch ex As BadImageFormatException
                myBot.Logger.Log(LogPriority.Error, "Currupt assembly: " & dll)
            End Try
        Next


        Dim myPlugins As IEnumerable(Of Type) =
            From myAssembly As Assembly In allAssemblies
            From myType As Type In myAssembly.GetTypes
            Where GetType(IPlugin).IsAssignableFrom(myType)
            Let myAttributes As Object() = myType.GetCustomAttributes(GetType(PluginAttribute), True)
            Where myAttributes IsNot Nothing AndAlso myAttributes.Length = 1
            Select myType

        Using myEnumrator As IEnumerator(Of Type) = myPlugins.GetEnumerator
            Do
                Try
                    Dim hasNext As Boolean = myEnumrator.MoveNext()
                    If Not hasNext Then Exit Do

                    myPluginsList.Add(New PluginObject(myBot, myEnumrator.Current))
                Catch
                End Try
            Loop
        End Using

        For Each myPlugin As IPluginObject In myPluginsList
            myPlugin.Start()
        Next
    End Sub
#End Region
End Class
