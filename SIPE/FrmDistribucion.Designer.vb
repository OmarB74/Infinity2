<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDistribucion
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.btnRemoveDoc = New System.Windows.Forms.Button()
        Me.btnAddDocto = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbTotalDisponibles = New System.Windows.Forms.Label()
        Me.LbAgregadas = New System.Windows.Forms.Label()
        Me.BtnGenerar = New System.Windows.Forms.Button()
        Me.dgvNotasDisponibles = New System.Windows.Forms.DataGridView()
        Me.dgvNotasAgregadas = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvNotasDisponibles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNotasAgregadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboSucursal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(706, 69)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(457, 26)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(117, 26)
        Me.dtpFecha.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(384, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Fecha"
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(108, 22)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(238, 28)
        Me.cboSucursal.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 25)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Sucursal"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(593, 17)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(97, 37)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(415, 73)
        Me.Label83.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(133, 20)
        Me.Label83.TabIndex = 132
        Me.Label83.Text = "Notas Agregadas"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(15, 73)
        Me.Label81.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(137, 20)
        Me.Label81.TabIndex = 131
        Me.Label81.Text = "Notas Disponibles"
        '
        'btnRemoveDoc
        '
        Me.btnRemoveDoc.Location = New System.Drawing.Point(320, 224)
        Me.btnRemoveDoc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnRemoveDoc.Name = "btnRemoveDoc"
        Me.btnRemoveDoc.Size = New System.Drawing.Size(86, 35)
        Me.btnRemoveDoc.TabIndex = 135
        Me.btnRemoveDoc.Text = "<"
        Me.btnRemoveDoc.UseVisualStyleBackColor = True
        '
        'btnAddDocto
        '
        Me.btnAddDocto.Location = New System.Drawing.Point(320, 141)
        Me.btnAddDocto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddDocto.Name = "btnAddDocto"
        Me.btnAddDocto.Size = New System.Drawing.Size(86, 35)
        Me.btnAddDocto.TabIndex = 134
        Me.btnAddDocto.Text = ">"
        Me.btnAddDocto.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 392)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 20)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = "Total"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(415, 392)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 20)
        Me.Label4.TabIndex = 138
        Me.Label4.Text = "Total"
        '
        'lbTotalDisponibles
        '
        Me.lbTotalDisponibles.AutoSize = True
        Me.lbTotalDisponibles.Location = New System.Drawing.Point(218, 392)
        Me.lbTotalDisponibles.Name = "lbTotalDisponibles"
        Me.lbTotalDisponibles.Size = New System.Drawing.Size(57, 20)
        Me.lbTotalDisponibles.TabIndex = 139
        Me.lbTotalDisponibles.Text = "Label5"
        '
        'LbAgregadas
        '
        Me.LbAgregadas.AutoSize = True
        Me.LbAgregadas.Location = New System.Drawing.Point(636, 392)
        Me.LbAgregadas.Name = "LbAgregadas"
        Me.LbAgregadas.Size = New System.Drawing.Size(57, 20)
        Me.LbAgregadas.TabIndex = 140
        Me.LbAgregadas.Text = "Label5"
        '
        'BtnGenerar
        '
        Me.BtnGenerar.Location = New System.Drawing.Point(309, 446)
        Me.BtnGenerar.Name = "BtnGenerar"
        Me.BtnGenerar.Size = New System.Drawing.Size(97, 37)
        Me.BtnGenerar.TabIndex = 141
        Me.BtnGenerar.Text = "&Generar"
        Me.BtnGenerar.UseVisualStyleBackColor = True
        '
        'dgvNotasDisponibles
        '
        Me.dgvNotasDisponibles.AllowUserToAddRows = False
        Me.dgvNotasDisponibles.AllowUserToDeleteRows = False
        Me.dgvNotasDisponibles.AllowUserToResizeRows = False
        Me.dgvNotasDisponibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvNotasDisponibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNotasDisponibles.Location = New System.Drawing.Point(12, 96)
        Me.dgvNotasDisponibles.Name = "dgvNotasDisponibles"
        Me.dgvNotasDisponibles.ReadOnly = True
        Me.dgvNotasDisponibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNotasDisponibles.Size = New System.Drawing.Size(294, 293)
        Me.dgvNotasDisponibles.TabIndex = 142
        '
        'dgvNotasAgregadas
        '
        Me.dgvNotasAgregadas.AllowUserToAddRows = False
        Me.dgvNotasAgregadas.AllowUserToDeleteRows = False
        Me.dgvNotasAgregadas.AllowUserToResizeRows = False
        Me.dgvNotasAgregadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvNotasAgregadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNotasAgregadas.Location = New System.Drawing.Point(418, 96)
        Me.dgvNotasAgregadas.Name = "dgvNotasAgregadas"
        Me.dgvNotasAgregadas.ReadOnly = True
        Me.dgvNotasAgregadas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNotasAgregadas.Size = New System.Drawing.Size(294, 293)
        Me.dgvNotasAgregadas.TabIndex = 143
        '
        'FrmDistribucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 533)
        Me.Controls.Add(Me.dgvNotasAgregadas)
        Me.Controls.Add(Me.dgvNotasDisponibles)
        Me.Controls.Add(Me.BtnGenerar)
        Me.Controls.Add(Me.LbAgregadas)
        Me.Controls.Add(Me.lbTotalDisponibles)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label83)
        Me.Controls.Add(Me.Label81)
        Me.Controls.Add(Me.btnRemoveDoc)
        Me.Controls.Add(Me.btnAddDocto)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDistribucion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Distribucion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvNotasDisponibles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNotasAgregadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents btnRemoveDoc As System.Windows.Forms.Button
    Friend WithEvents btnAddDocto As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbTotalDisponibles As System.Windows.Forms.Label
    Friend WithEvents LbAgregadas As System.Windows.Forms.Label
    Friend WithEvents BtnGenerar As System.Windows.Forms.Button
    Friend WithEvents dgvNotasDisponibles As System.Windows.Forms.DataGridView
    Friend WithEvents dgvNotasAgregadas As System.Windows.Forms.DataGridView
End Class
