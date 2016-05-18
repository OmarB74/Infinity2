<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehiculos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmVehiculos))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoVehiculo = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvVehiculos = New System.Windows.Forms.DataGridView()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPlaca = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvVehiculos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 29)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo Vehiculo"
        '
        'cboTipoVehiculo
        '
        Me.cboTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoVehiculo.FormattingEnabled = True
        Me.cboTipoVehiculo.Location = New System.Drawing.Point(148, 25)
        Me.cboTipoVehiculo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboTipoVehiculo.Name = "cboTipoVehiculo"
        Me.cboTipoVehiculo.Size = New System.Drawing.Size(220, 28)
        Me.cboTipoVehiculo.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvVehiculos)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 188)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(750, 272)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'dgvVehiculos
        '
        Me.dgvVehiculos.AllowUserToAddRows = False
        Me.dgvVehiculos.AllowUserToDeleteRows = False
        Me.dgvVehiculos.AllowUserToResizeRows = False
        Me.dgvVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVehiculos.Location = New System.Drawing.Point(16, 29)
        Me.dgvVehiculos.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvVehiculos.MultiSelect = False
        Me.dgvVehiculos.Name = "dgvVehiculos"
        Me.dgvVehiculos.ReadOnly = True
        Me.dgvVehiculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVehiculos.Size = New System.Drawing.Size(708, 231)
        Me.dgvVehiculos.TabIndex = 0
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(780, 29)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(140, 48)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(780, 86)
        Me.btnAgregar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(140, 48)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.Location = New System.Drawing.Point(780, 143)
        Me.btnBorrar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(140, 48)
        Me.btnBorrar.TabIndex = 5
        Me.btnBorrar.Text = "&Borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(780, 200)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(140, 48)
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 86)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Descripcion"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(148, 85)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(618, 26)
        Me.txtDescripcion.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 143)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Placa"
        '
        'txtPlaca
        '
        Me.txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlaca.Location = New System.Drawing.Point(148, 138)
        Me.txtPlaca.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPlaca.Name = "txtPlaca"
        Me.txtPlaca.Size = New System.Drawing.Size(220, 26)
        Me.txtPlaca.TabIndex = 10
        '
        'FrmVehiculos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 482)
        Me.Controls.Add(Me.txtPlaca)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboTipoVehiculo)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVehiculos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vehiculos"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvVehiculos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvVehiculos As System.Windows.Forms.DataGridView
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPlaca As System.Windows.Forms.TextBox
End Class
