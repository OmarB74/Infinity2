Public Class FrmComprasProveedor

    Private Sub FrmComprasProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        dtpFechaInicial.Value = sFechaSistema
        dtpFechaInicial.MaxDate = sFechaSistema
        dtpFechaFinal.Value = sFechaSistema
        dtpFechaFinal.MaxDate = sFechaSistema
        '
        LlenaCombosStatus = False
        cboProveedores.Items.Clear()
        LlenarCboProveedor(cboProveedores, cstrConnectBDapp)
        LlenarCboCapturistasBascula(cboCapturistasBascula, cstrConnectBDapp)
        cboProveedores.SelectedItem = 1
        LlenaCombosStatus = True
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub LlenarCboProveedor(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        objCombobox.DataSource = Obtener_Proveedor(strConexion).Tables("Proveedor")
        objCombobox.DisplayMember = "NombreProveedor"
        objCombobox.ValueMember = "ProveedorClienteid"
    End Sub

    Private Sub LlenarCboCapturistasBascula(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        objCombobox.DataSource = Obtener_CapturistaBascula(strConexion).Tables("Capturista")
        objCombobox.DisplayMember = "Nombre_Completo"
        objCombobox.ValueMember = "Usuarioid"
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Dim frmreporte As New FrmReporteComprasProveedor
        If Me.rbFechas.Checked Then
            frmreporte.iAccion = 1
        End If
        If Me.rbCapturistas.Checked Then
            frmreporte.iAccion = 2
        End If
        If Me.rbProveedor.Checked Then
            frmreporte.iAccion = 3
        End If
        frmreporte.iCapturistaId = cboCapturistasBascula.SelectedValue
        frmreporte.iProveedorCompraId = cboProveedores.SelectedValue
        '
        If dtpFechaInicial.Value > dtpFechaFinal.Value Then
            MsgBox("La Fecha Inicial no puede ser mayor a la Fecha Final", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            frmreporte.FechaInicial = Format(dtpFechaInicial.Value, "dd/MM/yyyy 00:00:00")
            frmreporte.FechaFinal = Format(dtpFechaFinal.Value, "dd/MM/yyyy 23:59:00")
        End If
        
        frmreporte.ShowDialog()
    End Sub
End Class