using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using ClassVbExtendss;

namespace TrainingCshar.Formulaio
{
    public partial class FApiTask : Form
    {
        private ToolTip tlp = new ToolTip();

        public FApiTask()
        {
            InitializeComponent();
        }

        private void LbResponse_Click(object sender, EventArgs e)
        {
            tlp.Show("Elige un metodo de envio en la lista",this.lbResponse,30);
        }

        private void CmbTypeEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool estado = cmbTypeEnv.SelectedIndex > 0 ? true : false;
            txtUrl.Enabled = estado;
            btnSend.Visible = estado;
        }

        private void TxtUrl_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
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
               lbStatus.Text =  except.Message.Substring(0,34);
            }
        }
    }
}