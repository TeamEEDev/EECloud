Friend NotInheritable Class Settings
    Inherits BaseGlobalComponent
    Implements ISettings

    Public Sub New(PBot As Bot)
        MyBase.New(PBot)
    End Sub

    Public Function GetBoolean(SettingName As String) As Boolean Implements ISettings.GetBoolean
        Try
            Return CBool(GetObj(SettingName))
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetByte(SettingName As String) As Byte Implements ISettings.GetByte
        Try
            Return CByte(GetObj(SettingName))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetDatabaseArray(SettingName As String) As DatabaseArray Implements ISettings.GetDatabaseArray
        Try
            Return CType(GetObj(SettingName), DatabaseArray)
        Catch ex As Exception
            Return New DatabaseArray
        End Try
    End Function

    Public Function GetDatabaseObject(SettingName As String) As PlayerIOClient.DatabaseObject Implements ISettings.GetDatabaseObject
        Try
            Return CType(GetObj(SettingName), DatabaseObject)
        Catch ex As Exception
            Return New DatabaseObject
        End Try
    End Function

    Public Function GetDate(SettingName As String) As Date Implements ISettings.GetDate
        Try
            Return CDate(GetObj(SettingName))
        Catch ex As Exception
            Return #1/1/2000#
        End Try
    End Function

    Public Function GetDouble(SettingName As String) As Double Implements ISettings.GetDouble
        Try
            Return CDbl(GetObj(SettingName))
        Catch ex As Exception
            Return 0.0
        End Try
    End Function

    Public Function GetInteger(SettingName As String) As Integer Implements ISettings.GetInteger
        Try
            Return CInt(GetObj(SettingName))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function GetLong(SettingName As String) As Long Implements ISettings.GetLong
        Try
            Return CLng(GetObj(SettingName))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function GetObj(SettingName As String) As Object
        Return myBot.Service.ServiceClient.BigDB.Load("SettingsDB", SettingName).Item("value")
    End Function

    Public Function GetSingle(SettingName As String) As Single Implements ISettings.GetSingle
        Try
            Return CSng(GetObj(SettingName))
        Catch ex As Exception
            Return 0.0
        End Try
    End Function

    Public Function GetString(SettingName As String) As String Implements ISettings.GetString
        Try
            Return CStr(GetObj(SettingName))
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Public Function GetUInteger(SettingName As String) As UInteger Implements ISettings.GetUInteger
        Try
            Return CUInt(GetObj(SettingName))
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Overloads Sub SetSetting(SettingName As String, Value As Boolean) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Byte) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Date) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Double) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Integer) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Long) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As PlayerIOClient.DatabaseArray) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As PlayerIOClient.DatabaseObject) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Single) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As String) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As UInteger) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Private Sub SetObjGet(SettingName As String, Callback As PlayerIOClient.Callback(Of PlayerIOClient.DatabaseObject))
        myBot.Service.ServiceClient.BigDB.Load("SettingsDB", SettingName, Callback,
            Sub(ex As PlayerIOError)
                myBot.Logger.Log(LogPriority.Serve, "Failed to save Setting: " & SettingName)
            End Sub)
    End Sub

    Private Sub SetObj(SettingName As String, Value As DatabaseObject)
        Try
            myBot.Service.ServiceClient.BigDB.SaveChanges(False, False, Value)
        Catch ex As Exception
            myBot.Logger.Log(LogPriority.Serve, "Failed to save Setting: " & SettingName)
        End Try
    End Sub
End Class
