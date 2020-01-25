Imports System.Collections.Generic

Namespace TrainingCshar.Collections
    Friend Interface IPila
        Sub Agregar(ByVal persona As Persona)
        Sub Agregar(ByVal stack As Stack(Of Persona))
        Function Cantidad() As String
        Function Clonar() As Stack(Of Persona)
        Sub Eliminar(ByVal todos As Boolean)
        Function Imprimir() As List(Of String)
    End Interface
End Namespace
