Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmLiberaProductoSucursal
    Dim objSucursal As New cSucursal
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private llenocbo As Boolean = False
    Private Sub FrmLiberaProductoSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarComboSucursal(cboSucursal, cstrConnectBDapp)
        CargaProductosSucursal()
        llenocbo = True
    End Sub
    '
    Private Sub LlenarComboSucursal(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objSucursal.Obtener_Sucursal(strConexion).Tables("Sucursales")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "SucursalId"
    End Sub
    Private Sub CargaProductosSucursal()
        Dim ds As New DataSet
        '
        'Limpia el Grid
        Me.dgvProductoSucursal.DataSource = Nothing
        Me.dgvProductoSucursal.Rows.Clear()
        '
        Try
            ' Se va a conectar a la base al servidor establecido y login establecido para la aplicacion            
            Cnn = New SqlConnection(cstrConnectBDapp)
            cmd = New SqlCommand("exec spListaProductoSucursalPorLiberar " & cboSucursal.SelectedValue & "", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "ProductosSucursal")       'llenar dataset
        Catch ex As SqlException
            MsgBox(ex.Number & "-" & ex.Message)
        Catch ex As Exception
            MsgBox(ex.Source & "-" & ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        If ds.Tables.Count > 0 Then
            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("NO SE ENCONTRO INFORMACION ACTUALMENTE")
            Else
                dgvProductoSucursal.Columns.Clear()
                dgvProductoSucursal.DataSource = Nothing
                dgvProductoSucursal.DataSource = ds.Tables(0)
                dgvProductoSucursal.Select()
            End If
        End If
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSucursal.SelectedIndexChanged
        If llenocbo Then
            CargaProductosSucursal()
        End If
    End Sub

    Private Sub btnLibera_Click(sender As Object, e As EventArgs) Handles btnLibera.Click
        LiberaProductos
    End Sub
    Private Sub LiberaProductos()
        Dim renglon As Integer
        renglon = 0
        While renglon < dgvProductoSucursal.Rows.Count
            EjecutaliberaProducto(dgvProductoSucursal.Item(0, renglon).Value) '
            '
            renglon = renglon + 1
        End While
        dgvProductoSucursal.DataSource = Nothing
        dgvProductoSucursal.Rows.Clear()
    End Sub
    Private Sub EjecutaliberaProducto(Id As Integer)
        Dim Transaccion As SqlTransaction = Nothing
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            Transaccion = Cnn.BeginTransaction
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spLiberaProductoSucursal"
            '
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlClient.SqlParameter("@FolioId", Id))
            '
            cmd.Transaction = Transaccion
            '
            cmd.ExecuteNonQuery()
            '
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
End Class