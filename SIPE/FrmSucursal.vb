Option Explicit On
Option Strict On
Imports System.Data.SqlClient
Public Class FrmSucursal
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If ValidarSucursal(Me) Then
            If MsgBox("¿Todos los datos son correctos?", vbYesNo) = vbYes Then
                If ABMSucursal(Me, False) Then
                    '
                    LimpiaCamposSucursal()
                    LlenaCombosStatus = False
                    LlenaCombos()
                    LlenaCombosStatus = True
                    txtRazonSocial.Focus()
                    '
                End If
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        bCerrarForma = True
        Me.Close()
    End Sub

    Private Sub FrmSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        LimpiaCamposSucursal
        LlenaCombosStatus = False
        LlenaCombos()
        LlenaCombosStatus = True
        txtRazonSocial.Focus()
        '
    End Sub
    Private Sub LlenaCombos()
        LlenarCboPais(cboPais, cstrConnectBDapp)
        cboPais.SelectedItem = 1
        '
        LlenarCboEstados(cboEstado, cstrConnectBDapp, CInt(cboPais.SelectedValue))
        cboEstado.SelectedItem = 1
        LlenarCboMunicipio(cboMunicipio, cstrConnectBDapp, CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        cboMunicipio.SelectedItem = 1
        LlenarCboColonias(cboColonia, cstrConnectBDapp, CInt(cboMunicipio.SelectedValue), CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        cboColonia.SelectedItem = 1
    End Sub
    Private Sub cboMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMunicipio.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboColonias(cboColonia, cstrConnectBDapp, CInt(cboMunicipio.SelectedValue), CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        End If
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

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboMunicipio(cboMunicipio, cstrConnectBDapp, CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        End If
    End Sub

    Private Sub LimpiaCamposSucursal()
        Me.txtRazonSocial.Text = ""
        Me.txtCalle.Text = ""
        Me.txtCP.Text = ""
        Me.txtemail.Text = ""
        Me.txtFax.Text = ""
        Me.txtTelefono.Text = ""
        Me.txtNumExterior.Text = ""
        Me.txtNuminterior.Text = ""
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        '
        LimpiaCamposSucursal()
        LlenaCombosStatus = False
        LlenaCombos()
        LlenaCombosStatus = True
        txtRazonSocial.Focus()
        '
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        '
        iSucursalBusqueda = 0
        Dim frmlistasucursales As New FrmListaSucursales
        frmlistasucursales.ShowDialog()
        '
        If iSucursalBusqueda > 0 Then
            CargaDatosSucursal(Me, iSucursalBusqueda)
        End If
    End Sub

    Private Sub FrmSucursal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        bCerrarForma = True
    End Sub
End Class