Namespace TrainingCshar.Formulaio
    Friend Partial Class FStart
        Private components As ComponentModel.IContainer = Nothing

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Dim resources As ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FStart))
            btnEjecutar = New System.Windows.Forms.Button()
            txtResultado = New System.Windows.Forms.TextBox()
            cmbAcciones = New System.Windows.Forms.ComboBox()
            Me.SuspendLayout()
            btnEjecutar.Enabled = False
            btnEjecutar.Location = New System.Drawing.Point(186, 12)
            btnEjecutar.Name = "btnEjecutar"
            btnEjecutar.Size = New System.Drawing.Size(139, 23)
            btnEjecutar.TabIndex = 0
            btnEjecutar.Text = "Ejecutar: None"
            btnEjecutar.TextAlign = Drawing.ContentAlignment.MiddleLeft
            btnEjecutar.UseVisualStyleBackColor = True
            AddHandler btnEjecutar.Click, New System.EventHandler(AddressOf Me.BtnEjecutar_Click)
            txtResultado.Anchor = ((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right))
            txtResultado.Cursor = Windows.Forms.Cursors.Cross
            txtResultado.Location = New System.Drawing.Point(13, 41)
            txtResultado.Multiline = True
            txtResultado.Name = "txtResult"
            txtResultado.[ReadOnly] = True
            txtResultado.Size = New System.Drawing.Size(312, 206)
            txtResultado.TabIndex = 4
            cmbAcciones.AutoCompleteMode = Windows.Forms.AutoCompleteMode.SuggestAppend
            cmbAcciones.FormattingEnabled = True
            cmbAcciones.Location = New System.Drawing.Point(13, 13)
            cmbAcciones.Name = "cmbAccion"
            cmbAcciones.Size = New System.Drawing.Size(167, 21)
            cmbAcciones.TabIndex = 5
            AddHandler cmbAcciones.SelectedIndexChanged, New System.EventHandler(AddressOf Me.CmbAccion_SelectedIndexChanged)
            AddHandler cmbAcciones.TextChanged, New System.EventHandler(AddressOf Me.CmbAcciones_TextChanged)
            AddHandler cmbAcciones.Click, New System.EventHandler(AddressOf Me.CmbAccion_Click)
            AddHandler cmbAcciones.PreviewKeyDown, New System.Windows.Forms.PreviewKeyDownEventHandler(AddressOf Me.CmbAccion_PreviewKeyDown)
            AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New System.Drawing.Size(337, 250)
            Me.Controls.Add(Me.cmbAcciones)
            Me.Controls.Add(Me.txtResultado)
            Me.Controls.Add(Me.btnEjecutar)
            Icon = CType((resources.GetObject("$this.Icon")), System.Drawing.Icon)
            MinimumSize = New System.Drawing.Size(353, 289)
            Name = "FStart"
            Text = "Metodos Disponibles"
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Private btnEjecutar As Windows.Forms.Button
        Private txtResultado As Windows.Forms.TextBox
        Private cmbAcciones As Windows.Forms.ComboBox
    End Class
End Namespace
