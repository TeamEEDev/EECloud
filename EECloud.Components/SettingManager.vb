Public Class SettingManager
    Implements ISettingManager

    Private m_ConnectionManager As IConnectionManager

    Public Function GetBoolean(SettingName As String) As Boolean Implements ISettingManager.GetBoolean
        Return CBool(GetObj(SettingName))
    End Function

    Public Function GetBuffer(SettingName As String) As Char() Implements ISettingManager.GetBuffer

    End Function

    Public Function GetByte(SettingName As String) As Byte Implements ISettingManager.GetByte

    End Function

    Public Function GetChar(SettingName As String) As Char Implements ISettingManager.GetChar

    End Function

    Public Function GetDatabaseObject(SettingName As String) As PlayerIOClient.DatabaseObject Implements ISettingManager.GetDatabaseObject

    End Function

    Public Function GetDate(SettingName As String) As Date Implements ISettingManager.GetDate

    End Function

    Public Function GetDouble(SettingName As String) As Double Implements ISettingManager.GetDouble

    End Function

    Public Function GetInteger(SettingName As String) As Integer Implements ISettingManager.GetInteger

    End Function

    Public Function GetLong(SettingName As String) As Long Implements ISettingManager.GetLong

    End Function

    Public Function GetObj(SettingName As String) As Object Implements ISettingManager.GetObj
        Try 'TODO: Better handeling of errors 
            Return m_ConnectionManager.DatabaseManager.GetObject("SettingsDB", SettingName)("value")
        Catch ex As PlayerIOClient.PlayerIOError
            Return Nothing
        End Try
    End Function

    Public Function GetSByte(SettingName As String) As SByte Implements ISettingManager.GetSByte

    End Function

    Public Function GetShort(SettingName As String) As Short Implements ISettingManager.GetShort

    End Function

    Public Function GetSingle(SettingName As String) As Single Implements ISettingManager.GetSingle

    End Function

    Public Function GetString(SettingName As String) As String Implements ISettingManager.GetString

    End Function

    Public Function GetUInteger(SettingName As String) As UInteger Implements ISettingManager.GetUInteger

    End Function

    Public Function GetULong(SettingName As String) As ULong Implements ISettingManager.GetULong

    End Function

    Public Function GetUShort(SettingName As String) As UShort Implements ISettingManager.GetUShort

    End Function

    Public Overloads Sub SetSetting(SettingName As String, Value As Boolean) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Byte) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Char) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value() As Char) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Date) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Double) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Integer) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Long) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As PlayerIOClient.DatabaseObject) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As SByte) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Short) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As Single) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As String) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As UInteger) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As ULong) Implements ISettingManager.SetSetting

    End Sub

    Public Overloads Sub SetSetting(SettingName As String, Value As UShort) Implements ISettingManager.SetSetting

    End Sub

    Public Sub AttemptSetup(PConnectionManager As IConnectionManager) Implements ISettingManager.AttemptSetup
        m_ConnectionManager = PConnectionManager
    End Sub
End Class
