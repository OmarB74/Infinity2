<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPerfil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPerfil))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtDescripcionPerfil = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvPerfiles = New System.Windows.Forms.DataGridView()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPerfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 89)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descripcion"
        '
        'txtCodigo
        '
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Location = New System.Drawing.Point(142, 32)
        Me.txtCodigo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtCodigo.MaxLength = 2
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(72, 26)
        Me.txtCodigo.TabIndex = 2
        '
        'txtDescripcionPerfil
        '
        Me.txtDescripcionPerfil.Location = New System.Drawing.Point(142, 85)
        Me.txtDescripcionPerfil.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDescripcionPerfil.MaxLength = 50
        Me.txtDescripcionPerfil.Name = "txtDescripcionPerfil"
        Me.txtDescripcionPerfil.Size = New System.Drawing.Size(564, 26)
        Me.txtDescripcionPerfil.TabIndex = 3
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(195, 145)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(146, 49)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(369, 145)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(146, 49)
        Me.btnEliminar.TabIndex = 5
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvPerfiles)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 226)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(698, 248)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lista Perfiles"
        '
        'dgvPerfiles
        '
        Me.dgvPerfiles.AllowUserToAddRows = False
        Me.dgvPerfiles.AllowUserToDeleteRows = False
        Me.dgvPerfiles.AllowUserToResizeRows = False
        Me.dgvPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPerfiles.Location = New System.Drawing.Point(4, 31)
        Me.dgvPerfiles.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvPerfiles.MultiSelect = False
        Me.dgvPerfiles.Name = "dgvPerfiles"
        Me.dgvPerfiles.ReadOnly = True
        Me.dgvPerfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPerfiles.Size = New System.Drawing.Size(681, 195)
        Me.dgvPerfiles.TabIndex = 0
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(21, 145)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(146, 49)
        Me.btnNuevo.TabIndex = 7
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(543, 145)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(146, 49)
        Me.btnSalir.TabIndex = 8
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'FrmPerfil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 492)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtDescripcionPerfil)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPerfil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Perfil"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvPerfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcionPerfil As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvPerfiles As System.Windows.Forms.DataGridView
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
