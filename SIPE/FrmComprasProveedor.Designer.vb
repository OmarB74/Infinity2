<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComprasProveedor
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
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbFechas = New System.Windows.Forms.RadioButton()
        Me.rbCapturistas = New System.Windows.Forms.RadioButton()
        Me.rbProveedor = New System.Windows.Forms.RadioButton()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.cboCapturistasBascula = New System.Windows.Forms.ComboBox()
        Me.cboProveedores = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(856, 57)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(180, 62)
        Me.btnGenerar.TabIndex = 0
        Me.btnGenerar.Text = "&Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(856, 169)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(180, 62)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboProveedores)
        Me.GroupBox1.Controls.Add(Me.cboCapturistasBascula)
        Me.GroupBox1.Controls.Add(Me.dtpFechaFinal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFechaInicial)
        Me.GroupBox1.Controls.Add(Me.rbProveedor)
        Me.GroupBox1.Controls.Add(Me.rbCapturistas)
        Me.GroupBox1.Controls.Add(Me.rbFechas)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 18)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(796, 243)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Condiciones"
        '
        'rbFechas
        '
        Me.rbFechas.AutoSize = True
        Me.rbFechas.Checked = True
        Me.rbFechas.Location = New System.Drawing.Point(30, 57)
        Me.rbFechas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbFechas.Name = "rbFechas"
        Me.rbFechas.Size = New System.Drawing.Size(80, 24)
        Me.rbFechas.TabIndex = 0
        Me.rbFechas.TabStop = True
        Me.rbFechas.Text = "Fechas"
        Me.rbFechas.UseVisualStyleBackColor = True
        '
        'rbCapturistas
        '
        Me.rbCapturistas.AutoSize = True
        Me.rbCapturistas.Location = New System.Drawing.Point(30, 112)
        Me.rbCapturistas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbCapturistas.Name = "rbCapturistas"
        Me.rbCapturistas.Size = New System.Drawing.Size(100, 24)
        Me.rbCapturistas.TabIndex = 1
        Me.rbCapturistas.Text = "Capturista"
        Me.rbCapturistas.UseVisualStyleBackColor = True
        '
        'rbProveedor
        '
        Me.rbProveedor.AutoSize = True
        Me.rbProveedor.Location = New System.Drawing.Point(30, 169)
        Me.rbProveedor.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbProveedor.Name = "rbProveedor"
        Me.rbProveedor.Size = New System.Drawing.Size(99, 24)
        Me.rbProveedor.TabIndex = 2
        Me.rbProveedor.Text = "Proveedor"
        Me.rbProveedor.UseVisualStyleBackColor = True
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicial.Location = New System.Drawing.Point(344, 52)
        Me.dtpFechaInicial.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(132, 26)
        Me.dtpFechaInicial.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(234, 60)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Fecha Inicial"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(536, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fecha Final"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(638, 52)
        Me.dtpFechaFinal.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(133, 26)
        Me.dtpFechaFinal.TabIndex = 6
        '
        'cboCapturistasBascula
        '
        Me.cboCapturistasBascula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCapturistasBascula.FormattingEnabled = True
        Me.cboCapturistasBascula.Location = New System.Drawing.Point(238, 106)
        Me.cboCapturistasBascula.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboCapturistasBascula.Name = "cboCapturistasBascula"
        Me.cboCapturistasBascula.Size = New System.Drawing.Size(530, 28)
        Me.cboCapturistasBascula.TabIndex = 7
        '
        'cboProveedores
        '
        Me.cboProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedores.FormattingEnabled = True
        Me.cboProveedores.Location = New System.Drawing.Point(238, 168)
        Me.cboProveedores.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboProveedores.Name = "cboProveedores"
        Me.cboProveedores.Size = New System.Drawing.Size(530, 28)
        Me.cboProveedores.TabIndex = 8
        '
        'FrmComprasProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 283)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGenerar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmComprasProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compras Proveedor"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboProveedores As System.Windows.Forms.ComboBox
    Friend WithEvents cboCapturistasBascula As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents rbProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents rbCapturistas As System.Windows.Forms.RadioButton
    Friend WithEvents rbFechas As System.Windows.Forms.RadioButton
End Class
