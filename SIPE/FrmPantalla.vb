Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmPantalla
    Public iPantallaId As Integer = 0
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private bNuevo As Boolean = False
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If ValidaCamposPantalla(Me) Then
            If bNuevo Then
                Insertar_Actualizar_Pantalla(Me, 1)
            Else
                Insertar_Actualizar_Pantalla(Me, 3)
            End If
            '
            Limpiar()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
    End Sub
    Private Sub Limpiar()
        txtCodigoPantalla.Text = ""
        txtNombrePantalla.Text = ""
        txtPantalla.Text = ""
        txtLigaPantalla.Text = ""
        cboTipoPantalla.SelectedIndex = 0
        txtCodigoPantalla.Enabled = True
        txtNombrePantalla.Enabled = True
        txtPantalla.Enabled = True
        txtLigaPantalla.Enabled = True
        cboTipoPantalla.Enabled = True
        '
        CargaPantallas()
        '
        bNuevo = True
        '
        txtCodigoPantalla.Select()
        txtCodigoPantalla.Focus()
    End Sub

    Private Sub FrmPantalla_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bCerrarForma = True
    End Sub

    Private Sub FrmPantalla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub CargaPantallas()
        Dim objDS As DataSet = Nothing
        '
        Windows.Forms.Cursor.Current = Cursors.WaitCursor ' Pon el relojito de arena
        objDS = LlenarPantallas(cstrConnectBDapp)
        'Obtener informacion de clientes
        If objDS.Tables.Count > 0 Then
            If objDS.Tables(0).Rows.Count = 0 Then        'no existe registro de remitente
                MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dgvPantallas.DataSource = objDS.Tables(0)
                'dgvPantallas.Columns.Item(0).Visible = False
                'dgvPantallas.Columns.Item(6).Visible = False
                'dgvPantallas.Columns.Item(7).Visible = False
                dgvPantallas.Select()
                '
            End If
        Else
            MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default ' 
    End Sub
    Private Function LlenarPantallas(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spListaPantallas", Cnn)
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
            da.Fill(ds, "Pantallas")       'llenar dataset
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        bCerrarForma = True
        Me.Close()
    End Sub

    Private Sub dgvPantallas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPantallas.CellDoubleClick
        If e.RowIndex >= 0 Then
            'iProductoId = dgvPantallas.Item(0, e.RowIndex).Value '
            Me.txtCodigoPantalla.Text = dgvPantallas.Item(0, e.RowIndex).Value.ToString '
            Me.txtNombrePantalla.Text = dgvPantallas.Item(1, e.RowIndex).Value.ToString '
            Me.txtPantalla.Text = dgvPantallas.Item(2, e.RowIndex).Value.ToString '
            Me.cboTipoPantalla.SelectedItem = dgvPantallas.Item(3, e.RowIndex).Value '
            Me.txtLigaPantalla.Text = dgvPantallas.Item(4, e.RowIndex).Value.ToString
            '
            BloqueaCampos()
            '
            bNuevo = False
        End If
    End Sub
    Private Sub BloqueaCampos()
        Me.txtCodigoPantalla.Enabled = False
        Me.txtPantalla.Enabled = False
        cboTipoPantalla.Enabled = False
    End Sub

    Private Sub dgvPantallas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvPantallas.KeyPress
        Dim row As Integer
        row = dgvPantallas.CurrentRow.Index
        If row > 0 Then
            Me.txtCodigoPantalla.Text = dgvPantallas.Item(0, row - 1).Value.ToString '
            Me.txtNombrePantalla.Text = dgvPantallas.Item(1, row - 1).Value.ToString '
            Me.txtPantalla.Text = dgvPantallas.Item(2, row - 1).Value.ToString '
            Me.cboTipoPantalla.SelectedItem = dgvPantallas.Item(3, row - 1).Value.ToString '
            Me.txtLigaPantalla.Text = dgvPantallas.Item(4, row - 1).Value.ToString
            '
            BloqueaCampos()
            '
            bNuevo = False
        End If
    End Sub

    Private Sub txtCodigoPantalla_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoPantalla.KeyPress
        If AscW(e.KeyChar) = 13 Then
            txtNombrePantalla.Select()
            txtNombrePantalla.Focus()
        End If
    End Sub
End Class