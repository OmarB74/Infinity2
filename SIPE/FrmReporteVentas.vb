Option Explicit On
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmReporteVentas
    Private Table As DataTable
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Dim objSucursal As New cSucursal
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        GeneraReporte()
    End Sub

    Private Sub FrmReporteVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarComboSucursal(cboSucursal, cstrConnectBDapp)
        '
        dtpFecha.Value = Now
    End Sub

    Private Sub FrmReporteVentas_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub GeneraReporte()
        Dim ds As DataSet
        Dim DS2 As DataSet
        ds = Rpte_listado(cstrConnectBDapp)
        If ds.Tables(0).Rows.Count > 0 Then
            Table = ds.Tables("Ventas").Copy
        Else
            MsgBox("NO EXISTE INFORMACION ACTUALMENTE", MsgBoxStyle.Information)
            Exit Sub
        End If
        '
        Dim lRpteImprimir As Object
        lRpteImprimir = New RptVentasXFecha
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
            cmd = New SqlCommand("spVentasXFecha", Cnn)
            With cmd
                .CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
                '
                param = New SqlParameter("@Fecha", SqlDbType.VarChar, 10)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = dtpFecha.Value.ToShortDateString       'asignar
                .Parameters.Add(param)
                '
                param = New SqlParameter("@SucursalId", SqlDbType.Int)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = cboSucursal.SelectedValue        'asignar
                .Parameters.Add(param)
            End With
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Ventas")       'llenar dataset
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
        Dim dat As New DataTable("Ventas")
        dat.Columns.Clear()
        '
        dat = Table
        daset.Tables.Add(dat)
        daset.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Rpt_Ventas.xml") '
        dat.Dispose()
        Return daset
        '
    End Function
    '
    Private Sub LlenarComboSucursal(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objSucursal.Obtener_Sucursal(strConexion).Tables("Sucursales")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "SucursalId"
    End Sub
End Class