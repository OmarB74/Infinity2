Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class FrmLiberaProductoSucursal
    Dim objSucursal As New cSucursal
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Private llenocbo As Boolean = False
    Private Sub FrmLiberaProductoSucursal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarComboSucursal(cboSucursal, cstrConnectBDapp)
        CargaProductosSucursal()
        llenocbo = True
    End Sub
    '
    Private Sub LlenarComboSucursal(ByVal objCombobox As ComboBox, ByVal strConexion As String)
        'llenar combobox
        objCombobox.DataSource = objSucursal.Obtener_Sucursal(strConexion).Tables("Sucursales")
        objCombobox.DisplayMember = "Descripcion"
        objCombobox.ValueMember = "SucursalId"
    End Sub
    Private Sub CargaProductosSucursal()
        Dim ds As New DataSet
        '
        'Limpia el Grid
        Me.dgvProductoSucursal.DataSource = Nothing
        Me.dgvProductoSucursal.Rows.Clear()
        '
        Try
            ' Se va a conectar a la base al servidor establecido y login establecido para la aplicacion            
            Cnn = New SqlConnection(cstrConnectBDapp)
            cmd = New SqlCommand("exec spListaProductoSucursalPorLiberar " & cboSucursal.SelectedValue & "", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "ProductosSucursal")       'llenar dataset
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
                dgvProductoSucursal.Columns.Clear()
                dgvProductoSucursal.DataSource = Nothing
                dgvProductoSucursal.DataSource = ds.Tables(0)
                dgvProductoSucursal.Select()
            End If
        End If
    End Sub

    Private Sub cboSucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSucursal.SelectedIndexChanged
        If llenocbo Then
            CargaProductosSucursal()
        End If
    End Sub
End Class