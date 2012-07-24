Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition.Primitives
Imports System.ComponentModel

Public Class CloudHost
    <Import()>
    Private m_ConnectionManager As IConnectionManager
    Public ReadOnly Property ConnectionManager As IConnectionManager
        Get
            Return m_ConnectionManager
        End Get
    End Property

    Private m_ComponentContainer As CompositionContainer
    Public ReadOnly Property ComponentContainer As CompositionContainer
        Get
            Return m_ComponentContainer
        End Get
    End Property

    Private m_OnAppHarbor As Boolean
    Public ReadOnly Property OnAppHarbor As Boolean
        Get
            Return m_OnAppHarbor
        End Get
    End Property

    Sub New(OnAppHarbor As Boolean, ComponentsPath As String)
        m_OnAppHarbor = OnAppHarbor
        Dim MyCatalog = New AggregateCatalog()
        MyCatalog.Catalogs.Add(New DirectoryCatalog(ComponentsPath))
        m_ComponentContainer = New CompositionContainer(MyCatalog)
        Try
            m_ComponentContainer.ComposeParts(Me)
        Catch ex As Exception 'TODO: better exeption handling
            Console.WriteLine(ex.ToString)
        End Try
        m_ConnectionManager.AttemptSetup(OnAppHarbor, m_ComponentContainer)
        m_ConnectionManager.Connect(
            "guest", "guest", "PWPC-Tjtqxa0I",
            Sub(PConnection As IConnection)
                m_ConnectionManager.SetMainConnection(PConnection)
            End Sub)
    End Sub
End Class
