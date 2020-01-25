Imports System
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports System.Web.Script.Serialization
Imports ClassVbExtendss

Namespace TrainingCshar.Formulaio
    Public Partial Class FApiTask
        Inherits Form

        Private tlp As ToolTip = New ToolTip()

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub LbResponse_Click(ByVal sender As Object, ByVal e As EventArgs)
            tlp.Show("Elige un metodo de envio en la lista", lbResponse, 30)
        End Sub

        Private Sub CmbTypeEnv_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim estado = If(cmbTypeEnv.SelectedIndex > 0, True, False)
            txtUrl.Enabled = estado
            btnSend.Visible = estado
        End Sub

        Private Sub TxtUrl_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Dim pattern = "^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$"
            Dim reg As Regex = New Regex(pattern, RegexOptions.Compiled Or RegexOptions.IgnoreCase)
            Dim isUri = reg.IsMatch(txtUrl.Text)
            btnSend.Enabled = isUri
            chkTexto.Visible = isUri
        End Sub

        Private Sub ChkTexto_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            txtJson.Enabled = chkTexto.Checked
            txtJson.ReadOnly = Not chkTexto.Checked
            btnToJson.Visible = chkTexto.Checked
            btnToClass.Visible = chkTexto.Checked
        End Sub

        Private Sub TxtJson_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            Try
                lbStatus.ResetText()
                Dim javaScript As JavaScriptSerializer
                javaScript = New JavaScriptSerializer()
                Dim objectPersona = javaScript.Deserialize(Of Persona)(txtJson.Text)
                Dim jsonPersona = javaScript.Serialize(txtJson.Text)
            Catch except As Exception
                lbStatus.Text = except.Message.Substring(0, 34)
            End Try
        End Sub
    End Class
End Namespace
