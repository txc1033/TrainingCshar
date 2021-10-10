namespace TrainingCshar.Formulaio
{
    partial class FApiTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FApiTask));
            this.cmbTypeEnv = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnToJson = new System.Windows.Forms.Button();
            this.btnToClass = new System.Windows.Forms.Button();
            this.chkTexto = new System.Windows.Forms.CheckBox();
            this.txtJson = new System.Windows.Forms.TextBox();
            this.tbcJson = new System.Windows.Forms.TabControl();
            this.tbJsonText = new System.Windows.Forms.TabPage();
            this.lbStatus = new System.Windows.Forms.Label();
            this.lbUrl = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.tbJsonClass = new System.Windows.Forms.TabPage();
            this.lbResponse = new System.Windows.Forms.Label();
            this.tbcJson.SuspendLayout();
            this.tbJsonText.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTypeEnv
            // 
            this.cmbTypeEnv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeEnv.FormattingEnabled = true;
            this.cmbTypeEnv.Items.AddRange(new object[] {
            "Ninguno",
            "Get",
            "Put",
            "Post",
            "Delete"});
            this.cmbTypeEnv.Location = new System.Drawing.Point(6, 34);
            this.cmbTypeEnv.Name = "cmbTypeEnv";
            this.cmbTypeEnv.Size = new System.Drawing.Size(121, 21);
            this.cmbTypeEnv.TabIndex = 0;
            this.cmbTypeEnv.SelectedIndexChanged += new System.EventHandler(this.CmbTypeEnv_SelectedIndexChanged);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(133, 34);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Enviar";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Visible = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_ClickAsync);
            // 
            // btnToJson
            // 
            this.btnToJson.Enabled = false;
            this.btnToJson.Location = new System.Drawing.Point(214, 34);
            this.btnToJson.Name = "btnToJson";
            this.btnToJson.Size = new System.Drawing.Size(75, 23);
            this.btnToJson.TabIndex = 2;
            this.btnToJson.Text = "Serializa";
            this.btnToJson.UseVisualStyleBackColor = true;
            this.btnToJson.Visible = false;
            this.btnToJson.Click += new System.EventHandler(this.btnToJson_Click);
            // 
            // btnToClass
            // 
            this.btnToClass.Enabled = false;
            this.btnToClass.Location = new System.Drawing.Point(295, 34);
            this.btnToClass.Name = "btnToClass";
            this.btnToClass.Size = new System.Drawing.Size(75, 23);
            this.btnToClass.TabIndex = 3;
            this.btnToClass.Text = "Deserializa";
            this.btnToClass.UseVisualStyleBackColor = true;
            this.btnToClass.Visible = false;
            this.btnToClass.Click += new System.EventHandler(this.btnToClass_Click);
            // 
            // chkTexto
            // 
            this.chkTexto.AutoSize = true;
            this.chkTexto.Location = new System.Drawing.Point(376, 36);
            this.chkTexto.Name = "chkTexto";
            this.chkTexto.Size = new System.Drawing.Size(97, 17);
            this.chkTexto.TabIndex = 4;
            this.chkTexto.Text = "Preparar Json?";
            this.chkTexto.UseVisualStyleBackColor = true;
            this.chkTexto.Visible = false;
            this.chkTexto.CheckedChanged += new System.EventHandler(this.ChkTexto_CheckedChanged);
            // 
            // txtJson
            // 
            this.txtJson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJson.Location = new System.Drawing.Point(6, 65);
            this.txtJson.Multiline = true;
            this.txtJson.Name = "txtJson";
            this.txtJson.ReadOnly = true;
            this.txtJson.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJson.Size = new System.Drawing.Size(475, 185);
            this.txtJson.TabIndex = 5;
            this.txtJson.TextChanged += new System.EventHandler(this.TxtJson_TextChanged);
            // 
            // tbcJson
            // 
            this.tbcJson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcJson.Controls.Add(this.tbJsonText);
            this.tbcJson.Controls.Add(this.tbJsonClass);
            this.tbcJson.Location = new System.Drawing.Point(2, 84);
            this.tbcJson.Name = "tbcJson";
            this.tbcJson.SelectedIndex = 0;
            this.tbcJson.Size = new System.Drawing.Size(497, 298);
            this.tbcJson.TabIndex = 6;
            // 
            // tbJsonText
            // 
            this.tbJsonText.Controls.Add(this.lbStatus);
            this.tbJsonText.Controls.Add(this.lbUrl);
            this.tbJsonText.Controls.Add(this.txtUrl);
            this.tbJsonText.Controls.Add(this.txtJson);
            this.tbJsonText.Location = new System.Drawing.Point(4, 22);
            this.tbJsonText.Name = "tbJsonText";
            this.tbJsonText.Padding = new System.Windows.Forms.Padding(3);
            this.tbJsonText.Size = new System.Drawing.Size(489, 272);
            this.tbJsonText.TabIndex = 0;
            this.tbJsonText.Text = "Json retornado";
            this.tbJsonText.UseVisualStyleBackColor = true;
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(6, 253);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(47, 13);
            this.lbStatus.TabIndex = 8;
            this.lbStatus.Text = "Status:";
            // 
            // lbUrl
            // 
            this.lbUrl.AutoSize = true;
            this.lbUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUrl.Location = new System.Drawing.Point(3, 24);
            this.lbUrl.Name = "lbUrl";
            this.lbUrl.Size = new System.Drawing.Size(102, 18);
            this.lbUrl.TabIndex = 7;
            this.lbUrl.Text = "Ingresa la  Url:";
            // 
            // txtUrl
            // 
            this.txtUrl.Enabled = false;
            this.txtUrl.Location = new System.Drawing.Point(114, 24);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(351, 20);
            this.txtUrl.TabIndex = 6;
            this.txtUrl.TextChanged += new System.EventHandler(this.TxtUrl_TextChanged);
            // 
            // tbJsonClass
            // 
            this.tbJsonClass.Location = new System.Drawing.Point(4, 22);
            this.tbJsonClass.Name = "tbJsonClass";
            this.tbJsonClass.Padding = new System.Windows.Forms.Padding(3);
            this.tbJsonClass.Size = new System.Drawing.Size(489, 272);
            this.tbJsonClass.TabIndex = 1;
            this.tbJsonClass.Text = "Objeto Json";
            this.tbJsonClass.UseVisualStyleBackColor = true;
            // 
            // lbResponse
            // 
            this.lbResponse.AutoSize = true;
            this.lbResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResponse.Location = new System.Drawing.Point(3, 15);
            this.lbResponse.Name = "lbResponse";
            this.lbResponse.Size = new System.Drawing.Size(124, 16);
            this.lbResponse.TabIndex = 7;
            this.lbResponse.Text = "Metodo de envio";
            this.lbResponse.Click += new System.EventHandler(this.LbResponse_Click);
            // 
            // FApiTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 385);
            this.Controls.Add(this.lbResponse);
            this.Controls.Add(this.tbcJson);
            this.Controls.Add(this.chkTexto);
            this.Controls.Add(this.btnToClass);
            this.Controls.Add(this.btnToJson);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cmbTypeEnv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FApiTask";
            this.Text = "Gestion Json";
            this.tbcJson.ResumeLayout(false);
            this.tbJsonText.ResumeLayout(false);
            this.tbJsonText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTypeEnv;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnToJson;
        private System.Windows.Forms.Button btnToClass;
        private System.Windows.Forms.CheckBox chkTexto;
        private System.Windows.Forms.TextBox txtJson;
        private System.Windows.Forms.TabControl tbcJson;
        private System.Windows.Forms.TabPage tbJsonText;
        private System.Windows.Forms.TabPage tbJsonClass;
        private System.Windows.Forms.Label lbUrl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lbResponse;
        private System.Windows.Forms.Label lbStatus;
    }
}