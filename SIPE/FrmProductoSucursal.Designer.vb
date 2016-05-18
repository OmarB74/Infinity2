<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductoSucursal
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
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboUnidad = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.cboSucursal = New System.Windows.Forms.ComboBox()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(674, 82)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(128, 52)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Ingresar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(674, 148)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(128, 52)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboUnidad)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCantidad)
        Me.GroupBox1.Controls.Add(Me.cboSucursal)
        Me.GroupBox1.Controls.Add(Me.cboProducto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 18)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(610, 185)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cboUnidad
        '
        Me.cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidad.FormattingEnabled = True
        Me.cboUnidad.Location = New System.Drawing.Point(340, 135)
        Me.cboUnidad.Name = "cboUnidad"
        Me.cboUnidad.Size = New System.Drawing.Size(130, 28)
        Me.cboUnidad.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(272, 138)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 20)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Medida"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(141, 135)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(92, 26)
        Me.txtCantidad.TabIndex = 5
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboSucursal
        '
        Me.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSucursal.FormattingEnabled = True
        Me.cboSucursal.Location = New System.Drawing.Point(141, 80)
        Me.cboSucursal.Name = "cboSucursal"
        Me.cboSucursal.Size = New System.Drawing.Size(238, 28)
        Me.cboSucursal.TabIndex = 4
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.FormattingEnabled = True
        Me.cboProducto.Location = New System.Drawing.Point(141, 31)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(238, 28)
        Me.cboProducto.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 138)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cantidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 80)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sucursal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Producto"
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(674, 20)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(128, 52)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "&Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'FrmProductoSucursal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 213)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProductoSucursal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Producto Sucursal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAceptar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboUnidad As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents cboSucursal As ComboBox
    Friend WithEvents cboProducto As ComboBox
    Friend WithEvents btnNuevo As Button
End Class
