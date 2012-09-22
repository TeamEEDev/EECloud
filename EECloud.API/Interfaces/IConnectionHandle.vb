Imports System.Threading.Tasks

Public Interface IConnectionHandle
    Function Join(Username As String, password As String, worldID As String) As Task
    Sub Disconnect()
End Interface
