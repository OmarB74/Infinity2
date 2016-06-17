Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmVentanilla
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Subtotal As Decimal
    Private Iva As Decimal

    Private Sub FrmVentanilla_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F4 Then
            LimpiarCampos()
        End If
        If e.KeyCode = Keys.F2 Then
            btnBuscar_Click(sender, e)
        End If
        If e.KeyCode = Keys.F5 Then
            btnGuardar_Click(sender, e)
        End If
    End Sub
    Private Sub FrmVentanilla_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AgregaColumnas()
        '
        txtVendedor.Text = NombreUsuario
        txtCodigoBarras.Select()
        txtCodigoBarras.Focus()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If Trim(txtCodigoBarras.Text) = "" And Len(txtCodigoBarras.Text) = 0 Then
            'sCodigodeBarras = ""
            sCodigoProducto = ""
            sCodigoBarrasV = ""
            bRealizaBusquedaVentanilla = True
            Dim frmbusqueda As New FrmBusquedaListaProductoPrecio
            frmbusqueda.ShowDialog()
            If bRealizarBusqueda Then
                '
                Dim frmELPP As New FrmEncontradosListaProductoPrecio

                frmELPP.ShowDialog()
                If iLPPBusqueda > 0 Then
                    txtCodigoBarras.Text = sCodigoBarrasV
                    txtCantidad.Focus()
                    'CargaProducto(txtCantidad.Text)
                End If
            End If
        Else
            If Len(txtCantidad.Text) = 0 Then
                txtCantidad.Text = "0"
            End If
            CargaProducto(txtCantidad.Text)
        End If
        bRealizaBusquedaVentanilla = False
    End Sub
    Private Sub CargaProducto(icantidad As Integer)
        Dim objDS As DataSet = Nothing
        '
        Windows.Forms.Cursor.Current = Cursors.WaitCursor ' Pon el relojito de arena
        objDS = BuscaProducto()
        If objDS.Tables.Count > 0 Then
            If objDS.Tables(0).Rows.Count = 0 Then        'no existe registro
                MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' 
                If icantidad = 0 Then
                    icantidad = 1
                End If
                Dim RenglonGrid As Object() = {objDS.Tables(0).Rows(0).Item(0).ToString, objDS.Tables(0).Rows(0).Item(1).ToString, objDS.Tables(0).Rows(0).Item(2).ToString, CDbl(objDS.Tables(0).Rows(0).Item(3).ToString) * icantidad, icantidad, objDS.Tables(0).Rows(0).Item(4).ToString, objDS.Tables(0).Rows(0).Item(5).ToString, objDS.Tables(0).Rows(0).Item(6).ToString}
                'Agregamos a una fila del DataGridView el objeto del tipo ParamArray
                dgvVentanilla.Rows.Add(RenglonGrid)
                '
                dgvVentanilla.Select()
                '
                dgvVentanilla.ScrollBars = ScrollBars.Both
                '
                CalculaSubTotal()
                '
                txtCodigoBarras.Text = ""
                txtCantidad.Text = ""
            End If
        Else
            MessageBox.Show("NO SE ENCONTRO INFORMACION", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default ' 
    End Sub

    Private Function BuscaProducto() As DataSet
        Dim ds As New DataSet
        Dim iTipoBusqueda As Int16
        iTipoBusqueda = 4
        sCodigodeBarras = Me.txtCodigoBarras.Text
        Try
            '
            Cnn = New SqlConnection(cstrConnectBDapp)
            cmd = New SqlCommand("spBusquedaListaProductoPrecio", Cnn)
            cmd.CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
            '
            With cmd
                '
                param = New SqlParameter("@TipoBusqueda", SqlDbType.Int)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = iTipoBusqueda                           '
                .Parameters.Add(param)
                '
                param = New SqlParameter("@CodigoProducto", SqlDbType.VarChar, 50)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = sCodigoProducto                           '
                .Parameters.Add(param)
                '
                param = New SqlParameter("@Producto", SqlDbType.VarChar, 250)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = sProducto                           '
                .Parameters.Add(param)
                '
                param = New SqlParameter("@CodigodeBarras", SqlDbType.VarChar, 50)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = sCodigodeBarras                           '
                .Parameters.Add(param)

            End With
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

    Private Sub txtCodigoBarras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigoBarras.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnBuscar_Click(sender, e)
        End If
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        '
        Me.txtCodigoBarras.Text = Trim(Replace(Me.txtCodigoBarras.Text, "  ", " "))
        '
        txtCodigoBarras.Select(txtCodigoBarras.Text.Length, 0)
    End Sub

    Private Sub CalculaSubTotal()
        Me.Subtotal = 0
        '
        ' Recorre el datagrid
        For Each lDataRow As DataGridViewRow In dgvVentanilla.Rows
            '
            ' Suma la columna de monto.
            If IsNumeric(lDataRow.Cells(3).Value) Then
                Me.Subtotal += CDec(lDataRow.Cells(3).Value)
            End If
        Next
        '
        ' Agrega el subtotal a la caja de texto.
        Me.txtTotal.Text = "$" & FormatNumber(Me.Subtotal, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)
    End Sub

    Private Sub AgregaColumnas()
        '/************DataGridView************/
        'Creamos los encabezados para el DGV 
        dgvVentanilla.Columns.Clear() 'Limpiamos todas las colecciones del DataGridView
        With dgvVentanilla
            .AutoGenerateColumns = False
            .EditMode = DataGridViewEditMode.EditOnEnter
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
            '
            Dim IdentificadorId As New DataGridViewTextBoxColumn
            With IdentificadorId
                .DataPropertyName = "IdentificadorId"
                .HeaderText = "IdentificadorId"
                .MaxInputLength = 10
                .Width = 0
                .Visible = False
            End With
            .Columns.Add(IdentificadorId)

            Dim CodigoBarras As New DataGridViewTextBoxColumn
            With CodigoBarras
                .DataPropertyName = "CodigoBarras"
                .HeaderText = "Codigo de Barras"
                .MaxInputLength = 35
                .Width = 35
            End With
            .Columns.Add(CodigoBarras)

            Dim Producto As New DataGridViewTextBoxColumn
            With Producto
                .DataPropertyName = "Producto"
                .HeaderText = "Producto"
                .MaxInputLength = 250
                .Width = 200
            End With
            .Columns.Add(Producto)

            Dim Precio As New DataGridViewTextBoxColumn
            With Precio
                .DataPropertyName = "Precio"
                .HeaderText = "Precio"
                .MaxInputLength = 35
                .Width = 124
            End With
            .Columns.Add(Precio)
            '
            Dim Cantidad As New DataGridViewTextBoxColumn
            With Cantidad
                .DataPropertyName = "Cantidad"
                .HeaderText = "Cantidad"
                .MaxInputLength = 10
                .Width = 10
            End With
            .Columns.Add(Cantidad)
            '

            Dim Contenido As New DataGridViewTextBoxColumn
            With Contenido
                .DataPropertyName = "Contenido"
                .HeaderText = "Contenido"
                .MaxInputLength = 35
                .Width = 124
            End With
            .Columns.Add(Contenido)

            Dim Peso As New DataGridViewTextBoxColumn
            With Peso
                .DataPropertyName = "Peso"
                .HeaderText = "Peso"
                .MaxInputLength = 10
                .Width = 15
            End With
            .Columns.Add(Peso)

            Dim Linea As New DataGridViewTextBoxColumn
            With Linea
                .DataPropertyName = "Linea"
                .HeaderText = "Tipo Linea"
                .MaxInputLength = 100
                .Width = 70
            End With
            .Columns.Add(Linea)
            '
        End With
    End Sub
    Private Sub LimpiarCampos()
        '
        dgvVentanilla.Rows.Clear()
        txtCodigoBarras.Text = ""
        txtCantidad.Text = ""
        txtTotal.Text = ""
        txtCodigoBarras.Select()
        txtCodigoBarras.Focus()
        bRealizaBusquedaVentanilla = False
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            btnBuscar_Click(sender, e)
        End If
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSymbol(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
        '
        Me.txtCantidad.Text = Trim(Replace(Me.txtCantidad.Text, "  ", " "))
        '
        txtCantidad.Select(txtCantidad.Text.Length, 0)
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If Me.dgvVentanilla.Rows.Count > 0 Then
            '
            XMLNotaVentaDetalle = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & "?>" & vbCrLf
            XMLNotaVentaDetalle &= "<Nota>" & vbCrLf
            XMLNotaVentaDetalle &= Genera_Detalle_XML(dgvVentanilla, "NotaDetalle")
            XMLNotaVentaDetalle &= "</Nota>"
            '
            Dim frmCobro As New FrmCajaPago
            frmCobro.dImporte = txtTotal.Text
            bRealizarCobro = False
            frmCobro.ShowDialog()
            If bRealizarCobro Then
                If iNotaId > 0 Then

                End If
                '
                LimpiarCampos()
            End If
        End If
    End Sub
    Private Function Genera_Detalle_XML(ByVal DataGV As DataGridView, ByVal Tabla As String) As String
        Dim str_XML As String = ""
        Dim i As Int16, j As Int16
        Dim campo As String, valor As String
        For i = 0 To DataGV.Rows.Count - 1
            If i > 0 Then
                str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
            Else
                str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
            End If
            For j = 0 To DataGV.Columns.Count - 1
                campo = DataGV.Columns.Item(j).DataPropertyName.ToString
                If campo <> "" Then
                    valor = IIf(DataGV.Item(j, i).Value Is DBNull.Value, "", DataGV.Item(j, i).Value)
                    str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
                End If
            Next
            str_XML &= "/>"
        Next
        Return str_XML
    End Function

    Private Sub txtCodigoBarras_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoBarras.TextChanged

    End Sub
End Class