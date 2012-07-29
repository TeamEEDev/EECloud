Imports System.IO
Imports System.Reflection

Public Class PluginManager
    Inherits BaseGlobalComponent
    Implements IPluginManager

    Public Sub New(PBot As Bot)
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
            From myType As Type In myAssembly.GetTypes()
            Where GetType(IPlugin).IsAssignableFrom(myType)
            Let myAttributes As Object() = myType.GetCustomAttributes(GetType(PluginAttribute), True)
            Where myAttributes IsNot Nothing AndAlso myAttributes.Length > 0
            Select myType

        Using myEnumrator As IEnumerator(Of Type) = myPlugins.GetEnumerator
            Do
                Try
                    Dim hasNext As Boolean = myEnumrator.MoveNext()
                    If Not hasNext Then Exit Do

                    myPluginTypes.Add(myEnumrator.Current)
                Catch
                End Try
            Loop
        End Using
    End Sub

    Private myPluginTypes As New List(Of Type)
    Private myPlugins As New Dictionary(Of Type, IPlugin)
    Public ReadOnly Property PluginTypes As IEnumerable(Of Type) Implements IPluginManager.PluginTypes
        Get
            Return myPluginTypes
        End Get
    End Property

    Public Sub ReloadAll() Implements IPluginManager.ReloadAll
        For Each Plugin As Type In myPlugins.Keys
            Unload(Plugin)
        Next
        For Each Type As Type In myPluginTypes
            Load(Type)
        Next
    End Sub

    Public Sub Load(PPlugin As Type) Implements IPluginManager.Load
        If GetType(IPlugin).IsAssignableFrom(PPlugin) Then
            If Not myPlugins.ContainsKey(PPlugin) Then
                myBot.Logger.Log(LogPriority.Info, String.Format("Enabling {0}...", PPlugin.Name))
                Dim myInstance As IPlugin = Nothing
                Try
                    myInstance = CType(Activator.CreateInstance(PPlugin, True), IPlugin)
                    myPlugins.Add(PPlugin, myInstance)
                    myInstance.SetupPlugin(myBot)
                    myInstance.OnEnable()
                Catch ex As Exception
                    myBot.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled: {1} {2}", ex.ToString, ex.Message, ex.StackTrace))
                    myBot.Logger.Log(LogPriority.Error, String.Format("Failed to start plugin {0}. Disabling...", PPlugin.Name))
                    Unload(PPlugin)
                End Try
            Else
                Throw New ApplicationException("Plugin already loaded.")
            End If
        Else
            Throw New ArgumentException("Type does not inherit from EECloud.API.IPlugin")
        End If
    End Sub

    Public Sub Unload(PPlugin As Type) Implements IPluginManager.Unload
        myBot.Logger.Log(LogPriority.Info, String.Format("Disabling {0}...", PPlugin.GetType.Name))
        Try
            myPlugins(PPlugin).OnDisable()
            myPlugins.Remove(PPlugin)
        Catch ex As Exception
            myBot.Logger.Log(LogPriority.Error, String.Format("{0} was unhandeled: {1} {2}", ex.ToString, ex.Message, ex.StackTrace))
            myBot.Logger.Log(LogPriority.Error, String.Format("Failed to disable Plugin {0}.", PPlugin.Name))
        End Try
    End Sub
End Class
