Namespace TrainingCshar.Algorithms
    Public Class Recursividad
        Implements IRecursividad

        Public Function Factorial(ByVal numero As Long) As Long Implements IRecursividad.Factorial
            Return If(numero > 0, numero * Factorial(numero - 1), 1)
        End Function
    End Class
End Namespace
