Public Interface ISettings
    Overloads Sub SetSetting(SettingName As String, Value As Boolean)
    Overloads Sub SetSetting(SettingName As String, Value As Date)

    Overloads Sub SetSetting(SettingName As String, Value As Single)
    Overloads Sub SetSetting(SettingName As String, Value As Double)

    Overloads Sub SetSetting(SettingName As String, Value As Byte)
    Overloads Sub SetSetting(SettingName As String, Value As String)

    Overloads Sub SetSetting(SettingName As String, Value As Integer)
    Overloads Sub SetSetting(SettingName As String, Value As UInteger)

    Overloads Sub SetSetting(SettingName As String, Value As Long)


    Overloads Sub SetSetting(SettingName As String, Value As PlayerIOClient.DatabaseObject)
    Overloads Sub SetSetting(SettingName As String, Value As PlayerIOClient.DatabaseArray)


    Function GetBoolean(SettingName As String) As Boolean
    Function GetDate(SettingName As String) As Date

    Function GetSingle(SettingName As String) As Single
    Function GetDouble(SettingName As String) As Double

    Function GetByte(SettingName As String) As Byte
    Function GetString(SettingName As String) As String

    Function GetInteger(SettingName As String) As Integer
    Function GetUInteger(SettingName As String) As UInteger

    Function GetLong(SettingName As String) As Long

    Function GetDatabaseArray(SettingName As String) As PlayerIOClient.DatabaseArray
    Function GetDatabaseObject(SettingName As String) As PlayerIOClient.DatabaseObject
End Interface
