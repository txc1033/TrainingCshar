Imports System
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports TrainingCshar.Encoder

Namespace TrainingCshar.Formulaio
    Public Partial Class FDataBaseTask
        Inherits Form

        Private sqlConnection As SqlConnection

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnExportToCsv_Click(ByVal sender As Object, ByVal e As EventArgs)
            GuardarCsv(DGPersona)
        End Sub

        Private Sub btnLoadCSV_Click(ByVal sender As Object, ByVal e As EventArgs)
            DGPersona = CargarCsv()
        End Sub

        Private Sub btnLoadDb_Click(ByVal sender As Object, ByVal e As EventArgs)
            DGPersona = CargarDbenBs(sqlConnection)
        End Sub

        Private Sub btnLocalToDb_Click(ByVal sender As Object, ByVal e As EventArgs)
            GuardarBSenDb(DGPersona)
        End Sub

        Private Function CargarCsv() As DataGridView
            Dim dgCsv As DataGridView = New DataGridView()
            Return dgCsv
        End Function

        Private Function CargarDbenBs(ByVal sqlConnection As SqlConnection) As DataGridView
            Dim dgDb As DataGridView = New DataGridView()
            Return dgDb
        End Function

        Private Sub DGPersona_RowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs)
            Dim cantidadFilas = DGPersona.Rows.Count

            For i = 1 To cantidadFilas - 1
                DGPersona.Rows(i - 1).Cells(0).Value = i
            Next
        End Sub

        Private Sub FDataBaseTask_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
            sqlConnection.Close()
        End Sub

        Private Sub FDataBaseTask_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim Codificacion As Codificacion = New Codificacion()
            sqlConnection = New SqlConnection(Codificacion.Cadena())

            Try
                Dim sql As SqlAccess = New SqlAccess()
                Codificacion.Procesar(sql.db, False)
                sqlConnection.Open()
            Catch __unusedException1__ As Exception
                Me.Close()
            End Try
        End Sub

        Private Sub GuardarBSenDb(ByVal dGPersona As DataGridView)
            Throw New NotImplementedException("Metodo en desarrollo")
        End Sub

        Private Sub GuardarCsv(ByVal dGPersona As DataGridView)
            If Me.DGPersona.RowCount > 1 Then
                Dim archivo = $"{Me.DGPersona.Name}_{Date.UtcNow.ToString("DD-MM-yyyy_hhmm")}.csv"
                Dim texto As StringBuilder = New StringBuilder()
                Dim columna = ""

                For j = 0 To Me.DGPersona.ColumnCount - 1
                    columna += Me.DGPersona.Columns(j).HeaderText & ","
                Next

                columna = columna.Substring(0, columna.Length - 1)
                texto.AppendLine(columna)

                For i = 0 To Me.DGPersona.RowCount - 1 - 1
                    Dim Fila = ""

                    For j = 0 To Me.DGPersona.ColumnCount - 1
                        Fila += Me.DGPersona.Rows(i).Cells(j).Value.ToString() & ","
                    Next

                    Fila = Fila.Substring(0, Fila.Length - 1)
                    texto.AppendLine(Fila)
                Next

                Dim carpeta = "D:\TrainingDb"

                If Not Directory.Exists(carpeta) Then
                    Directory.CreateDirectory(carpeta)
                End If

                Dim rutaArchivo = Path.Combine(carpeta, archivo)
                File.WriteAllText(rutaArchivo, texto.ToString())

                Try
                    Process.Start("notepad++.exe", rutaArchivo)
                Catch __unusedException1__ As Exception
                    Process.Start("notepad.exe", rutaArchivo)
                End Try
            End If
        End Sub
    End Class
End Namespace
