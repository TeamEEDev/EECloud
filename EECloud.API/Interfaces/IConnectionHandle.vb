Imports System.Threading.Tasks

Public Interface IConnectionHandle
    Inherits IConnection(Of Player)
    Function JoinAsync(Username As String, password As String, worldID As String) As Task
    Sub Disconnect()
End Interface
