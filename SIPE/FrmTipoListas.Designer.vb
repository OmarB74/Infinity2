<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTipoListas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTipoListas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtListaId = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvListas = New System.Windows.Forms.DataGridView()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvListas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtListaId)
        Me.GroupBox1.Controls.Add(Me.txtDescripcion)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 3)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(592, 97)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtListaId
        '
        Me.txtListaId.Location = New System.Drawing.Point(150, 14)
        Me.txtListaId.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtListaId.Name = "txtListaId"
        Me.txtListaId.Size = New System.Drawing.Size(67, 26)
        Me.txtListaId.TabIndex = 3
        Me.txtListaId.Visible = False
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(147, 42)
        Me.txtDescripcion.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(416, 26)
        Me.txtDescripcion.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ListaId"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Descripción Lista"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvListas)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 104)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(585, 306)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Listas"
        '
        'dgvListas
        '
        Me.dgvListas.AllowUserToAddRows = False
        Me.dgvListas.AllowUserToDeleteRows = False
        Me.dgvListas.AllowUserToResizeRows = False
        Me.dgvListas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListas.Location = New System.Drawing.Point(14, 29)
        Me.dgvListas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvListas.Name = "dgvListas"
        Me.dgvListas.ReadOnly = True
        Me.dgvListas.Size = New System.Drawing.Size(555, 254)
        Me.dgvListas.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(638, 306)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(144, 74)
        Me.btnSalir.TabIndex = 12
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNuevo.Location = New System.Drawing.Point(638, 43)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(144, 74)
        Me.btnNuevo.TabIndex = 9
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnBorrar
        '
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.Location = New System.Drawing.Point(638, 218)
        Me.btnBorrar.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(144, 74)
        Me.btnBorrar.TabIndex = 11
        Me.btnBorrar.Text = "&Borrar"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(638, 131)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(144, 74)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'FrmTipoListas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 416)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTipoListas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo Listas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvListas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtListaId As TextBox
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvListas As DataGridView
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnBorrar As Button
    Friend WithEvents btnGuardar As Button
End Class
