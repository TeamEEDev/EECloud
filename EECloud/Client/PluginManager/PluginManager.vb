﻿Friend NotInheritable Class PluginManager
    Implements IPluginManager

#Region "Fields"
    Private ReadOnly myCloneFactory As IClientCloneFactory
#End Region

#Region "Properties"
    Private ReadOnly myPluginsList As New List(Of IPluginObject)

    Friend ReadOnly Property Plugins As IReadOnlyCollection(Of IPluginObject) Implements IPluginManager.Plugins
        Get
            Return myPluginsList.AsReadOnly
        End Get
    End Property

#End Region

#Region "Methods"

    Sub New(cloneFactory As IClientCloneFactory)
        myCloneFactory = cloneFactory
    End Sub

    Friend Sub Load(ByVal t As Type) Implements IPluginManager.Load
        If (Not t.Namespace = "EECloud" AndAlso Not t.Namespace.StartsWith("EECloud.", StringComparison.Ordinal)) OrElse GetType(CommandsBot) = t Then
            If GetType(IPlugin).IsAssignableFrom(t) Then
                Dim attributes As Object() = t.GetCustomAttributes(GetType(PluginAttribute), True)
                If attributes IsNot Nothing AndAlso attributes.Length = 1 Then
                    Dim pluginObj As IPluginObject = New PluginObject(t, CType(attributes(0), PluginAttribute), myCloneFactory)
                    myPluginsList.Add(pluginObj)
                    Exit Sub
                End If
            End If
        End If
        Throw New EECloudException(ErrorCode.InvalidPlugin)
    End Sub

#End Region
End Class
