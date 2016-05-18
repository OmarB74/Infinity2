Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmProductos
    Public iProductoId As Integer = 0
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
    End Sub

    Private Sub Limpiar()
        txtCodigoProducto.Text = ""
        txtNombre.Text = ""
        txtDescripcion.Text = ""
        txtPrecio.Text = "0.00"
        '
        iProductoId = 0
        '
        LlenaCombosStatus = False
        LlenarcboUnidad(cboUnidad)
        LlenaCombosStatus = True
        '
        CargaProductos()
        txtCodigoProducto.Select()
        txtCodigoProducto.Focus()
    End Sub
    Public Sub LlenarcboUnidad(ByVal objCombobox As ComboBox)
        objCombobox.DataSource = Obtener_Unidad().Tables("Unidad")
        objCombobox.DisplayMember = "Descripcion_Unidad"
        objCombobox.ValueMember = "Unidadid"
    End Sub
    Private Sub FrmProductos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bCerrarForma = True
    End Sub

    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If ValidaCamposProducto(Me) Then
            Insertar_Actualizar_Producto(Me, IIf(iProductoId = 0, 1, 3))
            '
            Limpiar()
        End If
    End Sub

    Private Sub CargaProductos()
        Dim objDS As DataSet = Nothing
        '
        Windows.Forms.Cursor.Current = Cursors.WaitCursor ' Pon el relojito de arena
        objDS = LlenarProductos(cstrConnectBDapp)
        'Obtener informacion de clientes
        If objDS.Tables.Count > 0 Then
            If objDS.Tables(0).Rows.Count = 0 Then        'no existe registro de remitente
                MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dgvProductos.DataSource = objDS.Tables(0)
                dgvProductos.Columns.Item(0).Visible = False
                dgvProductos.Columns.Item(4).Visible = False
                dgvProductos.Columns.Item(5).Visible = False
                dgvProductos.Columns.Item(9).Visible = False
                dgvProductos.Select()
                '
            End If
        Else
            MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default ' 
    End Sub
    Private Function LlenarProductos(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spListaProductos", Cnn)
            '
            'With cmd
            '    '
            '    param = New SqlParameter("@ProveedorClienteId", SqlDbType.Int)
            '    param.Direction = ParameterDirection.Input      'parametro entrada
            '    param.Value = iProveeId                           '
            '    .Parameters.Add(param)
            'End With
            '
            cmd.CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Productos")       'llenar dataset
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
        Return ds
    End Function

    Private Sub dgvProductos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductos.CellDoubleClick
        If e.RowIndex >= 0 Then
            iProductoId = dgvProductos.Item(0, e.RowIndex).Value '
            Me.txtCodigoProducto.Text = dgvProductos.Item(1, e.RowIndex).Value.ToString '
            Me.txtNombre.Text = dgvProductos.Item(2, e.RowIndex).Value.ToString '
            Me.txtDescripcion.Text = dgvProductos.Item(3, e.RowIndex).Value.ToString '
            Me.txtPrecio.Text = dgvProductos.Item(4, e.RowIndex).Value.ToString '
            'Me.txtPrecioEspecial.Text = dgvProductos.Item(4, e.RowIndex).Value.ToString '
            'Me.txtPrecioSuperEspecial.Text = dgvProductos.Item(5, e.RowIndex).Value.ToString
            Me.cboUnidad.SelectedValue = dgvProductos.Item(9, e.RowIndex).Value
        End If
    End Sub

    Private Sub dgvProductos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvProductos.KeyPress
        Dim row As Integer
        row = dgvProductos.CurrentRow.Index
        If row > 0 Then
            'Me.txtDescripcion.Text = dgvVehiculos.Item(1, row - 1).Value.ToString '
            iProductoId = dgvProductos.Item(0, row - 1).Value '
            Me.txtCodigoProducto.Text = dgvProductos.Item(1, row - 1).Value.ToString '
            Me.txtNombre.Text = dgvProductos.Item(2, row - 1).Value.ToString '
            Me.txtDescripcion.Text = dgvProductos.Item(3, row - 1).Value.ToString '
            Me.txtPrecio.Text = dgvProductos.Item(4, row - 1).Value.ToString '
            'Me.txtPrecioEspecial.Text = dgvProductos.Item(4, row - 1).Value.ToString '
            'Me.txtPrecioSuperEspecial.Text = dgvProductos.Item(5, row - 1).Value.ToString
            Me.cboUnidad.SelectedValue = dgvProductos.Item(9, row - 1).Value
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            If MsgBox("seguro que desea borrar al producto: " & txtDescripcion.Text, vbYesNo) = vbYes Then
                If iProductoId > 0 Then
                    Insertar_Actualizar_Producto(Me, 2)
                    '
                    Limpiar()
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub txtPrecioMayoreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        If Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 8 Or e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioMayoreo_LostFocus(sender As Object, e As EventArgs) Handles txtPrecio.LostFocus
        If txtPrecio.Text.Length = 0 Then
            txtPrecio.Text = "0.00"
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        bCerrarForma = True
        Me.Close()
    End Sub

    Private Sub txtPrecioEspecial_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 8 Or e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtPrecioSuperEspecial_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 8 Or e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Buscar(txtDescripcion.Text, "Descripcion", Me.dgvProductos)
    End Sub
    Private Function Buscar(ByVal TextoABuscar As String, ByVal Columna As String, ByRef grid As DataGridView) As Boolean
        Dim encontrado As Boolean = False
        If TextoABuscar = String.Empty Then Return False
        If grid.RowCount = 0 Then Return False
        grid.ClearSelection()
        If Columna = String.Empty Then
            For Each row As DataGridViewRow In grid.Rows
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Value.ToString() = TextoABuscar Then
                        row.Selected = True
                        grid.CurrentCell = grid.Rows(row.Index).Cells(0)
                        Return True
                    End If
                Next
            Next
        Else
            For Each row As DataGridViewRow In grid.Rows
                If row.IsNewRow Then Return False
                If row.Cells(Columna).Value.ToString() = TextoABuscar Then
                    row.Selected = True
                    grid.CurrentCell = grid.Rows(row.Index).Cells(1)
                    Return True
                End If

            Next
        End If
        Return encontrado
    End Function

End Class