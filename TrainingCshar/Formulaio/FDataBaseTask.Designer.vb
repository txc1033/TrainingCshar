Namespace TrainingCshar.Formulaio
    Friend Partial Class FDataBaseTask
        Private components As ComponentModel.IContainer = Nothing

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
            Dim dataGridViewCellStyle1 As Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle2 As Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle3 As Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle4 As Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle5 As Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim dataGridViewCellStyle6 As Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FDataBaseTask))
            btnLoadDb = New System.Windows.Forms.Button()
            btnLocalToDb = New System.Windows.Forms.Button()
            DGPersona = New System.Windows.Forms.DataGridView()
            peridPersonaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            pernombreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            perapellidoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            peredadDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            perrutDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            perdvDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            perfechaNacimientoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            personaBS = New System.Windows.Forms.BindingSource(Me.components)
            lbStatus = New System.Windows.Forms.Label()
            btnExportToCsv = New System.Windows.Forms.Button()
            btnLoadCSV = New System.Windows.Forms.Button()
            CType((Me.DGPersona), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.personaBS), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            btnLoadDb.Location = New System.Drawing.Point(13, 23)
            btnLoadDb.Name = "btnLoadDb"
            btnLoadDb.Size = New System.Drawing.Size(118, 27)
            btnLoadDb.TabIndex = 0
            btnLoadDb.Text = "Cargar Data de la DB"
            btnLoadDb.UseVisualStyleBackColor = True
            AddHandler btnLoadDb.Click, New System.EventHandler(AddressOf Me.btnLoadDb_Click)
            btnLocalToDb.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right))
            btnLocalToDb.Location = New System.Drawing.Point(661, 23)
            btnLocalToDb.Name = "btnLocalToDb"
            btnLocalToDb.Size = New System.Drawing.Size(114, 27)
            btnLocalToDb.TabIndex = 1
            btnLocalToDb.Text = "Exportar Local a DB"
            btnLocalToDb.UseVisualStyleBackColor = True
            AddHandler btnLocalToDb.Click, New System.EventHandler(AddressOf Me.btnLocalToDb_Click)
            DGPersona.AllowUserToOrderColumns = True
            DGPersona.Anchor = ((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right))
            DGPersona.ColumnHeadersHeightSizeMode = Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DGPersona.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.peridPersonaDataGridViewTextBoxColumn, Me.pernombreDataGridViewTextBoxColumn, Me.perapellidoDataGridViewTextBoxColumn, Me.peredadDataGridViewTextBoxColumn, Me.perrutDataGridViewTextBoxColumn, Me.perdvDataGridViewTextBoxColumn, Me.perfechaNacimientoDataGridViewTextBoxColumn})
            DGPersona.Location = New System.Drawing.Point(13, 64)
            DGPersona.Name = "DGPersona"
            DGPersona.Size = New System.Drawing.Size(769, 231)
            DGPersona.TabIndex = 2
            AddHandler DGPersona.RowsAdded, New System.Windows.Forms.DataGridViewRowsAddedEventHandler(AddressOf Me.DGPersona_RowsAdded)
            peridPersonaDataGridViewTextBoxColumn.DataPropertyName = "per_idPersona"
            dataGridViewCellStyle1.Format = "N0"
            dataGridViewCellStyle1.NullValue = "0"
            peridPersonaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1
            peridPersonaDataGridViewTextBoxColumn.HeaderText = "ID"
            peridPersonaDataGridViewTextBoxColumn.Name = "peridPersonaDataGridViewTextBoxColumn"
            peridPersonaDataGridViewTextBoxColumn.[ReadOnly] = True
            peridPersonaDataGridViewTextBoxColumn.ToolTipText = "Auto incrementable"
            pernombreDataGridViewTextBoxColumn.DataPropertyName = "per_nombre"
            dataGridViewCellStyle2.NullValue = "<Vacio>"
            pernombreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2
            pernombreDataGridViewTextBoxColumn.HeaderText = "Nombre"
            pernombreDataGridViewTextBoxColumn.MaxInputLength = 60
            pernombreDataGridViewTextBoxColumn.Name = "pernombreDataGridViewTextBoxColumn"
            pernombreDataGridViewTextBoxColumn.ToolTipText = "Primer | Segundo | Tercer Nombre"
            perapellidoDataGridViewTextBoxColumn.DataPropertyName = "per_apellido"
            dataGridViewCellStyle3.NullValue = "<Vacio>"
            perapellidoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3
            perapellidoDataGridViewTextBoxColumn.HeaderText = "Apellidos"
            perapellidoDataGridViewTextBoxColumn.MaxInputLength = 60
            perapellidoDataGridViewTextBoxColumn.Name = "perapellidoDataGridViewTextBoxColumn"
            perapellidoDataGridViewTextBoxColumn.ToolTipText = "Ingresar apellido paterno y materno"
            peredadDataGridViewTextBoxColumn.DataPropertyName = "per_edad"
            dataGridViewCellStyle4.Format = "N0"
            dataGridViewCellStyle4.NullValue = "18"
            peredadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4
            peredadDataGridViewTextBoxColumn.HeaderText = "Edad"
            peredadDataGridViewTextBoxColumn.MaxInputLength = 3
            peredadDataGridViewTextBoxColumn.Name = "peredadDataGridViewTextBoxColumn"
            peredadDataGridViewTextBoxColumn.ToolTipText = "La edad minima es 18 y la maxima 70"
            perrutDataGridViewTextBoxColumn.DataPropertyName = "per_rut"
            dataGridViewCellStyle5.Format = "N0"
            dataGridViewCellStyle5.NullValue = Nothing
            perrutDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5
            perrutDataGridViewTextBoxColumn.HeaderText = "Rut"
            perrutDataGridViewTextBoxColumn.MaxInputLength = 8
            perrutDataGridViewTextBoxColumn.Name = "perrutDataGridViewTextBoxColumn"
            perrutDataGridViewTextBoxColumn.ToolTipText = "Identificador Numerico  Ej: 1234678"
            perdvDataGridViewTextBoxColumn.DataPropertyName = "per_dv"
            perdvDataGridViewTextBoxColumn.HeaderText = "Digito Verificador"
            perdvDataGridViewTextBoxColumn.MaxInputLength = 1
            perdvDataGridViewTextBoxColumn.MinimumWidth = 110
            perdvDataGridViewTextBoxColumn.Name = "perdvDataGridViewTextBoxColumn"
            perdvDataGridViewTextBoxColumn.ToolTipText = "0-9 o K"
            perdvDataGridViewTextBoxColumn.Width = 110
            perfechaNacimientoDataGridViewTextBoxColumn.DataPropertyName = "per_fechaNacimiento"
            dataGridViewCellStyle6.Format = "d"
            dataGridViewCellStyle6.NullValue = "01-01-1900"
            perfechaNacimientoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6
            perfechaNacimientoDataGridViewTextBoxColumn.HeaderText = "Fecha Nacimiento"
            perfechaNacimientoDataGridViewTextBoxColumn.MaxInputLength = 10
            perfechaNacimientoDataGridViewTextBoxColumn.MinimumWidth = 110
            perfechaNacimientoDataGridViewTextBoxColumn.Name = "perfechaNacimientoDataGridViewTextBoxColumn"
            perfechaNacimientoDataGridViewTextBoxColumn.ToolTipText = "DD-MM-YYYY"
            perfechaNacimientoDataGridViewTextBoxColumn.Width = 114
            personaBS.DataSource = GetType(TrainingCshar.Models.Persona)
            lbStatus.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom))
            lbStatus.AutoSize = True
            lbStatus.Font = New System.Drawing.Font("Segoe UI", 11.25F, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline)), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, (CByte((0))))
            lbStatus.Location = New System.Drawing.Point(285, 23)
            lbStatus.Name = "lbStatus"
            lbStatus.Size = New System.Drawing.Size(178, 20)
            lbStatus.TabIndex = 3
            lbStatus.Text = "Gestion de datos locales"
            btnExportToCsv.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right))
            btnExportToCsv.Location = New System.Drawing.Point(503, 23)
            btnExportToCsv.Name = "btnExportToCsv"
            btnExportToCsv.Size = New System.Drawing.Size(114, 27)
            btnExportToCsv.TabIndex = 4
            btnExportToCsv.Text = "Guardar en CSV"
            btnExportToCsv.UseVisualStyleBackColor = True
            AddHandler btnExportToCsv.Click, New System.EventHandler(AddressOf Me.btnExportToCsv_Click)
            btnLoadCSV.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right))
            btnLoadCSV.Location = New System.Drawing.Point(156, 23)
            btnLoadCSV.Name = "btnLoadCSV"
            btnLoadCSV.Size = New System.Drawing.Size(114, 27)
            btnLoadCSV.TabIndex = 5
            btnLoadCSV.Text = "Cargar CSV"
            btnLoadCSV.UseVisualStyleBackColor = True
            AddHandler btnLoadCSV.Click, New System.EventHandler(AddressOf Me.btnLoadCSV_Click)
            AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New System.Drawing.Size(787, 297)
            Me.Controls.Add(Me.btnLoadCSV)
            Me.Controls.Add(Me.btnExportToCsv)
            Me.Controls.Add(Me.lbStatus)
            Me.Controls.Add(Me.DGPersona)
            Me.Controls.Add(Me.btnLocalToDb)
            Me.Controls.Add(Me.btnLoadDb)
            Icon = CType((resources.GetObject("$this.Icon")), System.Drawing.Icon)
            MinimumSize = New System.Drawing.Size(803, 336)
            Name = "FDataBaseTask"
            Text = "Funciones de Db"
            AddHandler FormClosed, New System.Windows.Forms.FormClosedEventHandler(AddressOf Me.FDataBaseTask_FormClosed)
            AddHandler Load, New System.EventHandler(AddressOf Me.FDataBaseTask_Load)
            CType((Me.DGPersona), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.personaBS), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Private btnLoadDb As Windows.Forms.Button
        Private btnLocalToDb As Windows.Forms.Button
        Private DGPersona As Windows.Forms.DataGridView
        Private peridPersonaDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Private pernombreDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Private perapellidoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Private peredadDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Private perrutDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Private perdvDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Private perfechaNacimientoDataGridViewTextBoxColumn As Windows.Forms.DataGridViewTextBoxColumn
        Private personaBS As Windows.Forms.BindingSource
        Private lbStatus As Windows.Forms.Label
        Private btnExportToCsv As Windows.Forms.Button
        Private btnLoadCSV As Windows.Forms.Button
    End Class
End Namespace
