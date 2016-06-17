<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBusquedaListaProductoPrecio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBusquedaListaProductoPrecio))
        Me.txtCodigoProducto = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.rbCodigoProducto = New System.Windows.Forms.RadioButton()
        Me.rbNombreproducto = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'txtCodigoProducto
        '
        Me.txtCodigoProducto.Location = New System.Drawing.Point(188, 23)
        Me.txtCodigoProducto.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.txtCodigoProducto.MaxLength = 10
        Me.txtCodigoProducto.Name = "txtCodigoProducto"
        Me.txtCodigoProducto.Size = New System.Drawing.Size(187, 26)
        Me.txtCodigoProducto.TabIndex = 14
        Me.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtProducto
        '
        Me.txtProducto.Enabled = False
        Me.txtProducto.Location = New System.Drawing.Point(188, 73)
        Me.txtProducto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtProducto.MaxLength = 100
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(336, 26)
        Me.txtProducto.TabIndex = 16
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(336, 142)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(127, 55)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(61, 142)
        Me.btnBuscar.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(127, 55)
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'rbCodigoProducto
        '
        Me.rbCodigoProducto.AutoSize = True
        Me.rbCodigoProducto.Checked = True
        Me.rbCodigoProducto.Location = New System.Drawing.Point(12, 24)
        Me.rbCodigoProducto.Name = "rbCodigoProducto"
        Me.rbCodigoProducto.Size = New System.Drawing.Size(145, 24)
        Me.rbCodigoProducto.TabIndex = 20
        Me.rbCodigoProducto.TabStop = True
        Me.rbCodigoProducto.Text = "Codigo Producto"
        Me.rbCodigoProducto.UseVisualStyleBackColor = True
        '
        'rbNombreproducto
        '
        Me.rbNombreproducto.AutoSize = True
        Me.rbNombreproducto.Location = New System.Drawing.Point(12, 75)
        Me.rbNombreproducto.Name = "rbNombreproducto"
        Me.rbNombreproducto.Size = New System.Drawing.Size(151, 24)
        Me.rbNombreproducto.TabIndex = 21
        Me.rbNombreproducto.Text = "Nombre Producto"
        Me.rbNombreproducto.UseVisualStyleBackColor = True
        '
        'FrmBusquedaListaProductoPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 211)
        Me.Controls.Add(Me.rbNombreproducto)
        Me.Controls.Add(Me.rbCodigoProducto)
        Me.Controls.Add(Me.txtCodigoProducto)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBusquedaListaProductoPrecio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCodigoProducto As TextBox
    Friend WithEvents txtProducto As TextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents rbCodigoProducto As RadioButton
    Friend WithEvents rbNombreproducto As RadioButton
End Class
