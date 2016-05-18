<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPantalla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPantalla))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPantalla = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigoPantalla = New System.Windows.Forms.TextBox()
        Me.gbPantallas = New System.Windows.Forms.GroupBox()
        Me.dgvPantallas = New System.Windows.Forms.DataGridView()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.txtNombrePantalla = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboTipoPantalla = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLigaPantalla = New System.Windows.Forms.TextBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.gbPantallas.SuspendLayout()
        CType(Me.dgvPantallas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 112)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pantalla"
        '
        'txtPantalla
        '
        Me.txtPantalla.Location = New System.Drawing.Point(128, 108)
        Me.txtPantalla.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtPantalla.MaxLength = 7
        Me.txtPantalla.Name = "txtPantalla"
        Me.txtPantalla.Size = New System.Drawing.Size(180, 26)
        Me.txtPantalla.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 29)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Modulo"
        '
        'txtCodigoPantalla
        '
        Me.txtCodigoPantalla.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoPantalla.Location = New System.Drawing.Point(128, 25)
        Me.txtCodigoPantalla.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCodigoPantalla.MaxLength = 2
        Me.txtCodigoPantalla.Name = "txtCodigoPantalla"
        Me.txtCodigoPantalla.Size = New System.Drawing.Size(76, 26)
        Me.txtCodigoPantalla.TabIndex = 0
        '
        'gbPantallas
        '
        Me.gbPantallas.Controls.Add(Me.dgvPantallas)
        Me.gbPantallas.Location = New System.Drawing.Point(22, 248)
        Me.gbPantallas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbPantallas.Name = "gbPantallas"
        Me.gbPantallas.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.gbPantallas.Size = New System.Drawing.Size(884, 342)
        Me.gbPantallas.TabIndex = 4
        Me.gbPantallas.TabStop = False
        '
        'dgvPantallas
        '
        Me.dgvPantallas.AllowUserToAddRows = False
        Me.dgvPantallas.AllowUserToDeleteRows = False
        Me.dgvPantallas.AllowUserToResizeRows = False
        Me.dgvPantallas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPantallas.Location = New System.Drawing.Point(10, 29)
        Me.dgvPantallas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvPantallas.MultiSelect = False
        Me.dgvPantallas.Name = "dgvPantallas"
        Me.dgvPantallas.ReadOnly = True
        Me.dgvPantallas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPantallas.Size = New System.Drawing.Size(873, 303)
        Me.dgvPantallas.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(687, 68)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(156, 62)
        Me.btnGuardar.TabIndex = 6
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(687, 129)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(156, 62)
        Me.btnEliminar.TabIndex = 7
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(687, 6)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(156, 62)
        Me.btnNuevo.TabIndex = 5
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'txtNombrePantalla
        '
        Me.txtNombrePantalla.Location = New System.Drawing.Point(128, 68)
        Me.txtNombrePantalla.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtNombrePantalla.MaxLength = 40
        Me.txtNombrePantalla.Name = "txtNombrePantalla"
        Me.txtNombrePantalla.Size = New System.Drawing.Size(482, 26)
        Me.txtNombrePantalla.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 72)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 154)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Tipo Pantalla"
        '
        'cboTipoPantalla
        '
        Me.cboTipoPantalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoPantalla.FormattingEnabled = True
        Me.cboTipoPantalla.Items.AddRange(New Object() {"P", "R"})
        Me.cboTipoPantalla.Location = New System.Drawing.Point(128, 149)
        Me.cboTipoPantalla.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboTipoPantalla.Name = "cboTipoPantalla"
        Me.cboTipoPantalla.Size = New System.Drawing.Size(76, 28)
        Me.cboTipoPantalla.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 198)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Liga Pantalla"
        '
        'txtLigaPantalla
        '
        Me.txtLigaPantalla.Location = New System.Drawing.Point(128, 194)
        Me.txtLigaPantalla.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtLigaPantalla.MaxLength = 50
        Me.txtLigaPantalla.Name = "txtLigaPantalla"
        Me.txtLigaPantalla.Size = New System.Drawing.Size(482, 26)
        Me.txtLigaPantalla.TabIndex = 4
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(687, 191)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(156, 62)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'FrmPantalla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 592)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtLigaPantalla)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboTipoPantalla)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNombrePantalla)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.gbPantallas)
        Me.Controls.Add(Me.txtCodigoPantalla)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPantalla)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPantalla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pantalla"
        Me.gbPantallas.ResumeLayout(False)
        CType(Me.dgvPantallas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPantalla As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoPantalla As System.Windows.Forms.TextBox
    Friend WithEvents gbPantallas As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPantallas As System.Windows.Forms.DataGridView
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents txtNombrePantalla As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPantalla As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLigaPantalla As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
