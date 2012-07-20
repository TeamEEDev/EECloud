Public Interface ISettingManager
    Overloads Sub SetSetting(SetttingName As String, Value As Boolean)

    Overloads Sub SetSetting(SetttingName As String, Value As Char)
    Overloads Sub SetSetting(SetttingName As String, Value As Date)

    Overloads Sub SetSetting(SetttingName As String, Value As Single)
    Overloads Sub SetSetting(SetttingName As String, Value As Double)

    Overloads Sub SetSetting(SetttingName As String, Value As Byte)
    Overloads Sub SetSetting(SetttingName As String, Value As SByte)

    Overloads Sub SetSetting(SetttingName As String, Value As Short)
    Overloads Sub SetSetting(SetttingName As String, Value As UShort)

    Overloads Sub SetSetting(SetttingName As String, Value As Integer)
    Overloads Sub SetSetting(SetttingName As String, Value As UInteger)

    Overloads Sub SetSetting(SetttingName As String, Value As Long)
    Overloads Sub SetSetting(SetttingName As String, Value As ULong)

    Overloads Sub SetSetting(SetttingName As String, Value As String)
    Overloads Sub SetSetting(SetttingName As String, Value As Object)



    Function GetBoolean(SetttingName As String) As Boolean

    Function GetChar(SetttingName As String) As Char
    Function GetDate(SetttingName As String) As Date

    Function GetSingle(SetttingName As String) As Single
    Function GetDouble(SetttingName As String) As Double

    Function GetByte(SetttingName As String) As Byte
    Function GetSByte(SetttingName As String) As SByte

    Function GetShort(SetttingName As String) As Short
    Function GetUShort(SetttingName As String) As UShort

    Function GetInteger(SetttingName As String) As Integer
    Function GetUInteger(SetttingName As String) As UInteger

    Function GetLong(SetttingName As String) As Long
    Function GetULong(SetttingName As String) As ULong

    Function GetString(SetttingName As String) As String
    Function GetObject(SetttingName As String) As Object
End Interface
