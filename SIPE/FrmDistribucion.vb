Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmDistribucion
    Dim objSucursal As New cSucursal
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private ds As New DataSet
    Private Sub FrmDistribucion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarComboSucursal(cboSucursal, cstrConnectBDapp)
    End Sub
    '
    Private Sub LlenarComboSucursal(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objSucursal.Obtener_Sucursal(strConexion).Tables("Sucursales")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "SucursalId"
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargaVentasSucursal
    End Sub
    Private Sub CargaVentasSucursal()
        '
        'Limpia el Grid
        Me.dgvNotasDisponibles.DataSource = Nothing
        Me.dgvNotasDisponibles.Rows.Clear()
        '
        Try
            ' Se va a conectar a la base al servidor establecido y login establecido para la aplicacion            
            Cnn = New SqlConnection(cstrConnectBDapp)
            cmd = New SqlCommand("exec spListaNotasDispersion '" & dtpFecha.Value.ToShortDateString & "'," & cboSucursal.SelectedValue & "", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "NotasSucursalDia")       'llenar dataset
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
                dgvNotasDisponibles.Columns.Clear()
                dgvNotasDisponibles.DataSource = Nothing
                dgvNotasDisponibles.DataSource = ds.Tables(0)
                With Me.dgvNotasDisponibles
                    .Columns("Nota_Total").DefaultCellStyle.Format = "c"
                    .Columns("Nota_Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Columns("Nombre_Usuario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Columns("UsuarioId").Visible = False
                End With
                '
                SumaTotalDisponibles()
                'Clonar estructura
                CloneDGV()
                '
                dgvNotasDisponibles.Select()
            End If
        End If
    End Sub
    Private Sub SumaTotalDisponibles()
        Dim total As Double = 0
        Dim iTotal As Integer = Me.dgvNotasDisponibles.Rows.Count
        '
        Dim i As Integer
        '
        For i = 0 To iTotal - 1
            total = total + Double.Parse(Me.dgvNotasDisponibles(0, i).Value)
        Next
        '
        lbTotalDisponibles.Text = Format(total, "$ #,##0.00")
    End Sub
    Private Sub SumaTotalNotasAgregadas()
        Dim total As Double = 0
        Dim iTotal As Integer = Me.dgvNotasAgregadas.Rows.Count
        '
        Dim i As Integer
        '
        For i = 0 To iTotal - 1
            total = total + Double.Parse(Me.dgvNotasAgregadas(0, i).Value)
        Next
        '
        LbAgregadas.Text = Format(total, "$ #,##0.00")
    End Sub

    Private Sub btnAddDocto_Click(sender As Object, e As EventArgs) Handles btnAddDocto.Click
        MoverSeleccionadosDGV1aDGV2()
        '
        dgvNotasAgregadas.Columns("Nota_Total").DefaultCellStyle.Format = "C"
        '
        SumaTotalDisponibles()
    End Sub
    Private Sub MoverSeleccionadosDGV1aDGV2()
        Try
            'Para cada fila seleccionada
            For Each Seleccion As DataGridViewRow In dgvNotasDisponibles.SelectedRows
                'Añadir los valores obtenidos de la fila seleccionada
                'al segundo datagridview
                Me.dgvNotasAgregadas.Rows.Add(ObtenerValoresFila(Seleccion))
                'eliminar la fila del DataGridView origen
                dgvNotasDisponibles.Rows.Remove(Seleccion)
                '
            Next
            '
            SumaTotalNotasAgregadas()
        Catch ex As Exception
            MsgBox(ex.Source & "-" & ex.Message)
        End Try
    End Sub
    Function ObtenerValoresFila(ByVal fila As DataGridViewRow) As String()
        'Dimensionar el array al tamaño de columnas del DGV
        Dim Contenido(Me.dgvNotasDisponibles.ColumnCount - 1) As String
        'Rellenar el contenido con el valor de las celdas de la fila
        For Ndx As Integer = 0 To Contenido.Length - 1
            Contenido(Ndx) = fila.Cells(Ndx).Value
        Next
        Return Contenido
    End Function
    Private Sub CloneDGV()
        Dim x As Integer
        'Reproducir la estructura del 1er dataGrid en DataGridView2
        Me.dgvNotasAgregadas.ColumnCount = Me.dgvNotasDisponibles.ColumnCount
        For x = 0 To Me.dgvNotasDisponibles.ColumnCount - 1
            Me.dgvNotasAgregadas.Columns(x).Name = Me.dgvNotasDisponibles.Columns(x).Name
            Me.dgvNotasAgregadas.Columns(x).HeaderText = Me.dgvNotasDisponibles.Columns(x).HeaderText
        Next
        '
        With Me.dgvNotasAgregadas
            .Columns("Nota_Total").DefaultCellStyle.Format = "c"
            .Columns("Nota_Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Nombre_Usuario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("UsuarioId").Visible = False
        End With
    End Sub

    Private Sub btnRemoveDoc_Click(sender As Object, e As EventArgs) Handles btnRemoveDoc.Click
        MoverSeleccionadosDGV2aDGV1()
        '
        SumaTotalDisponibles()
        '
        SumaTotalNotasAgregadas()
    End Sub
    Private Sub MoverSeleccionadosDGV2aDGV1()
        'Para cada fila seleccionada
        For Each Seleccion As DataGridViewRow In dgvNotasAgregadas.SelectedRows
            'Añadir los valores obtenidos de la fila seleccionada
            'al segundo datagridview
            Me.ds.Tables(0).Rows.Add(ObtenerValoresFila(Seleccion))
            'eliminar la fila del DataGridView origen
            dgvNotasAgregadas.Rows.Remove(Seleccion)
        Next
    End Sub

    Private Sub BtnGenerar_Click(sender As Object, e As EventArgs) Handles BtnGenerar.Click
        If Me.dgvNotasAgregadas.Rows.Count > 0 Then

            Select Case MsgBox("Esta seguro(a) de generar la dispersion", vbYesNo)
                Case vbYes
                    GeneraDispersion()
            End Select
        Else

        End If
    End Sub
    Private Sub GeneraDispersion()

    End Sub
End Class