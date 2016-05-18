Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmPerfil
    Public iPerfilId As Integer = 0
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter

    Private Sub FrmPerfil_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bCerrarForma = True
    End Sub
    Private Sub FrmPerfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub
    Private Sub Limpiar()
        txtCodigo.Text = ""
        txtDescripcionPerfil.Text = ""
        iPerfilId = 0
        '
        CargaListaPerfiles()
        '
        txtCodigo.ReadOnly = False
        txtCodigo.Select()
        txtCodigo.Focus()
    End Sub
    Private Sub CargaListaPerfiles()
        Dim objDS As DataSet = Nothing
        '
        Windows.Forms.Cursor.Current = Cursors.WaitCursor ' Pon el relojito de arena
        objDS = LlenarPerfiles(cstrConnectBDapp)
        'Obtener informacion de clientes
        If objDS.Tables.Count > 0 Then
            If objDS.Tables(0).Rows.Count = 0 Then        'no existe registro de remitente
                MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dgvPerfiles.DataSource = objDS.Tables(0)
                dgvPerfiles.Columns.Item(0).Visible = False
                dgvPerfiles.Columns.Item(2).Width = 400
                dgvPerfiles.Select()
                '
            End If
        Else
            MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default ' 
    End Sub
    Private Function LlenarPerfiles(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spListaPerfiles", Cnn)
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
            da.Fill(ds, "Perfiles")       'llenar dataset
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
        If ValidaCamposPerfil(Me) Then
            Insertar_Actualizar_Perfil(Me, IIf(iPerfilId = 0, 1, 3))
            '
            Limpiar()
        End If
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Char.IsLetter(e.KeyChar) Or AscW(e.KeyChar) = 8 Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub dgvPerfiles_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPerfiles.CellDoubleClick
        If e.RowIndex >= 0 Then
            iPerfilId = dgvPerfiles.Item(0, e.RowIndex).Value '
            Me.txtCodigo.Text = dgvPerfiles.Item(1, e.RowIndex).Value.ToString '
            Me.txtDescripcionPerfil.Text = dgvPerfiles.Item(2, e.RowIndex).Value.ToString '
            '
            Me.txtDescripcionPerfil.Select()
            Me.txtDescripcionPerfil.Focus()
            '
            Me.txtCodigo.ReadOnly = True
        End If
    End Sub

    Private Sub dgvPerfiles_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvPerfiles.KeyPress
        Dim row As Integer
        row = dgvPerfiles.CurrentRow.Index
        '
        iPerfilId = dgvPerfiles.Item(0, row - 1).Value '
        Me.txtCodigo.Text = dgvPerfiles.Item(1, row - 1).Value.ToString '
        Me.txtDescripcionPerfil.Text = dgvPerfiles.Item(2, row - 1).Value.ToString '
        '
        Me.txtDescripcionPerfil.Select()
        Me.txtDescripcionPerfil.Focus()
        '
        Me.txtCodigo.ReadOnly = True
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If MsgBox("seguro que desea borrar el perfil: " & txtDescripcionPerfil.Text, vbYesNo) = vbYes Then
                If iPerfilId > 0 Then
                    Insertar_Actualizar_Perfil(Me, 2)
                    '
                    Limpiar()
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        bCerrarForma = True
        Me.Close()
    End Sub
End Class