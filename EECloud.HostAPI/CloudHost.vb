Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition.Primitives
Imports System.ComponentModel

Public Class CloudHost
    <Import()>
    Private m_Connections As IConnectionManager
    Public ReadOnly Property Connections As IConnectionManager
        Get
            Return m_Connections
        End Get
    End Property

    Private m_ComponentContainer As CompositionContainer
    Public ReadOnly Property ComponentContainer As CompositionContainer
        Get
            Return m_ComponentContainer
        End Get
    End Property

    Sub New(ComponentsPath As String)
        Dim MyCatalog = New AggregateCatalog()
        MyCatalog.Catalogs.Add(New DirectoryCatalog(ComponentsPath))
        m_ComponentContainer = New CompositionContainer(MyCatalog)
        Try
            m_ComponentContainer.ComposeParts(Me)
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        m_Connections.AttmeptSetup(m_ComponentContainer)
        m_Connections.Add("guest", "guest", "PWPC-Tjtqxa0I")
    End Sub
End Class
