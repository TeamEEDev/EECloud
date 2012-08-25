Friend NotInheritable Class EventHandlerList
#Region "Fields"
    Private myHead As EventHandlerList.ListEntry
#End Region

#Region "Properties"
    Default Friend Property Item(ByVal key As Object) As [Delegate]
        Get
            Dim myListEntry As EventHandlerList.ListEntry = Me.Find(key)
            If myListEntry Is Nothing Then
                Return Nothing
            Else
                Return myListEntry.Handler
            End If
        End Get
        Set(ByVal value As [Delegate])
            Dim myListEntry As EventHandlerList.ListEntry = Me.Find(key)
            If myListEntry Is Nothing Then
                myHead = New EventHandlerList.ListEntry(key, value, myHead)
            Else
                myListEntry.Handler = value
            End If
        End Set
    End Property
#End Region

#Region "Methods"
    Friend Sub Add(ByVal key As Object, ByVal value As [Delegate])
        Dim listEntry As EventHandlerList.ListEntry = Me.Find(key)
        If listEntry Is Nothing Then
            myHead = New EventHandlerList.ListEntry(key, value, myHead)
        Else
            listEntry.Handler = [Delegate].Combine(listEntry.Handler, value)
        End If
    End Sub

    Friend Sub Remove(ByVal key As Object, ByVal value As [Delegate])
        Dim myListEntry As EventHandlerList.ListEntry = Me.Find(key)
        If (myListEntry IsNot Nothing) Then
            myListEntry.Handler = [Delegate].Remove(myListEntry.Handler, value)
        End If
    End Sub

    Private Function Find(ByVal key As Object) As EventHandlerList.ListEntry
        Dim myListEntry As EventHandlerList.ListEntry = myHead
        While myListEntry IsNot Nothing AndAlso myListEntry.Key IsNot key
            myListEntry = myListEntry.NextEntry
        End While
        Return myListEntry
    End Function
#End Region

#Region "Nested Classes"
    Private NotInheritable Class ListEntry
        Friend Handler As [Delegate]
        Friend Key As Object
        Friend NextEntry As EventHandlerList.ListEntry

        Public Sub New(ByVal key As Object, ByVal handler As [Delegate], ByVal nextEntry As EventHandlerList.ListEntry)
            Me.NextEntry = nextEntry
            Me.Key = key
            Me.Handler = handler
        End Sub
    End Class
#End Region
End Class