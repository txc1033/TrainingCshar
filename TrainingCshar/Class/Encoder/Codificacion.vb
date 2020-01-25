Namespace TrainingCshar.Encoder
    Friend Class Codificacion
        Private Shared _cadena As String

        Public Shared Function Cadena() As String
            Return _cadena
        End Function

        Public Shared Sub Procesar(ByVal cadena As String, ByVal codifica As Boolean)
            cadena = If(codifica, Encriptar(cadena), Desencriptar(cadena))
        End Sub

        Private Shared Function Encriptar(ByVal cadena As String) As String
            Dim encriptado = Encoding.Unicode.GetBytes(cadena)
            _cadena = Convert.ToBase64String(encriptado)
            Return _cadena
        End Function

        Private Shared Function Desencriptar(ByVal cadena As String) As String
            Dim desencriptado = Convert.FromBase64String(cadena)
            _cadena = Encoding.Unicode.GetString(desencriptado)
            Return _cadena
        End Function
    End Class
End Namespace
