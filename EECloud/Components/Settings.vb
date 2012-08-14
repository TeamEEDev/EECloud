Friend NotInheritable Class Settings
    Inherits BaseGlobalComponent
    Implements ISettings

#Region "Methods"
    Friend Sub New(PBot As Bot)
        MyBase.New(PBot)
    End Sub

    Friend Function GetBoolean(SettingName As String) As Boolean Implements ISettings.GetBoolean
        Try
            Return CBool(GetObj(SettingName))
        Catch
            Return Nothing
        End Try
    End Function

    Friend Function GetByte(SettingName As String) As Byte Implements ISettings.GetByte
        Try
            Return CByte(GetObj(SettingName))
        Catch
            Return Nothing
        End Try
    End Function

    Friend Function GetDatabaseArray(SettingName As String) As PlayerIOClient.DatabaseArray Implements ISettings.GetDatabaseArray
        Try
            Return CType(GetObj(SettingName), PlayerIOClient.DatabaseArray)
        Catch
            Return Nothing
        End Try
    End Function

    Friend Function GetDatabaseObject(SettingName As String) As PlayerIOClient.DatabaseObject Implements ISettings.GetDatabaseObject
        Try
            Return CType(GetObj(SettingName), PlayerIOClient.DatabaseObject)
        Catch
            Return Nothing
        End Try
    End Function

    Friend Function GetDate(SettingName As String) As Date Implements ISettings.GetDate
        Try
            Return CDate(GetObj(SettingName))
        Catch
            Return Nothing
        End Try
    End Function

    Friend Function GetDouble(SettingName As String) As Double Implements ISettings.GetDouble
        Try
            Return CDbl(GetObj(SettingName))
        Catch
            Return Nothing
        End Try
    End Function

    Friend Function GetInteger(SettingName As String) As Integer Implements ISettings.GetInteger
        Try
            Return CInt(GetObj(SettingName))
        Catch
            Return Nothing
        End Try
    End Function

    Friend Function GetLong(SettingName As String) As Long Implements ISettings.GetLong
        Try
            Return CLng(GetObj(SettingName))
        Catch
            Return Nothing
        End Try
    End Function

    Private Function GetObj(SettingName As String) As Object
        Return myBot.Service.BigDB.Load("SettingsDB", SettingName).Item("value")
    End Function

    Friend Function GetSingle(SettingName As String) As Single Implements ISettings.GetSingle
        Try
            Return CSng(GetObj(SettingName))
        Catch
            Return Nothing
        End Try
    End Function

    Friend Function GetString(SettingName As String) As String Implements ISettings.GetString
        Try
            Return CStr(GetObj(SettingName))
        Catch
            Return String.Empty
        End Try
    End Function

    Friend Function GetUInteger(SettingName As String) As UInteger Implements ISettings.GetUInteger
        Try
            Return CUInt(GetObj(SettingName))
        Catch
            Return Nothing
        End Try
    End Function

    Friend Sub SetSetting(SettingName As String, Value As Boolean) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Friend Sub SetSetting(SettingName As String, Value As Byte) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Friend Sub SetSetting(SettingName As String, Value As Date) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Friend Sub SetSetting(SettingName As String, Value As Double) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Friend Sub SetSetting(SettingName As String, Value As Integer) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Friend Sub SetSetting(SettingName As String, Value As Long) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Friend Sub SetSetting(SettingName As String, Value As PlayerIOClient.DatabaseArray) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Friend Sub SetSetting(SettingName As String, Value As PlayerIOClient.DatabaseObject) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Friend Sub SetSetting(SettingName As String, Value As Single) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Friend Sub SetSetting(SettingName As String, Value As String) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Friend Sub SetSetting(SettingName As String, Value As UInteger) Implements ISettings.SetSetting
        SetObjGet(
            SettingName,
            Sub(myDBObj As PlayerIOClient.DatabaseObject)
                myDBObj.Set("value", Value)
                SetObj(SettingName, myDBObj)
            End Sub)
    End Sub

    Private Sub SetObjGet(SettingName As String, Callback As Action(Of PlayerIOClient.DatabaseObject))
        myBot.Service.BigDB.Load("SettingsDB", SettingName,
            Sub(myDatabaseObject As PlayerIOClient.DatabaseObject) Callback.Invoke(myDatabaseObject),
            Sub(ex As PlayerIOClient.PlayerIOError)
                myBot.Logger.Log(LogPriority.Error, "Failed to save Setting: " & SettingName)
            End Sub)
    End Sub

    Private Sub SetObj(SettingName As String, Value As PlayerIOClient.DatabaseObject)
        Try
            myBot.Service.BigDB.SaveChanges(False, False, Value)
        Catch ex As Exception
            myBot.Logger.Log(LogPriority.Error, "Failed to save Setting: " & SettingName)
        End Try
    End Sub
#End Region
End Class