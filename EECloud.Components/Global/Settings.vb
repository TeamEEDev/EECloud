Public Class Settings
    Implements ISettings

    Private m_ConnectionManager As IConnectionManager

    Public Function GetBoolean(SettingName As String) As Boolean Implements ISettings.GetBoolean
        Return CBool(GetObj(SettingName))
    End Function

    Public Function GetBuffer(SettingName As String) As Char() Implements ISettings.GetBuffer

    End Function

    Public Function GetByte(SettingName As String) As Byte Implements ISettings.GetByte

    End Function

    Public Function GetChar(SettingName As String) As Char Implements ISettings.GetChar

    End Function

    Public Function GetDatabaseObject(SettingName As String) As PlayerIOClient.DatabaseObject Implements ISettings.GetDatabaseObject

    End Function

    Public Function GetDate(SettingName As String) As Date Implements ISettings.GetDate

    End Function

    Public Function GetDouble(SettingName As String) As Double Implements ISettings.GetDouble

    End Function

    Public Function GetInteger(SettingName As String) As Integer Implements ISettings.GetInteger

    End Function

    Public Function GetLong(SettingName As String) As Long Implements ISettings.GetLong

    End Function

    Public Function GetObj(SettingName As String) As Object Implements ISettings.GetObj
        Try 'TODO: Better handeling of errors 
            Return m_ConnectionManager.DatabaseManager.GetObject("SettingsDB", SettingName)("value")
        Catch ex As PlayerIOClient.PlayerIOError
            Return Nothing
        End Try
    End Function

    Public Function GetSByte(SettingName As String) As SByte Implements ISettings.GetSByte

    End Function

    Public Function GetShort(SettingName As String) As Short Implements ISettings.GetShort

    End Function

    Public Function GetSingle(SettingName As String) As Single Implements ISettings.GetSingle

    End Function

    Public Function GetString(SettingName As String) As String Implements ISettings.GetString

    End Function

    Public Function GetUInteger(SettingName As String) As UInteger Implements ISettings.GetUInteger

    End Function

    Public Function GetULong(SettingName As String) As ULong Implements ISettings.GetULong

    End Function

    Public Function GetUShort(SettingName As String) As UShort Implements ISettings.GetUShort

    End Function

    Public Overloads Sub SetSetting(SettingName As String, Value As Boolean) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Byte) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Char) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value() As Char) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Date) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Double) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Integer) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Long) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As PlayerIOClient.DatabaseObject) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As SByte) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Short) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Single) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As String) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As UInteger) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As ULong) Implements ISettings.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As UShort) Implements ISettings.SetSetting

    End Sub

    Public Sub AttemptSetup(PConnectionManager As IConnectionManager) Implements ISettings.AttemptSetup
        m_ConnectionManager = PConnectionManager
    End Sub
End Class
