Option Explicit On
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmRptComanda
    Private Table As DataTable
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Public iEntradaIdR As Integer

    Private Sub FrmRptComanda_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub
    Private Sub FrmRptComanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GeneraReporte()
    End Sub
    Private Sub GeneraReporte()
        Dim ds As DataSet
        Dim DS2 As DataSet
        ds = Rpte_listado(cstrConnectBDapp)
        If ds.Tables(0).Rows.Count > 0 Then
            Table = ds.Tables("Comanda").Copy
        Else
            MsgBox("NO EXISTE INFORMACION ACTUALMENTE", MsgBoxStyle.Information)
            Exit Sub
        End If
        '
        Dim lRpteImprimir As Object
        lRpteImprimir = New rptComanda
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
            cmd = New SqlCommand("spReporteComanda", Cnn)
            With cmd
                .CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar

                param = New SqlParameter("@EntradaId", SqlDbType.Int)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = iEntradaIdR        'asignar
                .Parameters.Add(param)
                '
            End With
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Comanda")       'llenar dataset
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
        Dim dat As New DataTable("Comanda")
        dat.Columns.Clear()
        '
        dat = Table
        daset.Tables.Add(dat)
        daset.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Rpt_Comanda.xml") '
        dat.Dispose()
        Return daset
        '
    End Function
End Class