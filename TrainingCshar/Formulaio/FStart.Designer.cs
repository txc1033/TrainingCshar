namespace TrainingCshar.Formulaio
{
    partial class FStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FStart));
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.cmbAcciones = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Enabled = false;
            this.btnEjecutar.Location = new System.Drawing.Point(186, 12);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(139, 23);
            this.btnEjecutar.TabIndex = 0;
            this.btnEjecutar.Text = "Ejecutar: None";
            this.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.BtnEjecutar_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultado.Cursor = System.Windows.Forms.Cursors.Cross;
            this.txtResultado.Location = new System.Drawing.Point(13, 41);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(312, 206);
            this.txtResultado.TabIndex = 4;
            // 
            // cmbAcciones
            // 
            this.cmbAcciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcciones.FormattingEnabled = true;
            this.cmbAcciones.Location = new System.Drawing.Point(13, 13);
            this.cmbAcciones.Name = "cmbAcciones";
            this.cmbAcciones.Size = new System.Drawing.Size(167, 21);
            this.cmbAcciones.TabIndex = 5;
            this.cmbAcciones.SelectedIndexChanged += new System.EventHandler(this.CmbAccion_SelectedIndexChanged);
            this.cmbAcciones.TextChanged += new System.EventHandler(this.CmbAcciones_TextChanged);
            this.cmbAcciones.Click += new System.EventHandler(this.CmbAccion_Click);
            this.cmbAcciones.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.CmbAccion_PreviewKeyDown);
            // 
            // FStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 250);
            this.Controls.Add(this.cmbAcciones);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.btnEjecutar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(353, 289);
            this.Name = "FStart";
            this.Text = "Metodos Disponibles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.ComboBox cmbAcciones;
    }
}