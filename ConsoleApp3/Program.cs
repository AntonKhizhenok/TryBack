Module Module1

    Sub Main()
        MySub()
    End Sub

    Function MyFunction() As Decimal
        Static i As Integer
        i = i + 1
        Return i
    End Function

    Sub MySub()
        MyFunction()

    End Sub
End Module
