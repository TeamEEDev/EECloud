Friend NotInheritable Class EventHandlerList
#Region "Fields"
    Private myMyHead As ListEntry
#End Region

#Region "Properties"
    Default Friend Property Item(ByVal key As Object) As [Delegate]
        Get
            Dim listEntry As ListEntry = Find(key)
            If listEntry Is Nothing Then
                Return Nothing
            Else
                Return listEntry.Handler
            End If
        End Get
        Set(ByVal value As [Delegate])
            Dim listEntry As ListEntry = Find(key)
            If listEntry Is Nothing Then
                myMyHead = New ListEntry(key, value, myMyHead)
            Else
                listEntry.Handler = value
            End If
        End Set
    End Property
#End Region

#Region "Methods"
    Friend Sub Add(ByVal key As Object, ByVal value As [Delegate])
        Dim listEntry As ListEntry = Find(key)
        If listEntry Is Nothing Then
            myMyHead = New ListEntry(key, value, myMyHead)
        Else
            listEntry.Handler = [Delegate].Combine(listEntry.Handler, value)
        End If
    End Sub

    Friend Sub Remove(ByVal key As Object, ByVal value As [Delegate])
        Dim listEntry As ListEntry = Find(key)
        If (listEntry IsNot Nothing) Then
            listEntry.Handler = [Delegate].Remove(listEntry.Handler, value)
        End If
    End Sub

    Private Function Find(ByVal key As Object) As ListEntry
        Dim listEntry As ListEntry = myMyHead
        While listEntry IsNot Nothing AndAlso listEntry.Key IsNot key
            listEntry = listEntry.NextEntry
        End While
        Return listEntry
    End Function
#End Region

#Region "Nested Classes"
    Private NotInheritable Class ListEntry
        Friend Handler As [Delegate]
        Friend ReadOnly Key As Object
        Friend ReadOnly NextEntry As ListEntry

        Friend Sub New(ByVal key As Object, ByVal handler As [Delegate], ByVal nextEntry As ListEntry)
            Me.NextEntry = nextEntry
            Me.Key = key
            Me.Handler = handler
        End Sub
    End Class
#End Region
End Class