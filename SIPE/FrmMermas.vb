Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmMermas
    Dim objProducto As New cProductos
    Dim objUnidad As New cUnidad
    Dim objMermas As New cMerma
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Sub FrmMermas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LimpiarCampos()
    End Sub
    Private Sub LimpiarCampos()
        '
        LlenaCombosStatus = False
        LlenarComboProductos(cboProducto, cstrConnectBDapp) 'Llena el combo
        LlenarComboUnidad(cboUnidad, cstrConnectBDapp) 'Llena el combo
        LlenaCombosStatus = True
        cboUnidad.SelectedValue = objUnidad.BusquedaUnidad(cboProducto.SelectedValue)
        '
        txtCantidad.Text = ""
        txtCantidad.Select()
        txtCantidad.Focus()
    End Sub
    '
    Private Sub LlenarComboProductos(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objProducto.Obtener_Producto(strConexion).Tables("ProductosPerfumes")
        objCombobox.DisplayMember = "Nombre"
        objCombobox.ValueMember = "Productoid"
    End Sub
    '
    Private Sub LlenarComboUnidad(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objUnidad.Obtener_Unidad(strConexion).Tables("Unidad")
        objCombobox.DisplayMember = "Descripcion_Unidad"
        objCombobox.ValueMember = "Unidadid"
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Select Case MsgBox("¿Esta seguro(a) de querer guardar la merma?", vbYesNo)
            Case vbYes
                If Len(Trim(txtCantidad.Text)) > 0 Then
                    GuardaMerma()
                End If
        End Select
    End Sub
    Private Sub GuardaMerma()
        objMermas.GuardaMerma(Me)
    End Sub

    Private Sub cboProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProducto.SelectedIndexChanged
        If LlenaCombosStatus Then
            cboUnidad.SelectedValue = objUnidad.BusquedaUnidad(cboProducto.SelectedValue)
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        e.Handled = Numero(e, txtCantidad)
        '
        Me.txtCantidad.Text = Trim(Replace(Me.txtCantidad.Text, "  ", " "))
        '
        txtCantidad.Select(txtCantidad.Text.Length, 0)
    End Sub
End Class