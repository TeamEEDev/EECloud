Public Interface ISettingManager
    Sub AttemptSetup(ConnectionManager As IConnectionManager)

    Overloads Sub SetSetting(SettingName As String, Value As Boolean)

    Overloads Sub SetSetting(SettingName As String, Value As Char)
    Overloads Sub SetSetting(SettingName As String, Value As Char())

    Overloads Sub SetSetting(SettingName As String, Value As Date)

    Overloads Sub SetSetting(SettingName As String, Value As Single)
    Overloads Sub SetSetting(SettingName As String, Value As Double)

    Overloads Sub SetSetting(SettingName As String, Value As Byte)
    Overloads Sub SetSetting(SettingName As String, Value As SByte)

    Overloads Sub SetSetting(SettingName As String, Value As Short)
    Overloads Sub SetSetting(SettingName As String, Value As UShort)

    Overloads Sub SetSetting(SettingName As String, Value As Integer)
    Overloads Sub SetSetting(SettingName As String, Value As UInteger)

    Overloads Sub SetSetting(SettingName As String, Value As Long)
    Overloads Sub SetSetting(SettingName As String, Value As ULong)

    Overloads Sub SetSetting(SettingName As String, Value As String)
    Overloads Sub SetSetting(SettingName As String, Value As PlayerIOClient.DatabaseObject)



    Function GetBoolean(SettingName As String) As Boolean

    Function GetChar(SettingName As String) As Char
    Function GetBuffer(SettingName As String) As Char()

    Function GetDate(SettingName As String) As Date

    Function GetSingle(SettingName As String) As Single
    Function GetDouble(SettingName As String) As Double

    Function GetByte(SettingName As String) As Byte
    Function GetSByte(SettingName As String) As SByte

    Function GetShort(SettingName As String) As Short
    Function GetUShort(SettingName As String) As UShort

    Function GetInteger(SettingName As String) As Integer
    Function GetUInteger(SettingName As String) As UInteger

    Function GetLong(SettingName As String) As Long
    Function GetULong(SettingName As String) As ULong

    Function GetString(SettingName As String) As String
    Function GetDatabaseObject(SettingName As String) As PlayerIOClient.DatabaseObject

    Function GetObj(SettingName As String) As Object
End Interface
