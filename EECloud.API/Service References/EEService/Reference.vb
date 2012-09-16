﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.17929
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Runtime.Serialization

Namespace EEService
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute(Name:="UserData", [Namespace]:="http://schemas.datacontract.org/2004/07/EEService"),  _
     System.SerializableAttribute()>  _
    Partial Public Class UserData
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
        
        <System.NonSerializedAttribute()>  _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private GroupIDField As Integer
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private UserIDField As String
        
        <System.Runtime.Serialization.OptionalFieldAttribute()>  _
        Private UsernameField As String
        
        <Global.System.ComponentModel.BrowsableAttribute(false)>  _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set
                Me.extensionDataField = value
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property GroupID() As Integer
            Get
                Return Me.GroupIDField
            End Get
            Set
                If (Me.GroupIDField.Equals(value) <> true) Then
                    Me.GroupIDField = value
                    Me.RaisePropertyChanged("GroupID")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property UserID() As String
            Get
                Return Me.UserIDField
            End Get
            Set
                If (Object.ReferenceEquals(Me.UserIDField, value) <> true) Then
                    Me.UserIDField = value
                    Me.RaisePropertyChanged("UserID")
                End If
            End Set
        End Property
        
        <System.Runtime.Serialization.DataMemberAttribute()>  _
        Public Property Username() As String
            Get
                Return Me.UsernameField
            End Get
            Set
                If (Object.ReferenceEquals(Me.UsernameField, value) <> true) Then
                    Me.UsernameField = value
                    Me.RaisePropertyChanged("Username")
                End If
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute(ConfigurationName:="EEService.IEES")>  _
    Public Interface IEES
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IEES/GetSetting", ReplyAction:="http://tempuri.org/IEES/GetSettingResponse")>  _
        Function GetSetting(ByVal key As String) As String
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IEES/GetSetting", ReplyAction:="http://tempuri.org/IEES/GetSettingResponse")>  _
        Function GetSettingAsync(ByVal key As String) As System.Threading.Tasks.Task(Of String)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IEES/SetSetting", ReplyAction:="http://tempuri.org/IEES/SetSettingResponse")>  _
        Sub SetSetting(ByVal key As String, ByVal value As String)
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IEES/SetSetting", ReplyAction:="http://tempuri.org/IEES/SetSettingResponse")>  _
        Function SetSettingAsync(ByVal key As String, ByVal value As String) As System.Threading.Tasks.Task
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IEES/GetPlayerData", ReplyAction:="http://tempuri.org/IEES/GetPlayerDataResponse")>  _
        Function GetPlayerData(ByVal username As String) As EEService.UserData
        
        <System.ServiceModel.OperationContractAttribute(Action:="http://tempuri.org/IEES/GetPlayerData", ReplyAction:="http://tempuri.org/IEES/GetPlayerDataResponse")>  _
        Function GetPlayerDataAsync(ByVal username As String) As System.Threading.Tasks.Task(Of EEService.UserData)
    End Interface
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface IEESChannel
        Inherits EEService.IEES, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class EESClient
        Inherits System.ServiceModel.ClientBase(Of EEService.IEES)
        Implements EEService.IEES
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        Public Function GetSetting(ByVal key As String) As String Implements EEService.IEES.GetSetting
            Return MyBase.Channel.GetSetting(key)
        End Function
        
        Public Function GetSettingAsync(ByVal key As String) As System.Threading.Tasks.Task(Of String) Implements EEService.IEES.GetSettingAsync
            Return MyBase.Channel.GetSettingAsync(key)
        End Function
        
        Public Sub SetSetting(ByVal key As String, ByVal value As String) Implements EEService.IEES.SetSetting
            MyBase.Channel.SetSetting(key, value)
        End Sub
        
        Public Function SetSettingAsync(ByVal key As String, ByVal value As String) As System.Threading.Tasks.Task Implements EEService.IEES.SetSettingAsync
            Return MyBase.Channel.SetSettingAsync(key, value)
        End Function
        
        Public Function GetPlayerData(ByVal username As String) As EEService.UserData Implements EEService.IEES.GetPlayerData
            Return MyBase.Channel.GetPlayerData(username)
        End Function
        
        Public Function GetPlayerDataAsync(ByVal username As String) As System.Threading.Tasks.Task(Of EEService.UserData) Implements EEService.IEES.GetPlayerDataAsync
            Return MyBase.Channel.GetPlayerDataAsync(username)
        End Function
    End Class
End Namespace
