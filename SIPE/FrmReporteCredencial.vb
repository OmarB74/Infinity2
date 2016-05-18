Option Explicit On
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmReporteCredencial
    Public iProveedorClienteId As Integer
    Private Table As DataTable
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private Sub FrmReporteCredencial_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmReporteCredencial_Load(sender As Object, e As EventArgs) Handles Me.Load
        GeneraReporte()
    End Sub
    Private Sub GeneraReporte()
        Try

            Me.Cursor = Cursors.WaitCursor
            RptCredencialPF()
            'Me.GroupBox1.Visible = False
            Me.CrystalReportViewer1.Dock = DockStyle.Fill
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            MessageBox.Show(Err.Number & " - " & Err.Description, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Err.Clear()
        End Try
    End Sub
    Private Sub RptCredencialPF()
        Dim ds As DataSet
        Dim DS2 As DataSet
        ds = Rpte_listado(cstrConnectBDapp)
        If ds.Tables(0).Rows.Count > 0 Then
            Table = ds.Tables("Credencial").Copy
        Else
            MsgBox("NO EXISTE INFORMACION ACTUALMENTE", MsgBoxStyle.Information)
            Exit Sub
        End If
        '
        Dim lRpteImprimir As Object
        lRpteImprimir = New Global.INFINITY.rptCredencialProveedor
        DS2 = Rpt_L()
        '
        lRpteImprimir.SetDataSource(DS2) 'Esta DataSet es el que está en el PASO 3
        lRpteImprimir.Refresh()
        DS2.Dispose()
        CrystalReportViewer1.ReportSource = lRpteImprimir 'Se pasa el objeto instanciado al ReportSource del Visor de Reportes de Crystal
        CrystalReportViewer1.RefreshReport()

        'Try
        '    Dim lrptCredencial As rptCredencialProveedorCliente

        '    Dim crTables As Tables
        '    Dim crTable As Table
        '    Dim crTableLogOnInfo As TableLogOnInfo
        '    'Dim crLogOnInfo As CrystalDecisions.Shared.TableLogOnInfo

        '    Dim crConnectionInfo As New CrystalDecisions.Shared.ConnectionInfo
        '    'Parametros
        '    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        '    Dim crParameterFieldDefinition As ParameterFieldDefinition
        '    Dim crParameterValues As New ParameterValues
        '    ' Agrega los parametros para tus reportes 
        '    Dim crProveedorClienteId As New ParameterDiscreteValue
        '    '

        '    lrptCredencial = New rptCredencialProveedorCliente

        '    With crConnectionInfo
        '        .DatabaseName = pBD
        '        .ServerName = pServer
        '        .UserID = sUsuarioDB
        '        .Password = sPasswordUsuarioDB
        '    End With


        '    crTables = lrptCredencial.Database.Tables()

        '    For Each crTable In crTables
        '        crTableLogOnInfo = crTable.LogOnInfo
        '        crTableLogOnInfo.ConnectionInfo = crConnectionInfo
        '        crTable.ApplyLogOnInfo(crTableLogOnInfo)
        '    Next
        '    ' Asigna los valores a la parametros discretos del reporte.
        '    crProveedorClienteId.Value = iProveedorClienteId
        '    '
        '    crParameterFieldDefinitions = lrptCredencial.DataDefinition.ParameterFields

        '    '**************************************
        '    '**************************************
        '    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@ProveedorClienteId")
        '    crParameterValues = crParameterFieldDefinition.CurrentValues
        '    crParameterValues.Clear()
        '    crParameterValues.Add(crProveedorClienteId)
        '    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
        '    '
        '    'Muestra el reporte
        '    CrystalReportViewer1.ReportSource = lrptCredencial
        'Catch ex As Exception
        '    MessageBox.Show(Err.Number & " - " & Err.Description, "Error en " & Me.Name & "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Err.Clear()
        'End Try
    End Sub
    Private Function Rpte_listado(ByVal strconexion As String) As DataSet
        '
        Dim ds As New DataSet
        Try
            Cnn = New SqlConnection(strconexion)
            cmd = New SqlCommand("spCredencial_ProveedorClientePF", Cnn)
            With cmd
                .CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar

                param = New SqlParameter("@ProveedorClienteId", SqlDbType.Int)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = iProveedorClienteId        'asignar
                .Parameters.Add(param)
                '
            End With
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Credencial")       'llenar dataset
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
        Dim dat As New DataTable("Credencial")
        dat.Columns.Clear()
        '
        dat = Table
        daset.Tables.Add(dat)
        daset.WriteXmlSchema(My.Application.Info.DirectoryPath & "\Rpt_Credencial.xml") '
        dat.Dispose()
        Return daset
        '
    End Function
End Class