Public Interface IEEService
    ReadOnly Property ConnectionString As String

    Function CheckLicense(ByVal username As String, ByVal authKey As String) As Boolean

    Function GetSetting(ByVal key As String) As String

    Sub SetSetting(ByVal key As String, value As String)

    Sub SetFact(ByVal factID As String, ByVal factGroup As String)

    Sub RemoveFact(ByVal factID As String)

    Function GetFacts(ByVal factGroup As String) As String()

    Function GetPlayerData(ByVal username As String) As UserData

    Function GetPlayerDatas(ByVal usernames() As String) As UserData()

    Function GetPlayerDataRange(Optional ByVal offset As UInteger = 0, Optional ByVal limit As UInteger = 1000, Optional ByVal orderBy As String = "Username") As UserData()

    Sub SetPlayerDataGroupID(ByVal username As String, groupID As Short)

    Sub SetPlayerDataYoScrollWins(ByVal username As String, yoScrollWins As UShort)

    Sub SetPlayerDataFTBreakerWins(ByVal username As String, ftBreakerWins As UShort)
End Interface

Public NotInheritable Class UserData
    Public Property Username As String

    Public Property GroupID As Short

    Public Property YoScrollWins As UShort

    Public Property FTBreakerWins As UShort
End Class
