Imports System.Threading.Tasks

Public Interface IClientHandle
    ReadOnly Property Client As IClient(Of Player)
    Function ConnectAsync(username As String, password As String, id As String) As Task
    Sub Close()
End Interface
