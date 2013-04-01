Public Interface IEEService
    ReadOnly Property ConnectionString As String

    Function CheckLicense(username As String, authKey As String) As Boolean

    Function GetSetting(key As String) As String
    Function GetSettingTask(key As String) As Task(Of String)

    Function GetSettings(ParamArray keyList As String()) As Dictionary(Of String, String)
    Function GetSettingsTask(ParamArray keyList As String()) As Task(Of Dictionary(Of String, String))

    Sub SetSetting(key As String, value As String)
    Sub SetSettingAsync(key As String, value As String)

    Sub SetSettings(ParamArray keyValuePairs() As KeyValuePair(Of String, String))
    Sub SetSettingsAsync(ParamArray keyValuePairs() As KeyValuePair(Of String, String))

    Sub SetFact(factID As String, factGroup As String)

    Sub RemoveFact(factID As String)

    Function GetFacts(factGroup As String) As String()

    Function GetPlayerData(username As String) As UserData

    Function GetPlayerDatas(ParamArray usernames() As String) As Dictionary(Of String, UserData)

    Function GetPlayerDataRange(Optional offset As UInteger = 0, Optional limit As UInteger = 1000, Optional orderBy As String = "Username") As UserData()

    Sub SetPlayerDataGroupID(username As String, groupID As Short)

    Sub SetPlayerDataYoScrollWins(username As String, yoScrollWins As UShort)

    Sub SetPlayerDataFTBreakerWins(username As String, ftBreakerWins As UShort)
End Interface

Public NotInheritable Class UserData
    Public Property Username As String

    Public Property GroupID As Short

    Public Property YoScrollWins As UShort

    Public Property FTBreakerWins As UShort
End Class
