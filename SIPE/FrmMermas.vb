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
    Dim objMedida As New cMedida
    Dim objTipoListas As New cTipoListas
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
        LlenarComboMedida(cboMedida, cstrConnectBDapp) 'Llena el combo
        LlenarComboTipoListas(cboListaPrecios, cstrConnectBDapp) 'Llena el combo
        cboMedida.Enabled = False
        cboListaPrecios.Enabled = False
        cboListaPrecios.SelectedValue = 2
        cboMedida.SelectedValue = 7
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
            If ValidaProductoCampos() Then
                cboMedida.Enabled = True
                cboListaPrecios.Enabled = True
                cboUnidad.SelectedValue = 3
            Else
                cboMedida.Enabled = False
                cboListaPrecios.Enabled = False
                cboUnidad.SelectedValue = 1
                cboListaPrecios.SelectedValue = 2
                cboMedida.SelectedValue = 7
            End If
            '
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
    '
    Private Sub LlenarComboMedida(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objMedida.Obtener_Medidas(strConexion).Tables("Medidas")
        objCombobox.DisplayMember = "Contenido"
        objCombobox.ValueMember = "MedidaId"
    End Sub
    '
    Private Sub LlenarComboTipoListas(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objTipoListas.Obtener_NombreListas(strConexion).Tables("TipoListas")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "ListaId"
    End Sub
    Private Function ValidaProductoCampos() As Boolean
        Dim Transaccion As SqlTransaction = Nothing
        ValidaProductoCampos = False
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            Transaccion = Cnn.BeginTransaction
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spValidaProductoCampo"
            '
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlClient.SqlParameter("@ProductoId", cboProducto.SelectedValue))
            cmd.Parameters.Add("@Contador", SqlDbType.Int).Direction = ParameterDirection.Output
            '
            cmd.Transaction = Transaccion
            'Cnn.Open()
            cmd.ExecuteNonQuery()
            '
            If CInt(cmd.Parameters("@Contador").Value) > 0 Then
                ValidaProductoCampos = True
            End If
            'Dim read As SqlDataReader = cmd.ExecuteReader()
            '    read.Read()
            '    TempProdId = CInt(read(0))

            'read.Close()
            cmd.Dispose()
            Transaccion.Commit()
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Function
End Class