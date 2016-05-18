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
        Me.txtCodigodeBarras = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'txtCodigodeBarras
        '
        Me.txtCodigodeBarras.Location = New System.Drawing.Point(165, 19)
        Me.txtCodigodeBarras.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.txtCodigodeBarras.MaxLength = 10
        Me.txtCodigodeBarras.Name = "txtCodigodeBarras"
        Me.txtCodigodeBarras.Size = New System.Drawing.Size(187, 26)
        Me.txtCodigodeBarras.TabIndex = 14
        Me.txtCodigodeBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 22)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 20)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Codigo de Barras"
        '
        'txtProducto
        '
        Me.txtProducto.Location = New System.Drawing.Point(165, 73)
        Me.txtProducto.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtProducto.MaxLength = 100
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(359, 26)
        Me.txtProducto.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 77)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Producto"
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
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(21, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(503, 53)
        Me.Panel1.TabIndex = 20
        Me.Panel1.Visible = False
        '
        'FrmBusquedaListaProductoPrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 211)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtCodigodeBarras)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtProducto)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Label1)
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

    Friend WithEvents txtCodigodeBarras As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtProducto As TextBox
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
