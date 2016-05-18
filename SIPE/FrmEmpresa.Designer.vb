<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmpresa
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmpresa))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.txtNuminterior = New System.Windows.Forms.TextBox()
        Me.txtNumExterior = New System.Windows.Forms.TextBox()
        Me.txtCalle = New System.Windows.Forms.TextBox()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.cboColonia = New System.Windows.Forms.ComboBox()
        Me.cboMunicipio = New System.Windows.Forms.ComboBox()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.cboPais = New System.Windows.Forms.ComboBox()
        Me.txtRFC = New System.Windows.Forms.TextBox()
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtemail)
        Me.GroupBox1.Controls.Add(Me.txtFax)
        Me.GroupBox1.Controls.Add(Me.txtTelefono)
        Me.GroupBox1.Controls.Add(Me.txtNuminterior)
        Me.GroupBox1.Controls.Add(Me.txtNumExterior)
        Me.GroupBox1.Controls.Add(Me.txtCalle)
        Me.GroupBox1.Controls.Add(Me.txtCP)
        Me.GroupBox1.Controls.Add(Me.cboColonia)
        Me.GroupBox1.Controls.Add(Me.cboMunicipio)
        Me.GroupBox1.Controls.Add(Me.cboEstado)
        Me.GroupBox1.Controls.Add(Me.cboPais)
        Me.GroupBox1.Controls.Add(Me.txtRFC)
        Me.GroupBox1.Controls.Add(Me.txtRazonSocial)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1076, 375)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(526, 314)
        Me.txtemail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(336, 26)
        Me.txtemail.TabIndex = 12
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(273, 314)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(242, 26)
        Me.txtFax.TabIndex = 11
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(22, 314)
        Me.txtTelefono.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(240, 26)
        Me.txtTelefono.TabIndex = 10
        '
        'txtNuminterior
        '
        Me.txtNuminterior.Location = New System.Drawing.Point(621, 246)
        Me.txtNuminterior.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNuminterior.Name = "txtNuminterior"
        Me.txtNuminterior.Size = New System.Drawing.Size(166, 26)
        Me.txtNuminterior.TabIndex = 9
        '
        'txtNumExterior
        '
        Me.txtNumExterior.Location = New System.Drawing.Point(450, 246)
        Me.txtNumExterior.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNumExterior.Name = "txtNumExterior"
        Me.txtNumExterior.Size = New System.Drawing.Size(160, 26)
        Me.txtNumExterior.TabIndex = 8
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(22, 246)
        Me.txtCalle.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(415, 26)
        Me.txtCalle.TabIndex = 7
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(956, 162)
        Me.txtCP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(109, 26)
        Me.txtCP.TabIndex = 6
        '
        'cboColonia
        '
        Me.cboColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColonia.FormattingEnabled = True
        Me.cboColonia.Location = New System.Drawing.Point(728, 160)
        Me.cboColonia.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboColonia.Name = "cboColonia"
        Me.cboColonia.Size = New System.Drawing.Size(199, 28)
        Me.cboColonia.TabIndex = 5
        '
        'cboMunicipio
        '
        Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipio.FormattingEnabled = True
        Me.cboMunicipio.Location = New System.Drawing.Point(465, 160)
        Me.cboMunicipio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.Size = New System.Drawing.Size(252, 28)
        Me.cboMunicipio.TabIndex = 4
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(238, 160)
        Me.cboEstado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(199, 28)
        Me.cboEstado.TabIndex = 3
        '
        'cboPais
        '
        Me.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPais.FormattingEnabled = True
        Me.cboPais.Location = New System.Drawing.Point(22, 160)
        Me.cboPais.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPais.Name = "cboPais"
        Me.cboPais.Size = New System.Drawing.Size(199, 28)
        Me.cboPais.TabIndex = 2
        '
        'txtRFC
        '
        Me.txtRFC.Location = New System.Drawing.Point(146, 72)
        Me.txtRFC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(266, 26)
        Me.txtRFC.TabIndex = 1
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Location = New System.Drawing.Point(146, 20)
        Me.txtRazonSocial.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(919, 26)
        Me.txtRazonSocial.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(32, 77)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 20)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "R.F.C."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(549, 289)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 20)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Correo Electronico"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(308, 289)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 20)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Fax"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 289)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 20)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Telefono"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(726, 135)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Colonia"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(477, 135)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 20)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Municipio"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(234, 135)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 20)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Estado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 135)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Pais"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(974, 135)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "C.P."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(642, 222)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Numero Interior"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(460, 222)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Numero Exterior"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 222)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Calle"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Razon Social"
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(206, 389)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(165, 71)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.Location = New System.Drawing.Point(465, 389)
        Me.btnBorrar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(165, 71)
        Me.btnBorrar.TabIndex = 1
        Me.btnBorrar.Text = "&Borrar"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(717, 389)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(165, 71)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'FrmEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1112, 474)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empresa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents txtNuminterior As System.Windows.Forms.TextBox
    Friend WithEvents txtNumExterior As System.Windows.Forms.TextBox
    Friend WithEvents txtCalle As System.Windows.Forms.TextBox
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents cboColonia As System.Windows.Forms.ComboBox
    Friend WithEvents cboMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cboPais As System.Windows.Forms.ComboBox
    Friend WithEvents txtRFC As System.Windows.Forms.TextBox
    Friend WithEvents txtRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
