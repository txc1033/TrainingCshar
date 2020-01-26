namespace TrainingCshar.Formulaio
{
    partial class FDataBaseTask
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FDataBaseTask));
            this.btnLoadDb = new System.Windows.Forms.Button();
            this.btnLocalToDb = new System.Windows.Forms.Button();
            this.DGPersona = new System.Windows.Forms.DataGridView();
            this.peridPersonaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pernombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perapellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peredadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perrutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perdvDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perfechaNacimientoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personaBS = new System.Windows.Forms.BindingSource(this.components);
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnExportToCsv = new System.Windows.Forms.Button();
            this.btnLoadCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personaBS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadDb
            // 
            this.btnLoadDb.Location = new System.Drawing.Point(13, 23);
            this.btnLoadDb.Name = "btnLoadDb";
            this.btnLoadDb.Size = new System.Drawing.Size(118, 27);
            this.btnLoadDb.TabIndex = 0;
            this.btnLoadDb.Text = "Cargar Data de la DB";
            this.btnLoadDb.UseVisualStyleBackColor = true;
            this.btnLoadDb.Click += new System.EventHandler(this.btnLoadDb_Click);
            // 
            // btnLocalToDb
            // 
            this.btnLocalToDb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocalToDb.Location = new System.Drawing.Point(661, 23);
            this.btnLocalToDb.Name = "btnLocalToDb";
            this.btnLocalToDb.Size = new System.Drawing.Size(114, 27);
            this.btnLocalToDb.TabIndex = 1;
            this.btnLocalToDb.Text = "Exportar Local a DB";
            this.btnLocalToDb.UseVisualStyleBackColor = true;
            this.btnLocalToDb.Click += new System.EventHandler(this.btnLocalToDb_Click);
            // 
            // DGPersona
            // 
            this.DGPersona.AllowUserToOrderColumns = true;
            this.DGPersona.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGPersona.AutoGenerateColumns = false;
            this.DGPersona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGPersona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.peridPersonaDataGridViewTextBoxColumn,
            this.pernombreDataGridViewTextBoxColumn,
            this.perapellidoDataGridViewTextBoxColumn,
            this.peredadDataGridViewTextBoxColumn,
            this.perrutDataGridViewTextBoxColumn,
            this.perdvDataGridViewTextBoxColumn,
            this.perfechaNacimientoDataGridViewTextBoxColumn});
            this.DGPersona.DataSource = this.personaBS;
            this.DGPersona.Location = new System.Drawing.Point(13, 64);
            this.DGPersona.Name = "DGPersona";
            this.DGPersona.Size = new System.Drawing.Size(769, 231);
            this.DGPersona.TabIndex = 2;
            this.DGPersona.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGPersona_RowsAdded);
            // 
            // peridPersonaDataGridViewTextBoxColumn
            // 
            this.peridPersonaDataGridViewTextBoxColumn.DataPropertyName = "per_idPersona";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.peridPersonaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.peridPersonaDataGridViewTextBoxColumn.HeaderText = "ID";
            this.peridPersonaDataGridViewTextBoxColumn.Name = "peridPersonaDataGridViewTextBoxColumn";
            this.peridPersonaDataGridViewTextBoxColumn.ReadOnly = true;
            this.peridPersonaDataGridViewTextBoxColumn.ToolTipText = "Auto incrementable";
            // 
            // pernombreDataGridViewTextBoxColumn
            // 
            this.pernombreDataGridViewTextBoxColumn.DataPropertyName = "per_nombre";
            dataGridViewCellStyle2.NullValue = "<Vacio>";
            this.pernombreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.pernombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.pernombreDataGridViewTextBoxColumn.MaxInputLength = 60;
            this.pernombreDataGridViewTextBoxColumn.Name = "pernombreDataGridViewTextBoxColumn";
            this.pernombreDataGridViewTextBoxColumn.ToolTipText = "Primer | Segundo | Tercer Nombre";
            // 
            // perapellidoDataGridViewTextBoxColumn
            // 
            this.perapellidoDataGridViewTextBoxColumn.DataPropertyName = "per_apellido";
            dataGridViewCellStyle3.NullValue = "<Vacio>";
            this.perapellidoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.perapellidoDataGridViewTextBoxColumn.HeaderText = "Apellidos";
            this.perapellidoDataGridViewTextBoxColumn.MaxInputLength = 60;
            this.perapellidoDataGridViewTextBoxColumn.Name = "perapellidoDataGridViewTextBoxColumn";
            this.perapellidoDataGridViewTextBoxColumn.ToolTipText = "Ingresar apellido paterno y materno";
            // 
            // peredadDataGridViewTextBoxColumn
            // 
            this.peredadDataGridViewTextBoxColumn.DataPropertyName = "per_edad";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = "18";
            this.peredadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.peredadDataGridViewTextBoxColumn.HeaderText = "Edad";
            this.peredadDataGridViewTextBoxColumn.MaxInputLength = 3;
            this.peredadDataGridViewTextBoxColumn.Name = "peredadDataGridViewTextBoxColumn";
            this.peredadDataGridViewTextBoxColumn.ToolTipText = "La edad minima es 18 y la maxima 70";
            // 
            // perrutDataGridViewTextBoxColumn
            // 
            this.perrutDataGridViewTextBoxColumn.DataPropertyName = "per_rut";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.perrutDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.perrutDataGridViewTextBoxColumn.HeaderText = "Rut";
            this.perrutDataGridViewTextBoxColumn.MaxInputLength = 8;
            this.perrutDataGridViewTextBoxColumn.Name = "perrutDataGridViewTextBoxColumn";
            this.perrutDataGridViewTextBoxColumn.ToolTipText = "Identificador Numerico  Ej: 1234678";
            // 
            // perdvDataGridViewTextBoxColumn
            // 
            this.perdvDataGridViewTextBoxColumn.DataPropertyName = "per_dv";
            this.perdvDataGridViewTextBoxColumn.HeaderText = "Digito Verificador";
            this.perdvDataGridViewTextBoxColumn.MaxInputLength = 1;
            this.perdvDataGridViewTextBoxColumn.MinimumWidth = 110;
            this.perdvDataGridViewTextBoxColumn.Name = "perdvDataGridViewTextBoxColumn";
            this.perdvDataGridViewTextBoxColumn.ToolTipText = "0-9 o K";
            this.perdvDataGridViewTextBoxColumn.Width = 110;
            // 
            // perfechaNacimientoDataGridViewTextBoxColumn
            // 
            this.perfechaNacimientoDataGridViewTextBoxColumn.DataPropertyName = "per_fechaNacimiento";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = "01-01-1900";
            this.perfechaNacimientoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.perfechaNacimientoDataGridViewTextBoxColumn.HeaderText = "Fecha Nacimiento";
            this.perfechaNacimientoDataGridViewTextBoxColumn.MaxInputLength = 10;
            this.perfechaNacimientoDataGridViewTextBoxColumn.MinimumWidth = 110;
            this.perfechaNacimientoDataGridViewTextBoxColumn.Name = "perfechaNacimientoDataGridViewTextBoxColumn";
            this.perfechaNacimientoDataGridViewTextBoxColumn.ToolTipText = "DD-MM-YYYY";
            this.perfechaNacimientoDataGridViewTextBoxColumn.Width = 114;
            // 
            // personaBS
            // 
            this.personaBS.DataSource = typeof(TrainingCshar.Models.Persona);
            // 
            // lbStatus
            // 
            this.lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(285, 23);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(178, 20);
            this.lbStatus.TabIndex = 3;
            this.lbStatus.Text = "Gestion de datos locales";
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportToCsv.Location = new System.Drawing.Point(503, 23);
            this.btnExportToCsv.Name = "btnExportToCsv";
            this.btnExportToCsv.Size = new System.Drawing.Size(114, 27);
            this.btnExportToCsv.TabIndex = 4;
            this.btnExportToCsv.Text = "Guardar en CSV";
            this.btnExportToCsv.UseVisualStyleBackColor = true;
            this.btnExportToCsv.Click += new System.EventHandler(this.btnExportToCsv_Click);
            // 
            // btnLoadCSV
            // 
            this.btnLoadCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadCSV.Location = new System.Drawing.Point(156, 23);
            this.btnLoadCSV.Name = "btnLoadCSV";
            this.btnLoadCSV.Size = new System.Drawing.Size(114, 27);
            this.btnLoadCSV.TabIndex = 5;
            this.btnLoadCSV.Text = "Cargar CSV";
            this.btnLoadCSV.UseVisualStyleBackColor = true;
            this.btnLoadCSV.Click += new System.EventHandler(this.btnLoadCSV_Click);
            // 
            // FDataBaseTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 297);
            this.Controls.Add(this.btnLoadCSV);
            this.Controls.Add(this.btnExportToCsv);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.DGPersona);
            this.Controls.Add(this.btnLocalToDb);
            this.Controls.Add(this.btnLoadDb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(803, 336);
            this.Name = "FDataBaseTask";
            this.Text = "Funciones de Db";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FDataBaseTask_FormClosed);
            this.Load += new System.EventHandler(this.FDataBaseTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personaBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadDb;
        private System.Windows.Forms.Button btnLocalToDb;
        private System.Windows.Forms.DataGridView DGPersona;
        private System.Windows.Forms.DataGridViewTextBoxColumn peridPersonaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pernombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perapellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn peredadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perrutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perdvDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perfechaNacimientoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource personaBS;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnExportToCsv;
        private System.Windows.Forms.Button btnLoadCSV;
    }
}