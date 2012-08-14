Public Interface ISettings
    Sub SetSetting(settingName As String, value As Boolean)
    Sub SetSetting(settingName As String, value As Date)

    Sub SetSetting(settingName As String, value As Single)
    Sub SetSetting(settingName As String, value As Double)

    Sub SetSetting(settingName As String, value As Byte)
    Sub SetSetting(settingName As String, value As String)

    Sub SetSetting(settingName As String, value As Integer)
    Sub SetSetting(settingName As String, value As UInteger)

    Sub SetSetting(settingName As String, value As Long)


    Sub SetSetting(settingName As String, value As PlayerIOClient.DatabaseObject)
    Sub SetSetting(settingName As String, value As PlayerIOClient.DatabaseArray)


    Function GetBoolean(settingName As String) As Boolean
    Function GetDate(settingName As String) As Date

    Function GetSingle(settingName As String) As Single
    Function GetDouble(settingName As String) As Double

    Function GetByte(settingName As String) As Byte
    Function GetString(settingName As String) As String

    Function GetInteger(settingName As String) As Integer
    Function GetUInteger(settingName As String) As UInteger

    Function GetLong(settingName As String) As Long

    Function GetDatabaseArray(settingName As String) As PlayerIOClient.DatabaseArray
    Function GetDatabaseObject(settingName As String) As PlayerIOClient.DatabaseObject
End Interface
