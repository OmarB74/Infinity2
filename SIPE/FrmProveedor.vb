Option Explicit On
Public Class FrmProveedor
    Private iClienteProveedor As Integer = 0
    Private Sub btnFoto_Click(sender As Object, e As EventArgs) Handles btnTomarFoto.Click
        If Trim(Me.txtFolioProveedorCliente.Text) <> "" Then
            Dim frmfoto As New FrmFoto
            frmfoto.iProveedorClienteId = CInt(txtFolioProveedorCliente.Text)
            frmfoto.ShowDialog()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        bCerrarForma = True
        Me.Close()
    End Sub

    Private Sub rbPersonaFisica_CheckedChanged(sender As Object, e As EventArgs) Handles rbPersonaFisica.CheckedChanged
        If rbPersonaFisica.Checked Then
            Me.TabPage2.Enabled = False
            Me.TabPage1.Enabled = True
            Me.TabControl.SelectedIndex = 0
            Me.txtFolioProveedorCliente.Select()
            Me.txtFolioProveedorCliente.Focus()
            LimpiaCamposPM()
        End If
    End Sub

    Private Sub rbPersonaMoral_CheckedChanged(sender As Object, e As EventArgs) Handles rbPersonaMoral.CheckedChanged
        If rbPersonaMoral.Checked Then
            Me.TabPage2.Enabled = True
            Me.TabPage1.Enabled = False
            Me.TabControl.SelectedIndex = 1
            Me.txtFolioPM.Select()
            Me.txtFolioPM.Focus()
            LimpiaCamposPF()
        End If
    End Sub

    Private Sub btnAutoPF_Click(sender As Object, e As EventArgs) Handles btnAutoPF.Click
        If Trim(txtFolioProveedorCliente.Text) <> "" Then
            Dim frmVehiculoPF As New FrmVehiculos
            frmVehiculoPF.iProveedorClienteId = Me.txtFolioProveedorCliente.Text
            frmVehiculoPF.ShowDialog()
        End If
    End Sub

    Private Sub btnVehiculosPM_Click(sender As Object, e As EventArgs) Handles btnVehiculosPM.Click
        If Trim(txtFolioPM.Text) <> "" And Len(txtFolioPM.Text) >= 6 Then
            Dim frmvehiculoPM As New FrmVehiculos
            frmvehiculoPM.iProveedorClienteId = txtFolioPM.Text
            frmvehiculoPM.ShowDialog()
        End If
    End Sub

    Private Sub FrmProveedor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bCerrarForma = True
    End Sub

    Private Sub FrmProveedorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        LlenaCombosStatus = False
        LlenaCombosPF()
        LlenaCombosPM()
        LlenaCombosStatus = True
        '
    End Sub
    Private Sub LlenaCombosPF()
        LlenarCboPais(cboPais, cstrConnectBDapp)
        cboPais.SelectedItem = 1
        '
        LlenarCboEstados(cboEstado, cstrConnectBDapp, CInt(cboPais.SelectedValue))
        cboEstado.SelectedItem = 1
        LlenarCboMunicipio(cboMunicipio, cstrConnectBDapp, CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        cboMunicipio.SelectedItem = 1
        LlenarCboColonias(cboColonia, cstrConnectBDapp, CInt(cboMunicipio.SelectedValue), CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        cboColonia.SelectedItem = 1
        '
        LlenarCboIdentificacion(cboIdentificacion, cstrConnectBDapp)

    End Sub
    Private Sub LlenaCombosPM()
        '
        LlenarCboPais(cboPaisPM, cstrConnectBDapp)
        cboPais.SelectedItem = 1
        '
        LlenarCboEstados(cboEstadoPM, cstrConnectBDapp, CInt(cboPaisPM.SelectedValue))
        cboEstado.SelectedItem = 1
        LlenarCboMunicipio(cboPoblacionPM, cstrConnectBDapp, CInt(cboEstadoPM.SelectedValue), CInt(cboPaisPM.SelectedValue))
        cboMunicipio.SelectedItem = 1
        LlenarCboColonias(cboColoniaPM, cstrConnectBDapp, CInt(cboPoblacionPM.SelectedValue), CInt(cboEstadoPM.SelectedValue), CInt(cboPais.SelectedValue))
        cboColonia.SelectedItem = 1
    End Sub
    Public Sub LlenarCboPais(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        objCombobox.DataSource = Obtener_Pais(strConexion).Tables("Pais")
        objCombobox.DisplayMember = "DescPais"
        objCombobox.ValueMember = "Paisid"
    End Sub
    Public Sub LlenarCboEstados(ByVal objCombobox As ComboBox, ByVal strConexion As String, ByVal paisid As Integer)
        objCombobox.DataSource = Obtener_Estados(strConexion, paisid).Tables("Estados")
        objCombobox.DisplayMember = "DescEstado"
        objCombobox.ValueMember = "Estadoid"
    End Sub

    Public Sub LlenarCboMunicipio(ByVal objCombobox As ComboBox, ByVal strConexion As String, ByVal edoid As Integer, PaisId As Integer)
        objCombobox.DataSource = Obtener_Municipio(strConexion, edoid, PaisId).Tables("Municipio")
        objCombobox.DisplayMember = "DescPoblacion"
        objCombobox.ValueMember = "Poblacionid"
    End Sub

    Public Sub LlenarCboColonias(ByVal objCombobox As ComboBox, ByVal strConexion As String, ByVal munid As Integer, edoid As Integer, Paisid As Integer)
        objCombobox.DataSource = Obtener_Colonia(strConexion, munid, edoid, Paisid).Tables("Colonia")
        objCombobox.DisplayMember = "DescColonia"
        objCombobox.ValueMember = "ColoniaId"
    End Sub

    Public Sub LlenarCboIdentificacion(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        objCombobox.DataSource = Obtener_Identificacion(strConexion).Tables("Identificacion")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "TipoIdentificacionId"
    End Sub

    Private Sub cboPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPais.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboEstados(cboEstado, cstrConnectBDapp, CInt(cboPais.SelectedValue))
            ''
            'LlenarCboMunicipio(cboMunicipio, cstrConnectBDapp, CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
            ''
            'LlenarCboColonias(cboColonia, cstrConnectBDapp, CInt(cboMunicipio.SelectedValue), CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        End If
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboMunicipio(cboMunicipio, cstrConnectBDapp, CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        End If
    End Sub

    Private Sub cboMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMunicipio.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboColonias(cboColonia, cstrConnectBDapp, CInt(cboMunicipio.SelectedValue), CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        End If
    End Sub

    Private Sub cboPaisPM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPaisPM.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboEstados(cboEstadoPM, cstrConnectBDapp, CInt(cboPaisPM.SelectedValue))
            ''
            'LlenarCboMunicipio(cboPoblacionPM, cstrConnectBDapp, CInt(cboEstadoPM.SelectedValue), CInt(cboPaisPM.SelectedValue))
            ''
            'LlenarCboColonias(cboColoniaPM, cstrConnectBDapp, CInt(cboPoblacionPM.SelectedValue), CInt(cboEstadoPM.SelectedValue), CInt(cboPais.SelectedValue))
        End If
    End Sub

    Private Sub cboEstadoPM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstadoPM.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboMunicipio(cboPoblacionPM, cstrConnectBDapp, CInt(cboEstadoPM.SelectedValue), CInt(cboPaisPM.SelectedValue))
        End If
    End Sub

    Private Sub cboPoblacionPM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPoblacionPM.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboColonias(cboColoniaPM, cstrConnectBDapp, CInt(cboPoblacionPM.SelectedValue), CInt(cboEstadoPM.SelectedValue), CInt(cboPaisPM.SelectedValue))
        End If
    End Sub

    Private Sub btnSalirPM_Click(sender As Object, e As EventArgs) Handles btnSalirPM.Click
        bCerrarForma = True
        Me.Close()
    End Sub

    Private Sub BtnCredencial_Click(sender As Object, e As EventArgs) Handles BtnCredencial.Click
        If Trim(txtFolioProveedorCliente.Text) <> "" Then
            Dim frmCredencial As New FrmReporteCredencial
            frmCredencial.iProveedorClienteId = CInt(Me.txtFolioProveedorCliente.Text)
            frmCredencial.ShowDialog()
        End If
    End Sub

    Private Sub btnBuscarPF_Click(sender As Object, e As EventArgs) Handles btnBuscarPF.Click
        '
        iProveedorBusqueda = 0
        '
        Dim frmbusqueda As New FrmBusqueda
        frmbusqueda.ShowDialog()
        If bRealizarBusqueda Then
            '
            Dim frmlistaproveedor As New FrmListaProveedorCliente
            frmlistaproveedor.iTipoPersona = 1 ' Persona Fisica
            frmlistaproveedor.iTipoProveedorCliente = 1
            frmlistaproveedor.ShowDialog()
            If iProveedorBusqueda > 0 Then
                CargaDatosProveedorCliente(Me, iProveedorBusqueda, 1)
            End If
        End If
    End Sub

    Private Sub btnBuscarPM_Click(sender As Object, e As EventArgs) Handles btnBuscarPM.Click
        '
        iProveedorBusqueda = 0
        '
        Dim frmbusquedaPM As New frmBusquedaPM
        frmbusquedaPM.showdialog()
        If bRealizarBusqueda Then
            '
            Dim frmlistaproveedor As New FrmListaProveedorCliente
            frmlistaproveedor.iTipoPersona = 2
            frmlistaproveedor.iTipoProveedorCliente = 1
            frmlistaproveedor.ShowDialog()
            If iProveedorBusqueda > 0 Then
                CargaDatosProveedorCliente(Me, iProveedorBusqueda, 2)
            End If
        End If
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiaCamposPF()
    End Sub
    Private Sub LimpiaCamposPF()
        txtFolioProveedorCliente.Text = ""
        txtNombres.Text = ""
        txtApellidos.Text = ""
        txtCP.Text = ""
        txtCalle.Text = ""
        txtNumExterior.Text = ""
        txtNuminterior.Text = ""
        txtTelefono.Text = ""
        txtemail.Text = ""
        txtNumeroIdentificacion.Text = ""
        txtRFCPF.Text = ""
        rbPrecioMayoreo.Checked = True
        LlenaCombosPF()
        txtNombres.Select()
        txtNombres.Focus()
    End Sub

    Private Sub btnNuevoPM_Click(sender As Object, e As EventArgs) Handles btnNuevoPM.Click
        LimpiaCamposPM()
    End Sub
    Private Sub LimpiaCamposPM()
        txtFolioPM.Text = ""
        txtRazonSocial.Text = ""
        txtRepresentante.Text = ""
        txtRFC.Text = ""
        txtCP_PM.Text = ""
        txtCallePM.Text = ""
        txtNumeroExteriorPM.Text = ""
        txtNumeroInteriorPM.Text = ""
        txtTelefonoPM.Text = ""
        txtemailPM.Text = ""
        rbPrecioMayoreo.Checked = True
        txtRazonSocial.Select()
        txtRazonSocial.Focus()
    End Sub
    'Guardar Persona Fisica
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Trim(txtFolioProveedorCliente.Text) = "" Then
            If ValidaSinCamposVacios(Me, 1) Then
                If MsgBox("Todos los campos son correctos", vbYesNo) = vbYes Then
                    Insertar_Actualizar_Proveedor(Me, 1, 1)
                End If
            End If
        Else
            If ValidaSinCamposVacios(Me, 1) Then
                If MsgBox("Todos los campos son correctos", vbYesNo) = vbYes Then
                    Insertar_Actualizar_Proveedor(Me, 3, 1)
                End If
            End If
        End If
    End Sub

    Private Sub btnFotos_Click(sender As Object, e As EventArgs) Handles btnFotos.Click
        If Trim(txtFolioProveedorCliente.Text) <> "" Then
            Dim frmfotoproveedorcliente As New FrmFotoProveedorCliente
            frmfotoproveedorcliente.iProveedorCliente = txtFolioProveedorCliente.Text
            frmfotoproveedorcliente.ShowDialog()
        End If
    End Sub

    Private Sub txtFolioProveedorCliente_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioProveedorCliente.KeyPress
        ' Sólo se admitirán números y la tecla de retroceso.

        If Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            If AscW(e.KeyChar) = 13 Then
                CargaDatosProveedorCliente(Me, txtFolioProveedorCliente.Text, 1)
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtFolioPM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioPM.KeyPress
        ' Sólo se admitirán números y la tecla de retroceso.

        If Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            If AscW(e.KeyChar) = 13 Then
                CargaDatosProveedorCliente(Me, iProveedorBusqueda, 2)
            Else
                e.Handled = True
            End If
        End If
    End Sub

    'Guardar Persona Moral
    Private Sub btnGuardarPM_Click(sender As Object, e As EventArgs) Handles btnGuardarPM.Click
        If Trim(txtFolioPM.Text) = "" Then
            If ValidaSinCamposVacios(Me, 2) Then
                If MsgBox("Todos los campos son correctos", vbYesNo) = vbYes Then
                    Insertar_Actualizar_Proveedor(Me, 1, 1)
                End If
            End If
        Else
            If ValidaSinCamposVacios(Me, 2) Then
                If MsgBox("Todos los campos son correctos", vbYesNo) = vbYes Then
                    Insertar_Actualizar_Proveedor(Me, 3, 1)
                End If
            End If
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            If MsgBox("seguro que desea borrar al proveedor-cliente: " & txtNombres.Text, vbYesNo) = vbYes Then
                '
                Insertar_Actualizar_Proveedor(Me, 2, 1)
                MsgBox("Proveedor: " & txtNombres.Text & vbCrLf & "se borro Satisfactoriamente")
                LimpiaCamposPF()
            End If
        Catch
        End Try
    End Sub

    Private Sub btnBorrarPM_Click(sender As Object, e As EventArgs) Handles btnBorrarPM.Click
        Try
            If MsgBox("seguro que desea borrar al proveedor-cliente: " & txtNombres.Text, vbYesNo) = vbYes Then
                '
                Insertar_Actualizar_Proveedor(Me, 2, 2)
                MsgBox("Proveedor: " & txtRazonSocial.Text & vbCrLf & "se borro Satisfactoriamente")
                LimpiaCamposPM()
            End If
        Catch
        End Try
    End Sub

    Private Sub txtCP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCP.KeyPress
        If AscW(e.KeyChar) = 8 Or Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else

            e.Handled = True
        End If
    End Sub

    Private Sub txtRFCPF_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRFCPF.KeyPress
        If Char.IsLetter(e.KeyChar) Or AscW(e.KeyChar) = 8 Or Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else

            e.Handled = True
        End If
    End Sub

    Private Sub txtRFC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRFC.KeyPress
        If Char.IsLetter(e.KeyChar) Or AscW(e.KeyChar) = 8 Or Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else

            e.Handled = True
        End If
    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        If AscW(e.KeyChar) = 8 Or Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TabControl_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl.DrawItem
        'Firstly we'll define some parameters.
        Dim CurrentTab As TabPage = TabControl.TabPages(e.Index)
        Dim ItemRect As Rectangle = TabControl.GetTabRect(e.Index)
        Dim FillBrush As New SolidBrush(Color.Red)
        Dim TextBrush As New SolidBrush(Color.Aquamarine)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        'If we are currently painting the Selected TabItem we'll 
        'change the brush colors and inflate the rectangle.
        If CBool(e.State And DrawItemState.Selected) Then
            FillBrush.Color = Color.Aquamarine
            TextBrush.Color = Color.Red
            ItemRect.Inflate(2, 2)
        End If

        'Set up rotation for left and right aligned tabs
        If TabControl.Alignment = TabAlignment.Left Or TabControl.Alignment = TabAlignment.Right Then
            Dim RotateAngle As Single = 90
            If TabControl.Alignment = TabAlignment.Left Then RotateAngle = 270
            Dim cp As New PointF(ItemRect.Left + (ItemRect.Width \ 2), ItemRect.Top + (ItemRect.Height \ 2))
            e.Graphics.TranslateTransform(cp.X, cp.Y)
            e.Graphics.RotateTransform(RotateAngle)
            ItemRect = New Rectangle(-(ItemRect.Height \ 2), -(ItemRect.Width \ 2), ItemRect.Height, ItemRect.Width)
        End If

        'Next we'll paint the TabItem with our Fill Brush
        e.Graphics.FillRectangle(FillBrush, ItemRect)

        'Now draw the text.
        e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, RectangleF.op_Implicit(ItemRect), sf)

        'Reset any Graphics rotation
        e.Graphics.ResetTransform()

        'Finally, we should Dispose of our brushes.
        FillBrush.Dispose()
        TextBrush.Dispose()
    End Sub
End Class