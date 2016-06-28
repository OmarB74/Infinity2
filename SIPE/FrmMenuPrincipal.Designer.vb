<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMenuPrincipal
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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Caja", 3, 3)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reportes", 5, 5)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proveedor", 1, 1)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cliente", 13, 13)
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Productos", 2, 2)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Importacion Precios", 25, 25)
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Tipo Listas", 17, 17)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lista Producto Precio", 24, 24)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Producto Sucursal", 16, 16)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Catalogos", 15, 15, New System.Windows.Forms.TreeNode() {TreeNode3, TreeNode4, TreeNode5, TreeNode6, TreeNode7, TreeNode8, TreeNode9})
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Liberar Almacen", 18, 18)
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Dispersion", 20, 20)
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Actualizacion Masiva Precios Esencias")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Administracion", 19, 19, New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode13})
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Mermas", 21, 21)
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Produccion", 22, 22, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode10, TreeNode11, TreeNode14, TreeNode15})
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Usuario", 6, 6)
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pantallas", 7, 7)
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Perfil", 8, 8)
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Permisos", 9, 9)
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Empresa", 10, 10)
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Colonias", 14, 14)
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sucursales", 23, 23)
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Seguridad", 11, 11, New System.Windows.Forms.TreeNode() {TreeNode17, TreeNode18, TreeNode19, TreeNode20, TreeNode21, TreeNode22, TreeNode23})
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Salir", 12, 12)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMenuPrincipal))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblUsuario = New System.Windows.Forms.Label()
        Me.LblFechaSistema = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblSucursal = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(18, 8)
        Me.TreeView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.ImageIndex = 3
        TreeNode1.Name = "NodoCaja"
        TreeNode1.SelectedImageIndex = 3
        TreeNode1.Text = "Caja"
        TreeNode2.ImageIndex = 5
        TreeNode2.Name = "NodoReportes"
        TreeNode2.SelectedImageIndex = 5
        TreeNode2.Text = "Reportes"
        TreeNode3.ImageIndex = 1
        TreeNode3.Name = "NodoProveedor"
        TreeNode3.SelectedImageIndex = 1
        TreeNode3.Text = "Proveedor"
        TreeNode4.ImageIndex = 13
        TreeNode4.Name = "NodoCliente"
        TreeNode4.SelectedImageIndex = 13
        TreeNode4.Text = "Cliente"
        TreeNode5.ImageIndex = 2
        TreeNode5.Name = "NodoProductos"
        TreeNode5.SelectedImageIndex = 2
        TreeNode5.Text = "Productos"
        TreeNode6.ImageIndex = 25
        TreeNode6.Name = "NodoImporta"
        TreeNode6.SelectedImageIndex = 25
        TreeNode6.Text = "Importacion Precios"
        TreeNode7.ImageIndex = 17
        TreeNode7.Name = "NodoTipoListas"
        TreeNode7.SelectedImageIndex = 17
        TreeNode7.Text = "Tipo Listas"
        TreeNode8.ImageIndex = 24
        TreeNode8.Name = "NodoListaProductoPrecio"
        TreeNode8.SelectedImageIndex = 24
        TreeNode8.Text = "Lista Producto Precio"
        TreeNode9.ImageIndex = 16
        TreeNode9.Name = "NodoProductoSucursal"
        TreeNode9.SelectedImageIndex = 16
        TreeNode9.Text = "Producto Sucursal"
        TreeNode10.ImageIndex = 15
        TreeNode10.Name = "NodoCatalogos"
        TreeNode10.SelectedImageIndex = 15
        TreeNode10.Text = "Catalogos"
        TreeNode11.ImageIndex = 18
        TreeNode11.Name = "NodoLiberaProductoSucursal"
        TreeNode11.SelectedImageIndex = 18
        TreeNode11.Text = "Liberar Almacen"
        TreeNode12.ImageIndex = 20
        TreeNode12.Name = "NodoDispersion"
        TreeNode12.SelectedImageIndex = 20
        TreeNode12.Text = "Dispersion"
        TreeNode13.Name = "NodoActualizacionMasivaPreciosEsencias"
        TreeNode13.Text = "Actualizacion Masiva Precios Esencias"
        TreeNode14.ImageIndex = 19
        TreeNode14.Name = "NodoAdministracion"
        TreeNode14.SelectedImageIndex = 19
        TreeNode14.Text = "Administracion"
        TreeNode15.ImageIndex = 21
        TreeNode15.Name = "NodoMermas"
        TreeNode15.SelectedImageIndex = 21
        TreeNode15.Text = "Mermas"
        TreeNode16.ImageIndex = 22
        TreeNode16.Name = "NodoProduccion"
        TreeNode16.SelectedImageIndex = 22
        TreeNode16.Text = "Produccion"
        TreeNode17.ImageIndex = 6
        TreeNode17.Name = "NodoUsuario"
        TreeNode17.SelectedImageIndex = 6
        TreeNode17.Text = "Usuario"
        TreeNode18.ImageIndex = 7
        TreeNode18.Name = "NodoPantallas"
        TreeNode18.SelectedImageIndex = 7
        TreeNode18.Text = "Pantallas"
        TreeNode19.ImageIndex = 8
        TreeNode19.Name = "NodoPerfil"
        TreeNode19.SelectedImageIndex = 8
        TreeNode19.Text = "Perfil"
        TreeNode20.ImageIndex = 9
        TreeNode20.Name = "NodoPermisos"
        TreeNode20.SelectedImageIndex = 9
        TreeNode20.Text = "Permisos"
        TreeNode21.ImageIndex = 10
        TreeNode21.Name = "NodoEmpresa"
        TreeNode21.SelectedImageIndex = 10
        TreeNode21.Text = "Empresa"
        TreeNode22.ImageIndex = 14
        TreeNode22.Name = "NodoColonia"
        TreeNode22.SelectedImageIndex = 14
        TreeNode22.Text = "Colonias"
        TreeNode23.ImageIndex = 23
        TreeNode23.Name = "NodoSucursales"
        TreeNode23.SelectedImageIndex = 23
        TreeNode23.Text = "Sucursales"
        TreeNode24.ImageIndex = 11
        TreeNode24.Name = "NodoSeguridad"
        TreeNode24.SelectedImageIndex = 11
        TreeNode24.Text = "Seguridad"
        TreeNode25.ImageIndex = 12
        TreeNode25.Name = "NodoSalir"
        TreeNode25.SelectedImageIndex = 12
        TreeNode25.Text = "Salir"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode16, TreeNode24, TreeNode25})
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(295, 361)
        Me.TreeView1.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Acomet.ico")
        Me.ImageList1.Images.SetKeyName(1, "Clientes.ico")
        Me.ImageList1.Images.SetKeyName(2, "Caja.ico")
        Me.ImageList1.Images.SetKeyName(3, "Caja.png")
        Me.ImageList1.Images.SetKeyName(4, "Scale.png")
        Me.ImageList1.Images.SetKeyName(5, "Reportes.png")
        Me.ImageList1.Images.SetKeyName(6, "Usuarios.png")
        Me.ImageList1.Images.SetKeyName(7, "Monitor.png")
        Me.ImageList1.Images.SetKeyName(8, "Perfil.png")
        Me.ImageList1.Images.SetKeyName(9, "Permisos.png")
        Me.ImageList1.Images.SetKeyName(10, "city-building-icon.png")
        Me.ImageList1.Images.SetKeyName(11, "pc_security_2.png")
        Me.ImageList1.Images.SetKeyName(12, "Cancelar.ico")
        Me.ImageList1.Images.SetKeyName(13, "cliente-icono-8749-32.png")
        Me.ImageList1.Images.SetKeyName(14, "building.png")
        Me.ImageList1.Images.SetKeyName(15, "Catalogos.png")
        Me.ImageList1.Images.SetKeyName(16, "ProductoSucursal.png")
        Me.ImageList1.Images.SetKeyName(17, "TipoListas.png")
        Me.ImageList1.Images.SetKeyName(18, "LiberarAlmacen.png")
        Me.ImageList1.Images.SetKeyName(19, "administracion.png")
        Me.ImageList1.Images.SetKeyName(20, "dispersion.png")
        Me.ImageList1.Images.SetKeyName(21, "Perdida.png")
        Me.ImageList1.Images.SetKeyName(22, "infinityLogo1.png")
        Me.ImageList1.Images.SetKeyName(23, "store.png")
        Me.ImageList1.Images.SetKeyName(24, "listaPrecioProductos.png")
        Me.ImageList1.Images.SetKeyName(25, "ImportacionPrecios.png")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 375)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 414)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha:"
        '
        'LblUsuario
        '
        Me.LblUsuario.AutoSize = True
        Me.LblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUsuario.Location = New System.Drawing.Point(84, 375)
        Me.LblUsuario.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblUsuario.Name = "LblUsuario"
        Me.LblUsuario.Size = New System.Drawing.Size(82, 13)
        Me.LblUsuario.TabIndex = 3
        Me.LblUsuario.Text = "omar.bolanos"
        '
        'LblFechaSistema
        '
        Me.LblFechaSistema.AutoSize = True
        Me.LblFechaSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFechaSistema.Location = New System.Drawing.Point(84, 414)
        Me.LblFechaSistema.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblFechaSistema.Name = "LblFechaSistema"
        Me.LblFechaSistema.Size = New System.Drawing.Size(75, 13)
        Me.LblFechaSistema.TabIndex = 4
        Me.LblFechaSistema.Text = "25/02/2015"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 455)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Sucursal:"
        '
        'LblSucursal
        '
        Me.LblSucursal.AutoSize = True
        Me.LblSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSucursal.Location = New System.Drawing.Point(84, 455)
        Me.LblSucursal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblSucursal.Name = "LblSucursal"
        Me.LblSucursal.Size = New System.Drawing.Size(54, 13)
        Me.LblSucursal.TabIndex = 6
        Me.LblSucursal.Text = "MATRIZ"
        '
        'FrmMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 552)
        Me.Controls.Add(Me.LblSucursal)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblFechaSistema)
        Me.Controls.Add(Me.LblUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TreeView1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "FrmMenuPrincipal"
        Me.Text = "Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblUsuario As System.Windows.Forms.Label
    Friend WithEvents LblFechaSistema As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Label3 As Label
    Friend WithEvents LblSucursal As Label
End Class
