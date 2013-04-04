<Serializable>
Partial Friend Class Deque(Of T)
    Implements ICollection
    Implements IEnumerable(Of T)
    Implements ICloneable

#Region "Deque Members"

#Region "Fields"

    Private myFront As Node

    Private myBack As Node

    Private myCount As Integer

    Private myVersion As Long

#End Region

#Region "Construction"

    Friend Sub New()

    End Sub

    Friend Sub New(collection As IEnumerable(Of T))
        If collection Is Nothing Then
            Throw New ArgumentNullException("collection")
        End If

        For Each item In collection
            PushBack(item)
        Next
    End Sub

#End Region

#Region "Methods"

    Friend Overridable Sub Clear()
        myCount = 0

        myFront = InlineAssignHelper(myBack, Nothing)

        myVersion += 1
    End Sub

    Friend Overridable Function Contains(obj As T) As Boolean
        Return Any(Function(o) EqualityComparer(Of T).[Default].Equals(o, obj))
    End Function

    Friend Overridable Sub PushFront(item As T)
        Dim newNode As New Node(item)

        newNode.[Next] = myFront

        If Count > 0 Then
            myFront.Previous = newNode
        End If

        myFront = newNode

        myCount += 1

        If Count = 1 Then
            myBack = myFront
        End If

        myVersion += 1
    End Sub

    Friend Overridable Sub PushBack(item As T)
        Dim newNode As New Node(item)

        newNode.Previous = myBack

        If Count > 0 Then
            myBack.[Next] = newNode
        End If

        myBack = newNode

        myCount += 1

        If Count = 1 Then
            myFront = myBack
        End If

        myVersion += 1
    End Sub

    Friend Overridable Function PopFront() As T
        If Count = 0 Then
            Throw New InvalidOperationException("Deque is empty.")
        End If

        Dim item As T = myFront.Value

        myFront = myFront.[Next]

        myCount -= 1

        If Count > 0 Then
            myFront.Previous = Nothing
        Else
            myBack = Nothing
        End If

        myVersion += 1

        Return item
    End Function

    Friend Overridable Function PopBack() As T
        If Count = 0 Then
            Throw New InvalidOperationException("Deque is empty.")
        End If

        Dim item As T = myBack.Value

        myBack = myBack.Previous

        myCount -= 1

        If Count > 0 Then
            myBack.[Next] = Nothing
        Else
            myFront = Nothing
        End If

        myVersion += 1

        Return item
    End Function

    Friend Overridable Function PeekFront() As T
        If Count = 0 Then
            Throw New InvalidOperationException("Deque is empty.")
        End If

        Return myFront.Value
    End Function

    Friend Overridable Function PeekBack() As T
        If Count = 0 Then
            Throw New InvalidOperationException("Deque is empty.")
        End If

        Return myBack.Value
    End Function

    Friend Overridable Function ToArray() As T()
        Dim array As T() = New T(Count - 1) {}
        Dim index As Integer

        For Each item As T In Me
            array(index) = item
            index += 1
        Next

        Return array
    End Function

    Friend Shared Function Synchronized(deque As Deque(Of T)) As Deque(Of T)
        If deque Is Nothing Then
            Throw New ArgumentNullException("deque")
        End If

        Return New SynchronizedDeque(deque)
    End Function

#End Region

#End Region

#Region "ICollection Members"

    Friend Overridable ReadOnly Property IsSynchronized As Boolean Implements ICollection.IsSynchronized
        Get
            Return False
        End Get
    End Property

    Friend Overridable ReadOnly Property Count As Integer Implements ICollection.Count
        Get
            Return myCount
        End Get
    End Property

    Friend Overridable Sub CopyTo(array As Array, index As Integer) Implements ICollection.CopyTo
        If array Is Nothing Then
            Throw New ArgumentNullException("array")
        ElseIf index < 0 Then
            Throw New ArgumentOutOfRangeException("index", index, "Index is less than zero.")
        ElseIf array.Rank > 1 Then
            Throw New ArgumentException("Array is multidimensional.")
        ElseIf index >= array.Length Then
            Throw New ArgumentException("Index is equal to or greater than the length of array.")
        ElseIf Count > array.Length - index Then
            Throw New ArgumentException("The number of elements in the source Deque is greater than the available space from index to the end of the destination array.")
        End If

        Dim i As Integer = index

        For Each obj As Object In Me
            array.SetValue(obj, i)
            i += 1
        Next
    End Sub

    Friend Overridable ReadOnly Property SyncRoot As Object Implements ICollection.SyncRoot
        Get
            Return Me
        End Get
    End Property

#End Region

#Region "IEnumerable Members"

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return New Enumerator(Me)
    End Function

#End Region

#Region "ICloneable Members"

    Friend Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim clone1 As New Deque(Of T)(Me)

        clone1.myVersion = myVersion

        Return clone1
    End Function

#End Region

#Region "IEnumerable<T> Members"

    Friend Overridable Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
        Return New Enumerator(Me)
    End Function

    Private Shared Function InlineAssignHelper(Of TType)(ByRef target As TType, value As TType) As TType
        target = value
        Return value
    End Function

#End Region

End Class
