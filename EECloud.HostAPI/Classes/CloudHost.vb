Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition.Primitives
Imports System.ComponentModel

Public Class CloudHost
    <Import(GetType(IComponentManager))>
    Private m_ComponentManager As PluginAPI.IComponentManager
    Public ReadOnly Property ComponentManager As PluginAPI.IComponentManager
        Get
            Return m_ComponentManager
        End Get
    End Property

    Public Property Container As CompositionContainer

    Sub New(ComponentsPath As String)
        Dim MyCatalog = New AggregateCatalog()

        MyCatalog.Catalogs.Add(New DirectoryCatalog(ComponentsPath))

        Container = New CompositionContainer(MyCatalog)

        Try
            Container.ComposeParts(Me)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
End Class
