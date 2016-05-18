Option Explicit On
Option Strict On
Imports System.Data.SqlClient
Public Class FrmEmpresa
    Private EmpresaId As Integer = 0

    Private Sub FrmEmpresa_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bCerrarForma = True
    End Sub

    Private Sub FrmEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '
        LlenaCombosStatus = False
        LlenaCombos()
        LlenaCombosStatus = True
        '
        ObtenerEmpresa()
    End Sub

    Private Sub cboMunicipio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMunicipio.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboColonias(cboColonia, cstrConnectBDapp, CInt(cboMunicipio.SelectedValue), CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        End If
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        bCerrarForma = True
        Me.Close()
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
    Private Sub ObtenerEmpresa()
        '
        Dim strQry As String = "SELECT EmpresaId, RazonSocial, Calle, NumeroExterior, isNull(NumeroInterior,''), CP, ColoniaId, PoblacionId, EstadoId, Paisid, isnull(Fax,''), isnull(Email,''), Telefono, FechaAlta, RFC "
        strQry &= " FROM Empresa "
        Dim cnn As New SqlConnection(cstrConnectBDapp)
        Try
            Dim cmd As New SqlCommand(strQry, cnn)
            cnn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            cmd.CommandTimeout = 180

            While reader.Read
                EmpresaId = CInt(reader.Item(0))
                txtRazonSocial.Text = CStr(reader.Item(1))
                txtCalle.Text = CStr(reader.Item(2))
                txtNumExterior.Text = CStr(reader.Item(3))
                txtNuminterior.Text = CStr(reader.Item(4))
                cboPais.SelectedValue = reader.Item(9)
                LlenarCboEstados(cboEstado, cstrConnectBDapp, CInt(cboPais.SelectedValue))
                cboEstado.SelectedValue = reader.Item(8)
                '
                LlenarCboMunicipio(cboMunicipio, cstrConnectBDapp, CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
                cboMunicipio.SelectedValue = reader.Item(7)
                '
                LlenarCboColonias(cboColonia, cstrConnectBDapp, CInt(cboMunicipio.SelectedValue), CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
                cboColonia.SelectedValue = reader.Item(6)
                txtFax.Text = CStr(reader.Item(10))
                txtemail.Text = CStr(reader.Item(11))
                txtTelefono.Text = CStr(reader.Item(12))
                txtRFC.Text = CStr(reader.Item(14))
            End While

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, vbOKOnly)
            cnn.Close()
        Finally
            If Not cnn Is Nothing Then
                If cnn.State = ConnectionState.Open Then
                    cnn.Close()    'cerrar conexion
                    cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
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
        objCombobox.DataSource = Obtener_Colonia(strConexion, munid, edoid, paisid).Tables("Colonia")
        objCombobox.DisplayMember = "DescColonia"
        objCombobox.ValueMember = "ColoniaId"
    End Sub

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboMunicipio(cboMunicipio, cstrConnectBDapp, CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        End If
    End Sub

    Private Sub cboPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPais.SelectedIndexChanged

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    End Sub
End Class