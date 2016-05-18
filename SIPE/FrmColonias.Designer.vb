<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmColonias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmColonias))
        Me.cboMunicipio = New System.Windows.Forms.ComboBox()
        Me.cboEstado = New System.Windows.Forms.ComboBox()
        Me.cboPais = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtColonia = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCP = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboMunicipio
        '
        Me.cboMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipio.FormattingEnabled = True
        Me.cboMunicipio.Location = New System.Drawing.Point(140, 117)
        Me.cboMunicipio.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.Size = New System.Drawing.Size(376, 28)
        Me.cboMunicipio.TabIndex = 10
        '
        'cboEstado
        '
        Me.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEstado.FormattingEnabled = True
        Me.cboEstado.Location = New System.Drawing.Point(140, 69)
        Me.cboEstado.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.Size = New System.Drawing.Size(322, 28)
        Me.cboEstado.TabIndex = 9
        '
        'cboPais
        '
        Me.cboPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPais.Enabled = False
        Me.cboPais.FormattingEnabled = True
        Me.cboPais.Location = New System.Drawing.Point(140, 22)
        Me.cboPais.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.cboPais.Name = "cboPais"
        Me.cboPais.Size = New System.Drawing.Size(296, 28)
        Me.cboPais.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 122)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 20)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Municipio"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 74)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 20)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Estado"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 26)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 20)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Pais"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 171)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 20)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Colonia"
        '
        'txtColonia
        '
        Me.txtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtColonia.Location = New System.Drawing.Point(140, 165)
        Me.txtColonia.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.txtColonia.MaxLength = 250
        Me.txtColonia.Name = "txtColonia"
        Me.txtColonia.Size = New System.Drawing.Size(376, 26)
        Me.txtColonia.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 212)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 20)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "C.P."
        '
        'txtCP
        '
        Me.txtCP.Location = New System.Drawing.Point(140, 208)
        Me.txtCP.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.txtCP.MaxLength = 5
        Me.txtCP.Name = "txtCP"
        Me.txtCP.Size = New System.Drawing.Size(162, 26)
        Me.txtCP.TabIndex = 30
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(93, 266)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(179, 61)
        Me.btnGuardar.TabIndex = 31
        Me.btnGuardar.Text = "&Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(370, 266)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(179, 61)
        Me.btnSalir.TabIndex = 32
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.INFINITY.My.Resources.Resources.BuscarGrande
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(528, 151)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(136, 49)
        Me.btnBuscar.TabIndex = 33
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'FrmColonias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 343)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.txtCP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtColonia)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboMunicipio)
        Me.Controls.Add(Me.cboEstado)
        Me.Controls.Add(Me.cboPais)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmColonias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Colonias"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents cboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cboPais As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtColonia As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCP As System.Windows.Forms.TextBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
End Class
