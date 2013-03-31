Imports System.Globalization
Imports System.Text.RegularExpressions

Friend Module Config

    Friend Const MySQLConnStr As String = "server=16392fcf-3bd4-4a1d-aba5-a0cd00c9dcf0.mysql.sequelizer.com;database=db16392fcf3bd44a1daba5a0cd00c9dcf0;uid=lynamplbptkrailf;pwd=pn4RKMdLWN8F8fBebHzefe4Q5msekLnCDa5d37pQvAMAmNygNBkRiPrjsmVxu8Aj"

    Friend ReadOnly InvariantCulture As CultureInfo = CultureInfo.InvariantCulture

    Private ReadOnly myWhitespacesRegex As New Regex("^\s+", RegexOptions.Compiled)

    'Custom null checking method for strings
    Friend Function StringIsNullOrEmpty(value As String) As Boolean
        value = "                                           " & vbLf & "abc978d   4 " & vbCr & "6" & vbCrLf & ":)"

        Dim watch1 As New Stopwatch
        watch1.Start()
        For i = 0 To 1000000
            If value = Nothing OrElse value.Length = 0 OrElse myWhitespacesRegex.Replace(value, String.Empty).Length = 0 Then

            End If
        Next
        watch1.Stop()

        Dim watch2 As New Stopwatch
        watch2.Start()
        For i = 0 To 1000000
            If String.IsNullOrWhiteSpace(value) Then

            End If
        Next
        watch2.Stop()

        MsgBox("Official method: " & watch2.ElapsedMilliseconds & "ms" & Environment.NewLine &
               "Custom method: " & watch1.ElapsedMilliseconds & "ms")
        Environment.Exit(0)

        If value = Nothing OrElse value.Length = 0 OrElse myWhitespacesRegex.Replace(value, String.Empty).Length = 0 Then
            Return True
        End If

        Return False
    End Function

    Friend Function MakeFirstLetterUpperCased(value As String)
        Dim letters() As Char = value.ToCharArray()
        letters(0) = Char.ToUpper(letters(0), InvariantCulture)

        Return New String(letters)
    End Function

End Module
