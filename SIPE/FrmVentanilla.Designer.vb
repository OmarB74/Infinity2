<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVentanilla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVentanilla))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvVentanilla = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtVendedor = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtAtajos = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCodigoBarras = New System.Windows.Forms.TextBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvVentanilla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvVentanilla)
        Me.GroupBox1.Location = New System.Drawing.Point(275, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(755, 390)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dgvVentanilla
        '
        Me.dgvVentanilla.AllowUserToAddRows = False
        Me.dgvVentanilla.AllowUserToDeleteRows = False
        Me.dgvVentanilla.AllowUserToResizeRows = False
        Me.dgvVentanilla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvVentanilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVentanilla.Location = New System.Drawing.Point(7, 22)
        Me.dgvVentanilla.Name = "dgvVentanilla"
        Me.dgvVentanilla.ReadOnly = True
        Me.dgvVentanilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVentanilla.Size = New System.Drawing.Size(739, 347)
        Me.dgvVentanilla.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtVendedor)
        Me.GroupBox2.Controls.Add(Me.txtCliente)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(270, 128)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtVendedor
        '
        Me.txtVendedor.Location = New System.Drawing.Point(7, 69)
        Me.txtVendedor.Name = "txtVendedor"
        Me.txtVendedor.ReadOnly = True
        Me.txtVendedor.Size = New System.Drawing.Size(256, 26)
        Me.txtVendedor.TabIndex = 3
        Me.txtVendedor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(7, 15)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(256, 26)
        Me.txtCliente.TabIndex = 2
        Me.txtCliente.Text = "PUBLICO EN GENERAL"
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(107, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vendedor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(119, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtAtajos)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 144)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(269, 248)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Atajos"
        '
        'txtAtajos
        '
        Me.txtAtajos.Location = New System.Drawing.Point(6, 25)
        Me.txtAtajos.Multiline = True
        Me.txtAtajos.Name = "txtAtajos"
        Me.txtAtajos.Size = New System.Drawing.Size(256, 202)
        Me.txtAtajos.TabIndex = 0
        Me.txtAtajos.Text = "<F2> Buscar Producto" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<F3> Buscar Cliente" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<F4> Limpiar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<F5> Guardar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(73, 404)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Clave del producto"
        '
        'txtCodigoBarras
        '
        Me.txtCodigoBarras.Location = New System.Drawing.Point(15, 427)
        Me.txtCodigoBarras.MaxLength = 50
        Me.txtCodigoBarras.Name = "txtCodigoBarras"
        Me.txtCodigoBarras.Size = New System.Drawing.Size(257, 26)
        Me.txtCodigoBarras.TabIndex = 4
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(276, 427)
        Me.txtCantidad.MaxLength = 10
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(121, 26)
        Me.txtCantidad.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(300, 404)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Cantidad"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(485, 421)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(209, 37)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "TOTAL M.N."
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Black
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTotal.Location = New System.Drawing.Point(700, 414)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(198, 44)
        Me.txtTotal.TabIndex = 8
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(399, 423)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(83, 35)
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.Text = " B&uscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(905, 410)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(111, 48)
        Me.btnGuardar.TabIndex = 18
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'FrmVentanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 485)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.txtCodigoBarras)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVentanilla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Caja"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvVentanilla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvVentanilla As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtVendedor As TextBox
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtAtajos As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCodigoBarras As TextBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents btnGuardar As Button
End Class
