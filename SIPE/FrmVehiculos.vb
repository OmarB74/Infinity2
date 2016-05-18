Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmVehiculos
    Public iVehiculoId As Integer = 0
    Public iProveedorClienteId As Integer
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiarCampos()
        '
    End Sub

    Private Sub FrmVehiculos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LimpiarCampos()
    End Sub
    Public Sub LlenarcboTipoVehiculo(ByVal objCombobox As ComboBox)
        objCombobox.DataSource = Obtener_TipoVehiculo().Tables("Vehiculo")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "TipoVehiculoid"
    End Sub
    Private Sub LimpiarCampos()
        LlenarcboTipoVehiculo(Me.cboTipoVehiculo)
        '
        txtDescripcion.Text = ""
        txtPlaca.Text = ""
        '
        dgvVehiculos.Columns.Clear()
        dgvVehiculos.DataSource = Nothing
        '
        ListaVehiculos()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            If iVehiculoId = 0 Then
                Insertar_Actualizar_Vehiculo(Me, 1, iProveedorClienteId, 0)
            Else
                Insertar_Actualizar_Vehiculo(Me, 3, iProveedorClienteId, iVehiculoId)
            End If
            '
            LimpiarCampos()
        Catch
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            If iVehiculoId > 0 Then
                If MsgBox("seguro que desea borrar vehiculo: " & txtDescripcion.Text, vbYesNo) = vbYes Then
                    Insertar_Actualizar_Vehiculo(Me, 2, iProveedorClienteId, iVehiculoId)
                    '
                    LimpiarCampos()
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub ListaVehiculos()
        Dim objDS As DataSet = Nothing
        '
        Windows.Forms.Cursor.Current = Cursors.WaitCursor ' Pon el relojito de arena
        objDS = LlenarVehiculos(cstrConnectBDapp, iProveedorClienteId)
        'Obtener informacion de clientes
        If objDS.Tables.Count > 0 Then
            If objDS.Tables(0).Rows.Count = 0 Then        'no existe registro de remitente
                MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dgvVehiculos.DataSource = objDS.Tables(0)
                dgvVehiculos.Columns.Item(0).Width = 300
                dgvVehiculos.Columns.Item(3).Visible = False
                dgvVehiculos.Columns.Item(4).Visible = False
                dgvVehiculos.Select()
                '
            End If
        Else
            MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default ' 
    End Sub
    Private Function LlenarVehiculos(ByVal strConexion As String, ByVal iProveeId As Integer) As DataSet
        Dim ds As New DataSet
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spListaVehiculos_ProveedorClientes", Cnn)
            '
            With cmd
                '
                param = New SqlParameter("@ProveedorClienteId", SqlDbType.Int)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = iProveeId                           '
                .Parameters.Add(param)
            End With
            '
            cmd.CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Vehiculos")       'llenar dataset
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

    Private Sub dgvVehiculos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVehiculos.CellDoubleClick
        If e.RowIndex >= 0 Then
            Me.txtDescripcion.Text = dgvVehiculos.Item(1, e.RowIndex).Value.ToString '
            Me.txtPlaca.Text = dgvVehiculos.Item(2, e.RowIndex).Value.ToString '
            Me.cboTipoVehiculo.SelectedValue = dgvVehiculos.Item(3, e.RowIndex).Value '
            iVehiculoId = dgvVehiculos.Item(4, e.RowIndex).Value
        End If
    End Sub

    Private Sub dgvVehiculos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvVehiculos.KeyPress
        Dim row As Integer
        row = dgvVehiculos.CurrentRow.Index
        If row > 0 Then
            Me.txtDescripcion.Text = dgvVehiculos.Item(1, row - 1).Value.ToString '
            Me.txtPlaca.Text = dgvVehiculos.Item(2, row - 1).Value.ToString '
            Me.cboTipoVehiculo.SelectedValue = dgvVehiculos.Item(3, row - 1).Value '
            iVehiculoId = dgvVehiculos.Item(4, row - 1).Value
        End If
    End Sub

    Private Sub txtDescripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If AscW(e.KeyChar) = 13 Then
            txtPlaca.Select()
            txtPlaca.Focus()
        End If
    End Sub


    Private Sub txtPlaca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPlaca.KeyPress
        If Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 8 Or Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        Else
            If AscW(e.KeyChar) = 13 Then
                btnAgregar.Focus()
            Else
                e.Handled = True
            End If
        End If

    End Sub
End Class