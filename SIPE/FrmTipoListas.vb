Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmTipoListas
    Public iListaId As Integer = 0
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private ABMTipoListas As New cTipoListas
    Private Sub FrmTipoListas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub Limpiar()
        Me.txtListaId.Text = ""
        Me.txtDescripcion.Text = ""
        iListaId = 0
        CargaDatosListas()
    End Sub
    Private Sub CargaDatosListas()
        Dim objDS As DataSet = Nothing
        '
        Windows.Forms.Cursor.Current = Cursors.WaitCursor ' Pon el relojito de arena
        objDS = LlenarGrid(cstrConnectBDapp)
        'Obtener informacion de clientes
        If objDS.Tables.Count > 0 Then
            If objDS.Tables(0).Rows.Count = 0 Then        'no existe registro
                MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dgvListas.DataSource = objDS.Tables(0)
                dgvListas.Columns.Item(0).Visible = False
                dgvListas.Columns.Item(1).Width = 200
                dgvListas.Select()
                '
            End If
        Else
            MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default ' 
    End Sub
    Private Function LlenarGrid(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spTipoListas", Cnn)
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
            da.Fill(ds, "TipoListas")       'llenar dataset
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ABMTipoListas.ABMListas(Me, IIf(iListaId = 0, 1, 3))
        '
        Limpiar()
    End Sub


    Private Sub dgvListas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvListas.CellDoubleClick
        If e.RowIndex >= 0 Then
            iListaId = dgvListas.Item(0, e.RowIndex).Value '
            Me.txtListaId.Text = dgvListas.Item(0, e.RowIndex).Value '
            Me.txtDescripcion.Text = dgvListas.Item(1, e.RowIndex).Value.ToString '
        End If
    End Sub

    Private Sub dgvListas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvListas.KeyPress
        Dim row As Integer
        row = dgvListas.CurrentRow.Index
        If row > 0 Then
            'Me.txtDescripcion.Text = dgvVehiculos.Item(1, row - 1).Value.ToString '
            iListaId = dgvListas.Item(0, row - 1).Value '
            Me.txtListaId.Text = dgvListas.Item(0, row - 1).Value '
            Me.txtDescripcion.Text = dgvListas.Item(1, row - 1).Value.ToString '
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

    End Sub
End Class