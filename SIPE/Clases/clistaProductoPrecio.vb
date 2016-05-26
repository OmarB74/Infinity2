Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class clistaProductoPrecio
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter

    Public Sub Insertar_Actualizar_LPP(ByVal LPP As FrmListaProductoPrecio, iAccion As Integer, iIdentificador As Integer)
        Dim Transaccion As SqlTransaction = Nothing
        Dim TempProdId As Integer
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            With LPP
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spListaProductoPrecio"
                '
                cmd.CommandType = CommandType.StoredProcedure
                If iIdentificador = 0 Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@IdentificadorId", 0))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 1))
                Else
                    If iIdentificador > 0 And iAccion = 2 Then
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@IdentificadorId", iIdentificador))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 2))
                    Else
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@IdentificadorId", iIdentificador))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 3))
                    End If
                End If
                cmd.Parameters.Add(New SqlClient.SqlParameter("@CodigoBarras", .txtCodigoBarras.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Precio", .txtPrecio.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ProductoId", .cboProducto.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@MedidaId", .cboMedida.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@PesoId", .cboPeso.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ListaId", .cboListaPrecios.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@RellenoId", .cboTipoRelleno.SelectedValue))
                '
                cmd.Transaction = Transaccion

                If iIdentificador = 0 And iAccion = 1 Then
                    Dim read As SqlDataReader = cmd.ExecuteReader()
                    read.Read()
                    TempProdId = CInt(read(0))
                    MsgBox("Datos de Producto registrados con exito")
                    read.Close()
                Else
                    If iAccion = 2 Then
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Producto dados de baja con exito")
                    Else
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Producto actualizado con exito")
                    End If
                End If
            End With

            cmd.Dispose()
            Transaccion.Commit()
            If iAccion = 1 Then
                LPP.txtIdentificadorId.Text = TempProdId
            End If
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
