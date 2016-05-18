Option Explicit On
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmReimpresionComanda
    Private Table As DataTable
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If Trim(txtFolioComanda.Text) <> "" Then
            GeneraReporte()
        End If
    End Sub
    Private Sub GeneraReporte()
        Dim ds As DataSet
        Dim DS2 As DataSet
        ds = Rpte_listado(cstrConnectBDapp)
        If ds.Tables(0).Rows.Count > 0 Then
            Table = ds.Tables("Nota").Copy
        Else
            MsgBox("NO EXISTE INFORMACION ACTUALMENTE", MsgBoxStyle.Information)
            Exit Sub
        End If
        '
        Dim lRpteImprimir As Object
        lRpteImprimir = New rptNota
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
            cmd = New SqlCommand("spReporteNota", Cnn)
            With cmd
                .CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar

                param = New SqlParameter("@Codigo", SqlDbType.VarChar, 15)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = txtFolioComanda.Text        'asignar
                .Parameters.Add(param)
                '
            End With
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Nota")       'llenar dataset
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
        Dim dat As New DataTable("Nota")
        dat.Columns.Clear()
        '
        dat = Table
        daset.Tables.Add(dat)
        daset.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Rpt_Nota.xml") '
        dat.Dispose()
        Return daset
        '
    End Function

    Private Sub txtFolioComanda_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtFolioComanda.KeyPress
        If Char.IsNumber(e.KeyChar) Or AscW(e.KeyChar) = 8 Then

            e.Handled = False
        Else

            e.Handled = True
        End If
    End Sub
End Class