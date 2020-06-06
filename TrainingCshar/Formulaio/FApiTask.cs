using CsharLibrary.Class.Data_Process;
using CsharLibrary.Models;
using System;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace TrainingCshar.Formulaio
{
    public partial class FApiTask : Form
    {
        private IManagement management;
        private readonly ToolTip tlp = new ToolTip();

        public FApiTask(IManagement _management)
        {
            InitializeComponent();
            management = _management;
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
            Regex reg = new Regex(management.GetPattern(), RegexOptions.Compiled | RegexOptions.IgnoreCase);

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

                Person objectPersona = javaScript.Deserialize<Person>(txtJson.Text);
                var jsonPersona = javaScript.Serialize(txtJson.Text);
            }
            catch (Exception except)
            {
                lbStatus.Text = except.Message.Substring(0, 34);
            }
        }

        private async void btnSend_ClickAsync(object sender, EventArgs e)
        {
            txtJson.Text = await management.GetHttpUrl(txtUrl.Text);
        }
    }
}