Imports System.Collections.Generic

Namespace TrainingCshar.Collections
    Friend Class Pila
        Implements IPila

        Private pilaPersona As Stack(Of Persona) = New Stack(Of Persona)()

        Public Sub Agregar(ByVal persona As Persona) Implements IPila.Agregar
            pilaPersona.Push(persona)
        End Sub

        Public Sub Agregar(ByVal stack As Stack(Of Persona)) Implements IPila.Agregar
            For Each persona In stack
                pilaPersona.Push(persona)
            Next
        End Sub

        Public Function Clonar() As Stack(Of Persona) Implements IPila.Clonar
            Dim pilaCopia As Stack(Of Persona) = New Stack(Of Persona)()

            For Each persona In pilaPersona
                pilaCopia.Push(persona)
            Next

            Return pilaCopia
        End Function

        Public Function Cantidad() As String Implements IPila.Cantidad
            Return $"Cantidad de elementos en Pila: {pilaPersona.Count} "
        End Function

        Public Function Imprimir() As List(Of String) Implements IPila.Imprimir
            Dim pl As List(Of String) = New List(Of String)()

            For Each persona In pilaPersona
                pl.Add($"Hola Me llamo {persona.nombre} ")
                pl.Add($"y tengo {persona.edad} años ")
            Next

            Return pl
        End Function

        Public Sub Eliminar(ByVal todos As Boolean) Implements IPila.Eliminar
            If todos Then
                pilaPersona.Clear()
            Else
                pilaPersona.Pop()
            End If
        End Sub
    End Class

    Public Class Persona
        Private _nombre As String
        Private _edad As Integer

        Public Sub New(ByVal nombre As String, ByVal Optional edad As Integer = 15)
            _nombre = nombre
            _edad = edad
        End Sub

        Public ReadOnly Property nombre As String
            Get
                Return _nombre
            End Get
        End Property

        Public ReadOnly Property edad As Integer
            Get
                Return _edad
            End Get
        End Property
    End Class
End Namespace
