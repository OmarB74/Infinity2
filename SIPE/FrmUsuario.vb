Public Class FrmUsuario

    Private Sub FrmUsuario_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bCerrarForma = True
    End Sub

    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TxtLogin.Text = ""
        Me.TxtNombre.Text = ""
        Me.TxtPassword.Text = ""
        Me.TxtUserId.Text = ""
        LlenarcboPerfil(cboPerfil)
        LlenarcboSucursal(cboSucursal)
        'Me.ActiveControl = Me.Controls(4)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If ValidarUsuario(Me) Then
            If MsgBox("¿Todos los datos son correctos?", vbYesNo) = vbYes Then
                If ABMUsuario(Me, False) Then
                    Me.TxtLogin.Text = ""
                    Me.TxtNombre.Text = ""
                    Me.TxtPassword.Text = ""
                    Me.TxtUserId.Text = ""
                    Me.chkAdministrador.Checked = False
                    LlenarcboPerfil(cboPerfil)
                    Me.chkSupervisor.Checked = False
                    Me.TxtLogin.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        bCerrarForma = True
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Me.TxtLogin.Text = ""
        Me.TxtLogin.ReadOnly = False
        Me.TxtNombre.Text = ""
        Me.TxtPassword.Text = ""
        Me.TxtUserId.Text = ""
        LlenarcboPerfil(cboPerfil)
        Me.chkAdministrador.Checked = False
        Me.chkSupervisor.Checked = False
        Me.TxtLogin.Focus()
    End Sub

    Public Sub LlenarcboPerfil(ByVal objCombobox As ComboBox)
        objCombobox.DataSource = Obtener_Perfil().Tables("Perfil")
        objCombobox.DisplayMember = "DescGrupo"
        objCombobox.ValueMember = "GrupoId"
    End Sub
    Public Sub LlenarcboSucursal(ByVal objCombobox As ComboBox)
        objCombobox.DataSource = Obtener_Sucursal().Tables("Sucursales")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "SucursalId"
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        '
        iUsuarioBusqueda = 0
        Dim frmlistausuarios As New FrmListaUsuarios
        frmlistausuarios.ShowDialog()
        '
        If iUsuarioBusqueda > 0 Then
            CargaDatosUsuario(Me, iUsuarioBusqueda)
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If MsgBox("¿Esta seguro(a) de querer eliminar al Usuario?", vbYesNo) = vbYes Then
            If ABMUsuario(Me, True) Then
                Me.TxtLogin.Text = ""
                Me.TxtNombre.Text = ""
                Me.TxtPassword.Text = ""
                Me.TxtUserId.Text = ""
                Me.chkAdministrador.Checked = False
                LlenarcboPerfil(cboPerfil)
                Me.TxtLogin.Focus()
            End If
        End If
    End Sub
End Class
