<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCajaPago
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.txtEfectivo = New System.Windows.Forms.TextBox()
        Me.txtCambio = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbSI = New System.Windows.Forms.RadioButton()
        Me.rbNO = New System.Windows.Forms.RadioButton()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.txtNeto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(135, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Importe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(135, 151)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Efectivo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(135, 190)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cambio"
        '
        'btnAceptar
        '
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Location = New System.Drawing.Point(281, 250)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(105, 54)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(17, 250)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(105, 54)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtImporte
        '
        Me.txtImporte.BackColor = System.Drawing.Color.Black
        Me.txtImporte.ForeColor = System.Drawing.Color.Green
        Me.txtImporte.Location = New System.Drawing.Point(238, 14)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.ReadOnly = True
        Me.txtImporte.Size = New System.Drawing.Size(148, 26)
        Me.txtImporte.TabIndex = 0
        Me.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEfectivo
        '
        Me.txtEfectivo.Location = New System.Drawing.Point(238, 148)
        Me.txtEfectivo.Name = "txtEfectivo"
        Me.txtEfectivo.Size = New System.Drawing.Size(148, 26)
        Me.txtEfectivo.TabIndex = 3
        Me.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCambio
        '
        Me.txtCambio.Location = New System.Drawing.Point(238, 187)
        Me.txtCambio.Name = "txtCambio"
        Me.txtCambio.ReadOnly = True
        Me.txtCambio.Size = New System.Drawing.Size(148, 26)
        Me.txtCambio.TabIndex = 4
        Me.txtCambio.Text = "0.00"
        Me.txtCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 56)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Descuento 10%"
        '
        'rbSI
        '
        Me.rbSI.AutoSize = True
        Me.rbSI.Location = New System.Drawing.Point(139, 54)
        Me.rbSI.Name = "rbSI"
        Me.rbSI.Size = New System.Drawing.Size(43, 24)
        Me.rbSI.TabIndex = 9
        Me.rbSI.Text = "SI"
        Me.rbSI.UseVisualStyleBackColor = True
        '
        'rbNO
        '
        Me.rbNO.AutoSize = True
        Me.rbNO.Checked = True
        Me.rbNO.Location = New System.Drawing.Point(188, 54)
        Me.rbNO.Name = "rbNO"
        Me.rbNO.Size = New System.Drawing.Size(50, 24)
        Me.rbNO.TabIndex = 10
        Me.rbNO.TabStop = True
        Me.rbNO.Text = "NO"
        Me.rbNO.UseVisualStyleBackColor = True
        '
        'txtDescuento
        '
        Me.txtDescuento.Location = New System.Drawing.Point(238, 53)
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(148, 26)
        Me.txtDescuento.TabIndex = 1
        Me.txtDescuento.Text = "0.00"
        Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNeto
        '
        Me.txtNeto.Location = New System.Drawing.Point(238, 109)
        Me.txtNeto.Name = "txtNeto"
        Me.txtNeto.ReadOnly = True
        Me.txtNeto.Size = New System.Drawing.Size(148, 26)
        Me.txtNeto.TabIndex = 2
        Me.txtNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(135, 112)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Neto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(208, 81)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(189, 20)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "____________________"
        '
        'FrmCajaPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 316)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNeto)
        Me.Controls.Add(Me.txtDescuento)
        Me.Controls.Add(Me.rbNO)
        Me.Controls.Add(Me.rbSI)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCambio)
        Me.Controls.Add(Me.txtEfectivo)
        Me.Controls.Add(Me.txtImporte)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCajaPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cobro"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents txtEfectivo As System.Windows.Forms.TextBox
    Friend WithEvents txtCambio As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rbSI As System.Windows.Forms.RadioButton
    Friend WithEvents rbNO As System.Windows.Forms.RadioButton
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents txtNeto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
