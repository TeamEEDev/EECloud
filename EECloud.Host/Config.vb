Imports System.Globalization

Module Config

    'Friend Const MySQLConnStr As String = ""

    Friend ReadOnly InvariantCulture As CultureInfo = CultureInfo.InvariantCulture

    Friend Function MakeFirstLetterUpperCased(value As String)
        Dim letters As Char() = value.ToCharArray()
        letters(0) = Char.ToUpper(letters(0), InvariantCulture)

        Return New String(letters)
    End Function

End Module
