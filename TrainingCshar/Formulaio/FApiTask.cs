using ClassVbExtendss;
using System;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace TrainingCshar.Formulaio
{
    public partial class FApiTask : Form
    {
        private readonly ToolTip tlp = new ToolTip();

        private const string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";


        public FApiTask()
        {
            InitializeComponent();
        }

        private void LbResponse_Click(object sender, EventArgs e)
        {
            tlp.Show("Elige un metodo de envio en la lista", this.lbResponse, 30);
        }

        private void CmbTypeEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool estado = cmbTypeEnv.SelectedIndex > 0 ? true : false;
            txtUrl.Enabled = estado;
            btnSend.Visible = estado;
        }

        private void TxtUrl_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            bool isUri = reg.IsMatch(txtUrl.Text);
            btnSend.Enabled = isUri;
            chkTexto.Visible = isUri;
        }

        private void ChkTexto_CheckedChanged(object sender, EventArgs e)
        {
            txtJson.Enabled = chkTexto.Checked;
            txtJson.ReadOnly = !chkTexto.Checked;
            btnToJson.Visible = chkTexto.Checked;
            btnToClass.Visible = chkTexto.Checked;
        }

        private void TxtJson_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbStatus.ResetText();
                JavaScriptSerializer javaScript;

                javaScript = new JavaScriptSerializer();

                Persona objectPersona = javaScript.Deserialize<Persona>(txtJson.Text);
                var jsonPersona = javaScript.Serialize(txtJson.Text);
            }
            catch (Exception except)
            {
                lbStatus.Text = except.Message.Substring(0, 34);
            }
        }
    }
}