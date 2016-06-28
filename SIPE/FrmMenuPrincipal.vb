Public Class FrmMenuPrincipal

    Private Sub TreeView1_KeyUp(sender As Object, e As KeyEventArgs) Handles TreeView1.KeyUp
        Select Case e.KeyCode
            Case Keys.Enter
                ' MsgBox("Presiono tecla Enter")
                If TreeView1.SelectedNode.Name.Equals("NodoUsuario") And bCerrarForma = False Then
                    If ValidaPerfil(iUsuario, "FrmUsuario") Then
                        Dim FrmUsuario As New FrmUsuario
                        FrmUsuario.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoPantallas") Then
                    If ValidaPerfil(iUsuario, "FrmPantalla") Then
                        Dim FrmPantalla As New FrmPantalla
                        FrmPantalla.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoPerfil") Then
                    If ValidaPerfil(iUsuario, "FrmPerfil") Then
                        Dim FrmPerfil As New FrmPerfil
                        FrmPerfil.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoPermisos") Then
                    If ValidaPerfil(iUsuario, "FrmPermisos") Then
                        Dim FrmPermisos As New FrmPermisos
                        FrmPermisos.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoEmpresa") Then
                    If ValidaPerfil(iUsuario, "FrmEmpresa") Then
                        Dim FrmEmpresa As New FrmEmpresa
                        FrmEmpresa.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoProveedor") Then
                    If ValidaPerfil(iUsuario, "FrmProveedor") Then
                        Dim FrmProveedor As New FrmProveedor
                        FrmProveedor.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoCliente") Then
                    If ValidaPerfil(iUsuario, "FrmCliente") Then
                        Dim FrmCliente As New FrmCliente
                        FrmCliente.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoProductos") Then
                    If ValidaPerfil(iUsuario, "FrmProductos") Then
                        Dim FrmProductos As New FrmProductos
                        FrmProductos.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                'If TreeView1.SelectedNode.Name.Equals("NodoPesaje") Then
                '    If ValidaPerfil(iUsuario, "FrmPesaje") Then
                '        Dim Frmoperacion As New frmPesaje
                '        Frmoperacion.ShowDialog()
                '    Else
                '        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                '    End If
                'End If
                If TreeView1.SelectedNode.Name.Equals("NodoReportes") Then
                    If ValidaPerfil(iUsuario, "FrmReportes") Then
                        Dim Frmreporte As New FrmReportes
                        Frmreporte.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoSalir") Then
                    Me.Close()
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoColonia") Then
                    If ValidaPerfil(iUsuario, "FrmColonias") Then
                        Dim Frmcolonias As New FrmColonias
                        Frmcolonias.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoSucursales") Then
                    If ValidaPerfil(iUsuario, "FrmSucursal") Then
                        Dim FrmSUCURSAL As New FrmSucursal
                        FrmSUCURSAL.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoTipoListas") Then
                    If ValidaPerfil(iUsuario, "FrmTipoListas") Then
                        Dim FrmTipoListas As New FrmTipoListas
                        FrmTipoListas.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoListaProductoPrecio") Then
                    If ValidaPerfil(iUsuario, "FrmListaProductoPrecio") Then
                        Dim FrmListaProductoPrecio As New FrmListaProductoPrecio
                        FrmListaProductoPrecio.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoCaja") Then
                    If ValidaPerfil(iUsuario, "FrmVentanilla") Then
                        Dim FrmVentanilla As New FrmVentanilla
                        FrmVentanilla.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoProductoSucursal") Then
                    If ValidaPerfil(iUsuario, "FrmProductoSucursal") Then
                        Dim FrmProductoSucursal As New FrmProductoSucursal
                        FrmProductoSucursal.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                If TreeView1.SelectedNode.Name.Equals("NodoLiberaProductoSucursal") Then
                    If ValidaPerfil(iUsuario, "FrmLiberaProductoSucursal") Then
                        Dim FrmLiberaProductoSucursal As New FrmLiberaProductoSucursal
                        FrmLiberaProductoSucursal.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                'FrmDistribucion
                If TreeView1.SelectedNode.Name.Equals("NodoDispersion") Then
                    If ValidaPerfil(iUsuario, "FrmDistribucion") Then
                        Dim FrmDistribucion As New FrmDistribucion
                        FrmDistribucion.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                'FrmMermas
                If TreeView1.SelectedNode.Name.Equals("NodoMermas") Then
                    If ValidaPerfil(iUsuario, "FrmMermas") Then
                        Dim FrmMermas As New FrmMermas
                        FrmMermas.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
                'FrmActualizacionMasivaPrecios
                If TreeView1.SelectedNode.Name.Equals("NodoActualizacionMasivaPreciosEsencias") Then
                    If ValidaPerfil(iUsuario, "FrmActualizacionMasivaPrecios") Then
                        Dim FrmActualizacionMasivaPrecios As New FrmActualizacionMasivaPrecios
                        FrmActualizacionMasivaPrecios.ShowDialog()
                    Else
                        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                    End If
                End If
            Case Keys.Up, Keys.Down
                bCerrarForma = False
        End Select
    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Node.Name.Equals("NodoUsuario") Then
            If ValidaPerfil(iUsuario, "FrmUsuario") Then
                Dim FrmUsuario As New FrmUsuario
                FrmUsuario.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoPantallas") Then
            If ValidaPerfil(iUsuario, "FrmPantalla") Then
                Dim FrmPantalla As New FrmPantalla
                FrmPantalla.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoPerfil") Then
            If ValidaPerfil(iUsuario, "FrmPerfil") Then
                Dim FrmPerfil As New FrmPerfil
                FrmPerfil.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoPermisos") Then
            If ValidaPerfil(iUsuario, "FrmPermisos") Then
                Dim FrmPermisos As New FrmPermisos
                FrmPermisos.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoEmpresa") Then
            If ValidaPerfil(iUsuario, "FrmEmpresa") Then
                Dim FrmEmpresa As New FrmEmpresa
                FrmEmpresa.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoProveedor") Then
            If ValidaPerfil(iUsuario, "FrmProveedor") Then
                Dim FrmProveedor As New FrmProveedor
                FrmProveedor.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoCliente") Then
            If ValidaPerfil(iUsuario, "FrmCliente") Then
                Dim FrmCliente As New FrmCliente
                FrmCliente.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoProductos") Then
            If ValidaPerfil(iUsuario, "FrmProductos") Then
                Dim FrmProductos As New FrmProductos
                FrmProductos.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        'If e.Node.Name.Equals("NodoPesaje") Then
        '    If ValidaPerfil(iUsuario, "FrmPesaje") Then
        '        Dim Frmoperacion As New frmPesaje
        '        Frmoperacion.ShowDialog()
        '    Else
        '        MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
        '    End If
        'End If
        If e.Node.Name.Equals("NodoReportes") Then
            If ValidaPerfil(iUsuario, "FrmReportes") Then
                Dim Frmreporte As New FrmReportes
                Frmreporte.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoColonia") Then
            If ValidaPerfil(iUsuario, "FrmColonias") Then
                Dim Frmcolonias As New FrmColonias
                Frmcolonias.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoImportar") Then
            If ValidaPerfil(iUsuario, "FrmImportarPrecios") Then
                Dim FrmImportar As New FrmImportarPrecios
                FrmImportar.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoSucursales") Then
            If ValidaPerfil(iUsuario, "FrmSucursal") Then
                Dim FrmSUCURSAL As New FrmSucursal
                FrmSUCURSAL.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoTipoListas") Then
            If ValidaPerfil(iUsuario, "FrmTipoListas") Then
                Dim FrmTipoListas As New FrmTipoListas
                FrmTipoListas.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoListaProductoPrecio") Then
            If ValidaPerfil(iUsuario, "FrmListaProductoPrecio") Then
                Dim FrmListaProductoPrecio As New FrmListaProductoPrecio
                FrmListaProductoPrecio.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoCaja") Then
            If ValidaPerfil(iUsuario, "FrmVentanilla") Then
                Dim FrmVentanilla As New FrmVentanilla
                FrmVentanilla.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoProductoSucursal") Then
            If ValidaPerfil(iUsuario, "FrmProductoSucursal") Then
                Dim FrmProductoSucursal As New FrmProductoSucursal
                FrmProductoSucursal.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoLiberaProductoSucursal") Then
            If ValidaPerfil(iUsuario, "FrmLiberaProductoSucursal") Then
                Dim FrmLiberaProductoSucursal As New FrmLiberaProductoSucursal
                FrmLiberaProductoSucursal.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        'FrmDistribucion
        If e.Node.Name.Equals("NodoDispersion") Then
            If ValidaPerfil(iUsuario, "FrmDistribucion") Then
                Dim FrmDistribucion As New FrmDistribucion
                FrmDistribucion.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        'FrmMermas
        If e.Node.Name.Equals("NodoMermas") Then
            If ValidaPerfil(iUsuario, "FrmMermas") Then
                Dim FrmMermas As New FrmMermas
                FrmMermas.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        'FrmActualizacionMasivaPrecios
        If e.Node.Name.Equals("NodoActualizacionMasivaPreciosEsencias") Then
            If ValidaPerfil(iUsuario, "FrmActualizacionMasivaPrecios") Then
                Dim FrmActualizacionMasivaPrecios As New FrmActualizacionMasivaPrecios
                FrmActualizacionMasivaPrecios.ShowDialog()
            Else
                MsgBox("No tiene permisos de acceso a esta opción", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            End If
        End If
        If e.Node.Name.Equals("NodoSalir") Then
            'Me.Close()
            If MsgBox("¿Realmente desea salir?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Application.Exit()
            End If
        End If
    End Sub

    Private Sub FrmMenuPrincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            If MsgBox("¿Realmente desea salir?", MsgBoxStyle.YesNo, "¿Salir?") = MsgBoxResult.Yes Then
                Application.Exit()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub FrmMenuPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblUsuario.Text = NombreUsuario
        LblFechaSistema.Text = sFechaSistema
        LblSucursal.Text = sSucursal
    End Sub

End Class