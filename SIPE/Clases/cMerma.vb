Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class cMerma
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Public Sub GuardaMerma(ByVal frmMerma As FrmMermas)
        Dim Transaccion As SqlTransaction = Nothing
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            With frmMerma
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spGuardaMerma"
                '
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ProdcutoId", .cboProducto.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Cantidad", .txtCantidad.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@UnidadId", .cboUnidad.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@UsuarioId", iUsuario))
                '
                cmd.Transaction = Transaccion
                '
                cmd.ExecuteNonQuery()
                MsgBox("Datos de Merma guardados con exito")
            End With
            '
            cmd.Dispose()
            Transaccion.Commit()
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Sub

End Class
