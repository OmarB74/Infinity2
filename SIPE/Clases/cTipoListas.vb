Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class cTipoListas
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Public Sub ABMListas(ByVal Listas As FrmTipoListas, iAccion As Integer)
        Dim Transaccion As SqlTransaction = Nothing
        Dim TempListaId As Integer
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            With Listas
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spABMTipoListaProductos"
                '
                cmd.CommandType = CommandType.StoredProcedure
                If iAccion = 1 Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@ListaId", 0))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 1))
                Else
                    If iAccion = 3 Then
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@ProductoId", .txtListaId.Text))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 3))
                    Else
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@ProductoId", .txtListaId.Text))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 2))
                    End If
                End If
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Descripcion", .txtDescripcion.Text))
                '
                cmd.Transaction = Transaccion

                If iAccion = 1 Then
                    Dim read As SqlDataReader = cmd.ExecuteReader()
                    read.Read()
                    TempListaId = CInt(read(0))
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
                Listas.iListaId = TempListaId
                Listas.txtListaId.Text = CStr(TempListaId)
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

    Public Function Obtener_NombreListas(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spTipoListas", Cnn)
            cmd.CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "TipoListas")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
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

End Class
