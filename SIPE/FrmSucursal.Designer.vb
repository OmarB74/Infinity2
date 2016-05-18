<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSucursal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSucursal))
        Dim SucursalId As System.Windows.Forms.Label
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
        Me.txtRazonSocial = New System.Windows.Forms.TextBox()
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
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.TxtSucursalId = New System.Windows.Forms.TextBox()
        SucursalId = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtSucursalId)
        Me.GroupBox1.Controls.Add(SucursalId)
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
        Me.GroupBox1.Controls.Add(Me.txtRazonSocial)
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
        Me.GroupBox1.Location = New System.Drawing.Point(13, 14)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(951, 298)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(526, 245)
        Me.txtemail.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(336, 26)
        Me.txtemail.TabIndex = 11
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(273, 245)
        Me.txtFax.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(242, 26)
        Me.txtFax.TabIndex = 10
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(22, 245)
        Me.txtTelefono.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(240, 26)
        Me.txtTelefono.TabIndex = 9
        '
        'txtNuminterior
        '
        Me.txtNuminterior.Location = New System.Drawing.Point(621, 177)
        Me.txtNuminterior.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNuminterior.Name = "txtNuminterior"
        Me.txtNuminterior.Size = New System.Drawing.Size(166, 26)
        Me.txtNuminterior.TabIndex = 7
        '
        'txtNumExterior
        '
        Me.txtNumExterior.Location = New System.Drawing.Point(450, 177)
        Me.txtNumExterior.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNumExterior.Name = "txtNumExterior"
        Me.txtNumExterior.Size = New System.Drawing.Size(160, 26)
        Me.txtNumExterior.TabIndex = 6
        '
        'txtCalle
        '
        Me.txtCalle.Location = New System.Drawing.Point(22, 177)
        Me.txtCalle.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCalle.Name = "txtCalle"
        Me.txtCalle.Size = New System.Drawing.Size(415, 26)
        Me.txtCalle.TabIndex = 5
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(795, 177)
        Me.txtCP.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(109, 26)
        Me.txtCP.TabIndex = 8
        '
        'cboColonia
        '
        Me.cboColonia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboColonia.FormattingEnabled = True
        Me.cboColonia.Location = New System.Drawing.Point(728, 91)
        Me.cboColonia.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboColonia.Name = "cboColonia"
        Me.cboColonia.Size = New System.Drawing.Size(199, 28)
        Me.cboColonia.TabIndex = 4
        '
        'cboMunicipio
        '
        Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipio.FormattingEnabled = True
        Me.cboMunicipio.Location = New System.Drawing.Point(465, 91)
        Me.cboMunicipio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.Size = New System.Drawing.Size(252, 28)
        Me.cboMunicipio.TabIndex = 3
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(238, 91)
        Me.cboEstado.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(199, 28)
        Me.cboEstado.TabIndex = 2
        '
        'cboPais
        '
        Me.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPais.Enabled = False
        Me.cboPais.FormattingEnabled = True
        Me.cboPais.Location = New System.Drawing.Point(22, 91)
        Me.cboPais.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPais.Name = "cboPais"
        Me.cboPais.Size = New System.Drawing.Size(199, 28)
        Me.cboPais.TabIndex = 1
        '
        'txtRazonSocial
        '
        Me.txtRazonSocial.Location = New System.Drawing.Point(146, 20)
        Me.txtRazonSocial.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtRazonSocial.Name = "txtRazonSocial"
        Me.txtRazonSocial.Size = New System.Drawing.Size(781, 26)
        Me.txtRazonSocial.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(549, 220)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 20)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Correo Electronico"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(308, 220)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 20)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Fax"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(32, 220)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 20)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Telefono"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(726, 66)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Colonia"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(477, 66)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 20)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Municipio"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(234, 66)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 20)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Estado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(32, 66)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Pais"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(824, 153)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "C.P."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(642, 153)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Numero Interior"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(460, 153)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Numero Exterior"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 153)
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
        Me.Label1.Size = New System.Drawing.Size(65, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(773, 322)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(165, 71)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.Location = New System.Drawing.Point(393, 322)
        Me.btnBorrar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(165, 71)
        Me.btnBorrar.TabIndex = 1
        Me.btnBorrar.Text = "&Borrar"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(203, 322)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(165, 71)
        Me.btnGuardar.TabIndex = 0
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(583, 322)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(165, 71)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(13, 322)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(165, 71)
        Me.btnNuevo.TabIndex = 4
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'TxtSucursalId
        '
        Me.TxtSucursalId.BackColor = System.Drawing.SystemColors.Window
        Me.TxtSucursalId.Location = New System.Drawing.Point(238, 130)
        Me.TxtSucursalId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TxtSucursalId.Name = "TxtSucursalId"
        Me.TxtSucursalId.ReadOnly = True
        Me.TxtSucursalId.Size = New System.Drawing.Size(124, 26)
        Me.TxtSucursalId.TabIndex = 12
        Me.TxtSucursalId.Visible = False
        '
        'SucursalId
        '
        SucursalId.AutoSize = True
        SucursalId.Location = New System.Drawing.Point(145, 133)
        SucursalId.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        SucursalId.Name = "SucursalId"
        SucursalId.Size = New System.Drawing.Size(85, 20)
        SucursalId.TabIndex = 13
        SucursalId.Text = "SucursalId"
        SucursalId.Visible = False
        '
        'FrmSucursal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 406)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmSucursal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sucursal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtemail As TextBox
    Friend WithEvents txtFax As TextBox
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents txtNuminterior As TextBox
    Friend WithEvents txtNumExterior As TextBox
    Friend WithEvents txtCalle As TextBox
    Friend WithEvents txtCP As TextBox
    Friend WithEvents cboColonia As ComboBox
    Friend WithEvents cboMunicipio As ComboBox
    Friend WithEvents cboEstado As ComboBox
    Friend WithEvents cboPais As ComboBox
    Friend WithEvents txtRazonSocial As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnBorrar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents TxtSucursalId As TextBox
End Class
