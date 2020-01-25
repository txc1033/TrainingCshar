Imports System
Imports System.Collections.Generic
Imports System.Reflection
Imports Microsoft.VisualBasic
Imports System.Windows.Forms

Namespace TrainingCshar.Formulaio
    Public Partial Class FStart
        Inherits Form

        Private tiposEjemplo As Type
        Private metodosEjemplos As MethodInfo()

        Public Sub New()
            InitializeComponent()
            tiposEjemplo = GetType(Examples.Ejemplos)
            metodosEjemplos = tiposEjemplo.GetMethods()
            InitializeCombobox(metodosEjemplos)
        End Sub

        Private Sub InitializeCombobox(ByVal listaMetodos As MethodInfo())
            cmbAcciones.Items.Add("Seleccione Una Accion...")
            cmbAcciones.SelectedIndex = 0
            Dim tipoObject = GetType(Object)
            Dim metodosObject As MethodInfo() = tipoObject.GetMethods()

            For Each metodo In listaMetodos
                Dim accion = metodo.Name
                cmbAcciones.Items.Add(accion)

                For Each metodoObject In metodosObject

                    If accion.Equals(metodoObject.Name) Then
                        cmbAcciones.Items.Remove(accion)
                    End If
                Next
            Next
        End Sub

        Private Sub CmbAcciones_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim posicionAccion = cmbAcciones.FindString(cmbAcciones.Text.ToString)
            Dim indiceAcciones = If(posicionAccion > 0, posicionAccion, 0)
            cmbAcciones.SelectedIndex = indiceAcciones
            btnEjecutar.Text = If(indiceAcciones > 0, $"Ejecutar: {cmbAcciones.Text}", "Ejecutar: Nada")
        End Sub

        Private Sub BtnEjecutar_Click(ByVal sender As Object, ByVal e As EventArgs)
            txtResultado.Clear()
            Dim accion = cmbAcciones.Text
            Dim resultados = EjecutaAccion(accion)

            For Each resultado In resultados
                txtResultado.Text += $"{resultado} {Environment.NewLine}"
            Next

            Select Case accion
                Case "Json"
                    OpenFApi()
                Case "BaseDatos"

                    If txtResultado.Text.ToLower().Contains("open") Then
                        OpenFDb()
                    End If
            End Select
        End Sub

        Private Function EjecutaAccion(ByVal accion As String) As List(Of String)
            Try
                Dim Ejemplos As Examples.Ejemplos = New Examples.Ejemplos()

                For Each metodo In metodosEjemplos
                    Dim parametros As ParameterInfo() = metodo.GetParameters()

                    If metodo.Name Is accion Then
                        Dim respuestas As List(Of String)

                        If parametros.Length < 1 Then
                            respuestas = CType(Interaction.CallByName(Ejemplos, accion, CallType.Method), List(Of String))
                        ElseIf parametros(0).Name Is "numero" Then
                            Dim mensaje = $"Favor escribe un {parametros(0).Name} para la tarea {accion}"
                            Dim valor = Integer.Parse(Interaction.InputBox(mensaje))
                            respuestas = CType(Interaction.CallByName(Ejemplos, accion, CallType.Method, valor), List(Of String))
                        Else
                            Dim mensaje = $"Favor escribe un {parametros(0).Name} para la tarea {accion}"
                            Dim valor = Interaction.InputBox(mensaje)
                            respuestas = CType(Interaction.CallByName(Ejemplos, accion, CallType.Method, valor), List(Of String))
                        End If

                        Return respuestas
                    End If
                Next

                Return New List(Of String) From {
                    $"Accion {accion} No encontrada"
                }
            Catch e As Exception
                Return New List(Of String) From {
                    $"Error en {accion}: {e.Message}"
                }
            End Try
        End Function

        Private Sub OpenFApi()
            Dim fApi As FApiTask = New FApiTask()
            Me.Hide()
            fApi.ShowDialog()
            Me.Show()
        End Sub

        Private Sub OpenFDb()
            Dim fDB As FDataBaseTask = New FDataBaseTask()
            Me.Hide()
            fDB.ShowDialog()
            Me.Show()
        End Sub

        Private Sub CmbAccion_Click(ByVal sender As Object, ByVal e As EventArgs)
            cmbAcciones.SelectAll()
        End Sub

        Private Sub CmbAccion_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            btnEjecutar.Enabled = If(cmbAcciones.SelectedIndex > 0, True, False)
        End Sub

        Private Sub CmbAccion_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
            cmbAcciones.SelectAll()
        End Sub
    End Class
End Namespace
