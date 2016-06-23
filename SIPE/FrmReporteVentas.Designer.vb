<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporteVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReporteVentas))
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbGeneral = New System.Windows.Forms.RadioButton()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.rbFechas = New System.Windows.Forms.RadioButton()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGenerar
        '
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = CType(resources.GetObject("btnGenerar.Image"), System.Drawing.Image)
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.Location = New System.Drawing.Point(898, 25)
        Me.btnGenerar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(154, 54)
        Me.btnGenerar.TabIndex = 5
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboSucursal)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.rbFechas)
        Me.GroupBox1.Controls.Add(Me.rbGeneral)
        Me.GroupBox1.Location = New System.Drawing.Point(-1, 2)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(868, 92)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Opciones"
        '
        'rbGeneral
        '
        Me.rbGeneral.AutoSize = True
        Me.rbGeneral.Location = New System.Drawing.Point(21, 38)
        Me.rbGeneral.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbGeneral.Name = "rbGeneral"
        Me.rbGeneral.Size = New System.Drawing.Size(84, 24)
        Me.rbGeneral.TabIndex = 0
        Me.rbGeneral.Text = "General"
        Me.rbGeneral.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 126)
        Me.CrystalReportViewer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1908, 919)
        Me.CrystalReportViewer1.TabIndex = 3
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'rbFechas
        '
        Me.rbFechas.AutoSize = True
        Me.rbFechas.Checked = True
        Me.rbFechas.Location = New System.Drawing.Point(172, 38)
        Me.rbFechas.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rbFechas.Name = "rbFechas"
        Me.rbFechas.Size = New System.Drawing.Size(72, 24)
        Me.rbFechas.TabIndex = 1
        Me.rbFechas.TabStop = True
        Me.rbFechas.Text = "Fecha"
        Me.rbFechas.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(251, 35)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(121, 26)
        Me.dtpFecha.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(423, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sucursal"
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(500, 36)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(238, 28)
        Me.cboSucursal.TabIndex = 5
        '
        'FrmReporteVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1908, 1045)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmReporteVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Ventas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents rbFechas As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cboSucursal As ComboBox
End Class
