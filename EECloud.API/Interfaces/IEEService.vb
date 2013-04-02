﻿Public Interface IEEService
    ReadOnly Property ConnectionString As String


    Function CheckLicense(username As String, authKey As String) As Boolean
    Function CheckLicenseAsync(username As String, authKey As String) As Task(Of Boolean)


    Function GetSetting(key As String) As String
    Function GetSettingAsync(key As String) As Task(Of String)

    Function GetSettings(ParamArray keyList As String()) As Dictionary(Of String, String)
    Function GetSettingsAsync(ParamArray keyList As String()) As Task(Of Dictionary(Of String, String))

    Sub SetSetting(key As String, value As String)
    Function SetSettingAsync(key As String, value As String) As Task

    Sub SetSettings(ParamArray keyValuePairs() As KeyValuePair(Of String, String))
    Function SetSettingsAsync(ParamArray keyValuePairs() As KeyValuePair(Of String, String)) As Task


    Function GetFacts(factGroup As String) As String()
    Function GetFactsAsync(factGroup As String) As Task(Of String())

    Sub SetFact(factID As String, factGroup As String)
    Function SetFactAsync(factID As String, factGroup As String) As Task

    Sub RemoveFact(factID As String)
    Function RemoveFactAsync(factID As String) As Task


    Function GetPlayerData(username As String) As UserData
    Function GetPlayerDataAsync(username As String) As Task(Of UserData)

    Function GetPlayerDatas(ParamArray usernames() As String) As Dictionary(Of String, UserData)
    Function GetPlayerDatasAsync(ParamArray usernames() As String) As Task(Of Dictionary(Of String, UserData))

    Function GetPlayerDataRange(Optional offset As UInteger = 0,
                                Optional limit As UInteger = 1000,
                                Optional orderBy As String = "Username") As UserData()
    Function GetPlayerDataRangeAsync(Optional offset As UInteger = 0,
                                     Optional limit As UInteger = 1000,
                                     Optional orderBy As String = "Username") As Task(Of UserData())

    Sub SetPlayerDataGroupID(username As String, groupID As Short)
    Function SetPlayerDataGroupIDAsync(username As String, groupID As Short) As Task

    Sub SetPlayerDataYoScrollWins(username As String, yoScrollWins As UShort)
    Function SetPlayerDataYoScrollWinsAsync(username As String, yoScrollWins As UShort) As Task

    Sub SetPlayerDataFTBreakerWins(username As String, ftBreakerWins As UShort)
    Function SetPlayerDataFTBreakerWinsAsync(username As String, ftBreakerWins As UShort) As Task
End Interface

Public NotInheritable Class UserData
    Public Property Username As String
    Public Property GroupID As Short
    Public Property YoScrollWins As UShort
    Public Property FTBreakerWins As UShort
End Class
