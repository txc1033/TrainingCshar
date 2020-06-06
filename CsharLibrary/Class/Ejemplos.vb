Imports System
Imports TrainingCshar.Collections
Imports TrainingCshar.Heritage
Imports TrainingCshar.Algorithms
Imports TrainingCshar.Encoder
Imports System.Collections.Generic
Imports System.Data.SqlClient

Namespace TrainingCshar.Examples
    Friend Class Ejemplos
        Implements IEjemplos

        Public Function Recursividad(ByVal numero As Integer) As List(Of String) Implements IEjemplos.Recursividad
            Dim lRecursividadResult As List(Of String) = New List(Of String)()
            lRecursividadResult.Add("//////RECURSIVIDAD//////////")
            Dim Recursivo As Recursividad = New Recursividad()
            Dim factorial As Long = 0

            If numero < 66 Then
                factorial = Recursivo.Factorial(numero)
                lRecursividadResult.Add($"El facorial de {numero} es: {factorial}")
            Else
                lRecursividadResult.Add($"El resultado del factorial de {numero} supera los limites")
            End If

            Return lRecursividadResult
        End Function

        Public Function Codificacion(ByVal mensaje As String) As List(Of String)
            Dim lCodificacionResult As List(Of String) = New List(Of String)()

            If Not String.IsNullOrEmpty(mensaje) Then
                Encoder.Codificacion.Procesar(mensaje, True)
                lCodificacionResult.Add($"Mensaje Codificado: {Encoder.Codificacion.Cadena()}")
                Encoder.Codificacion.Procesar(Encoder.Codificacion.Cadena(), False)
                lCodificacionResult.Add($"Mensaje Decodificado: {Encoder.Codificacion.Cadena()}")
            Else
                lCodificacionResult.Add("No se puede codificar texto vacio..")
            End If

            Return lCodificacionResult
        End Function

        Public Function Pila() As List(Of String) Implements IEjemplos.Pila
            Dim lPilaResult As List(Of String) = New List(Of String)()
            Console.WriteLine("//////PILA//////////")
            Dim pilaPersona As IPila = New Pila()
            Dim pepe As Persona = New Persona("Pepe", 25)
            Dim juan As Persona = New Persona("Juan", 40)
            pilaPersona.Agregar(pepe)
            pilaPersona.Agregar(juan)
            lPilaResult.AddRange(pilaPersona.Imprimir())
            lPilaResult.Add(pilaPersona.Cantidad())
            Dim pilaClon As Pila = New Pila()
            pilaClon.Agregar(pilaPersona.Clonar())
            pilaClon.Eliminar(True)
            lPilaResult.AddRange(pilaClon.Imprimir())
            Return lPilaResult
        End Function

        Public Function Herencia() As List(Of String) Implements IEjemplos.Herencia
            Dim lHerenciaResult As List(Of String) = New List(Of String)()
            lHerenciaResult.Add("//////HERENCIA//////////")
            Dim vehiculo As Vehiculo = New Vehiculo("vehiculo")
            Dim avion As Avion = New Avion("Avion")
            Dim coche As Coche = New Coche("Automovil")
            Dim vehiculos = New Vehiculo(2) {}
            vehiculos(0) = avion
            vehiculos(1) = coche
            vehiculos(2) = vehiculo

            For i = 0 To vehiculos.Length - 1
                lHerenciaResult.Add($"{vehiculos(i).arrancarMotor()}")
                lHerenciaResult.Add($"{vehiculos(i).pararMotor()}")
            Next

            Dim poliMorphVehiculo As Vehiculo = avion
            lHerenciaResult.Add(poliMorphVehiculo.conducir())
            poliMorphVehiculo = coche
            lHerenciaResult.Add(poliMorphVehiculo.conducir())
            poliMorphVehiculo = vehiculo
            lHerenciaResult.Add(poliMorphVehiculo.conducir())
            Return lHerenciaResult
        End Function

        Public Function Json() As List(Of String)
            Return New List(Of String) From {
                "Abriendo Json..."
            }
        End Function

        Public Function BaseDatos() As List(Of String) Implements IEjemplos.BaseDatos
            Dim lBaseDatosResult As List(Of String) = New List(Of String)()

            Try
                Dim sqlConnection As SqlConnection
                Dim sql As ISqlAccess = New SqlAccess()
                Encoder.Codificacion.Procesar(sql.db, False)
                sqlConnection = New SqlConnection(Encoder.Codificacion.Cadena())
                sqlConnection.Open()
                lBaseDatosResult.Add($"Bien Se conecto a {sqlConnection.Database} estado: {sqlConnection.State}")
                Return lBaseDatosResult
            Catch e As Exception
                lBaseDatosResult.Add($"Oops! hemos tenido un problema en {e.Message}")
                Return lBaseDatosResult
            End Try
        End Function
    End Class
End Namespace
