Imports System.Configuration

Namespace TrainingCshar.Encoder
    Friend Class SqlAccess
        Implements ISqlAccess

        Private sql_avanzado As String

        Public ReadOnly Property db As String Implements ISqlAccess.db
            Get
                Return sql_avanzado
            End Get
        End Property

        Public Sub New()
            sql_avanzado = ConfigurationManager.ConnectionStrings("sql_avanzado").ToString()
        End Sub
    End Class
End Namespace
