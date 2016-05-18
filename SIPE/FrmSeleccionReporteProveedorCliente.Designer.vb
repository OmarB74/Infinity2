<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSeleccionReporteProveedorCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSeleccionReporteProveedorCliente))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboTipoProveedorCliente = New System.Windows.Forms.ComboBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.rbProveedor = New System.Windows.Forms.RadioButton()
        Me.rbCliente = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 52)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo"
        '
        'cboTipoProveedorCliente
        '
        Me.cboTipoProveedorCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoProveedorCliente.FormattingEnabled = True
        Me.cboTipoProveedorCliente.Items.AddRange(New Object() {"Persona Fisica", "Persona Moral"})
        Me.cboTipoProveedorCliente.Location = New System.Drawing.Point(86, 49)
        Me.cboTipoProveedorCliente.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboTipoProveedorCliente.Name = "cboTipoProveedorCliente"
        Me.cboTipoProveedorCliente.Size = New System.Drawing.Size(318, 28)
        Me.cboTipoProveedorCliente.TabIndex = 2
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(122, 102)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(202, 75)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'rbProveedor
        '
        Me.rbProveedor.AutoSize = True
        Me.rbProveedor.Checked = True
        Me.rbProveedor.Location = New System.Drawing.Point(131, 12)
        Me.rbProveedor.Name = "rbProveedor"
        Me.rbProveedor.Size = New System.Drawing.Size(99, 24)
        Me.rbProveedor.TabIndex = 0
        Me.rbProveedor.TabStop = True
        Me.rbProveedor.Text = "Proveedor"
        Me.rbProveedor.UseVisualStyleBackColor = True
        '
        'rbCliente
        '
        Me.rbCliente.AutoSize = True
        Me.rbCliente.Location = New System.Drawing.Point(251, 12)
        Me.rbCliente.Name = "rbCliente"
        Me.rbCliente.Size = New System.Drawing.Size(76, 24)
        Me.rbCliente.TabIndex = 1
        Me.rbCliente.Text = "Cliente"
        Me.rbCliente.UseVisualStyleBackColor = True
        '
        'FrmSeleccionReporteProveedorCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 195)
        Me.Controls.Add(Me.rbCliente)
        Me.Controls.Add(Me.rbProveedor)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.cboTipoProveedorCliente)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSeleccionReporteProveedorCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccion Proveedor Cliente"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoProveedorCliente As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents rbProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbCliente As System.Windows.Forms.RadioButton
End Class
