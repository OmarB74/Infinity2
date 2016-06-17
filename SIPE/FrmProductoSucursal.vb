Option Explicit On
Imports System.Data
Imports System.Data.SqlClient

Public Class FrmProductoSucursal
    Dim objProducto As New cProductos
    Dim objMedida As New cMedida
    Dim objSucursal As New cSucursal
    Dim objTipoListas As New cTipoListas
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private llenocbo As Boolean = False
    Private Sub FrmProductoSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiacampos()
    End Sub
    Private Sub Limpiacampos()
        llenocbo = False
        txtCantidad.Text = ""
        '
        LlenarComboProductos(cboProducto, cstrConnectBDapp) 'Llena el combo
        LlenarComboSucursal(cboSucursal, cstrConnectBDapp)
        LlenarcboUnidad(cboUnidad)
        LlenarComboMedida(cboMedida, cstrConnectBDapp) 'Llena el combo
        LlenarComboTipoListas(cboListaPrecios, cstrConnectBDapp) 'Llena el combo
        cboMedida.Enabled = False
        cboListaPrecios.Enabled = False
        cboListaPrecios.SelectedValue = 2
        cboMedida.SelectedValue = 7
        '
        llenocbo = True
    End Sub
    '
    Private Sub LlenarComboProductos(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objProducto.Obtener_Producto(strConexion).Tables("ProductosPerfumes")
        objCombobox.DisplayMember = "Nombre"
        objCombobox.ValueMember = "Productoid"
    End Sub
    '
    Private Sub LlenarComboSucursal(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objSucursal.Obtener_Sucursal(strConexion).Tables("Sucursales")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "SucursalId"
    End Sub
    Public Sub LlenarcboUnidad(ByVal objCombobox As ComboBox)
        objCombobox.DataSource = Obtener_Unidad().Tables("Unidad")
        objCombobox.DisplayMember = "Descripcion_Unidad"
        objCombobox.ValueMember = "Unidadid"
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
    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        e.Handled = Numero(e, txtCantidad)
        '
        Me.txtCantidad.Text = Trim(Replace(Me.txtCantidad.Text, "  ", " "))
        '
        txtCantidad.Select(txtCantidad.Text.Length, 0)
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ValidaCampoCantidad() Then
            Select Case MsgBox("Esta seguro(a) de guardar los datos", vbYesNo)
                Case vbYes
                    InsertarProductoSucursal()
                    '
                    Limpiacampos()
            End Select
        Else
            MsgBox("Favor de verificar la cantidad", vbOKOnly)
            txtCantidad.Focus()
        End If
    End Sub
    Private Function ValidaCampoCantidad() As Boolean
        ValidaCampoCantidad = True
        If Trim(txtCantidad.Text) = "" Then
            txtCantidad.Text = "0.00"
            ValidaCampoCantidad = False
        End If
        If txtCantidad.Text = "0.00" Then
            ValidaCampoCantidad = False
        End If
    End Function
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiacampos()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    Private Sub InsertarProductoSucursal()
        Dim Transaccion As SqlTransaction = Nothing
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            Transaccion = Cnn.BeginTransaction
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spInsertaProductoSucursal"
            '
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add(New SqlClient.SqlParameter("@ProductoId", cboProducto.SelectedValue))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@SucursalId", cboSucursal.SelectedValue))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@Cantidad", txtCantidad.Text))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@UnidadId", cboUnidad.SelectedValue))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@MedidaId", cboMedida.SelectedValue))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@ListaId", cboListaPrecios.SelectedValue))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@UsuarioId", iUsuario))
            cmd.Parameters.Add("@MaxFolioid", SqlDbType.Int).Direction = ParameterDirection.Output
            '
            cmd.Transaction = Transaccion
            'Cnn.Open()
            cmd.ExecuteNonQuery()
            '
            If CInt(cmd.Parameters("@MaxFolioid").Value.ToString) > 0 Then
                MsgBox("Datos de Producto registrados con exito")
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

    End Sub

    Private Sub cboProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProducto.SelectedIndexChanged
        If llenocbo Then
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
        End If
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