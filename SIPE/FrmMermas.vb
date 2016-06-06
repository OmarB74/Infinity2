Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmMermas
    Dim objProducto As New cProductos
    Dim objUnidad As New cUnidad
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Sub FrmMermas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LimpiarCampos()
    End Sub
    Private Sub LimpiarCampos()
        '
        LlenarComboProductos(cboProducto, cstrConnectBDapp) 'Llena el combo
        LlenarComboUnidad(cboUnidad, cstrConnectBDapp) 'Llena el combo
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
                GuardaMerma
        End Select
    End Sub
    Private Sub GuardaMerma()

    End Sub
End Class