Partial Friend Class Deque(Of T)

#Region "SynchronizedDeque Class"

    <Serializable>
    Private NotInheritable Class SynchronizedDeque
        Inherits Deque(Of T)
        Implements IEnumerable

#Region "SynchronziedDeque Members"

#Region "Fields"
        Private ReadOnly myDeque As Deque(Of T)

        Private ReadOnly myRoot As Object
#End Region

#Region "Construction"

        Friend Sub New(deque As Deque(Of T))
            If deque Is Nothing Then
                Throw New ArgumentNullException("deque")
            End If

            myDeque = deque
            myRoot = deque.SyncRoot
        End Sub

#End Region

#Region "Methods"

        Friend Overrides Sub Clear()
            SyncLock myRoot
                myDeque.Clear()
            End SyncLock
        End Sub

        Friend Overrides Function Contains(item As T) As Boolean
            SyncLock myRoot
                Return myDeque.Contains(item)
            End SyncLock
        End Function

        Friend Overrides Sub PushFront(item As T)
            SyncLock myRoot
                myDeque.PushFront(item)
            End SyncLock
        End Sub

        Friend Overrides Sub PushBack(item As T)
            SyncLock myRoot
                myDeque.PushBack(item)
            End SyncLock
        End Sub

        Friend Overrides Function PopFront() As T
            SyncLock myRoot
                Return myDeque.PopFront()
            End SyncLock
        End Function

        Friend Overrides Function PopBack() As T
            SyncLock myRoot
                Return myDeque.PopBack()
            End SyncLock
        End Function

        Friend Overrides Function PeekFront() As T
            SyncLock myRoot
                Return myDeque.PeekFront()
            End SyncLock
        End Function

        Friend Overrides Function PeekBack() As T
            SyncLock myRoot
                Return myDeque.PeekBack()
            End SyncLock
        End Function

        Friend Overrides Function ToArray() As T()
            SyncLock myRoot
                Return myDeque.ToArray()
            End SyncLock
        End Function

        Friend Overrides Function Clone() As Object
            SyncLock myRoot
                Return myDeque.Clone()
            End SyncLock
        End Function

        Friend Overrides Sub CopyTo(array As Array, index As Integer)
            SyncLock myRoot
                myDeque.CopyTo(array, index)
            End SyncLock
        End Sub

        Friend Overrides Function GetEnumerator() As IEnumerator(Of T)
            SyncLock myRoot
                Return myDeque.GetEnumerator()
            End SyncLock
        End Function

#End Region

#Region "Properties"

        Friend Overrides ReadOnly Property Count As Integer
            Get
                SyncLock myRoot
                    Return myDeque.Count
                End SyncLock
            End Get
        End Property

        Friend Overrides ReadOnly Property IsSynchronized As Boolean
            Get
                Return True
            End Get
        End Property

#End Region

#End Region

    End Class

#End Region

End Class
