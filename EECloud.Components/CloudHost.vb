Imports System.ComponentModel

Public Class CloudHost
    Private m_ConnectionManager As IConnectionManager = New ConnectionManager
    Public ReadOnly Property ConnectionManager As IConnectionManager
        Get
            Return m_ConnectionManager
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
        m_ConnectionManager.AttemptSetup(OnAppHarbor)
        m_ConnectionManager.Connect(
            "guest", "guest", "PWPC-Tjtqxa0I",
            Sub(PConnection As IConnection)
                m_ConnectionManager.SetMainConnection(PConnection)
            End Sub)
    End Sub
End Class
