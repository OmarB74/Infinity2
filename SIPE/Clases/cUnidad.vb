﻿Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class cUnidad
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Public Function Obtener_Unidad(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spUnidad", Cnn)
            cmd.CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Unidad")       'llenar dataset
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
    Public Function BusquedaUnidad(ByVal iProductoId As Integer) As Integer
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spUnidadProducto"
            cmd.CommandType = CommandType.StoredProcedure
            '
            cmd.Parameters.Add(New SqlClient.SqlParameter("@ProductoId", iProductoId))
            '
            Dim read As SqlDataReader = cmd.ExecuteReader()
            If read.HasRows Then
                While read.Read
                    BusquedaUnidad = CInt(read(0))
                End While
            End If
            '
            cmd.Dispose()
            '
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return BusquedaUnidad
    End Function
End Class
