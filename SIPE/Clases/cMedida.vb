Option Explicit On
Imports System.Data
Imports System.Data.SqlClient
Public Class cMedida
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Public Function Obtener_Medidas(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spMedidas", Cnn)
            cmd.CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
            '
            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Medidas")       'llenar dataset
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
