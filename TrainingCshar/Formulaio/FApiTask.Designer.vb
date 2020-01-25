Namespace TrainingCshar.Formulaio
    Friend Partial Class FApiTask
        Private components As ComponentModel.IContainer = Nothing

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Dim resources As ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FApiTask))
            cmbTypeEnv = New System.Windows.Forms.ComboBox()
            btnSend = New System.Windows.Forms.Button()
            btnToJson = New System.Windows.Forms.Button()
            btnToClass = New System.Windows.Forms.Button()
            chkTexto = New System.Windows.Forms.CheckBox()
            txtJson = New System.Windows.Forms.TextBox()
            tbcJson = New System.Windows.Forms.TabControl()
            tbJsonText = New System.Windows.Forms.TabPage()
            lbStatus = New System.Windows.Forms.Label()
            lbUrl = New System.Windows.Forms.Label()
            txtUrl = New System.Windows.Forms.TextBox()
            tbJsonClass = New System.Windows.Forms.TabPage()
            lbResponse = New System.Windows.Forms.Label()
            Me.tbcJson.SuspendLayout()
            Me.tbJsonText.SuspendLayout()
            Me.SuspendLayout()
            cmbTypeEnv.FormattingEnabled = True
            Me.cmbTypeEnv.Items.AddRange(New Object() {"Ninguno", "Get", "Put", "Post", "Delete"})
            cmbTypeEnv.Location = New System.Drawing.Point(6, 34)
            cmbTypeEnv.Name = "cmbTypeEnv"
            cmbTypeEnv.Size = New System.Drawing.Size(121, 21)
            cmbTypeEnv.TabIndex = 0
            AddHandler cmbTypeEnv.SelectedIndexChanged, New System.EventHandler(AddressOf Me.CmbTypeEnv_SelectedIndexChanged)
            btnSend.Enabled = False
            btnSend.Location = New System.Drawing.Point(133, 34)
            btnSend.Name = "btnSend"
            btnSend.Size = New System.Drawing.Size(75, 23)
            btnSend.TabIndex = 1
            btnSend.Text = "Enviar"
            btnSend.UseVisualStyleBackColor = True
            btnSend.Visible = False
            btnToJson.Enabled = False
            btnToJson.Location = New System.Drawing.Point(214, 34)
            btnToJson.Name = "btnToJson"
            btnToJson.Size = New System.Drawing.Size(75, 23)
            btnToJson.TabIndex = 2
            btnToJson.Text = "Serializa"
            btnToJson.UseVisualStyleBackColor = True
            btnToJson.Visible = False
            btnToClass.Enabled = False
            btnToClass.Location = New System.Drawing.Point(295, 34)
            btnToClass.Name = "btnToClass"
            btnToClass.Size = New System.Drawing.Size(75, 23)
            btnToClass.TabIndex = 3
            btnToClass.Text = "Deserializa"
            btnToClass.UseVisualStyleBackColor = True
            btnToClass.Visible = False
            chkTexto.AutoSize = True
            chkTexto.Location = New System.Drawing.Point(376, 36)
            chkTexto.Name = "chkTexto"
            chkTexto.Size = New System.Drawing.Size(97, 17)
            chkTexto.TabIndex = 4
            chkTexto.Text = "Preparar Json?"
            chkTexto.UseVisualStyleBackColor = True
            chkTexto.Visible = False
            AddHandler chkTexto.CheckedChanged, New System.EventHandler(AddressOf Me.ChkTexto_CheckedChanged)
            txtJson.Anchor = ((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right))
            txtJson.Location = New System.Drawing.Point(6, 65)
            txtJson.Multiline = True
            txtJson.Name = "txtJson"
            txtJson.[ReadOnly] = True
            txtJson.Size = New System.Drawing.Size(459, 130)
            txtJson.TabIndex = 5
            AddHandler txtJson.TextChanged, New System.EventHandler(AddressOf Me.TxtJson_TextChanged)
            tbcJson.Anchor = ((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right))
            Me.tbcJson.Controls.Add(Me.tbJsonText)
            Me.tbcJson.Controls.Add(Me.tbJsonClass)
            tbcJson.Location = New System.Drawing.Point(2, 84)
            tbcJson.Name = "tbcJson"
            tbcJson.SelectedIndex = 0
            tbcJson.Size = New System.Drawing.Size(481, 243)
            tbcJson.TabIndex = 6
            Me.tbJsonText.Controls.Add(Me.lbStatus)
            Me.tbJsonText.Controls.Add(Me.lbUrl)
            Me.tbJsonText.Controls.Add(Me.txtUrl)
            Me.tbJsonText.Controls.Add(Me.txtJson)
            tbJsonText.Location = New System.Drawing.Point(4, 22)
            tbJsonText.Name = "tbJsonText"
            tbJsonText.Padding = New System.Windows.Forms.Padding(3)
            tbJsonText.Size = New System.Drawing.Size(473, 217)
            tbJsonText.TabIndex = 0
            tbJsonText.Text = "Json retornado"
            tbJsonText.UseVisualStyleBackColor = True
            lbStatus.AutoSize = True
            lbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte((0))))
            lbStatus.Location = New System.Drawing.Point(7, 198)
            lbStatus.Name = "lbStatus"
            lbStatus.Size = New System.Drawing.Size(0, 13)
            lbStatus.TabIndex = 8
            lbUrl.AutoSize = True
            lbUrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte((0))))
            lbUrl.Location = New System.Drawing.Point(3, 24)
            lbUrl.Name = "lbUrl"
            lbUrl.Size = New System.Drawing.Size(102, 18)
            lbUrl.TabIndex = 7
            lbUrl.Text = "Ingresa la  Url:"
            txtUrl.Enabled = False
            txtUrl.Location = New System.Drawing.Point(114, 24)
            txtUrl.Name = "txtUrl"
            txtUrl.Size = New System.Drawing.Size(351, 20)
            txtUrl.TabIndex = 6
            AddHandler txtUrl.TextChanged, New System.EventHandler(AddressOf Me.TxtUrl_TextChanged)
            tbJsonClass.Location = New System.Drawing.Point(4, 22)
            tbJsonClass.Name = "tbJsonClass"
            tbJsonClass.Padding = New System.Windows.Forms.Padding(3)
            tbJsonClass.Size = New System.Drawing.Size(473, 217)
            tbJsonClass.TabIndex = 1
            tbJsonClass.Text = "Objeto Json"
            tbJsonClass.UseVisualStyleBackColor = True
            lbResponse.AutoSize = True
            lbResponse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte((0))))
            lbResponse.Location = New System.Drawing.Point(3, 15)
            lbResponse.Name = "lbResponse"
            lbResponse.Size = New System.Drawing.Size(124, 16)
            lbResponse.TabIndex = 7
            lbResponse.Text = "Metodo de envio"
            AddHandler lbResponse.Click, New System.EventHandler(AddressOf Me.LbResponse_Click)
            AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New System.Drawing.Size(483, 330)
            Me.Controls.Add(Me.lbResponse)
            Me.Controls.Add(Me.tbcJson)
            Me.Controls.Add(Me.chkTexto)
            Me.Controls.Add(Me.btnToClass)
            Me.Controls.Add(Me.btnToJson)
            Me.Controls.Add(Me.btnSend)
            Me.Controls.Add(Me.cmbTypeEnv)
            Icon = CType((resources.GetObject("$this.Icon")), System.Drawing.Icon)
            Name = "FApiTask"
            Text = "Gestion Json"
            Me.tbcJson.ResumeLayout(False)
            Me.tbJsonText.ResumeLayout(False)
            Me.tbJsonText.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

        Private cmbTypeEnv As Windows.Forms.ComboBox
        Private btnSend As Windows.Forms.Button
        Private btnToJson As Windows.Forms.Button
        Private btnToClass As Windows.Forms.Button
        Private chkTexto As Windows.Forms.CheckBox
        Private txtJson As Windows.Forms.TextBox
        Private tbcJson As Windows.Forms.TabControl
        Private tbJsonText As Windows.Forms.TabPage
        Private tbJsonClass As Windows.Forms.TabPage
        Private lbUrl As Windows.Forms.Label
        Private txtUrl As Windows.Forms.TextBox
        Private lbResponse As Windows.Forms.Label
        Private lbStatus As Windows.Forms.Label
    End Class
End Namespace
