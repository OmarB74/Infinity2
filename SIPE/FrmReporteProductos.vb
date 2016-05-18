Option Explicit On
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmReporteProductos
    Private Table As DataTable
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Sub FrmReporteProductos_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmReporteProductos_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        'LlenaCombosStatus = False
        ''LlenaCombo()
        'LlenaCombosStatus = True
        '
    End Sub
   
    Public Sub LlenarCboTipoPrecio(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        objCombobox.DataSource = Obtener_Precios(strConexion).Tables("Precios")
        objCombobox.DisplayMember = "Descripcion_Tipo_Precio"
        objCombobox.ValueMember = "TipoPrecioId"
    End Sub
   
    Private Sub GeneraReporte()
        Dim ds As DataSet
        Dim DS2 As DataSet
        ds = Rpte_listado(cstrConnectBDapp)
        If ds.Tables(0).Rows.Count > 0 Then
            Table = ds.Tables("CatalogoProductos").Copy
        Else
            MsgBox("NO EXISTE INFORMACION ACTUALMENTE", MsgBoxStyle.Information)
            Exit Sub
        End If
        '
        Dim lRpteImprimir As Object
        lRpteImprimir = New rptCatalogoProductos
        DS2 = Rpt_L()
        '
        lRpteImprimir.SetDataSource(DS2) 'Esta DataSet es el que está en el PASO 3
        lRpteImprimir.Refresh()
        DS2.Dispose()
        CrystalReportViewer1.ReportSource = lRpteImprimir 'Se pasa el objeto instanciado al ReportSource del Visor de Reportes de Crystal
        CrystalReportViewer1.RefreshReport()
    End Sub
   
    Private Function Rpte_listado(ByVal strconexion As String) As DataSet
        '
        Dim ds As New DataSet
        Try
            Cnn = New SqlConnection(strconexion)
            cmd = New SqlCommand("spReporteProductos", Cnn)
            'With cmd
            '    .CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
            '    '
            '    param = New SqlParameter("@UserId", SqlDbType.Int)
            '    param.Direction = ParameterDirection.Input      'parametro entrada
            '    param.Value = id_teller        'asignar
            '    .Parameters.Add(param)
            '    '
            '    param = New SqlParameter("@SucursalId", SqlDbType.Int)
            '    param.Direction = ParameterDirection.Input      'parametro entrada
            '    param.Value = Id_Sucursal        'asignar
            '    .Parameters.Add(param)
            '    '
            '    param = New SqlParameter("@FechaInicial", SqlDbType.SmallDateTime)
            '    param.Direction = ParameterDirection.Input      'parametro entrada
            '    param.Value = Format(Me.dtpFechaInicial.Value, "dd/MM/yyyy 00:00:00")        'asignar
            '    .Parameters.Add(param)
            '    '
            '    param = New SqlParameter("@FechaFinal", SqlDbType.SmallDateTime)
            '    param.Direction = ParameterDirection.Input      'parametro entrada
            '    param.Value = Format(Me.dtpFechaFinal.Value, "dd/MM/yyyy 23:59:00")        'asignar
            '    .Parameters.Add(param)
            '    '
            'End With
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "CatalogoProductos")       'llenar dataset
        Catch ex As SqlException
            MsgBox(ex.Message)
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
        Return ds 'regresar dataset
    End Function
    Private Function Rpt_L() As DataSet
        Dim daset As New DataSet
        Dim dat As New DataTable("CatalogoProductos")
        dat.Columns.Clear()
        '
        dat = Table
        daset.Tables.Add(dat)
        daset.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Rpt_CatalogoProductos.xml") '
        dat.Dispose()
        Return daset
        '
    End Function

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If rbGeneral.Checked Then
            GeneraReporte()
        End If
        
    End Sub

    'Private Sub GenerareportePrecios()
    '    Dim ds As DataSet
    '    Dim DS2 As DataSet
    '    ds = Rpte_listadoPrecios(cstrConnectBDapp, iTipoPrecioSel)
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Table = ds.Tables("ProductosPrecios").Copy
    '    Else
    '        MsgBox("NO EXISTE INFORMACION ACTUALMENTE", MsgBoxStyle.Information)
    '        Exit Sub
    '    End If
    '    '
    '    Dim lRpteImprimir As Object
    '    lRpteImprimir = New rptCatalogoProductosXPrecio
    '    DS2 = Rpt_LP()
    '    '
    '    lRpteImprimir.SetDataSource(DS2) 'Esta DataSet es el que está en el PASO 3
    '    lRpteImprimir.Refresh()
    '    DS2.Dispose()
    '    CrystalReportViewer1.ReportSource = lRpteImprimir 'Se pasa el objeto instanciado al ReportSource del Visor de Reportes de Crystal
    '    CrystalReportViewer1.RefreshReport()
    'End Sub
    Private Function Rpte_listadoPrecios(ByVal strconexion As String, iTipoPrecioId As Integer) As DataSet
        '
        Dim ds As New DataSet
        Try
            Cnn = New SqlConnection(strconexion)
            cmd = New SqlCommand("spReporteProductosxPrecios", Cnn)
            With cmd
                .CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
                '
                param = New SqlParameter("@TipoPrecioId", SqlDbType.Int)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = iTipoPrecioId        'asignar
                .Parameters.Add(param)
            End With
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "ProductosPrecios")       'llenar dataset
        Catch ex As SqlException
            MsgBox(ex.Message)
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
        Return ds 'regresar dataset
    End Function
    Private Function Rpt_LP() As DataSet
        Dim daset As New DataSet
        Dim dat As New DataTable("ProductosPrecios")
        dat.Columns.Clear()
        '
        dat = Table
        daset.Tables.Add(dat)
        daset.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Rpt_ProductosPrecios.xml") '
        dat.Dispose()
        Return daset
        '
    End Function

    'Private Sub cboPrecios_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If LlenaCombosStatus Then
    '        iTipoPrecioSel = cboPrecios.SelectedValue
    '    End If
    'End Sub
End Class