Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmActualizacionMasivaPrecios
    Dim objMedida As New cMedida
    Dim objPeso As New cPeso
    Dim objTipoListas As New cTipoListas
    Dim objTipoRelleno As New cTipoRelleno
    Private Sub FrmActualizacionMasivaPrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtPrecio.Text = "0.00"
        '
        LlenarComboMedida(cboMedida, cstrConnectBDapp) 'Llena el combo
        LlenarComboPeso(cboPeso, cstrConnectBDapp) 'Llena el combo
        LlenarComboTipoListas(cboListaPrecios, cstrConnectBDapp) 'Llena el combo
        LlenarComboTipoRelleno(cboTipoRelleno, cstrConnectBDapp) 'Llena el combo
    End Sub
    '
    Private Sub LlenarComboTipoRelleno(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objTipoRelleno.Obtener_TipoRelleno(strConexion).Tables("TipoRelleno")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "TipoRellenoId"
    End Sub
    '
    Private Sub LlenarComboMedida(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objMedida.Obtener_Medidas(strConexion).Tables("Medidas")
        objCombobox.DisplayMember = "Contenido"
        objCombobox.ValueMember = "MedidaId"
    End Sub
    '
    Private Sub LlenarComboPeso(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objPeso.Obtener_Peso(strConexion).Tables("Peso")
        objCombobox.DisplayMember = "Peso"
        objCombobox.ValueMember = "PesoId"
    End Sub
    '
    Private Sub LlenarComboTipoListas(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objTipoListas.Obtener_NombreListas(strConexion).Tables("TipoListas")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "ListaId"
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 8 Or e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Private Sub txtPrecio_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
        If txtPrecio.Text.Length = 0 Then
            txtPrecio.Text = "0.00"
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiaCampos()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub LimpiaCampos()
        Me.txtPrecio.Text = "0.00"
        '
        LlenarComboMedida(cboMedida, cstrConnectBDapp) 'Llena el combo
        LlenarComboPeso(cboPeso, cstrConnectBDapp) 'Llena el combo
        LlenarComboTipoListas(cboListaPrecios, cstrConnectBDapp) 'Llena el combo
        LlenarComboTipoRelleno(cboTipoRelleno, cstrConnectBDapp) 'Llena el combo
    End Sub

End Class