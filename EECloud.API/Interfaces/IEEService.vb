Public Interface IEEService

    ReadOnly Property MySqlConnectionString As String


    Function GetSetting(key As String) As String
    Function GetSettingAsync(key As String) As Task(Of String)

    Function GetSettings(ParamArray keyList As String()) As Dictionary(Of String, String)
    Function GetSettingsAsync(ParamArray keyList As String()) As Task(Of Dictionary(Of String, String))

    Sub SetSetting(key As String, value As String)
    Function SetSettingAsync(key As String, value As String) As Task

    Sub SetSettings(ParamArray keyValuePairs As KeyValuePair(Of String, String)())
    Function SetSettingsAsync(ParamArray keyValuePairs As KeyValuePair(Of String, String)()) As Task


    Function GetFacts(factGroup As String) As String()
    Function GetFactsAsync(factGroup As String) As Task(Of String())

    Sub SetFact(factID As String, factGroup As String)
    Function SetFactAsync(factID As String, factGroup As String) As Task

    Sub RemoveFact(factID As String)
    Function RemoveFactAsync(factID As String) As Task


    Function GetPlayerData(username As String) As UserData
    Function GetPlayerDataAsync(username As String) As Task(Of UserData)

    Function GetPlayerDatas(ParamArray usernames As String()) As Dictionary(Of String, UserData)
    Function GetPlayerDatasAsync(ParamArray usernames As String()) As Task(Of Dictionary(Of String, UserData))

    Function GetPlayerDataRange(Optional offset As UInteger = 0,
                                Optional limit As UInteger = 1000,
                                Optional orderBy As String = "Username") As UserData()
    Function GetPlayerDataRangeAsync(Optional offset As UInteger = 0,
                                     Optional limit As UInteger = 1000,
                                     Optional orderBy As String = "Username") As Task(Of UserData())

    Sub SetPlayerDataGroupID(username As String, groupID As Short)
    Function SetPlayerDataGroupIDAsync(username As String, groupID As Short) As Task

    Sub SetPlayerDataWins(gameName As RegisteredGameName, username As String, wins As UShort)
    Function SetPlayerDataWinsAsync(gameName As RegisteredGameName, username As String, wins As UShort) As Task

    Sub OptimizeTable(tableName As String)
    Function OptimizeTableAsync(tableName As String) As Task

    Sub OptimizeTables(ParamArray tableNames As String())
    Function OptimizeTablesAsync(ParamArray tableNames As String()) As Task


    Sub ForceOpenConnection()
    Function ForceOpenConnectionAsync() As Task


    Sub CreateDefaultMySqlTables()
    Function CreateDefaultMySqlTablesAsync() As Task

End Interface


Public NotInheritable Class UserData

    Public Property Username As String
    Public Property GroupID As Short
    Public Property Wins As Dictionary(Of RegisteredGameName, UShort)

End Class
