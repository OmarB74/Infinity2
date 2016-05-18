Public Class FrmColonias

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        bCerrarForma = True
        Me.Close()
    End Sub

    Private Sub FrmColonias_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bCerrarForma = True
    End Sub

    Private Sub FrmColonias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaCombosForma()
    End Sub
    Private Sub LlenaCombosForma()
        LlenaCombosStatus = False
        '
        LlenarCboPais(cboPais, cstrConnectBDapp)
        cboPais.SelectedItem = 1
        '
        LlenarCboEstados(cboEstado, cstrConnectBDapp, CInt(cboPais.SelectedValue))
        cboEstado.SelectedItem = 1
        LlenarCboMunicipio(cboMunicipio, cstrConnectBDapp, CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        cboMunicipio.SelectedItem = 1
        '
        LlenaCombosStatus = True
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

    Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
        If LlenaCombosStatus Then
            LlenarCboMunicipio(cboMunicipio, cstrConnectBDapp, CInt(cboEstado.SelectedValue), CInt(cboPais.SelectedValue))
        End If
    End Sub
End Class