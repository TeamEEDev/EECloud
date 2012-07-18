Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition.Primitives
Imports System.ComponentModel

Public Class EECloudHost
    <Import(GetType(PluginAPI.IComponentManager))>
    Private m_ComponentManager As PluginAPI.IComponentManager
    Public ReadOnly Property ComponentManager As PluginAPI.IComponentManager
        Get
            Return m_ComponentManager
        End Get
    End Property

    Public Property Container As CompositionContainer

    Sub New()
        Dim MyCatalog = New AggregateCatalog()

        Dim PluginsPath As String = My.Application.Info.DirectoryPath & "\Plugins"
        If Not System.IO.Directory.Exists(PluginsPath) Then
            System.IO.Directory.CreateDirectory(PluginsPath)
        End If

        Dim ComponentsPath As String = My.Application.Info.DirectoryPath & "\Components"
        If Not System.IO.Directory.Exists(ComponentsPath) Then
            System.IO.Directory.CreateDirectory(ComponentsPath)
        End If

        MyCatalog.Catalogs.Add(New AssemblyCatalog(GetType(EECloudHost).Assembly))
        MyCatalog.Catalogs.Add(New DirectoryCatalog(PluginsPath))
        MyCatalog.Catalogs.Add(New DirectoryCatalog(ComponentsPath))

        _Container = New CompositionContainer(MyCatalog)
        Try
            _Container.ComposeParts(Me)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        Console.ReadLine()
    End Sub
End Class
