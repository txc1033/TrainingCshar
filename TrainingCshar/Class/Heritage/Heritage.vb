Namespace TrainingCshar.Heritage
    Public Class Vehiculo
        Private vehiculo As String

        Public Function arrancarMotor() As String
            Return $"Estoy arracando el motor del {vehiculo}"
        End Function

        Public Function pararMotor() As String
            Return $"Estoy deteniendo el motor del {vehiculo}"
        End Function

        Public Overridable Function conducir() As String
            Return $"Estoy manejando el {vehiculo}"
        End Function

        Public Sub New(ByVal nombre As String)
            vehiculo = nombre
        End Sub
    End Class

    Public Class Coche
        Inherits Vehiculo

        Public Sub New(ByVal nombre As String)
            MyBase.New(nombre)
        End Sub

        Overloads Public Overridable Function conducir() As String
            Return "Estoy avanzando por la carretera"
        End Function
    End Class

    Public Class Avion
        Inherits Vehiculo

        Public Sub New(ByVal nombre As String)
            MyBase.New(nombre)
        End Sub

        Public Overrides Function conducir() As String
            Return "Estoy volando por los aires"
        End Function
    End Class
End Namespace
