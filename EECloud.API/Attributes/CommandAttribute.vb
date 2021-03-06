﻿<AttributeUsage(AttributeTargets.Method)>
Public NotInheritable Class CommandAttribute
    Inherits Attribute

#Region "Properties"

    Private ReadOnly myType As String
    
    ''' <summary>
    ''' Command type (name) eg. "!test" will have the type "test"
    ''' </summary>
    Public ReadOnly Property Type As String
        Get
            Return myType
        End Get
    End Property

    Private ReadOnly myMinPermission As Group
    
    ''' <summary>
    ''' The required permission to invoke the command
    ''' </summary>
    Public ReadOnly Property MinPermission As Group
        Get
            Return myMinPermission
        End Get
    End Property
    
    ''' <summary>
    ''' The access right the bot account must have to run the command
    ''' </summary>
    Public Property AccessRight As AccessRight
    
    ''' <summary>
    ''' Alternative Types for this command
    ''' </summary>
    Public Property Aliases As String()

#End Region

#Region "Methods"

    Sub New(type As String, minPermission As Group)
        myType = type
        myMinPermission = minPermission
    End Sub

#End Region

End Class
