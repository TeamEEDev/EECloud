Imports System.IO
Imports System.Reflection

Public Class PluginManager
    Inherits BaseGlobalComponent
    Implements IPluginManager


    Public Sub New(PBot As Bot)
        MyBase.New(PBot)
        Dim allAssemblies As New List(Of Assembly)()
        Dim path As String = My.Application.Info.DirectoryPath

        For Each dll As String In Directory.GetFiles(path, "*.dll")
            Try
                allAssemblies.Add(Assembly.LoadFile(dll))
            Catch ex As FileLoadException
                myBot.Logger.Log(LogPriority.Error, "Assembly already loaded: " & dll)
            Catch ex As BadImageFormatException
                myBot.Logger.Log(LogPriority.Error, "Currupt assembly: " & dll)
            End Try
        Next

        myPluginTypes = From myAssembly As Assembly In allAssemblies
                        From myType As Type In myAssembly.GetTypes()
                        Where GetType(IPlugin).IsAssignableFrom(myType)
                        Let myAttributes As Object() = myType.GetCustomAttributes(GetType(PluginAttribute), True)
                        Where myAttributes IsNot Nothing AndAlso myAttributes.Length > 0
                        Select myType

        Dim w = myPluginTypes(0)
    End Sub

    Private myPluginTypes As IEnumerable(Of Type)
    Public ReadOnly Property PluginTypes As IEnumerable(Of Type) Implements IPluginManager.PluginTypes
        Get
            Return myPluginTypes
        End Get
    End Property

    Public Sub Load(plugin As IPlugin) Implements IPluginManager.Load

    End Sub

    Public Sub Unload(plugin As IPlugin) Implements IPluginManager.Unload

    End Sub
End Class
