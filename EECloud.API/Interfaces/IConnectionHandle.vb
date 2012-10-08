Imports System.Threading.Tasks

Public Interface IConnectionHandle
    ReadOnly Property Connection As IConnection(Of Player)
    Function ConnectAsync(username As String, password As String, id As String) As Task
    Sub Close()
End Interface
