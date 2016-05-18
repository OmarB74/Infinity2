<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmListaProductoPrecio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmListaProductoPrecio))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.txtIdentificadorId = New System.Windows.Forms.TextBox()
        Me.cboListaPrecios = New System.Windows.Forms.ComboBox()
        Me.cboPeso = New System.Windows.Forms.ComboBox()
        Me.cboMedida = New System.Windows.Forms.ComboBox()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.txtCodigoBarras = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboTipoRelleno = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboTipoRelleno)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtPrecio)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Controls.Add(Me.btnBorrar)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.txtIdentificadorId)
        Me.GroupBox1.Controls.Add(Me.cboListaPrecios)
        Me.GroupBox1.Controls.Add(Me.cboPeso)
        Me.GroupBox1.Controls.Add(Me.cboMedida)
        Me.GroupBox1.Controls.Add(Me.cboProducto)
        Me.GroupBox1.Controls.Add(Me.txtCodigoBarras)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 6)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(709, 339)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtPrecio
        '
        Me.txtPrecio.Location = New System.Drawing.Point(152, 78)
        Me.txtPrecio.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPrecio.MaxLength = 12
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.Size = New System.Drawing.Size(132, 26)
        Me.txtPrecio.TabIndex = 18
        Me.txtPrecio.Text = "0.00"
        Me.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 78)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Precio"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(438, 38)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(83, 35)
        Me.btnBuscar.TabIndex = 16
        Me.btnBuscar.Text = " B&uscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(540, 192)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(152, 48)
        Me.btnSalir.TabIndex = 15
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(540, 21)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(152, 48)
        Me.btnNuevo.TabIndex = 12
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.Location = New System.Drawing.Point(540, 135)
        Me.btnBorrar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(152, 48)
        Me.btnBorrar.TabIndex = 14
        Me.btnBorrar.Text = "&Borrar"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(540, 78)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(152, 48)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'txtIdentificadorId
        '
        Me.txtIdentificadorId.Location = New System.Drawing.Point(152, 12)
        Me.txtIdentificadorId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtIdentificadorId.MaxLength = 12
        Me.txtIdentificadorId.Name = "txtIdentificadorId"
        Me.txtIdentificadorId.ReadOnly = True
        Me.txtIdentificadorId.Size = New System.Drawing.Size(229, 26)
        Me.txtIdentificadorId.TabIndex = 11
        Me.txtIdentificadorId.Visible = False
        '
        'cboListaPrecios
        '
        Me.cboListaPrecios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboListaPrecios.FormattingEnabled = True
        Me.cboListaPrecios.Location = New System.Drawing.Point(152, 246)
        Me.cboListaPrecios.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboListaPrecios.Name = "cboListaPrecios"
        Me.cboListaPrecios.Size = New System.Drawing.Size(271, 28)
        Me.cboListaPrecios.TabIndex = 10
        '
        'cboPeso
        '
        Me.cboPeso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPeso.FormattingEnabled = True
        Me.cboPeso.Location = New System.Drawing.Point(152, 205)
        Me.cboPeso.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPeso.Name = "cboPeso"
        Me.cboPeso.Size = New System.Drawing.Size(271, 28)
        Me.cboPeso.TabIndex = 9
        '
        'cboMedida
        '
        Me.cboMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMedida.FormattingEnabled = True
        Me.cboMedida.Location = New System.Drawing.Point(152, 163)
        Me.cboMedida.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboMedida.Name = "cboMedida"
        Me.cboMedida.Size = New System.Drawing.Size(271, 28)
        Me.cboMedida.TabIndex = 8
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.FormattingEnabled = True
        Me.cboProducto.Location = New System.Drawing.Point(152, 121)
        Me.cboProducto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(271, 28)
        Me.cboProducto.TabIndex = 7
        '
        'txtCodigoBarras
        '
        Me.txtCodigoBarras.Location = New System.Drawing.Point(152, 40)
        Me.txtCodigoBarras.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCodigoBarras.MaxLength = 12
        Me.txtCodigoBarras.Name = "txtCodigoBarras"
        Me.txtCodigoBarras.ReadOnly = True
        Me.txtCodigoBarras.Size = New System.Drawing.Size(229, 26)
        Me.txtCodigoBarras.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 249)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Lista Precios"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 208)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 20)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Peso"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 166)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Medida"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 124)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Producto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Codigo de Barras"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 15)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IdentificadorId"
        Me.Label1.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 290)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 20)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Relleno"
        '
        'cboTipoRelleno
        '
        Me.cboTipoRelleno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoRelleno.FormattingEnabled = True
        Me.cboTipoRelleno.Location = New System.Drawing.Point(152, 287)
        Me.cboTipoRelleno.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboTipoRelleno.Name = "cboTipoRelleno"
        Me.cboTipoRelleno.Size = New System.Drawing.Size(271, 28)
        Me.cboTipoRelleno.TabIndex = 20
        '
        'FrmListaProductoPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 359)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmListaProductoPrecio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista Producto Precio"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboListaPrecios As ComboBox
    Friend WithEvents cboPeso As ComboBox
    Friend WithEvents cboMedida As ComboBox
    Friend WithEvents cboProducto As ComboBox
    Friend WithEvents txtCodigoBarras As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtIdentificadorId As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnBorrar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents txtPrecio As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboTipoRelleno As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
