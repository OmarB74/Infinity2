<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusqueda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusqueda))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.txtApellidosProveedor = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFolioProveedorCliente = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombres"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 99)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Apellidos"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(102, 151)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(136, 54)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(428, 151)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(136, 54)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(102, 50)
        Me.txtNombres.MaxLength = 100
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(547, 26)
        Me.txtNombres.TabIndex = 1
        '
        'txtApellidosProveedor
        '
        Me.txtApellidosProveedor.Location = New System.Drawing.Point(102, 96)
        Me.txtApellidosProveedor.Name = "txtApellidosProveedor"
        Me.txtApellidosProveedor.Size = New System.Drawing.Size(547, 26)
        Me.txtApellidosProveedor.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 17)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Folio"
        '
        'txtFolioProveedorCliente
        '
        Me.txtFolioProveedorCliente.Location = New System.Drawing.Point(102, 14)
        Me.txtFolioProveedorCliente.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtFolioProveedorCliente.MaxLength = 10
        Me.txtFolioProveedorCliente.Name = "txtFolioProveedorCliente"
        Me.txtFolioProveedorCliente.Size = New System.Drawing.Size(126, 26)
        Me.txtFolioProveedorCliente.TabIndex = 0
        Me.txtFolioProveedorCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmBusqueda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 212)
        Me.Controls.Add(Me.txtFolioProveedorCliente)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtApellidosProveedor)
        Me.Controls.Add(Me.txtNombres)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusqueda"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents txtApellidosProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFolioProveedorCliente As System.Windows.Forms.TextBox
End Class
