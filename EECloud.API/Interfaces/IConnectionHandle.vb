Imports System.Threading.Tasks

Public Interface IConnectionHandle
    Function JoinAsync(Username As String, password As String, worldID As String) As Task
    Sub Disconnect()
End Interface
